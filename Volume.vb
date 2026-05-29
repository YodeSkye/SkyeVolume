
Imports System.Drawing.Drawing2D
Imports NAudio.CoreAudioApi
Imports SkyeVolume.My

Public Class Volume
    Inherits Form

    ' DECLARATIONS
    Private _volume As Integer = 0 ' 0-100, percentage, updated by MeterTimer_Tick and UpdateVolumeFromPoint
    Private _isMuted As Boolean = False
    Private _alpha As Byte = 255
    Private IsDragging As Boolean = False
    Private IsDraggingForm As Boolean = False
    Private DragRect As Rectangle
    Private DragStartPoint As Point
    Private DragThresholdPassed As Boolean = False
    Private ClickHandled As Boolean = False
    Private RectIcon As Rectangle
    Private RectText As Rectangle
    Private HoverIcon As Boolean = False
    Private HoverText As Boolean = False
    Private ReadOnly TimerAutoHide As New Timer
    Private ReadOnly TimerFade As Timer
    Private Const CardPadding As Integer = 6
    Private Const HiddenBorder As Integer = 7 ' Windows invisible resize border
    Private Enum VDirection
        Down
        Up
    End Enum

    ' Theme Colors (updated by ApplyLightTheme / ApplyDarkTheme)
    Private _cardBack As Color
    Private _shadowOuter As Color
    Private _shadowInner As Color
    Private _barBack As Color
    Private _textColor As Color
    Private _muteColor As Color

    ' Audio Meter
    Private ReadOnly _devEnum As New MMDeviceEnumerator()
    Private ReadOnly _audioDev As MMDevice = _devEnum.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia)
    Private TimerMeter As Timer
    Private TimerRender As Timer
    Private _meterLeft As Single = 0.0F
    Private _meterRight As Single = 0.0F

    ' Context Menu
    Private WithEvents CM As New ContextMenuStrip
    Friend MIPlayerInfo As ToolStripMenuItem
    Friend MIPlayerInfo_MPC As ToolStripMenuItem
    Friend MIPlayerInfo_VLC As ToolStripMenuItem
    Friend MIPlayerInfo_WA As ToolStripMenuItem
    Friend MIPlayerInfo_SM As ToolStripMenuItem
    Friend MISettings As ToolStripMenuItem
    Private ReadOnly TipCM As Skye.UI.ToolTipEX

    ' FORM EVENTS
    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim cp = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or Skye.WinAPI.WS_EX_LAYERED Or Skye.WinAPI.WS_EX_TOOLWINDOW
            Return cp
        End Get
    End Property
    Friend Sub New()
        FormBorderStyle = FormBorderStyle.None
        ShowInTaskbar = False
        TopMost = True
        StartPosition = FormStartPosition.Manual
        BackColor = Color.Black ' not visible, but required

        ' actual visible card size
        Dim cardWidth As Integer = 320
        Dim cardHeight As Integer = 80
        ' total form size
        Width = cardWidth + CardPadding * 2
        Height = cardHeight + CardPadding * 2

        AddHandler MouseDown, AddressOf VolumePopupLayeredWindow_MouseDown
        AddHandler MouseMove, AddressOf VolumePopupLayeredWindow_MouseMove
        AddHandler MouseUp, AddressOf VolumePopupLayeredWindow_MouseUp

        BuildContextMenu()
        TipCM = New Skye.UI.ToolTipEX() With {
            .BackColor = Skye.UI.ThemeManager.CurrentTheme.TooltipBack,
            .ForeColor = Skye.UI.ThemeManager.CurrentTheme.TooltipFore,
            .BorderColor = Skye.UI.ThemeManager.CurrentTheme.TooltipBorder,
            .Font = App.TipFont,
            .ShadowAlpha = 0,
            .ShadowThickness = 0,
            .FadeInRate = 25,
            .FadeOutRate = 25,
            .HideDelay = 5000,
            .ShowDelay = 250
        }
        App.HookTSItemsForCMTooltip(CM, TipCM)

        AddHandler App.ThemeChanged, AddressOf OnThemeChanged
        OnThemeChanged(App.CurrentTheme)

        AddHandler TimerAutoHide.Tick, AddressOf AutoHideTimer_Tick
        TimerFade = New Timer With {.Interval = 16}
        AddHandler TimerFade.Tick, AddressOf FadeTimer_Tick
        TimerMeter = New Timer With {.Interval = 16} ' ~60 FPS
        AddHandler TimerMeter.Tick, AddressOf MeterTimer_Tick
        TimerMeter.Start()
        TimerRender = New Timer With {.Interval = 66} ' ~15 FPS
        AddHandler TimerRender.Tick, Sub() RedrawLayered()
        TimerRender.Start()

    End Sub
    Friend Sub ShowInstant()
        TimerFade.Stop()
        _alpha = 255
        SetPlacement()
        Visible = True
        RedrawLayered()
        SetHideTimer()
    End Sub
    Friend Sub HideWithFade()
        If App.Settings.AutoHideWithFadeVolume Then
            TimerFade.Start()
        Else
            TimerFade.Stop()
            _alpha = 0
            Visible = False
            RedrawLayered()
        End If
    End Sub
    Protected Overrides Sub OnFormClosed(e As FormClosedEventArgs)
        Try
            RemoveHandler App.ThemeChanged, AddressOf OnThemeChanged
            If TimerRender IsNot Nothing Then TimerRender.Stop()
            If TimerMeter IsNot Nothing Then TimerMeter.Stop()
            TimerAutoHide?.Stop()
            _audioDev?.Dispose()
            _devEnum?.Dispose()
        Catch
        End Try
        MyBase.OnFormClosed(e)
    End Sub
    Private Sub Frm_MouseEnter(sender As Object, e As EventArgs) Handles MyBase.MouseEnter
        If TimerFade.Enabled Then
            TimerFade.Stop()
            _alpha = 255
            RedrawLayered()
        End If
    End Sub
    Private Sub Frm_MouseLeave(sender As Object, e As EventArgs) Handles MyBase.MouseLeave
        If App.Settings.AutoHideIntervalVolume > 0 Then SetHideTimer()
    End Sub
    Private Sub Frm_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        ClickHandled = False

        If e.Button = MouseButtons.Right Then
            Dim screenPos = Me.PointToScreen(e.Location)
            CM.Show(screenPos)
            ClickHandled = True
            Return
        End If

        If e.Button = MouseButtons.Left Then

            ' 1. Mute icon or text → handle and BLOCK dragging
            If RectIcon.Contains(e.Location) OrElse RectText.Contains(e.Location) Then
                ToggleMute()
                ClickHandled = True
                ' IMPORTANT: disable drag for this click
                IsDraggingForm = False
                DragThresholdPassed = False
                Return
            End If

            ' 2. Volume bar → let bar-drag logic handle it
            If GetVolumeBarRect().Contains(e.Location) Then
                Return
            End If

            ' 3. Otherwise prepare for form drag or click-to-close
            DragStartPoint = e.Location
            DragThresholdPassed = False
            IsDraggingForm = False

        End If
    End Sub
    Private Sub Frm_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        If ClickHandled Then Return

        If e.Button = MouseButtons.Left AndAlso Not IsDragging Then
            Dim dx = Math.Abs(e.X - DragStartPoint.X)
            Dim dy = Math.Abs(e.Y - DragStartPoint.Y)

            If Not DragThresholdPassed Then
                If dx >= SystemInformation.DragSize.Width OrElse dy >= SystemInformation.DragSize.Height Then
                    DragThresholdPassed = True
                    IsDraggingForm = True
                Else
                    Return
                End If
            End If

            If IsDraggingForm Then
                Dim screenPos = PointToScreen(e.Location)
                Me.Location = New Point(screenPos.X - DragStartPoint.X, screenPos.Y - DragStartPoint.Y)
                ClampToWorkingArea()
                Return
            End If

        End If

        ' For mute icon and text highlighting on mouseover
        Dim overIcon = RectIcon.Contains(e.Location)
        Dim overText = RectText.Contains(e.Location)
        If overIcon <> HoverIcon OrElse overText <> HoverText Then
            HoverIcon = overIcon
            HoverText = overText
            RedrawLayered()
        End If

    End Sub
    Private Sub Frm_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
        If e.Button = MouseButtons.Left Then

            ' If mute/text handled the click → do NOT close
            If ClickHandled Then
                ClickHandled = False
                Return
            End If

            ' If form was dragged → do NOT close
            If IsDraggingForm Then
                IsDraggingForm = False
                DragThresholdPassed = False
                My.Settings.PlacementVolume = My.App.SettingsType.Placement.Manual
                My.Settings.LocationVolume = Me.Location
                If My.FrmSettings IsNot Nothing Then My.FrmSettings.ShowSettings()
                App.Settings.SetSave()
                Return
            End If

            ' If dragging the volume bar → do NOT close
            If IsDragging Then
                Return
            End If

            ' Otherwise → click-to-close
            App.HideVolume()
            Return

        End If
    End Sub
    Private Sub FrmKeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyData
            Case Keys.Escape : Hide()
            Case Keys.M : ToggleMute()
            Case Keys.Left, Keys.Down : StepVolume(VDirection.Down)
            Case Keys.Right, Keys.Up : StepVolume(VDirection.Up)
            Case Keys.Left Or Keys.Control, Keys.Down Or Keys.Control : BabyStepVolume(VDirection.Down)
            Case Keys.Right Or Keys.Control, Keys.Up Or Keys.Control : BabyStepVolume(VDirection.Up)
            Case Keys.P Or Keys.Control
                Static pi As Integer
                pi = CInt(My.Settings.PlacementVolume) + 1
                If pi >= [Enum].GetNames(Of App.SettingsType.Placement)().Length Then pi = 0
                App.Settings.PlacementVolume = CType(pi, App.SettingsType.Placement)
                SetPlacement()
                If App.FrmSettings IsNot Nothing Then App.FrmSettings.ShowSettings()
                App.Settings.SetSave()
        End Select
    End Sub

    ' DRAWING
    Private Sub RedrawLayered()
        If Not Me.IsHandleCreated OrElse Not Me.Visible Then Return

        Dim bmp As New Bitmap(Me.Width, Me.Height, Imaging.PixelFormat.Format32bppArgb)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.SmoothingMode = SmoothingMode.AntiAlias
            g.Clear(Color.Transparent)

            DrawShadowAndBackground(g)
            DrawContent(g)
        End Using

        ApplyBitmapToLayeredWindow(bmp)
        bmp.Dispose()
    End Sub
    Private Sub DrawShadowAndBackground(g As Graphics)
        Dim radius As Integer = 16
        ' The card rectangle is inset so the shadow can live outside it
        Dim cardRect As New Rectangle(
            CardPadding,
            CardPadding,
            Me.Width - CardPadding * 2,
            Me.Height - CardPadding * 2
        )

        '  Outer soft shadow (bigger)
        Using shadowPath As GraphicsPath = CreateRoundRect(cardRect, radius)
            Using br As New SolidBrush(_shadowOuter)
                g.TranslateTransform(4, 4) ' bigger offset = bigger shadow
                g.FillPath(br, shadowPath)
                g.ResetTransform()
            End Using
        End Using

        '  Inner stronger shadow
        Using shadowPath As GraphicsPath = CreateRoundRect(cardRect, radius)
            Using br As New SolidBrush(_shadowInner)
                g.TranslateTransform(2, 2) ' bigger offset = bigger shadow
                g.FillPath(br, shadowPath)
                g.ResetTransform()
            End Using
        End Using

        '  Background (your popup)
        Using cardPath As GraphicsPath = CreateRoundRect(cardRect, radius)
            Using br As New SolidBrush(_cardBack)
                g.FillPath(br, cardPath)
            End Using
        End Using

    End Sub
    Private Sub DrawContent(g As Graphics)

        Dim contentLeft As Integer = 48 ' space for mute icon
        Dim contentRight As Integer = ClientSize.Width - 48 ' space for volume text
        Dim contentWidth As Integer = contentRight - contentLeft

        ' VOLUME BAR
        Dim barRect As New Rectangle(
            contentLeft,
            ClientSize.Height \ 2 - 12,
            contentWidth,
            28
        )
        ' Background
        DrawRoundedBar(g, barRect, _barBack)
        ' Fill
        Dim fillRect = barRect
        fillRect.Width = CInt(contentWidth * (_volume / 100.0))
        DrawRoundedBar(g, fillRect, GetZoneColor(_volume, _isMuted))

        ' METERS
        Dim meterHeight As Integer = 6
        Dim meterSpacing As Integer = 6
        ' Left channel (above volume bar)
        Dim leftLevel = _meterLeft
        Dim leftMeterRect As New Rectangle(
            contentLeft,
            barRect.Top - meterHeight - meterSpacing,
            CInt(contentWidth * leftLevel),
            meterHeight
        )
        DrawRoundedBar(g, leftMeterRect, GetZoneColor(CInt(leftLevel * 100), False))
        ' Right channel (below volume bar)
        Dim rightLevel = _meterRight
        Dim rightMeterRect As New Rectangle(
            contentLeft,
            barRect.Bottom + meterSpacing,
            CInt(contentWidth * rightLevel),
            meterHeight
        )
        DrawRoundedBar(g, rightMeterRect, GetZoneColor(CInt(rightLevel * 100), False))

        ' MUTE ICON (left of volume bar)
        If HoverIcon Then
            Dim pad As Integer = 4
            Dim bgRect As New Rectangle(
                RectIcon.Left - pad - 2,
                RectIcon.Top - pad - 2,
                RectIcon.Width + pad * 2 + 2,
                RectIcon.Height + pad * 2
            )
            Dim highlight = GetHoverHighlight()
            DrawRoundedBar(g, bgRect, highlight)
        End If
        Dim iconSize As Integer = 32
        Dim iconX As Integer = contentLeft - iconSize - 4
        RectIcon = New Rectangle(
            iconX,
            barRect.Top + (barRect.Height \ 2) - (iconSize \ 2) + 2,
            iconSize,
            iconSize
        )
        Using img As Image = If(_isMuted, Resources.Resources.imageSoundMute, Resources.Resources.imageSound)
            g.DrawImage(img, RectIcon)
        End Using

        ' TEXT (right of volume bar)
        If HoverText Then
            Dim pad As Integer = 4
            Dim bgRect As New Rectangle(
                RectText.Left + 3,
                RectText.Top,
                RectText.Width - pad - 4,
                RectText.Height
            )
            Dim highlight = GetHoverHighlight()
            DrawRoundedBar(g, bgRect, highlight)
        End If
        Using f As New Font("Segoe UI", 12.0F, FontStyle.Bold)
            Dim text As String = _volume.ToString() & "%"
            RectText = New Rectangle(
                contentRight - 3,
                barRect.Top,
                Me.ClientSize.Width - (contentRight - 3),
                barRect.Height
            )
            Dim sz As SizeF = g.MeasureString(text, f)
            Dim pt As New PointF(
                RectText.Left + (RectText.Width - sz.Width) / 2,
                RectText.Top + (RectText.Height - sz.Height) / 2
            )
            Using br As New SolidBrush(GetZoneColor(_volume, _isMuted))
                g.DrawString(text, f, br, pt)
            End Using
        End Using

    End Sub
    Private Sub ApplyBitmapToLayeredWindow(bmp As Bitmap)
        Dim screenDC As IntPtr = Skye.WinAPI.GetDC(IntPtr.Zero)
        Dim memDC As IntPtr = Skye.WinAPI.CreateCompatibleDC(screenDC)
        Dim hBitmap As IntPtr = bmp.GetHbitmap(Color.FromArgb(0))
        Dim oldBitmap As IntPtr = Skye.WinAPI.SelectObject(memDC, hBitmap)
        Dim size As New Skye.WinAPI.SIZE With {.cx = bmp.Width, .cy = bmp.Height}
        Dim pointSource As New Skye.WinAPI.POINT With {.X = 0, .Y = 0}
        Dim topPos As New Skye.WinAPI.POINT With {.X = Me.Left, .Y = Me.Top}
        Dim blend As New Skye.WinAPI.BLENDFUNCTION With {
            .BlendOp = Skye.WinAPI.AC_SRC_OVER,
            .BlendFlags = 0,
            .SourceConstantAlpha = _alpha,
            .AlphaFormat = Skye.WinAPI.AC_SRC_ALPHA
        }

        Skye.WinAPI.UpdateLayeredWindow(Me.Handle, screenDC, topPos, size, memDC, pointSource, 0, blend, Skye.WinAPI.ULW_ALPHA)
        Skye.WinAPI.SelectObject(memDC, oldBitmap)
        Skye.WinAPI.DeleteObject(hBitmap)
        Skye.WinAPI.DeleteDC(memDC)
        Dim hresult = Skye.WinAPI.ReleaseDC(IntPtr.Zero, screenDC)

    End Sub
    Private Shared Sub DrawRoundedBar(g As Graphics, rect As Rectangle, color As Color)
        If rect.Width <= 0 Then Return

        Dim fullHeight As Integer = rect.Height
        Dim width As Integer = rect.Width
        ' Height collapses with width
        Dim h As Integer = Math.Min(fullHeight, width)
        ' Center vertically
        Dim y As Integer = rect.Top + (fullHeight - h) \ 2
        Dim collapsedRect As New Rectangle(rect.Left, y, width, h)
        ' Radius = height
        Dim radius As Integer = h

        Using path As GraphicsPath = CreateRoundRect(collapsedRect, radius),
          br As New SolidBrush(color)
            g.FillPath(br, path)
        End Using

    End Sub
    Private Shared Function CreateRoundRect(rect As Rectangle, radius As Integer) As GraphicsPath
        Dim path As New GraphicsPath()
        Dim d As Integer = radius

        path.AddArc(rect.X, rect.Y, d, d, 180, 90)
        path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90)
        path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90)
        path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90)
        path.CloseFigure()

        Return path
    End Function

    ' CONTROL EVENTS
    Private Sub VolumePopupLayeredWindow_MouseDown(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            Dim sliderRect = GetVolumeBarRect()
            If sliderRect.Contains(e.Location) Then
                IsDragging = True
                DragRect = sliderRect
                UpdateVolumeFromPoint(e.Location)
            End If
        End If
    End Sub
    Private Sub VolumePopupLayeredWindow_MouseMove(sender As Object, e As MouseEventArgs)
        If IsDragging Then
            UpdateVolumeFromPoint(e.Location)
        End If
    End Sub
    Private Sub VolumePopupLayeredWindow_MouseUp(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            IsDragging = False
        End If
    End Sub
    Private Sub CM_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles CM.Opening
        If App.FrmPlayer Is Nothing Then
            MIPlayerInfo.ForeColor = Color.Maroon
        Else
            MIPlayerInfo.ForeColor = Color.Teal
        End If
    End Sub

    ' HANDLERS
    Private Sub AutoHideTimer_Tick(sender As Object, e As EventArgs)
        If Not MouseInFormBounds() AndAlso Not CM.Visible Then
            TimerAutoHide.Stop()
            HideWithFade()
        End If
    End Sub
    Private Sub FadeTimer_Tick(sender As Object, e As EventArgs)
        If _alpha <= App.Settings.AutoHideRateVolume Then
            _alpha = 0
            TimerFade.Stop()
            Visible = False
        Else
            _alpha = CByte(_alpha - App.Settings.AutoHideRateVolume)
        End If
        RedrawLayered()
    End Sub
    Private Sub OnThemeChanged(theme As App.Theme)
        Select Case theme
            Case App.Theme.Light
                _cardBack = Color.White
                _shadowOuter = Color.FromArgb(40, Color.Black)
                _shadowInner = Color.FromArgb(80, Color.Black)
                _barBack = Color.FromArgb(200, 200, 200)
                _textColor = Color.Black
                _muteColor = Color.Black
            Case App.Theme.Dark
                _cardBack = Color.FromArgb(32, 32, 32)
                _shadowOuter = Color.FromArgb(60, Color.Black)
                _shadowInner = Color.FromArgb(120, Color.Black)
                _barBack = Color.FromArgb(70, 70, 70)
                _textColor = Color.White
                _muteColor = Color.Black
        End Select
        CM.BackColor = Skye.UI.ThemeManager.CurrentTheme.MenuBack
        CM.ForeColor = Skye.UI.ThemeManager.CurrentTheme.MenuFore
        TipCM.BackColor = Skye.UI.ThemeManager.CurrentTheme.TooltipBack
        TipCM.ForeColor = Skye.UI.ThemeManager.CurrentTheme.TooltipFore
        TipCM.BorderColor = Skye.UI.ThemeManager.CurrentTheme.TooltipBorder
        RedrawLayered()
    End Sub
    Private Sub MeterTimer_Tick(sender As Object, e As EventArgs)
        Try

            ' REMEMBER PREVIOUS VALUES
            Dim oldMuted = _isMuted
            Dim oldVolume = _volume

            ' MUTE
            _isMuted = _audioDev.AudioEndpointVolume.Mute

            ' VOLUME
            _volume = CInt(_audioDev.AudioEndpointVolume.MasterVolumeLevelScalar * 100)

            ' DETECT CHANGED
            If _isMuted <> oldMuted OrElse _volume <> oldVolume Then
                ShowInstant()
                App.SetChangeTimeForSaveEars()
            End If
            CheckUnMuteOnVolumeChange(_volume, oldVolume)

            ' METERS
            Dim meter = _audioDev.AudioMeterInformation
            Dim rawLeft As Single = meter.PeakValues(0)
            Dim rawRight As Single = If(meter.PeakValues.Count > 1, meter.PeakValues(1), rawLeft)
            ' Smooth rise
            Dim _smoothLeft As Single = 0.0F
            Dim _smoothRight As Single = 0.0F
            Const smoothing As Single = 0.4F
            _smoothLeft = (_smoothLeft * smoothing) + (rawLeft * (1 - smoothing))
            _smoothRight = (_smoothRight * smoothing) + (rawRight * (1 - smoothing))
            ' Decay only when falling
            Const decay As Single = 0.94F
            If rawLeft < _smoothLeft Then
                _smoothLeft *= decay
            Else
                _smoothLeft = rawLeft
            End If
            If rawRight < _smoothRight Then
                _smoothRight *= decay
            Else
                _smoothRight = rawRight
            End If
            ' Boost
            Const MeterBoost As Single = 1.4F
            _meterLeft = Math.Min(1.0F, _smoothLeft * MeterBoost)
            _meterRight = Math.Min(1.0F, _smoothRight * MeterBoost)

        Catch
        End Try
    End Sub

    ' METHODS
    Friend Sub UpdateVolume()
        RedrawLayered()
    End Sub
    Friend Sub SetVolume(volumepercent As Integer)
        _volume = Math.Max(0, Math.Min(100, volumepercent))
        _audioDev.AudioEndpointVolume.MasterVolumeLevelScalar = CSng(_volume / 100)
        RedrawLayered()
    End Sub
    Private Sub StepVolume(direction As VDirection)
        Dim newVolume As Integer = _volume
        Select Case direction
            Case VDirection.Down
                newVolume -= My.Settings.vStep
            Case VDirection.Up
                newVolume += My.Settings.vStep
        End Select
        If newVolume < 0 Then newVolume = 0
        If newVolume > 100 Then newVolume = 100
        SetVolume(newVolume)
    End Sub
    Private Sub BabyStepVolume(direction As VDirection)
        Dim newVolume As Integer = _volume
        Select Case direction
            Case VDirection.Down
                newVolume -= My.Settings.vBabyStep
            Case VDirection.Up
                newVolume += My.Settings.vBabyStep
        End Select
        If newVolume < 0 Then newVolume = 0
        If newVolume > 100 Then newVolume = 100
        SetVolume(newVolume)
    End Sub
    Friend Function GetVolume() As Integer
        Return _volume
    End Function
    Private Sub UpdateVolumeFromPoint(p As System.Drawing.Point)
        Dim r = GetVolumeBarRect()
        Dim x = Math.Max(r.Left, Math.Min(p.X, r.Right))
        Dim ratio As Double = (x - r.Left) / Math.Max(1, r.Width)
        Dim newVol As Integer = CInt(Math.Round(ratio * 100))

        If newVol <> _volume Then
            CheckUnMuteOnVolumeChange(newVol, _volume)
            _volume = newVol
            _audioDev.AudioEndpointVolume.MasterVolumeLevelScalar = CSng(_volume / 100)
            RedrawLayered()
        End If
    End Sub
    Private Sub ToggleMute()
        _isMuted = Not _isMuted
        _audioDev.AudioEndpointVolume.Mute = _isMuted
    End Sub
    Friend Sub SetPlacement()
        Dim wa = Screen.FromControl(Me).WorkingArea

        Select Case My.Settings.PlacementVolume
            Case My.App.SettingsType.Placement.Center
                Me.Location = New Point(
                wa.Left + CInt((wa.Width - Me.Width) / 2),
                wa.Top + CInt((wa.Height - Me.Height) / 2))
            Case My.App.SettingsType.Placement.TopLeft
                Me.Location = New Point(wa.Left + App.PlacementMargin, wa.Top + App.PlacementMargin)
            Case My.App.SettingsType.Placement.TopCenterLeft
                Me.Location = New Point(
                wa.Left + CInt(wa.Width * 0.25 - Me.Width / 2),
                wa.Top + App.PlacementMargin)
            Case My.App.SettingsType.Placement.TopCenter
                Me.Location = New Point(
                wa.Left + CInt((wa.Width - Me.Width) / 2),
                wa.Top + App.PlacementMargin)
            Case My.App.SettingsType.Placement.TopCenterRight
                Me.Location = New Point(
                wa.Left + CInt(wa.Width * 0.75 - Me.Width / 2),
                wa.Top + App.PlacementMargin)
            Case My.App.SettingsType.Placement.TopRight
                Me.Location = New Point(
                wa.Right - Me.Width - App.PlacementMargin,
                wa.Top + App.PlacementMargin)
            Case My.App.SettingsType.Placement.RightCenterTop
                Me.Location = New Point(
                wa.Right - Me.Width - App.PlacementMargin,
                wa.Top + CInt(wa.Height * 0.25 - Me.Height / 2))
            Case My.App.SettingsType.Placement.RightCenter
                Me.Location = New Point(
                wa.Right - Me.Width - App.PlacementMargin,
                wa.Top + CInt((wa.Height - Me.Height) / 2))
            Case My.App.SettingsType.Placement.RightCenterBottom
                Me.Location = New Point(
                wa.Right - Me.Width - App.PlacementMargin,
                wa.Top + CInt(wa.Height * 0.75 - Me.Height / 2))
            Case My.App.SettingsType.Placement.BottomRight
                Me.Location = New Point(
                wa.Right - Me.Width - App.PlacementMargin,
                wa.Bottom - Me.Height - App.PlacementMargin)
            Case My.App.SettingsType.Placement.BottomCenterRight
                Me.Location = New Point(
                wa.Left + CInt(wa.Width * 0.75 - Me.Width / 2),
                wa.Bottom - Me.Height - App.PlacementMargin)
            Case My.App.SettingsType.Placement.BottomCenter
                Me.Location = New Point(
                wa.Left + CInt((wa.Width - Me.Width) / 2),
                wa.Bottom - Me.Height - App.PlacementMargin)
            Case My.App.SettingsType.Placement.BottomCenterLeft
                Me.Location = New Point(
                wa.Left + CInt(wa.Width * 0.25 - Me.Width / 2),
                wa.Bottom - Me.Height - App.PlacementMargin)
            Case My.App.SettingsType.Placement.BottomLeft
                Me.Location = New Point(
                wa.Left + App.PlacementMargin,
                wa.Bottom - Me.Height - App.PlacementMargin)
            Case My.App.SettingsType.Placement.LeftCenterBottom
                Me.Location = New Point(
                wa.Left + App.PlacementMargin,
                wa.Top + CInt(wa.Height * 0.75 - Me.Height / 2))
            Case My.App.SettingsType.Placement.LeftCenter
                Me.Location = New Point(
                wa.Left + App.PlacementMargin,
                wa.Top + CInt((wa.Height - Me.Height) / 2))
            Case My.App.SettingsType.Placement.LeftCenterTop
                Me.Location = New Point(
                wa.Left + App.PlacementMargin,
                wa.Top + CInt(wa.Height * 0.25 - Me.Height / 2))
            Case My.App.SettingsType.Placement.Manual
                Me.Location = My.Settings.LocationVolume
        End Select

    End Sub
    Private Sub SetHideTimer()
        TimerAutoHide.Stop()
        If App.Settings.AutoHideVolume Then
            TimerAutoHide.Interval = App.Settings.AutoHideIntervalVolume * 1000
            TimerAutoHide.Start()
        End If
    End Sub
    Friend Sub ShowSave()
        If App.Settings.NeedsSaved Then
            MISettings.ForeColor = Color.Firebrick
            MISettings.Font = New Font(App.TipFont, FontStyle.Bold)
            MISettings.ToolTipText = "Settings Need Saved"
        Else
            MISettings.ResetFont()
            MISettings.ResetForeColor()
            MISettings.ToolTipText = String.Empty
        End If
    End Sub
    Private Sub CheckUnMuteOnVolumeChange(newVolume As Integer, oldVolume As Integer)
        If newVolume = oldVolume OrElse Not _isMuted Then Exit Sub

        Dim mode = My.Settings.UnMuteOnVolumeChange
        Dim shouldUnmute As Boolean = False
        Select Case mode
            Case My.App.SettingsType.UnMuteOnVolumeChangeWhen.Never
                shouldUnmute = False
            Case My.App.SettingsType.UnMuteOnVolumeChangeWhen.OnDecrease
                shouldUnmute = (newVolume < oldVolume)
            Case My.App.SettingsType.UnMuteOnVolumeChangeWhen.OnIncrease
                shouldUnmute = (newVolume > oldVolume)
            Case My.App.SettingsType.UnMuteOnVolumeChangeWhen.Always
                shouldUnmute = True
        End Select

        If shouldUnmute Then _audioDev.AudioEndpointVolume.Mute = False
    End Sub


    ' HELPERS
    Private Function GetVolumeBarRect() As Rectangle
        Dim margin As Integer = 48
        Dim barHeight As Integer = 28
        Return New Rectangle(margin, Me.ClientSize.Height \ 2 - barHeight \ 2, Me.ClientSize.Width - margin * 2, barHeight)
    End Function
    Private Function GetMeterRects() As List(Of Rectangle)
        Dim list As New List(Of Rectangle)
        Dim barWidth As Integer = 6
        Dim spacing As Integer = 4
        Dim count As Integer = 10
        Dim totalWidth As Integer = count * barWidth + (count - 1) * spacing
        Dim startX As Integer = (Me.ClientSize.Width - totalWidth) \ 2
        Dim bottom As Integer = GetVolumeBarRect().Top - 10
        Dim heightMax As Integer = 24

        For i = 0 To count - 1
            Dim h As Integer = 6 + (i Mod 5) * 3
            If h > heightMax Then h = heightMax
            Dim r As New Rectangle(startX + i * (barWidth + spacing), bottom - h, barWidth, h)
            list.Add(r)
        Next

        Return list
    End Function
    Private Function GetZoneColor(value As Integer, isMuted As Boolean) As Color
        If isMuted Then
            Return _muteColor
        End If
        If value < My.Settings.vBlueZone Then
            Return My.Settings.cGreenZone
        ElseIf value >= My.Settings.vRedZone Then
            Return My.Settings.cRedZone
        Else
            Return My.Settings.cBlueZone
        End If
    End Function
    Private Shared Function GetHoverHighlight() As Color
        If App.CurrentTheme = App.Theme.Dark Then
            Return Color.FromArgb(60, 65, 65, 65)
        Else
            Return Color.FromArgb(60, 235, 235, 235)
        End If
    End Function
    Private Function MouseInFormBounds() As Boolean
        If MousePosition.X > Me.Left AndAlso MousePosition.X < Me.Right AndAlso MousePosition.Y > Me.Top AndAlso MousePosition.Y < Me.Bottom Then : Return True
            'ElseIf cmVolume.Visible AndAlso (MousePosition.X > Me.cmVolume.Left - 1 AndAlso MousePosition.X < Me.cmVolume.Right AndAlso MousePosition.Y > Me.cmVolume.Top - 1 AndAlso MousePosition.Y < Me.cmVolume.Bottom) Then : Return True
            'ElseIf cmPlayers.Visible AndAlso (MousePosition.X > Me.cmPlayers.Left - 1 AndAlso MousePosition.X < Me.cmPlayers.Right AndAlso MousePosition.Y > Me.cmPlayers.Top - 1 AndAlso MousePosition.Y < Me.cmPlayers.Bottom) Then : Return True
        Else : Return False
        End If
    End Function
    Private Sub ClampToWorkingArea()
        Dim wa = Screen.FromControl(Me).WorkingArea

        Dim newX = Left
        Dim newY = Top

        ' Left
        If newX < wa.Left - HiddenBorder Then
            newX = wa.Left - HiddenBorder
        End If

        ' Top
        If newY < wa.Top - HiddenBorder Then
            newY = wa.Top - HiddenBorder
        End If

        ' Right
        If newX + Width > wa.Right + HiddenBorder Then
            newX = wa.Right - Width + HiddenBorder
        End If

        ' Bottom
        If newY + Height > wa.Bottom + HiddenBorder Then
            newY = wa.Bottom - Height + HiddenBorder
        End If

        Location = New Point(newX, newY)
    End Sub
    Private Sub BuildContextMenu()
        CM.Font = App.TipFont
        CM.ShowItemToolTips = False
        CM.RenderMode = ToolStripRenderMode.System

        ' --- PLAYER INFO ---
        MIPlayerInfo = New ToolStripMenuItem("Player Info", Resources.Resources.imagePlayerPlay) With {
            .ToolTipText = "LeftClick = Start / Show() Player Info" & vbCr & "RightClick = Stop Player Info"
        }
        AddHandler MIPlayerInfo.MouseUp,
            Sub(sender As Object, e As MouseEventArgs)
                If e.Button = MouseButtons.Right Then
                    App.ClosePlayer()
                Else
                    App.ShowPlayer()
                End If
            End Sub
        CM.Items.Add(MIPlayerInfo)

        ' --- PLAYERS ---
        MIPlayerInfo_MPC = New ToolStripMenuItem("MPC-HC", Resources.Resources.imageMPC, Sub() App.OpenPlayer("MPC-HC"))
        MIPlayerInfo_VLC = New ToolStripMenuItem("VLC", Resources.Resources.imageVLC, Sub() App.OpenPlayer("VLC"))
        MIPlayerInfo_WA = New ToolStripMenuItem("Winamp", Resources.Resources.imageWA, Sub() App.OpenPlayer("Winamp"))
        MIPlayerInfo_SM = New ToolStripMenuItem("Skye Music", Resources.Resources.imageSM, Sub() App.OpenPlayer("Skye Music"))
        CM.Items.Add(MIPlayerInfo_MPC)
        CM.Items.Add(MIPlayerInfo_VLC)
        CM.Items.Add(MIPlayerInfo_WA)
        CM.Items.Add(MIPlayerInfo_SM)
        CM.Items.Add(New ToolStripSeparator())

        ' --- SYSTEM VOLUME CONTROL ---
        Dim miSysVol As New ToolStripMenuItem("System Volume Control", GetSystemVolumeControlIcon, Sub() App.OpenSystemVolumeControl())
        CM.Items.Add(miSysVol)
        CM.Items.Add(New ToolStripSeparator())

        ' --- SETTINGS ---
        MISettings = New ToolStripMenuItem("Settings", Resources.Resources.imageSettings, Sub() App.ShowSettings())
        CM.Items.Add(MISettings)

        ' --- HELP ---
        CM.Items.Add(New ToolStripMenuItem("Help", Resources.Resources.ImageHelp16, Sub() App.ShowHelp()))
        ' --- LOG ---
        CM.Items.Add(New ToolStripMenuItem("Log", Resources.Resources.imageLog, Sub() App.ShowLog()))
        CM.Items.Add(New ToolStripSeparator())

        ' --- EXIT ---
        Dim miExit As New ToolStripMenuItem("Exit", Resources.Resources.imageClose) With {
            .ToolTipText = "RightClick = Restart " & My.Application.Info.ProductName
        }
        AddHandler miExit.MouseUp,
            Sub(sender As Object, e As MouseEventArgs)
                If e.Button = MouseButtons.Right Then
                    App.Finalize(True)   ' restart
                Else
                    App.Finalize(False)  ' exit
                End If
            End Sub

        CM.Items.Add(miExit)
    End Sub
    Private Function GetSystemVolumeControlIcon() As Image
        Dim icon As Icon = Skye.WinAPI.GetApplicationIcon(My.Settings.SystemVolumeControlPath)
        If icon IsNot Nothing Then
            GetSystemVolumeControlIcon = icon.ToBitmap
            icon.Dispose()
            icon = Nothing
        Else
            Return Resources.Resources.imageVolumeControl
        End If
    End Function

End Class
