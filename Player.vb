
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports SkyeVolume.My

Public Class Player
    Inherits Form

    ' DECLARATIONS
    Private _alpha As Byte = 255
    Private IsDraggingForm As Boolean = False
    Private DragRect As Rectangle
    Private DragStartPoint As Point
    Private DragThresholdPassed As Boolean = False
    Private ClickHandled As Boolean = False
    Private TimerAutoHide As New Timer
    Private ReadOnly TimerFade As Timer
    Private Const CardPadding As Integer = 6
    Private Const HiddenBorder As Integer = 7 ' Windows invisible resize border

    ' Player State
    Private _playerIcon As Image        ' left icon (MPC/VLC/WA/SM)
    Private _playStateIcon As Image     ' play/pause/stop icon
    Private _trackText As String = ""   ' combined artist/title text
    Private ReadOnly FontSmall As New Font("Segoe UI Semibold", 12.0!, FontStyle.Bold)
    Private ReadOnly FontMedium As New Font("Segoe UI Semibold", 16.0!, FontStyle.Bold)
    Private ReadOnly FontLarge As New Font("Segoe UI Semibold", 22.0!, FontStyle.Bold)
    Private TimerPlayer As New Timer With {.Interval = 100}

    ' Theme Colors (updated by ApplyLightTheme / ApplyDarkTheme)
    Private _cardBack As Color
    Private _shadowOuter As Color
    Private _shadowInner As Color
    Private _barBack As Color
    Private _textColor As Color
    Private _muteColor As Color

    ' Context Menu
    Private WithEvents CM As New ContextMenuStrip
    Private MIViewer As ToolStripMenuItem
    Private MIOpenFileLocation As ToolStripMenuItem
    Private MICopyTitle As ToolStripMenuItem
    Private MISize As ToolStripMenuItem
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
        AddHandler TimerPlayer.Tick, AddressOf TimerPlayer_Tick
        TimerPlayer.Start()

        UpdatePlayer()

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
        If App.Settings.AutoHideWithFadePlayer Then
            TimerFade.Start()
        Else
            TimerFade.Stop()
            _alpha = 0
            Visible = False
            RedrawLayered()
        End If
    End Sub
    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        Try
            ' Stop the timers immediately so no new ticks fire during teardown
            If TimerPlayer IsNot Nothing Then
                TimerPlayer.Stop()
                TimerPlayer.Dispose()
                TimerPlayer = Nothing
            End If
            If TimerAutoHide IsNot Nothing Then
                TimerAutoHide.Stop()
                TimerAutoHide.Dispose()
                TimerAutoHide = Nothing
            End If
            ' Unhook events
            RemoveHandler App.ThemeChanged, AddressOf OnThemeChanged
        Catch
        End Try
        MyBase.OnFormClosing(e)
    End Sub
    Private Sub Frm_MouseEnter(sender As Object, e As EventArgs) Handles MyBase.MouseEnter
        If TimerFade.Enabled Then
            TimerFade.Stop()
            _alpha = 255
            RedrawLayered()
        End If
    End Sub
    Private Sub Frm_MouseLeave(sender As Object, e As EventArgs) Handles MyBase.MouseLeave
        If App.Settings.AutoHideIntervalPlayer > 0 Then SetHideTimer()
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

            ' 3. Otherwise prepare for form drag or click-to-close
            DragStartPoint = e.Location
            DragThresholdPassed = False
            IsDraggingForm = False

        End If
    End Sub
    Private Sub Frm_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        If ClickHandled Then Return

        If e.Button = MouseButtons.Left Then
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

    End Sub
    Private Sub Frm_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
        If e.Button = MouseButtons.Left Then

            ' If icons/text handled the click → do NOT close
            If ClickHandled Then
                ClickHandled = False
                Return
            End If

            ' If form was dragged → do NOT close
            If IsDraggingForm Then
                IsDraggingForm = False
                DragThresholdPassed = False
                My.Settings.PlacementPlayer = My.App.SettingsType.Placement.Manual
                My.Settings.LocationPlayer = Me.Location
                If My.FrmSettings IsNot Nothing Then My.FrmSettings.ShowSettings()
                App.Settings.SetSave()
                Return
            End If

            ' Otherwise → click-to-close
            App.HidePlayer()
            Return

        End If
    End Sub
    Private Sub FrmKeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyData
            Case Keys.Escape : App.HidePlayer()
            Case Keys.P Or Keys.Control
                Static pi As Integer
                pi = CInt(My.Settings.PlacementPlayer) + 1
                If pi >= [Enum].GetNames(Of App.SettingsType.Placement)().Length Then pi = 0
                App.Settings.PlacementPlayer = CType(pi, App.SettingsType.Placement)
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
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit

        Dim f = GetPlayerFont()
        Dim iconSize As Integer = 16
        Dim gap As Integer = 10
        Dim marginLeft As Integer = 20
        Dim textWidth As Integer
        Dim textHeight As Integer
        If Not String.IsNullOrEmpty(_trackText) Then
            Dim size As SizeF = g.MeasureString(_trackText, f)
            textWidth = CInt(size.Width)
            textHeight = CInt(size.Height)
        End If
        Dim iconY As Integer = (ClientSize.Height - iconSize) \ 2 + 1
        Dim textY As Integer = (ClientSize.Height - textHeight) \ 2
        Dim x As Integer = marginLeft

        ' Player icon
        If _playerIcon IsNot Nothing Then
            g.DrawImage(_playerIcon, x, iconY, iconSize, iconSize)
        End If
        x += iconSize + gap

        ' Playstate icon
        If _playStateIcon IsNot Nothing Then
            g.DrawImage(_playStateIcon, x, iconY, iconSize, iconSize)
        End If
        x += iconSize + gap

        ' Text
        If Not String.IsNullOrEmpty(_trackText) Then
            Using br As New SolidBrush(_textColor)
                g.DrawString(_trackText, f, br, x, textY)
            End Using
        End If

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
    Private Sub CM_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles CM.Opening
        If String.IsNullOrEmpty(App.CurrentSelectionPath) OrElse String.IsNullOrEmpty(App.Settings.ViewerPath) OrElse Not System.IO.Path.HasExtension(App.CurrentSelectionPath) Then
            MIViewer.Enabled = False
        Else
            MIViewer.Enabled = True
        End If
        If String.IsNullOrEmpty(App.Settings.ViewerName) Then
            MIViewer.Text = "No Viewer"
        Else
            MIViewer.Text = "Show In " + App.Settings.ViewerName
        End If
        If String.IsNullOrEmpty(App.CurrentSelectionPath) OrElse Not System.IO.Path.HasExtension(App.CurrentSelectionPath) Then
            MIOpenFileLocation.Enabled = False
        Else
            MIOpenFileLocation.Enabled = True
        End If
        If String.IsNullOrEmpty(App.CurrentSelectionPath) Then
            MICopyTitle.Enabled = False
        Else
            MICopyTitle.Enabled = True
        End If
        Select Case App.Settings.PlayerSize
            Case App.SettingsType.PlayerSizes.Small
                MISize.ToolTipText = "LeftClick = Medium" & vbCr & "RightClick = Large"
            Case App.SettingsType.PlayerSizes.Medium
                MISize.ToolTipText = "LeftClick = Large" & vbCr & "RightClick = Small"
            Case App.SettingsType.PlayerSizes.Large
                MISize.ToolTipText = "LeftClick = Small" & vbCr & "RightClick = Medium"
        End Select
    End Sub

    ' HANDLERS
    Private Sub TimerPlayer_Tick(sender As Object, e As EventArgs)
        If Me.IsDisposed OrElse Not Me.IsHandleCreated Then Return
        UpdatePlayer()
    End Sub
    Private Sub AutoHideTimer_Tick(sender As Object, e As EventArgs)
        If Me.IsDisposed OrElse Not Me.IsHandleCreated Then Return
        If Not MouseInFormBounds() AndAlso Not CM.Visible Then
            TimerAutoHide?.Stop()
            HideWithFade()
        End If
    End Sub
    Private Sub FadeTimer_Tick(sender As Object, e As EventArgs)
        If _alpha <= App.Settings.AutoHideRatePlayer Then
            _alpha = 0
            TimerFade.Stop()
            Visible = False
        Else
            _alpha = CByte(_alpha - App.Settings.AutoHideRatePlayer)
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

    ' METHODS
    Friend Sub UpdatePlayer()
        Static cHandleMPC, cHandleVLC, cHandleWA, cHandleSM As IntPtr
        Static cTitleMPC, cTitleVLC, cTitleWA, cTitleSM As String
        Static cPSVLC, cPSWA, cPSSM As PlayState

        Dim changed As Boolean = False

        ' 1. Detect handles
        changed = UpdateHandles(cHandleMPC, cHandleVLC, cHandleWA, cHandleSM) Or changed

        ' 2. Detect titles
        changed = UpdateTitles(cTitleMPC, cTitleVLC, cTitleWA, cTitleSM,
                           cHandleMPC, cHandleVLC, cHandleWA, cHandleSM) Or changed

        ' 3. Detect playstates
        changed = UpdatePlayStates(cPSVLC, cPSWA, cPSSM,
                               cHandleVLC, cHandleWA, cHandleSM) Or changed

        ' 4. If nothing changed → do nothing
        If Not changed Then Exit Sub

        ' 5. Apply UI changes (icons + text)
        ApplyUIChanges(cHandleMPC, cHandleVLC, cHandleWA, cHandleSM,
                   cTitleMPC, cTitleVLC, cTitleWA, cTitleSM,
                   cPSVLC, cPSWA, cPSSM)

        If Not Visible OrElse _alpha < 255 Then ShowInstant()

    End Sub
    Private Shared Function UpdateHandles(ByRef cHandleMPC As IntPtr, ByRef cHandleVLC As IntPtr,
                               ByRef cHandleWA As IntPtr, ByRef cHandleSM As IntPtr) As Boolean

        Dim changed As Boolean = False

        Dim nMPC = PlayerAPI.GetHandleMPC()
        If nMPC <> cHandleMPC Then cHandleMPC = nMPC : changed = True

        Dim nVLC = PlayerAPI.GetHandleVLC()
        If nVLC <> cHandleVLC Then cHandleVLC = nVLC : changed = True

        Dim nWA = PlayerAPI.GetHandleWA()
        If nWA <> cHandleWA Then cHandleWA = nWA : changed = True

        Dim nSM = PlayerAPI.GetHandleSM()
        If nSM <> cHandleSM Then cHandleSM = nSM : changed = True

        Return changed
    End Function
    Private Shared Function UpdateTitles(ByRef cTitleMPC As String, ByRef cTitleVLC As String,
                              ByRef cTitleWA As String, ByRef cTitleSM As String,
                              cHandleMPC As IntPtr, cHandleVLC As IntPtr,
                              cHandleWA As IntPtr, cHandleSM As IntPtr) As Boolean

        Dim changed As Boolean = False

        Dim nMPC = PlayerAPI.GetSelectionMPC(cHandleMPC)
        If nMPC <> cTitleMPC Then cTitleMPC = nMPC : changed = True

        Dim nVLC = PlayerAPI.GetSelectionVLC(cHandleVLC)
        If nVLC <> cTitleVLC Then cTitleVLC = nVLC : changed = True

        Dim nWA = PlayerAPI.GetSelectionWA(cHandleWA)
        If nWA <> cTitleWA Then cTitleWA = nWA : changed = True

        Dim nSM = PlayerAPI.GetSelectionSM(cHandleSM)
        If nSM <> cTitleSM Then cTitleSM = nSM : changed = True

        Return changed
    End Function
    Private Shared Function UpdatePlayStates(ByRef cPSVLC As PlayState,
                                  ByRef cPSWA As PlayState,
                                  ByRef cPSSM As PlayState,
                                  cHandleVLC As IntPtr,
                                  cHandleWA As IntPtr,
                                  cHandleSM As IntPtr) As Boolean

        Dim changed As Boolean = False

        Dim nVLC = PlayerAPI.GetPlayStateVLC(cHandleVLC)
        If nVLC <> cPSVLC Then cPSVLC = nVLC : changed = True

        Dim nWA = PlayerAPI.GetPlayStateWA(cHandleWA)
        If nWA <> cPSWA Then cPSWA = nWA : changed = True

        Dim nSM = PlayerAPI.GetPlayStateSM(cHandleSM)
        If nSM <> cPSSM Then cPSSM = nSM : changed = True

        Return changed
    End Function
    Private Sub ApplyUIChanges(cHandleMPC As IntPtr, cHandleVLC As IntPtr,
                           cHandleWA As IntPtr, cHandleSM As IntPtr,
                           cTitleMPC As String, cTitleVLC As String,
                           cTitleWA As String, cTitleSM As String,
                           cPSVLC As PlayState, cPSWA As PlayState, cPSSM As PlayState)

        Dim icon As Image
        Dim playIcon As Image
        Dim text As String

        ' --- MPC ---
        If Not (cHandleMPC = IntPtr.Zero OrElse String.IsNullOrEmpty(cTitleMPC) OrElse cTitleMPC = PlayerAPI.MPC_CLASSNAME) Then
            icon = My.Resources.Resources.imageMPC
            playIcon = Nothing 'My.Resources.Resources.imagePlayerPlay   ' MPC has no playstate API
            text = cTitleMPC
            App.CurrentSelectionPath = cTitleMPC

            ' --- VLC ---
        ElseIf Not (cHandleVLC = IntPtr.Zero OrElse String.IsNullOrEmpty(cTitleVLC)) Then
            icon = My.Resources.Resources.imageVLC
            Select Case cPSVLC
                Case PlayState.Playing : playIcon = My.Resources.Resources.imagePlayerPlay
                Case PlayState.Paused : playIcon = My.Resources.Resources.imagePlayerPause
                Case Else : playIcon = My.Resources.Resources.imagePlayerStop
            End Select
            text = cTitleVLC
            App.CurrentSelectionPath = cTitleVLC

            ' --- Winamp ---
        ElseIf Not (cHandleWA = IntPtr.Zero OrElse String.IsNullOrEmpty(cTitleWA) OrElse cTitleWA = PlayerAPI.WA_CLASSNAME) Then
            icon = My.Resources.Resources.imageWA
            Dim parsed = ParseWinampTitle(cTitleWA)
            text = parsed.Title
            App.CurrentSelectionPath = parsed.Path
            Select Case cPSWA
                Case PlayState.Playing : playIcon = My.Resources.Resources.imagePlayerPlay
                Case PlayState.Paused : playIcon = My.Resources.Resources.imagePlayerPause
                Case Else : playIcon = My.Resources.Resources.imagePlayerStop
            End Select

            ' --- Skye Music ---
        ElseIf Not (cHandleSM = IntPtr.Zero OrElse String.IsNullOrEmpty(cTitleSM) OrElse cTitleSM = PlayerAPI.SM_CLASSNAME) Then
            icon = My.Resources.Resources.imageSM
            Dim parsed = ParseSkyeMusicTitle(cTitleSM)
            text = parsed.Title
            App.CurrentSelectionPath = parsed.Path
            Select Case cPSSM
                Case PlayState.Playing : playIcon = My.Resources.Resources.imagePlayerPlay
                Case PlayState.Paused : playIcon = My.Resources.Resources.imagePlayerPause
                Case Else : playIcon = My.Resources.Resources.imagePlayerStop
            End Select

            ' --- No Player ---
        Else
            icon = My.Resources.Resources.ImageApp16
            playIcon = My.Resources.Resources.imagePlayerStop
            text = "No Player"
            App.CurrentSelectionPath = String.Empty
        End If

        ' Push results into the new UI
        SetPlayerUI(icon, playIcon, text)
    End Sub
    Private Sub SetPlayerUI(playerIcon As Image, playIcon As Image, trackText As String)
        _playerIcon = playerIcon
        _playStateIcon = playIcon
        _trackText = trackText

        ResizeToFitText()
        RedrawLayered()
    End Sub
    Private Sub ResizeToFitText()
        Dim f As Font = GetPlayerFont()
        Dim textHeight As Integer
        Dim textWidth As Integer
        Using g As Graphics = Me.CreateGraphics()
            If Not String.IsNullOrEmpty(_trackText) Then
                Dim size As SizeF = g.MeasureString(_trackText & "_", f)
                textWidth = CInt(size.Width)
                textHeight = CInt(size.Height)
            Else
                textWidth = 0
                textHeight = 0
            End If
        End Using
        Dim iconSize As Integer = 16
        Dim gap As Integer = 12

        ' Width
        Dim totalWidth As Integer =
        CardPadding +
        iconSize + gap +
        iconSize + gap +
        textWidth +
        CardPadding

        ' Height
        Dim contentHeight As Integer = Math.Max(iconSize, textHeight)
        Dim extraMargin As Integer = 10
        Dim totalHeight As Integer = CardPadding + contentHeight + CardPadding + extraMargin

        Me.Width = totalWidth
        Me.Height = totalHeight
    End Sub
    Friend Sub SetPlacement()
        Dim wa = Screen.FromControl(Me).WorkingArea

        Select Case My.Settings.PlacementPlayer
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
                Me.Location = My.Settings.LocationPlayer
        End Select

    End Sub
    Private Sub SetHideTimer()
        TimerAutoHide.Stop()
        If App.Settings.AutoHidePlayer Then
            TimerAutoHide.Interval = App.Settings.AutoHideIntervalPlayer * 1000
            TimerAutoHide.Start()
        End If
    End Sub

    ' HELPERS
    Private Function GetPlayerFont() As Font
        Select Case App.Settings.PlayerSize
            Case App.SettingsType.PlayerSizes.Small : Return FontSmall
            Case App.SettingsType.PlayerSizes.Medium : Return FontMedium
            Case App.SettingsType.PlayerSizes.Large : Return FontLarge
            Case Else : Return FontMedium
        End Select
    End Function
    Private Shared Function ParseWinampTitle(raw As String) As (Title As String, Path As String)
        If String.IsNullOrWhiteSpace(raw) Then
            Return ("", "")
        End If

        If Not raw.Contains("@"c) Then
            Return (raw.Trim(), "")
        End If

        Dim parts = raw.Split("@"c)

        ' Title = everything except last part
        Dim title As String = String.Join("", parts.Take(parts.Length - 1)).Trim()

        ' Path = last part
        Dim path As String = parts(parts.Length - 1).Trim()

        Return (title, path)
    End Function
    Private Shared Function ParseSkyeMusicTitle(full As String) As (Title As String, Path As String)
        If String.IsNullOrWhiteSpace(full) Then
            Return ("", "")
        End If

        If Not full.Contains("@"c) Then
            Return (full.Trim(), "")
        End If

        Dim parts = full.Split("@"c)

        Dim title As String = String.Join("", parts.Take(parts.Length - 1)).Trim()
        title = title.Replace(PlayerAPI.SM_TITLEPREFIX, "").Trim()

        ' Path is last part
        Dim path As String = parts(parts.Length - 1).Trim()

        Return (title, path)
    End Function
    Private Function MouseInFormBounds() As Boolean
        If MousePosition.X > Me.Left AndAlso MousePosition.X < Me.Right AndAlso MousePosition.Y > Me.Top AndAlso MousePosition.Y < Me.Bottom Then : Return True
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

        ' --- Viewer ---
        MIViewer = New ToolStripMenuItem("", My.Resources.Resources.imageViewer)
        AddHandler MIViewer.MouseUp,
            Sub(sender As Object, e As MouseEventArgs)
                If e.Button = MouseButtons.Left Then
                    App.ShowViewer()
                End If
            End Sub
        CM.Items.Add(MIViewer)

        ' --- Open File Location ---
        MIOpenFileLocation = New ToolStripMenuItem("Open File Location", My.Resources.Resources.imageFolder, Sub() App.OpenFileLocation())
        CM.Items.Add(MIOpenFileLocation)

        ' --- Copy Title ---
        MICopyTitle = New ToolStripMenuItem("Copy Title", My.Resources.Resources.imageEditCopy) With {
            .ToolTipText = "RightClick = Copy Full Path"
        }
        AddHandler MICopyTitle.MouseDown,
            Sub(sender, e)
                If e.Button = MouseButtons.Left Then
                    My.Computer.Clipboard.SetText(_trackText, TextDataFormat.UnicodeText)
                ElseIf e.Button = MouseButtons.Right Then
                    My.Computer.Clipboard.SetText(App.CurrentSelectionPath, TextDataFormat.UnicodeText)
                End If
            End Sub
        CM.Items.Add(MICopyTitle)

        ' --- Size ---
        MISize = New ToolStripMenuItem("Size", My.Resources.Resources.ImageSize16)
        AddHandler MISize.MouseUp,
            Sub(sender As Object, e As MouseEventArgs)
                If e.Button = MouseButtons.Left Then
                    Select Case App.Settings.PlayerSize
                        Case App.SettingsType.PlayerSizes.Small
                            App.Settings.PlayerSize = App.SettingsType.PlayerSizes.Medium
                        Case App.SettingsType.PlayerSizes.Medium
                            App.Settings.PlayerSize = App.SettingsType.PlayerSizes.Large
                        Case App.SettingsType.PlayerSizes.Large
                            App.Settings.PlayerSize = App.SettingsType.PlayerSizes.Small
                    End Select
                ElseIf e.Button = MouseButtons.Right Then
                    Select Case App.Settings.PlayerSize
                        Case App.SettingsType.PlayerSizes.Small
                            App.Settings.PlayerSize = App.SettingsType.PlayerSizes.Large
                        Case App.SettingsType.PlayerSizes.Medium
                            App.Settings.PlayerSize = App.SettingsType.PlayerSizes.Small
                        Case App.SettingsType.PlayerSizes.Large
                            App.Settings.PlayerSize = App.SettingsType.PlayerSizes.Medium
                    End Select
                End If
                ResizeToFitText()
                RedrawLayered()
                App.Settings.SetSave()
            End Sub
        CM.Items.Add(MISize)

    End Sub

End Class
