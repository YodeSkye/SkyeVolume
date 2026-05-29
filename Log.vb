
Imports SkyeVolume.My

Public Class Log

    ' DECLARATIONS
    Private mMove As Boolean = False
    Private mOffset, mPosition As Point
    Private DeleteLogConfirm As Boolean = False
    Private WithEvents TimerDeleteLog As New Timer

    ' FORM EVENTS
    Private Sub Frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TimerDeleteLog.Interval = 5000
        FrmLog.Lblnfo.Text = Skye.Common.Log.LogFilePath & " (" & Skye.Common.Log.LineCount.ToString & " Lines)"
        Skye.UI.ThemeManager.RegisterComponent(TipLogEX)
        OnThemeChanged(App.CurrentTheme)
        AddHandler App.ThemeChanged, AddressOf OnThemeChanged
    End Sub
    Private Sub Log_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        App.FrmLog.Dispose()
        App.FrmLog = Nothing
    End Sub
    Private Sub Frm_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown, Lblnfo.MouseDown
        Dim cSender As Control
        If e.Button = MouseButtons.Left AndAlso Me.WindowState = FormWindowState.Normal Then
            mMove = True
            cSender = DirectCast(sender, Control)
            If cSender Is Lblnfo Then
                mOffset = New Point(-e.X - cSender.Left - SystemInformation.FrameBorderSize.Width - 4, -e.Y - cSender.Top - SystemInformation.FrameBorderSize.Height - SystemInformation.CaptionHeight - 4)
            Else : mOffset = New Point(-e.X - SystemInformation.FrameBorderSize.Width - 4, -e.Y - SystemInformation.FrameBorderSize.Height - SystemInformation.CaptionHeight - 4)
            End If
        End If
    End Sub
    Private Sub Frm_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove, Lblnfo.MouseMove
        If mMove Then
            mPosition = Control.MousePosition
            mPosition.Offset(mOffset.X, mOffset.Y)
            CheckMove(mPosition)
            Location = mPosition
        End If
    End Sub
    Private Sub Frm_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp, Lblnfo.MouseUp
        mMove = False
    End Sub
    Private Sub Frm_Move(sender As Object, e As EventArgs) Handles MyBase.Move
        If Not mMove AndAlso Me.WindowState = FormWindowState.Normal Then
            CheckMove(Me.Location)
        End If
    End Sub
    Private Sub Log_DoubleClick(sender As Object, e As EventArgs) Handles MyBase.DoubleClick
        ToggleMaximized()
    End Sub
    Private Sub Frm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyData
            Case Keys.W Or Keys.Control
                Close()
            Case Keys.W Or Keys.Control Or Keys.Shift, Keys.Escape
                WindowState = FormWindowState.Minimized
            Case Keys.F12
                ToggleMaximized()
        End Select
    End Sub

    ' CONTROL EVENTS
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If DeleteLogConfirm Then
            Skye.Common.Log.Clear()
            Me.LogViewer.RefreshContent()
        End If
        SetDeleteLogConfirm()
    End Sub
    Private Sub Lblnfo_DoubleClick(sender As Object, e As EventArgs) Handles Lblnfo.DoubleClick
        Skye.Common.Log.OpenLocation()
    End Sub

    ' HANDLERS
    Private Sub OnThemeChanged(theme As App.Theme)
        Select Case theme
            Case App.Theme.Light
                Skye.UI.ThemeManager.CurrentTheme = Skye.UI.SkyeThemes.Light
            Case App.Theme.Dark
                Skye.UI.ThemeManager.CurrentTheme = Skye.UI.SkyeThemes.Dark
        End Select
        Skye.UI.ThemeManager.ApplyTheme(Me)
    End Sub
    Private Sub TimerDeleteLog_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles TimerDeleteLog.Tick
        SetDeleteLogConfirm()
    End Sub

    ' METHODS
    Private Sub SetDeleteLogConfirm(Optional forcereset As Boolean = False)
        If DeleteLogConfirm Or forcereset Then
            TimerDeleteLog.Stop()
            DeleteLogConfirm = False
            OnThemeChanged(App.CurrentTheme)
            TipLogEX.HideTooltip()
            TipLogEX.HideDelay = 500
        Else
            DeleteLogConfirm = True
            Me.BtnDelete.BackColor = Color.Red
            TipLogEX.HideDelay = 5000
            TipLogEX.ShowTooltipAtCursor("Are You Sure?")
            TimerDeleteLog.Start()
        End If
    End Sub
    Private Sub ToggleMaximized()
        Select Case WindowState
            Case FormWindowState.Normal
                WindowState = FormWindowState.Maximized
            Case FormWindowState.Maximized, FormWindowState.Minimized
                WindowState = FormWindowState.Normal
        End Select
    End Sub
    Private Sub CheckMove(ByRef location As Point)
        If location.X + Width > My.Computer.Screen.WorkingArea.Right Then location.X = My.Computer.Screen.WorkingArea.Right - Width + App.AdjustScreenBoundsNormalWindow
        If location.Y + Height > My.Computer.Screen.WorkingArea.Bottom Then location.Y = My.Computer.Screen.WorkingArea.Bottom - Height + App.AdjustScreenBoundsNormalWindow
        If location.X < My.Computer.Screen.WorkingArea.Left Then location.X = My.Computer.Screen.WorkingArea.Left - App.AdjustScreenBoundsNormalWindow
        If location.Y < App.AdjustScreenBoundsNormalWindow Then location.Y = My.Computer.Screen.WorkingArea.Top
    End Sub

End Class
