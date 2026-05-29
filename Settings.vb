
Imports Microsoft.Win32
Imports SkyeVolume.My

Partial Public Class Settings

    ' DECLARATIONS
    Private txtboxCM As New Skye.UI.TextBoxContextMenu
    Private uiFileBrowserEXE As New OpenFileDialog
    Private uiFileBrowserTXT As New OpenFileDialog
    Private DisableLockKeys As Boolean = False
    Private DisableLockKeysRegPath As String = "SYSTEM\CurrentControlSet\Control\Keyboard Layout"
    Private DisableLockKeysRegValue As String = "ScanCode Map"
    Private DisableLockKeysRegData As Byte() = {0, 0, 0, 0, 0, 0, 0, 0, &H4, 0, 0, 0, &H3A, 0, 0, 0, 0, 0, &H3A, 0, 0, 0, &H45, 0, 0, 0, 0, 0, 0, 0, 0, 0}

    ' FORM EVENTS
    Protected Overrides Sub WndProc(ByRef m As Message)
        Try
            Select Case CLng(m.WParam)
                Case Skye.WinAPI.SC_CLOSE
#If DEBUG Then
                    App.Finalize()
#Else
                    App.CloseSettings()
#End If
            End Select
        Catch ex As Exception
            Skye.Common.Log.Write("WndProc Handler Error" + Chr(13) + ex.ToString)
        Finally
            MyBase.WndProc(m)
        End Try
    End Sub
    Friend Sub New()

        ' Initialize Locals
        uiFileBrowserEXE.Title = "Select An App..."
        uiFileBrowserEXE.DefaultExt = "exe"
        uiFileBrowserEXE.Filter = "Executable Files|*.exe"
        uiFileBrowserTXT.Title = "Select A Text File..."
        uiFileBrowserTXT.DefaultExt = "txt"
        uiFileBrowserTXT.Filter = "Text Files|*.txt"

        ' Initialize Form
        InitializeComponent()
        Me.Text = "Settings For " + My.Application.Info.ProductName
        For Each name As String In [Enum].GetNames(Of SettingsType.UnMuteOnVolumeChangeWhen)()
            Me.cobxUnMuteOnVolumeChange.Items.Add(name)
        Next
        txbxZoneRed.ContextMenuStrip = txtboxCM
        txbxZoneBlue.ContextMenuStrip = txtboxCM
        txbxWAPath.ContextMenuStrip = txtboxCM
        txbxViewerPath.ContextMenuStrip = txtboxCM
        txbxViewerName.ContextMenuStrip = txtboxCM
        txbxSysVCPath.ContextMenuStrip = txtboxCM
        txbxSaveEarsVolume.ContextMenuStrip = txtboxCM
        txbxSaveEarsInterval.ContextMenuStrip = txtboxCM
        txbxPlayerOutputCurrentPath.ContextMenuStrip = txtboxCM
        txbxAutoHideRateVolume.ContextMenuStrip = txtboxCM
        txbxAutoHideRatePlayer.ContextMenuStrip = txtboxCM
        txbxAutoHideIntervalVolume.ContextMenuStrip = txtboxCM
        txbxAutoHideIntervalPlayer.ContextMenuStrip = txtboxCM
        txbxSMPath.ContextMenuStrip = txtboxCM
        ShowSettings()
        Skye.UI.ThemeManager.RegisterComponent(TipSettingsEX)
        OnThemeChanged(App.CurrentTheme)
        AddHandler App.ThemeChanged, AddressOf OnThemeChanged

    End Sub
    Private Sub SettingsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ShowSave() ' moved here to keep if from being overridden by theming
    End Sub
    Private Sub FrmPaint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        ' Dynamic zone area based on tbarZoneRed
        Dim zArea As New Rectangle(
            tbarZoneRed.Left,
            tbarZoneRed.Bottom + 6,
            tbarZoneRed.Width,
            20
        )
        Dim g = e.Graphics
        ' Calculate pixel positions for the zone boundaries
        Dim pxBlue = zArea.X + CInt(App.Settings.vBlueZone / 100.0 * zArea.Width)
        Dim pxRed = zArea.X + CInt(App.Settings.vRedZone / 100.0 * zArea.Width)

        ' Draw GREEN zone
        Using b As New SolidBrush(App.Settings.cGreenZone)
            g.FillRectangle(b, zArea.X, zArea.Y, pxBlue - zArea.X, zArea.Height)
        End Using
        ' Draw BLUE zone
        Using b As New SolidBrush(App.Settings.cBlueZone)
            g.FillRectangle(b, pxBlue, zArea.Y, pxRed - pxBlue, zArea.Height)
        End Using
        ' Draw RED zone
        Using b As New SolidBrush(App.Settings.cRedZone)
            g.FillRectangle(b, pxRed, zArea.Y, zArea.Right - pxRed, zArea.Height)
        End Using
        ' Draw border
        Using p As New Pen(Color.Black, 2)
            g.DrawRectangle(p, zArea)
        End Using

    End Sub
    Private Sub FrmMove(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Move
        If Me.WindowState = FormWindowState.Normal Then
            If Me.Top < My.Computer.Screen.WorkingArea.Top Then Me.Top = My.Computer.Screen.WorkingArea.Top
            If Me.Bottom > My.Computer.Screen.WorkingArea.Height + My.Computer.Screen.WorkingArea.Top Then Me.Top = My.Computer.Screen.WorkingArea.Height + My.Computer.Screen.WorkingArea.Top - Me.Height
            If Me.Left < My.Computer.Screen.WorkingArea.Left Then Me.Left = My.Computer.Screen.WorkingArea.Left
            If Me.Right > My.Computer.Screen.WorkingArea.Width + My.Computer.Screen.WorkingArea.Left Then Me.Left = My.Computer.Screen.WorkingArea.Width + My.Computer.Screen.WorkingArea.Left - Me.Width
        End If
    End Sub
    Private Sub FrmKeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyData
            Case Keys.F1 : My.App.ShowHelp()
            Case Keys.Escape : My.App.CloseSettings()
            Case Keys.W Or Keys.Control : My.App.CloseSettings()
            Case Keys.W Or Keys.Control Or Keys.Shift : Me.WindowState = FormWindowState.Minimized
        End Select
    End Sub

    ' CONTROL EVENTS
    Private Sub TbarZoneBlueScroll(sender As Object, e As EventArgs) Handles tbarZoneBlue.Scroll
        Me.tbarZoneBlue.Value = CheckBlueZone(Me.tbarZoneBlue.Value)
        If Not My.Settings.vBlueZone = CheckBlueZone(Me.tbarZoneBlue.Value) Then
            My.Settings.vBlueZone = CheckBlueZone(Me.tbarZoneBlue.Value)
            ShowSettings()

            If App.FrmVolume.Visible Then
                App.FrmVolume.UpdateVolume()
                Me.Focus()
            End If
            App.Settings.SetSave()
        End If
    End Sub
    Private Sub TbarZoneRedScroll(sender As Object, e As EventArgs) Handles tbarZoneRed.Scroll
        Me.tbarZoneRed.Value = CheckRedZone(Me.tbarZoneRed.Value)
        If Not My.Settings.vRedZone = CheckRedZone(Me.tbarZoneRed.Value) Then
            My.Settings.vRedZone = CheckRedZone(Me.tbarZoneRed.Value)
            ShowSettings()

            If App.FrmVolume.Visible Then
                App.FrmVolume.UpdateVolume()
                Me.Focus()
            End If
            App.Settings.SetSave()
        End If
    End Sub
    Private Sub TxbxPreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txbxZoneRed.PreviewKeyDown, txbxZoneBlue.PreviewKeyDown, txbxWAPath.PreviewKeyDown, txbxViewerPath.PreviewKeyDown, txbxViewerName.PreviewKeyDown, txbxSysVCPath.PreviewKeyDown, txbxSaveEarsVolume.PreviewKeyDown, txbxSaveEarsInterval.PreviewKeyDown, txbxPlayerOutputCurrentPath.PreviewKeyDown, txbxAutoHideRateVolume.PreviewKeyDown, txbxAutoHideRatePlayer.PreviewKeyDown, txbxAutoHideIntervalVolume.PreviewKeyDown, txbxAutoHideIntervalPlayer.PreviewKeyDown, txbxSMPath.PreviewKeyDown, txbxVLCPath.PreviewKeyDown, txbxMPCPath.PreviewKeyDown
        txtboxCM.ShortcutKeys(DirectCast(sender, TextBox), e)
    End Sub
    Private Sub TxbxKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txbxZoneRed.KeyDown, txbxZoneBlue.KeyDown, txbxWAPath.KeyDown, txbxViewerPath.KeyDown, txbxViewerName.KeyDown, txbxSysVCPath.KeyDown, txbxSaveEarsVolume.KeyDown, txbxSaveEarsInterval.KeyDown, txbxPlayerOutputCurrentPath.KeyDown, txbxAutoHideRateVolume.KeyDown, txbxAutoHideRatePlayer.KeyDown, txbxAutoHideIntervalVolume.KeyDown, txbxAutoHideIntervalPlayer.KeyDown, txbxSMPath.KeyDown, txbxVLCPath.KeyDown, txbxMPCPath.KeyDown
        If e.KeyCode = Keys.Enter Then Validate()
    End Sub
    Private Sub TxbxNumbersOnlyKeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txbxZoneRed.KeyPress, txbxZoneBlue.KeyPress, txbxSaveEarsVolume.KeyPress, txbxSaveEarsInterval.KeyPress, txbxAutoHideRateVolume.KeyPress, txbxAutoHideRatePlayer.KeyPress, txbxAutoHideIntervalVolume.KeyPress, txbxAutoHideIntervalPlayer.KeyPress
        Static nonNumberEntered As Boolean
        nonNumberEntered = False
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then : nonNumberEntered = True
        ElseIf Asc(e.KeyChar) = Keys.Enter Then : Me.Validate()
        End If
        If nonNumberEntered Then e.Handled = True
    End Sub
    Private Sub TxbxZoneBlueValidated(sender As Object, e As EventArgs) Handles txbxZoneBlue.Validated
        Dim blue As Integer
        If Not Integer.TryParse(Me.txbxZoneBlue.Text, blue) Then
            blue = App.Settings.Defaults.vBlueZone
        End If
        blue = CheckBlueZone(blue)
        Me.txbxZoneBlue.Text = blue.ToString
        If My.Settings.vBlueZone <> CByte(blue) Then
            My.Settings.vBlueZone = CByte(blue)
            Me.txbxZoneBlue.SelectAll()
            ShowSettings()
            If App.FrmVolume.Visible Then
                App.FrmVolume.UpdateVolume()
                Me.Focus()
            End If
            App.Settings.SetSave()
        End If
    End Sub
    Private Sub TxbxZoneRedValidated(sender As Object, e As EventArgs) Handles txbxZoneRed.Validated
        Dim red As Integer
        If Not Integer.TryParse(Me.txbxZoneRed.Text, red) Then
            red = App.Settings.Defaults.vRedZone
        End If
        red = CheckRedZone(red)
        Me.txbxZoneRed.Text = red.ToString
        If My.Settings.vRedZone <> CByte(red) Then
            My.Settings.vRedZone = CByte(red)
            Me.txbxZoneRed.SelectAll()
            ShowSettings()
            If App.FrmVolume.Visible Then
                App.FrmVolume.UpdateVolume()
                Me.Focus()
            End If
            App.Settings.SetSave()
        End If
    End Sub
    Private Sub TxbxAutoHideIntervalVolumeValidated(sender As Object, e As EventArgs) Handles txbxAutoHideIntervalVolume.Validated
        Dim v As Integer
        If Not Integer.TryParse(Me.txbxAutoHideIntervalVolume.Text, v) Then
            v = App.Settings.Defaults.AutoHideIntervalVolume
        End If
        v = CheckHideIntervalVolume(CUShort(v))
        Me.txbxAutoHideIntervalVolume.Text = v.ToString
        If My.Settings.AutoHideIntervalVolume <> CUShort(v) Then
            My.Settings.AutoHideIntervalVolume = CUShort(v)
            Me.txbxAutoHideIntervalVolume.SelectAll()
            App.Settings.SetSave()
        End If
    End Sub
    Private Sub TxbxAutoHideIntervalPlayerValidated(sender As Object, e As EventArgs) Handles txbxAutoHideIntervalPlayer.Validated
        Dim v As Integer
        If Not Integer.TryParse(Me.txbxAutoHideIntervalPlayer.Text, v) Then
            v = App.Settings.Defaults.AutoHideIntervalPlayer
        End If

        v = CheckHideIntervalPlayer(CUShort(v))
        Me.txbxAutoHideIntervalPlayer.Text = v.ToString

        If My.Settings.AutoHideIntervalPlayer <> CUShort(v) Then
            My.Settings.AutoHideIntervalPlayer = CUShort(v)
            Me.txbxAutoHideIntervalPlayer.SelectAll()
            App.Settings.SetSave()
        End If
    End Sub
    Private Sub TxbxAutoHideRateVolumeValidated(sender As Object, e As EventArgs) Handles txbxAutoHideRateVolume.Validated
        Dim v As Integer
        If Not Integer.TryParse(Me.txbxAutoHideRateVolume.Text, v) Then
            v = App.Settings.Defaults.AutoHideRateVolume
        End If

        v = CheckHideRateVolume(CUShort(v))
        Me.txbxAutoHideRateVolume.Text = v.ToString

        If My.Settings.AutoHideRateVolume <> CUShort(v) Then
            My.Settings.AutoHideRateVolume = CUShort(v)
            Me.txbxAutoHideRateVolume.SelectAll()
            App.Settings.SetSave()
        End If
    End Sub
    Private Sub TxbxAutoHideRatePlayerValidated(sender As Object, e As EventArgs) Handles txbxAutoHideRatePlayer.Validated
        Dim v As Integer
        If Not Integer.TryParse(Me.txbxAutoHideRatePlayer.Text, v) Then
            v = App.Settings.Defaults.AutoHideRatePlayer
        End If

        v = CheckHideRatePlayer(CUShort(v))
        Me.txbxAutoHideRatePlayer.Text = v.ToString

        If My.Settings.AutoHideRatePlayer <> CUShort(v) Then
            My.Settings.AutoHideRatePlayer = CUShort(v)
            Me.txbxAutoHideRatePlayer.SelectAll()
            My.Settings.SetSave()
        End If
    End Sub
    Private Sub TxbxViewerNameValidated(sender As Object, e As EventArgs) Handles txbxViewerName.Validated
        If Not My.Settings.ViewerName = Me.txbxViewerName.Text Then
            My.Settings.ViewerName = Me.txbxViewerName.Text
            Me.txbxViewerName.SelectAll()
            ShowSettings()
            My.Settings.SetSave()
        End If
    End Sub
    Private Sub TxbxViewerPathValidated(sender As Object, e As EventArgs) Handles txbxViewerPath.Validated
        If My.Settings.ViewerPath = Me.txbxViewerPath.Text Then : SetViewerPathError(False)
        Else
            If My.Computer.FileSystem.FileExists(Me.txbxViewerPath.Text) Then
                My.Settings.ViewerPath = Me.txbxViewerPath.Text
                Me.txbxViewerPath.SelectAll()
                ShowSettings()
                My.Settings.SetSave()
            Else : SetViewerPathError(True)
            End If
        End If
    End Sub
    Private Sub TxbxSysVCPathValidated(sender As Object, e As EventArgs) Handles txbxSysVCPath.Validated
        If My.Settings.SystemVolumeControlPath = Me.txbxSysVCPath.Text Then : SetSysVCPathError(False)
        Else
            If My.Computer.FileSystem.FileExists(Me.txbxSysVCPath.Text) Then
                My.Settings.SystemVolumeControlPath = Me.txbxSysVCPath.Text
                Me.txbxSysVCPath.SelectAll()
                ShowSettings()
                My.Settings.SetSave()
            Else : SetSysVCPathError(True)
            End If
        End If
    End Sub
    Private Sub TxbxMPCPath_Validated(sender As Object, e As EventArgs) Handles txbxMPCPath.Validated
        If App.Settings.AppPathMPC = txbxMPCPath.Text Then : SetMPCPathError(False)
        Else
            If My.Computer.FileSystem.FileExists(txbxMPCPath.Text) Then
                App.Settings.AppPathMPC = txbxMPCPath.Text
                txbxMPCPath.SelectAll()
                ShowSettings()
                App.Settings.SetSave()
            Else : SetMPCPathError(True)
            End If
        End If
    End Sub
    Private Sub TxbxVLCPath_Validated(sender As Object, e As EventArgs) Handles txbxVLCPath.Validated
        If App.Settings.AppPathVLC = txbxVLCPath.Text Then : SetVLCPathError(False)
        Else
            If My.Computer.FileSystem.FileExists(txbxVLCPath.Text) Then
                App.Settings.AppPathVLC = txbxVLCPath.Text
                txbxVLCPath.SelectAll()
                ShowSettings()
                App.Settings.SetSave()
            Else : SetVLCPathError(True)
            End If
        End If
    End Sub
    Private Sub TxbxWAPathValidated(sender As Object, e As EventArgs) Handles txbxWAPath.Validated
        If App.Settings.AppPathWA = txbxWAPath.Text Then : SetWAPathError(False)
        Else
            If My.Computer.FileSystem.FileExists(txbxWAPath.Text) Then
                App.Settings.AppPathWA = txbxWAPath.Text
                txbxWAPath.SelectAll()
                ShowSettings()
                App.Settings.SetSave()
            Else : SetWAPathError(True)
            End If
        End If
    End Sub
    Private Sub TxbxSMPath_Validated(sender As Object, e As EventArgs) Handles txbxSMPath.Validated
        If App.Settings.AppPathSM = txbxSMPath.Text Then : SetSMPathError(False)
        Else
            If My.Computer.FileSystem.FileExists(txbxSMPath.Text) Then
                App.Settings.AppPathSM = txbxSMPath.Text
                txbxSMPath.SelectAll()
                ShowSettings()
                App.Settings.SetSave()
            Else : SetSMPathError(True)
            End If
        End If
    End Sub
    Private Sub TxbxPlayerOutputCurrentPathValidated(sender As Object, e As EventArgs) Handles txbxPlayerOutputCurrentPath.Validated
        If My.Settings.PlayerOutputCurrentPath = Me.txbxPlayerOutputCurrentPath.Text Then : SetPlayerOutputCurrentPathError(False)
        Else
            If My.Computer.FileSystem.FileExists(Me.txbxPlayerOutputCurrentPath.Text) Then
                My.Settings.PlayerOutputCurrentPath = Me.txbxPlayerOutputCurrentPath.Text
                Me.txbxPlayerOutputCurrentPath.SelectAll()
                ShowSettings()
                My.Settings.SetSave()
            Else : SetPlayerOutputCurrentPathError(True)
            End If
        End If
    End Sub
    Private Sub TxbxSaveEarsVolumeValidated(sender As Object, e As EventArgs) Handles txbxSaveEarsVolume.Validated
        Dim v As Integer
        If Not Integer.TryParse(Me.txbxSaveEarsVolume.Text, v) Then
            v = App.Settings.Defaults.vSaveEars
        End If
        v = CheckSaveEarsVolume(CByte(v))
        Me.txbxSaveEarsVolume.Text = v.ToString
        If My.Settings.vSaveEars <> CByte(v) Then
            My.Settings.vSaveEars = CByte(v)
            Me.txbxSaveEarsVolume.SelectAll()
            My.Settings.SetSave()
        End If
    End Sub
    Private Sub TxbxSaveEarsIntervalValidated(sender As Object, e As EventArgs) Handles txbxSaveEarsInterval.Validated
        Dim v As Integer
        If Not Integer.TryParse(Me.txbxSaveEarsInterval.Text, v) Then
            v = App.Settings.Defaults.SaveEarsInterval
        End If
        v = CheckSaveEarsInterval(v)
        Me.txbxSaveEarsInterval.Text = v.ToString
        If My.Settings.SaveEarsInterval <> CByte(v) Then
            My.Settings.SaveEarsInterval = CByte(v)
            Me.txbxSaveEarsInterval.SelectAll()
            My.Settings.SetSave()
            App.SetSaveEars()
        End If
    End Sub
    Private Sub TxbxHotKeyKeyPress(sender As Object, e As KeyPressEventArgs) Handles txbxHotKeyVolumeInfo.KeyPress, txbxHotKeyViewer.KeyPress, txbxHotKeyPlayerInfo.KeyPress
        e.Handled = True
    End Sub
    Private Sub TxbxHotKeyPreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txbxHotKeyVolumeInfo.PreviewKeyDown, txbxHotKeyViewer.PreviewKeyDown, txbxHotKeyPlayerInfo.PreviewKeyDown
        Dim senderTextBox As TextBox = CType(sender, TextBox)
        Dim senderTag As My.App.SettingsType.HotKey = CType(senderTextBox.Tag, My.App.SettingsType.HotKey)
        If Not e.KeyData = senderTag.Key Then
            'Setup New HotKey
            Dim newhotkey As New My.App.SettingsType.HotKey
            Dim keysinuse As Collections.Generic.List(Of Keys) = My.App.GenerateUsedKeyList
            Dim modifiers As Integer = 0
            Dim match As Boolean = False
            If e.Shift Then modifiers += Skye.WinAPI.MOD_SHIFT
            If e.Control Then modifiers += Skye.WinAPI.MOD_CONTROL
            If e.Alt Then modifiers += Skye.WinAPI.MOD_ALT
            newhotkey.Description = senderTag.Description
            newhotkey.WinID = senderTag.WinID
            newhotkey.Key = e.KeyData
            newhotkey.KeyCode = CByte(e.KeyValue)
            newhotkey.KeyMod = CByte(modifiers)
            'Check If Already In-Use
            If Not CType(Me.txbxHotKeyVolumeInfo.Tag, My.App.SettingsType.HotKey).Key = My.Settings.HotKeyVolume.Key Then keysinuse.Add(CType(Me.txbxHotKeyVolumeInfo.Tag, My.App.SettingsType.HotKey).Key)
            If Not CType(Me.txbxHotKeyPlayerInfo.Tag, My.App.SettingsType.HotKey).Key = My.Settings.HotKeyPlayer.Key Then keysinuse.Add(CType(Me.txbxHotKeyPlayerInfo.Tag, My.App.SettingsType.HotKey).Key)
            If Not CType(Me.txbxHotKeyViewer.Tag, My.App.SettingsType.HotKey).Key = My.Settings.HotKeyViewer.Key Then keysinuse.Add(CType(Me.txbxHotKeyViewer.Tag, My.App.SettingsType.HotKey).Key)
            For Each usedkey As Keys In keysinuse : If usedkey = newhotkey.Key Then match = True
            Next
            'Display New HotKey If Not Already In-Use
            If Not match Then
                senderTextBox.Font = New Font(senderTextBox.Font, FontStyle.Regular)
                senderTextBox.ForeColor = Color.Maroon
                senderTextBox.Text = e.KeyData.ToString
                senderTextBox.Tag = newhotkey
                Me.btnHotKeysUndo.Enabled = True
                Me.btnHotKeysSet.Enabled = True
            End If
        End If
    End Sub
    Private Sub CobxUnMuteOnVolumeChangeSelectionChangeCommitted(sender As Object, e As EventArgs) Handles cobxUnMuteOnVolumeChange.SelectionChangeCommitted
        If Not My.Settings.UnMuteOnVolumeChange = Me.cobxUnMuteOnVolumeChange.SelectedIndex Then
            My.Settings.UnMuteOnVolumeChange = CType(Me.cobxUnMuteOnVolumeChange.SelectedIndex, My.App.SettingsType.UnMuteOnVolumeChangeWhen)
            My.Settings.SetSave()
        End If
    End Sub
    Private Sub CoBoxTheme_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles CoBoxTheme.SelectionChangeCommitted
        App.Settings.SelectedTheme = CType(CoBoxTheme.SelectedIndex, App.Theme)
        ApplyTheme()
        App.Settings.SetSave()
    End Sub
    Private Sub ChBoxTheme_Click(sender As Object, e As EventArgs) Handles ChBoxTheme.Click
        App.Settings.UseSystemTheme = ChBoxTheme.Checked
        ApplyTheme()
        App.Settings.SetSave()
        ShowSettings()
    End Sub
    Private Sub ChbxShowMetersClick(sender As Object, e As EventArgs) Handles chbxShowMeters.Click
        If Not My.Settings.ShowMeters = Me.chbxShowMeters.Checked Then
            My.Settings.ShowMeters = Me.chbxShowMeters.Checked
            My.Settings.SetSave()
        End If
        If Not My.Settings.ShowMeters Then App.FrmVolume.UpdateVolume()
    End Sub
    Private Sub ChbxHotKeysClick(sender As Object, e As EventArgs) Handles chbxHotKeys.Click
        If My.Settings.HotKeysEnabled Then
            My.App.RegisterHotKeys(False)
            My.Settings.HotKeysEnabled = False
        Else
            My.Settings.HotKeysEnabled = True
            My.App.RegisterHotKeys(True)
        End If
        ShowSettings()
        My.Settings.SetSave()
    End Sub
    Private Sub ChbxAutoHideVolumeClick(sender As Object, e As EventArgs) Handles chbxAutoHideVolume.Click
        If Not My.Settings.AutoHideVolume = Me.chbxAutoHideVolume.Checked Then
            My.Settings.AutoHideVolume = Me.chbxAutoHideVolume.Checked
            My.Settings.SetSave()
            App.FrmVolume.ShowInstant()
            UpdateAutoHide()
            Me.Focus()
        End If
    End Sub
    Private Sub ChbxAutoHidePlayerClick(sender As Object, e As EventArgs) Handles chbxAutoHidePlayer.Click
        If Not My.Settings.AutoHidePlayer = Me.chbxAutoHidePlayer.Checked Then
            My.Settings.AutoHidePlayer = Me.chbxAutoHidePlayer.Checked
            My.Settings.SetSave()
            If My.FrmPlayer IsNot Nothing Then
                My.FrmPlayer.ShowInstant()
                UpdateAutoHide()
                Me.Focus()
            End If
        End If
    End Sub
    Private Sub ChbxAutoHideWithFadeVolumeClick(sender As Object, e As EventArgs) Handles chbxAutoHideWithFadeVolume.Click
        If Not My.Settings.AutoHideWithFadeVolume = Me.chbxAutoHideWithFadeVolume.Checked Then
            My.Settings.AutoHideWithFadeVolume = Me.chbxAutoHideWithFadeVolume.Checked
            My.Settings.SetSave()
            My.FrmMain.Show()
            UpdateAutoHide()
            Me.Focus()
        End If
    End Sub
    Private Sub ChbxAutoHideWithFadePlayerClick(sender As Object, e As EventArgs) Handles chbxAutoHideWithFadePlayer.Click
        If Not My.Settings.AutoHideWithFadePlayer = Me.chbxAutoHideWithFadePlayer.Checked Then
            My.Settings.AutoHideWithFadePlayer = Me.chbxAutoHideWithFadePlayer.Checked
            My.Settings.SetSave()

            If My.FrmPlayer IsNot Nothing Then
                My.FrmPlayer.ShowInstant()
                UpdateAutoHide()
                Me.Focus()
            End If
        End If
    End Sub
    Private Sub ChbxAlwaysHideOnClickVolumeClick(sender As Object, e As EventArgs) Handles chbxAlwaysHideOnClickVolume.Click
        If Not My.Settings.AlwaysHideOnClickVolume = Me.chbxAlwaysHideOnClickVolume.Checked Then
            My.Settings.AlwaysHideOnClickVolume = Me.chbxAlwaysHideOnClickVolume.Checked
            My.Settings.SetSave()
        End If
    End Sub
    Private Sub ChbxAutoShowPlayerClick(sender As Object, e As EventArgs) Handles chbxAutoShowPlayer.Click
        If Not My.Settings.PlayerAutoShow = Me.chbxAutoShowPlayer.Checked Then
            My.Settings.PlayerAutoShow = Me.chbxAutoShowPlayer.Checked
            My.Settings.SetSave()
        End If
    End Sub
    Private Sub ChbxPlayerOutputCurrentClick(sender As Object, e As EventArgs) Handles chbxPlayerOutputCurrent.Click
        If Not My.Settings.PlayerOutputCurrent = Me.chbxPlayerOutputCurrent.Checked Then
            My.Settings.PlayerOutputCurrent = Me.chbxPlayerOutputCurrent.Checked
            My.Settings.SetSave()
        End If
    End Sub
    Private Sub LsbxSaveEarsAppsMouseDown(sender As Object, e As MouseEventArgs) Handles lsbxSaveEarsApps.MouseDown
        If e.Button = MouseButtons.Right Then
            Me.lsbxSaveEarsApps.SelectedIndex = Me.lsbxSaveEarsApps.IndexFromPoint(e.Location)
            Me.lsbxSaveEarsApps.Focus()
        End If
    End Sub
    Private Sub LsbxSaveEarsAppsLeave(sender As Object, e As EventArgs) Handles lsbxSaveEarsApps.Leave
        If Not Me.btnSaveEarsAppsRemove.Focused Then Me.lsbxSaveEarsApps.SelectedIndex = -1
    End Sub
    Private Sub LsbxSaveEarsAppsSelectedIndexChanged(sender As Object, e As EventArgs) Handles lsbxSaveEarsApps.SelectedIndexChanged
        If Me.lsbxSaveEarsApps.SelectedIndex >= 0 Then : Me.btnSaveEarsAppsRemove.Enabled = True
        Else : Me.btnSaveEarsAppsRemove.Enabled = False
        End If
    End Sub
    Private Sub RadbtnVolumePlacementClick(sender As Object, e As EventArgs) Handles radbtnVolumePlacementTopRight.Click, radbtnVolumePlacementTopLeft.Click, radbtnVolumePlacementTopCenterRight.Click, radbtnVolumePlacementTopCenterLeft.Click, radbtnVolumePlacementTopCenter.Click, radbtnVolumePlacementRightCenterTop.Click, radbtnVolumePlacementRightCenterBottom.Click, radbtnVolumePlacementRightCenter.Click, radbtnVolumePlacementManual.Click, radbtnVolumePlacementLeftCenterTop.Click, radbtnVolumePlacementLeftCenterBottom.Click, radbtnVolumePlacementLeftCenter.Click, radbtnVolumePlacementCenter.Click, radbtnVolumePlacementBottomRight.Click, radbtnVolumePlacementBottomLeft.Click, radbtnVolumePlacementBottomCenterRight.Click, radbtnVolumePlacementBottomCenterLeft.Click, radbtnVolumePlacementBottomCenter.Click
        For Each c As Control In grbxVolumePlacement.Controls
            If sender Is c Then
                Select Case c.Name
                    Case "radbtnVolumePlacementTopLeft" : App.Settings.PlacementVolume = App.SettingsType.Placement.TopLeft
                    Case "radbtnVolumePlacementTopCenterLeft" : App.Settings.PlacementVolume = App.SettingsType.Placement.TopCenterLeft
                    Case "radbtnVolumePlacementTopCenter" : App.Settings.PlacementVolume = App.SettingsType.Placement.TopCenter
                    Case "radbtnVolumePlacementTopCenterRight" : App.Settings.PlacementVolume = App.SettingsType.Placement.TopCenterRight
                    Case "radbtnVolumePlacementTopRight" : App.Settings.PlacementVolume = App.SettingsType.Placement.TopRight
                    Case "radbtnVolumePlacementRightCenterTop" : App.Settings.PlacementVolume = App.SettingsType.Placement.RightCenterTop
                    Case "radbtnVolumePlacementRightCenter" : App.Settings.PlacementVolume = App.SettingsType.Placement.RightCenter
                    Case "radbtnVolumePlacementRightCenterBottom" : App.Settings.PlacementVolume = App.SettingsType.Placement.RightCenterBottom
                    Case "radbtnVolumePlacementBottomRight" : App.Settings.PlacementVolume = App.SettingsType.Placement.BottomRight
                    Case "radbtnVolumePlacementBottomCenterRight" : App.Settings.PlacementVolume = App.SettingsType.Placement.BottomCenterRight
                    Case "radbtnVolumePlacementBottomCenter" : App.Settings.PlacementVolume = App.SettingsType.Placement.BottomCenter
                    Case "radbtnVolumePlacementBottomCenterLeft" : App.Settings.PlacementVolume = App.SettingsType.Placement.BottomCenterLeft
                    Case "radbtnVolumePlacementBottomLeft" : App.Settings.PlacementVolume = App.SettingsType.Placement.BottomLeft
                    Case "radbtnVolumePlacementLeftCenterBottom" : App.Settings.PlacementVolume = App.SettingsType.Placement.LeftCenterBottom
                    Case "radbtnVolumePlacementLeftCenter" : App.Settings.PlacementVolume = App.SettingsType.Placement.LeftCenter
                    Case "radbtnVolumePlacementLeftCenterTop" : App.Settings.PlacementVolume = App.SettingsType.Placement.LeftCenterTop
                    Case "radbtnVolumePlacementCenter" : App.Settings.PlacementVolume = App.SettingsType.Placement.Center
                    Case "radbtnVolumePlacementManual" : App.Settings.PlacementVolume = App.SettingsType.Placement.Manual
                End Select
                If App.FrmVolume.Visible Then : App.FrmVolume.SetPlacement()
                Else : App.FrmVolume.ShowInstant()
                End If
                App.Settings.SetSave()
            End If
        Next
    End Sub
    Private Sub RadbtnPlayerPlacementClick(sender As Object, e As EventArgs) Handles radbtnPlayerPlacementTopRight.Click, radbtnPlayerPlacementTopLeft.Click, radbtnPlayerPlacementTopCenterRight.Click, radbtnPlayerPlacementTopCenterLeft.Click, radbtnPlayerPlacementTopCenter.Click, radbtnPlayerPlacementRightCenterTop.Click, radbtnPlayerPlacementRightCenterBottom.Click, radbtnPlayerPlacementRightCenter.Click, radbtnPlayerPlacementManual.Click, radbtnPlayerPlacementLeftCenterTop.Click, radbtnPlayerPlacementLeftCenterBottom.Click, radbtnPlayerPlacementLeftCenter.Click, radbtnPlayerPlacementCenter.Click, radbtnPlayerPlacementBottomRight.Click, radbtnPlayerPlacementBottomLeft.Click, radbtnPlayerPlacementBottomCenterRight.Click, radbtnPlayerPlacementBottomCenterLeft.Click, radbtnPlayerPlacementBottomCenter.Click
        For Each c As Control In Me.grbxPlayerPlacement.Controls
            If sender Is c Then
                Select Case c.Name
                    Case "radbtnPlayerPlacementTopLeft" : My.Settings.PlacementPlayer = My.App.SettingsType.Placement.TopLeft
                    Case "radbtnPlayerPlacementTopCenterLeft" : My.Settings.PlacementPlayer = My.App.SettingsType.Placement.TopCenterLeft
                    Case "radbtnPlayerPlacementTopCenter" : My.Settings.PlacementPlayer = My.App.SettingsType.Placement.TopCenter
                    Case "radbtnPlayerPlacementTopCenterRight" : My.Settings.PlacementPlayer = My.App.SettingsType.Placement.TopCenterRight
                    Case "radbtnPlayerPlacementTopRight" : My.Settings.PlacementPlayer = My.App.SettingsType.Placement.TopRight
                    Case "radbtnPlayerPlacementRightCenterTop" : My.Settings.PlacementPlayer = My.App.SettingsType.Placement.RightCenterTop
                    Case "radbtnPlayerPlacementRightCenter" : My.Settings.PlacementPlayer = My.App.SettingsType.Placement.RightCenter
                    Case "radbtnPlayerPlacementRightCenterBottom" : My.Settings.PlacementPlayer = My.App.SettingsType.Placement.RightCenterBottom
                    Case "radbtnPlayerPlacementBottomRight" : My.Settings.PlacementPlayer = My.App.SettingsType.Placement.BottomRight
                    Case "radbtnPlayerPlacementBottomCenterRight" : My.Settings.PlacementPlayer = My.App.SettingsType.Placement.BottomCenterRight
                    Case "radbtnPlayerPlacementBottomCenter" : My.Settings.PlacementPlayer = My.App.SettingsType.Placement.BottomCenter
                    Case "radbtnPlayerPlacementBottomCenterLeft" : My.Settings.PlacementPlayer = My.App.SettingsType.Placement.BottomCenterLeft
                    Case "radbtnPlayerPlacementBottomLeft" : My.Settings.PlacementPlayer = My.App.SettingsType.Placement.BottomLeft
                    Case "radbtnPlayerPlacementLeftCenterBottom" : My.Settings.PlacementPlayer = My.App.SettingsType.Placement.LeftCenterBottom
                    Case "radbtnPlayerPlacementLeftCenter" : My.Settings.PlacementPlayer = My.App.SettingsType.Placement.LeftCenter
                    Case "radbtnPlayerPlacementLeftCenterTop" : My.Settings.PlacementPlayer = My.App.SettingsType.Placement.LeftCenterTop
                    Case "radbtnPlayerPlacementCenter" : My.Settings.PlacementPlayer = My.App.SettingsType.Placement.Center
                    Case "radbtnPlayerPlacementManual" : My.Settings.PlacementPlayer = My.App.SettingsType.Placement.Manual
                End Select
                If My.FrmPlayer.Visible Then : My.FrmPlayer.SetPlacement()
                Else : My.FrmPlayer.ShowInstant()
                End If
                My.Settings.SetSave()
            End If
        Next
    End Sub
    Private Sub CMSaveEarsAppsOpening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmSaveEarsApps.Opening
        If Me.lsbxSaveEarsApps.SelectedIndex >= 0 Then : Me.cmiSaveEarsAppsRemoveApp.Enabled = True
        Else : Me.cmiSaveEarsAppsRemoveApp.Enabled = False
        End If
    End Sub
    Private Sub BtnEnter(sender As Object, e As EventArgs) Handles tbarZoneRed.Enter, tbarZoneBlue.Enter, btnWAPath.Enter, btnViewerPath.Enter, btnSysVCPath.Enter, btnSaveEarsAppsRemove.Enter, btnSaveEarsAppsAdd.Enter, btnSave.Enter, btnRestore.Enter, btnPlayerOutputCurrentPath.Enter, btnHotKeysUndo.Enter, btnHotKeysSet.Enter, btnDefaults.Enter, btnClose.Enter, btnSMPath.Enter, btnVLCPath.Enter, btnMPCPath.Enter
        btnClose.Focus()
    End Sub
    Private Sub BtnViewerPathClick(sender As Object, e As EventArgs) Handles btnViewerPath.Click
        Dim fInfo As New IO.FileInfo(My.Settings.ViewerPath)
        Me.uiFileBrowserEXE.InitialDirectory = fInfo.DirectoryName
        Me.uiFileBrowserEXE.FileName = fInfo.Name
        Dim r As DialogResult = Me.uiFileBrowserEXE.ShowDialog(Me)
        If r = System.Windows.Forms.DialogResult.OK And Not String.IsNullOrEmpty(Me.uiFileBrowserEXE.FileName) Then
            Me.txbxViewerPath.Text = Me.uiFileBrowserEXE.FileName
            Me.txbxViewerPath.Focus()
            Me.Validate()
        End If
        fInfo = Nothing
    End Sub
    Private Sub BtnSysVCPathClick(sender As Object, e As EventArgs) Handles btnSysVCPath.Click
        Dim fInfo As New IO.FileInfo(My.Settings.SystemVolumeControlPath)
        Me.uiFileBrowserEXE.InitialDirectory = fInfo.DirectoryName
        Me.uiFileBrowserEXE.FileName = fInfo.Name
        Dim r As DialogResult = Me.uiFileBrowserEXE.ShowDialog(Me)
        If r = System.Windows.Forms.DialogResult.OK And Not String.IsNullOrEmpty(Me.uiFileBrowserEXE.FileName) Then
            Me.txbxSysVCPath.Text = Me.uiFileBrowserEXE.FileName
            Me.txbxSysVCPath.Focus()
            Me.Validate()
        End If
        fInfo = Nothing
    End Sub
    Private Sub BtnMPCPath_Click(sender As Object, e As EventArgs) Handles btnMPCPath.Click
        Dim fInfo As New IO.FileInfo(App.Settings.AppPathMPC)
        uiFileBrowserEXE.InitialDirectory = fInfo.DirectoryName
        uiFileBrowserEXE.FileName = fInfo.Name
        Dim r = uiFileBrowserEXE.ShowDialog(Me)
        If r = System.Windows.Forms.DialogResult.OK And Not String.IsNullOrEmpty(uiFileBrowserEXE.FileName) Then
            txbxMPCPath.Text = uiFileBrowserEXE.FileName
            txbxMPCPath.Focus()
            Validate()
        End If
    End Sub
    Private Sub BtnVLCPath_Click(sender As Object, e As EventArgs) Handles btnVLCPath.Click
        Dim fInfo As New IO.FileInfo(App.Settings.AppPathVLC)
        uiFileBrowserEXE.InitialDirectory = fInfo.DirectoryName
        uiFileBrowserEXE.FileName = fInfo.Name
        Dim r = uiFileBrowserEXE.ShowDialog(Me)
        If r = System.Windows.Forms.DialogResult.OK And Not String.IsNullOrEmpty(uiFileBrowserEXE.FileName) Then
            txbxVLCPath.Text = uiFileBrowserEXE.FileName
            txbxVLCPath.Focus()
            Validate()
        End If
    End Sub
    Private Sub BtnWAPathClick(sender As Object, e As EventArgs) Handles btnWAPath.Click
        Dim fInfo As New IO.FileInfo(App.Settings.AppPathWA)
        uiFileBrowserEXE.InitialDirectory = fInfo.DirectoryName
        uiFileBrowserEXE.FileName = fInfo.Name
        Dim r = uiFileBrowserEXE.ShowDialog(Me)
        If r = System.Windows.Forms.DialogResult.OK And Not String.IsNullOrEmpty(uiFileBrowserEXE.FileName) Then
            txbxWAPath.Text = uiFileBrowserEXE.FileName
            txbxWAPath.Focus()
            Validate()
        End If
    End Sub
    Private Sub BtnSMPathClick(sender As Object, e As EventArgs) Handles btnSMPath.Click
        Dim fInfo As New IO.FileInfo(App.Settings.AppPathSM)
        uiFileBrowserEXE.InitialDirectory = fInfo.DirectoryName
        uiFileBrowserEXE.FileName = fInfo.Name
        Dim r = uiFileBrowserEXE.ShowDialog(Me)
        If r = System.Windows.Forms.DialogResult.OK And Not String.IsNullOrEmpty(uiFileBrowserEXE.FileName) Then
            txbxSMPath.Text = uiFileBrowserEXE.FileName
            txbxSMPath.Focus()
            Validate()
        End If
    End Sub
    Private Sub BtnPlayerOutputCurrentPathClick(sender As Object, e As EventArgs) Handles btnPlayerOutputCurrentPath.Click
        Dim fInfo As New IO.FileInfo(My.Settings.PlayerOutputCurrentPath)
        Me.uiFileBrowserTXT.InitialDirectory = fInfo.DirectoryName
        Me.uiFileBrowserTXT.FileName = fInfo.Name
        Dim r As DialogResult = Me.uiFileBrowserTXT.ShowDialog(Me)
        If r = System.Windows.Forms.DialogResult.OK And Not String.IsNullOrEmpty(Me.uiFileBrowserTXT.FileName) Then
            Me.txbxPlayerOutputCurrentPath.Text = Me.uiFileBrowserTXT.FileName
            Me.txbxPlayerOutputCurrentPath.Focus()
            Me.Validate()
        End If
        fInfo = Nothing
    End Sub
    Private Sub BtnSaveEarsAppsAddClick(sender As Object, e As EventArgs) Handles cmiSaveEarsAppsAddApp.Click, btnSaveEarsAppsAdd.Click
        Dim r As DialogResult = Me.uiFileBrowserEXE.ShowDialog(Me)
        If r = System.Windows.Forms.DialogResult.OK And Not String.IsNullOrEmpty(Me.uiFileBrowserEXE.FileName) Then
            Dim s As String() = Me.uiFileBrowserEXE.FileName.Split(CChar("\"))
            If Not My.Settings.SaveEarsApps.Contains(s(s.Length - 1).ToUpper) Then
                My.Settings.SaveEarsApps.Add(s(s.Length - 1).ToUpper)
                My.Settings.SaveEarsApps.Sort()
                ShowSettings()
                My.Settings.SetSave()
            End If
        End If
    End Sub
    Private Sub BtnSaveEarsAppsRemoveClick(sender As Object, e As EventArgs) Handles cmiSaveEarsAppsRemoveApp.Click, btnSaveEarsAppsRemove.Click
        If Me.lsbxSaveEarsApps.SelectedIndex >= 0 Then
            My.Settings.SaveEarsApps.RemoveAt(Me.lsbxSaveEarsApps.SelectedIndex)
            ShowSettings()
            Me.btnSaveEarsAppsRemove.Enabled = False
            My.Settings.SetSave()
        End If
    End Sub
    Private Sub BtnHotKeyDisableEnter(sender As Object, e As EventArgs) Handles btnHotKeyVolumeInfoDisable.Enter, btnHotKeyViewerDisable.Enter, btnHotKeyPlayerInfoDisable.Enter
        If Me.btnHotKeysSet.Enabled Then : Me.btnHotKeysSet.Focus()
        Else : Me.btnClose.Focus()
        End If
    End Sub
    Private Sub BtnHotKeyDisableClick(sender As Object, e As EventArgs) Handles btnHotKeyVolumeInfoDisable.Click, btnHotKeyViewerDisable.Click, btnHotKeyPlayerInfoDisable.Click
        Dim senderTextBox As New TextBox
        Dim senderTag As New My.App.SettingsType.HotKey
        Select Case CType(sender, Button).Name
            Case Me.btnHotKeyVolumeInfoDisable.Name
                senderTextBox = Me.txbxHotKeyVolumeInfo
                senderTag = CType(Me.txbxHotKeyVolumeInfo.Tag, My.App.SettingsType.HotKey)
            Case Me.btnHotKeyPlayerInfoDisable.Name
                senderTextBox = Me.txbxHotKeyPlayerInfo
                senderTag = CType(Me.txbxHotKeyPlayerInfo.Tag, My.App.SettingsType.HotKey)
            Case Me.btnHotKeyViewerDisable.Name
                senderTextBox = Me.txbxHotKeyViewer
                senderTag = CType(Me.txbxHotKeyViewer.Tag, My.App.SettingsType.HotKey)
        End Select

        Dim newhotkey As New My.App.SettingsType.HotKey With {
            .Description = senderTag.Description,
            .WinID = senderTag.WinID,
            .Key = Keys.None,
            .KeyCode = 0,
            .KeyMod = 0}
        senderTextBox.Font = New Font(senderTextBox.Font, FontStyle.Regular)
        senderTextBox.ForeColor = Color.Maroon
        senderTextBox.Text = newhotkey.Key.ToString
        senderTextBox.Tag = newhotkey
        Me.btnHotKeysUndo.Enabled = True
        Me.btnHotKeysSet.Enabled = True
        Me.btnHotKeysSet.Focus()
    End Sub
    Private Sub BtnHotKeysUndoClick(sender As Object, e As EventArgs) Handles btnHotKeysUndo.Click
        ShowSettings()
    End Sub
    Private Sub BtnHotKeysSetClick(sender As Object, e As EventArgs) Handles btnHotKeysSet.Click
        Static NeedsReRegistered As Boolean
        NeedsReRegistered = False
        If Not CType(Me.txbxHotKeyVolumeInfo.Tag, My.App.SettingsType.HotKey).Key = My.Settings.HotKeyVolume.Key Then
            My.Settings.HotKeyVolume = CType(Me.txbxHotKeyVolumeInfo.Tag, My.App.SettingsType.HotKey)
            NeedsReRegistered = True
        End If
        If Not CType(Me.txbxHotKeyPlayerInfo.Tag, My.App.SettingsType.HotKey).Key = My.Settings.HotKeyPlayer.Key Then
            My.Settings.HotKeyPlayer = CType(Me.txbxHotKeyPlayerInfo.Tag, My.App.SettingsType.HotKey)
            NeedsReRegistered = True
        End If
        If Not CType(Me.txbxHotKeyViewer.Tag, My.App.SettingsType.HotKey).Key = My.Settings.HotKeyViewer.Key Then
            My.Settings.HotKeyViewer = CType(Me.txbxHotKeyViewer.Tag, My.App.SettingsType.HotKey)
            NeedsReRegistered = True
        End If
        If NeedsReRegistered Then
            My.App.RegisterHotKeys(False)
            My.App.GenerateHotKeyList()
            My.App.RegisterHotKeys(True)
            ShowSettings()
            My.Settings.SetSave()
        End If
    End Sub
    Private Sub BtnDisableLockKeysClick(sender As Object, e As EventArgs) Handles btnDisableLockKeys.Click
        If DisableLockKeys Then
            Dim RegKey As RegistryKey = My.Computer.Registry.LocalMachine.OpenSubKey(DisableLockKeysRegPath, True)
            RegKey.DeleteValue(DisableLockKeysRegValue)
            RegKey.Close()
            RegKey.Dispose()
            DisableLockKeys = False
            Me.btnDisableLockKeys.Checked = False
        Else
            Dim RegKey As RegistryKey = My.Computer.Registry.LocalMachine.OpenSubKey(DisableLockKeysRegPath, True)
            RegKey.SetValue(DisableLockKeysRegValue, DisableLockKeysRegData, RegistryValueKind.Binary)
            RegKey.Close()
            RegKey.Dispose()
            DisableLockKeys = True
            Me.btnDisableLockKeys.Checked = True
        End If
    End Sub
    Private Sub BtnCloseClick(sender As Object, e As EventArgs) Handles btnClose.Click
        My.App.CloseSettings()
    End Sub
    Private Sub BtnSaveClick(sender As Object, e As EventArgs) Handles btnSave.Click
#If DEBUG Then
        My.App.SaveSettings()
#Else
		If My.Settings.NeedsSaved Then My.App.SaveSettings()
#End If
    End Sub
    Private Sub BtnRestoreClick(sender As Object, e As EventArgs) Handles btnRestore.Click
        If App.Settings.HotKeysEnabled Then App.RegisterHotKeys(False)
#If DEBUG Then
        App.GetSettings()
#Else
		If App.Settings.NeedsSaved Then App.GetSettings()
#End If
        ShowSettings()
        If App.FrmVolume.Visible Then
            App.FrmVolume.SetPlacement()
            App.FrmVolume.UpdateVolume()
            Focus()
        Else
            App.FrmVolume.ShowInstant()
        End If
        If App.FrmPlayer IsNot Nothing Then
            If App.FrmPlayer.Visible Then
                App.FrmPlayer.SetPlacement()
            Else
                App.FrmPlayer.ShowInstant()
            End If
        End If
        If App.Settings.HotKeysEnabled Then App.RegisterHotKeys(True)
        ApplyTheme()
        App.Settings.ShowSave()
    End Sub
    Private Sub BtnDefaultsClick(sender As Object, e As EventArgs) Handles btnDefaults.Click
        If My.Settings.HotKeysEnabled Then My.App.RegisterHotKeys(False)
        My.App.GetDefaults()
        ShowSettings()
        If App.FrmVolume.Visible Then
            App.FrmVolume.SetPlacement()
            App.FrmVolume.UpdateVolume()
            Me.Focus()
        Else : App.FrmVolume.ShowInstant()
        End If
        If My.FrmPlayer IsNot Nothing Then
            If My.FrmPlayer.Visible Then : My.FrmPlayer.SetPlacement()
            Else : My.FrmPlayer.ShowInstant()
            End If
        End If
        If My.Settings.HotKeysEnabled Then My.App.RegisterHotKeys(True)
        ApplyTheme()
        My.Settings.SetSave()
    End Sub
    Private Sub BtnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        App.ShowHelp()
    End Sub
    Private Sub BtnLog_Click(sender As Object, e As EventArgs) Handles btnLog.Click
        App.ShowLog()
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

    ' METHODS
    Friend Sub ShowSave()
        If App.Settings.NeedsSaved Then
            btnSave.BackColor = Color.Firebrick
            TipSettingsEX.SetText(btnSave, "Settings Need Saved")
        Else
            btnSave.BackColor = Skye.UI.ThemeManager.CurrentTheme.ButtonBack
            TipSettingsEX.SetText(btnSave, "Save Settings")
        End If
    End Sub
    Friend Sub ShowSettings()
        Me.tbarZoneBlue.Value = My.Settings.vBlueZone
        Me.tbarZoneRed.Value = My.Settings.vRedZone
        Me.txbxZoneBlue.Text = My.Settings.vBlueZone.ToString
        Me.txbxZoneRed.Text = My.Settings.vRedZone.ToString
        Me.InvokePaint(Me, New PaintEventArgs(Me.CreateGraphics, Me.Bounds))
        Me.chbxShowMeters.Checked = My.Settings.ShowMeters
        Me.chbxAutoHideVolume.Checked = My.Settings.AutoHideVolume
        Me.chbxAutoHidePlayer.Checked = My.Settings.AutoHidePlayer
        Me.txbxAutoHideIntervalVolume.Text = My.Settings.AutoHideIntervalVolume.ToString
        Me.txbxAutoHideIntervalPlayer.Text = My.Settings.AutoHideIntervalPlayer.ToString
        Me.chbxAutoHideWithFadeVolume.Checked = My.Settings.AutoHideWithFadeVolume
        Me.chbxAutoHideWithFadePlayer.Checked = My.Settings.AutoHideWithFadePlayer
        Me.txbxAutoHideRateVolume.Text = My.Settings.AutoHideRateVolume.ToString
        Me.txbxAutoHideRatePlayer.Text = My.Settings.AutoHideRatePlayer.ToString
        UpdateAutoHide()
        Me.chbxAlwaysHideOnClickVolume.Checked = My.Settings.AlwaysHideOnClickVolume
        Me.chbxAutoShowPlayer.Checked = My.Settings.PlayerAutoShow
        Me.cobxUnMuteOnVolumeChange.SelectedIndex = My.Settings.UnMuteOnVolumeChange
        Me.txbxViewerName.Text = My.Settings.ViewerName
        Me.txbxViewerPath.Text = My.Settings.ViewerPath
        SetViewerPathError(False)
        Me.txbxSysVCPath.Text = My.Settings.SystemVolumeControlPath
        SetSysVCPathError(False)
        Me.txbxMPCPath.Text = My.Settings.AppPathMPC
        SetMPCPathError(False)
        Me.txbxVLCPath.Text = My.Settings.AppPathVLC
        SetVLCPathError(False)
        Me.txbxWAPath.Text = My.Settings.AppPathWA
        SetWAPathError(False)
        Me.txbxSMPath.Text = My.Settings.AppPathSM
        SetSMPathError(False)
        Me.chbxPlayerOutputCurrent.Checked = My.Settings.PlayerOutputCurrent
        Me.txbxPlayerOutputCurrentPath.Text = My.Settings.PlayerOutputCurrentPath
        SetPlayerOutputCurrentPathError(False)
        Me.txbxSaveEarsVolume.Text = My.Settings.vSaveEars.ToString
        Me.txbxSaveEarsInterval.Text = My.Settings.SaveEarsInterval.ToString
        Me.lsbxSaveEarsApps.Items.Clear()
        Me.lsbxSaveEarsApps.Items.AddRange(My.Settings.SaveEarsApps.ToArray)
        Me.chbxHotKeys.Checked = My.Settings.HotKeysEnabled
        If My.Settings.HotKeysEnabled Then : Me.grbxHotKeys.Enabled = True
        Else : Me.grbxHotKeys.Enabled = False
        End If
        Me.lblHotKeyVolumeInfo.Text = My.Settings.HotKeyVolume.Description
        Me.txbxHotKeyVolumeInfo.Text = My.Settings.HotKeyVolume.Key.ToString
        Me.txbxHotKeyVolumeInfo.Tag = My.Settings.HotKeyVolume
        Me.txbxHotKeyVolumeInfo.Font = New Font(Me.txbxHotKeyVolumeInfo.Font, FontStyle.Bold)
        Me.txbxHotKeyVolumeInfo.ForeColor = Color.Teal
        Me.lblHotKeyPlayerInfo.Text = My.Settings.HotKeyPlayer.Description
        Me.txbxHotKeyPlayerInfo.Text = My.Settings.HotKeyPlayer.Key.ToString
        Me.txbxHotKeyPlayerInfo.Tag = My.Settings.HotKeyPlayer
        Me.txbxHotKeyPlayerInfo.Font = New Font(Me.txbxHotKeyPlayerInfo.Font, FontStyle.Bold)
        Me.txbxHotKeyPlayerInfo.ForeColor = Color.Teal
        Me.lblHotKeyViewer.Text = My.Settings.HotKeyViewer.Description
        Me.txbxHotKeyViewer.Text = My.Settings.HotKeyViewer.Key.ToString
        Me.txbxHotKeyViewer.Tag = My.Settings.HotKeyViewer
        Me.txbxHotKeyViewer.Font = New Font(Me.txbxHotKeyViewer.Font, FontStyle.Bold)
        Me.txbxHotKeyViewer.ForeColor = Color.Teal
        Me.TipSettingsEX.SetText(Me.lblHotKeyViewer, My.Settings.ViewerName + " (" + My.Settings.ViewerPath + ")")
        Me.btnHotKeysUndo.Enabled = False
        Me.btnHotKeysSet.Enabled = False
        Select Case My.Settings.PlacementVolume
            Case My.App.SettingsType.Placement.TopLeft : Me.radbtnVolumePlacementTopLeft.Checked = True
            Case My.App.SettingsType.Placement.TopCenterLeft : Me.radbtnVolumePlacementTopCenterLeft.Checked = True
            Case My.App.SettingsType.Placement.TopCenter : Me.radbtnVolumePlacementTopCenter.Checked = True
            Case My.App.SettingsType.Placement.TopCenterRight : Me.radbtnVolumePlacementTopCenterRight.Checked = True
            Case My.App.SettingsType.Placement.TopRight : Me.radbtnVolumePlacementTopRight.Checked = True
            Case My.App.SettingsType.Placement.RightCenterTop : Me.radbtnVolumePlacementRightCenterTop.Checked = True
            Case My.App.SettingsType.Placement.RightCenter : Me.radbtnVolumePlacementRightCenter.Checked = True
            Case My.App.SettingsType.Placement.RightCenterBottom : Me.radbtnVolumePlacementRightCenterBottom.Checked = True
            Case My.App.SettingsType.Placement.BottomRight : Me.radbtnVolumePlacementBottomRight.Checked = True
            Case My.App.SettingsType.Placement.BottomCenterRight : Me.radbtnVolumePlacementBottomCenterRight.Checked = True
            Case My.App.SettingsType.Placement.BottomCenter : Me.radbtnVolumePlacementBottomCenter.Checked = True
            Case My.App.SettingsType.Placement.BottomCenterLeft : Me.radbtnVolumePlacementBottomCenterLeft.Checked = True
            Case My.App.SettingsType.Placement.BottomLeft : Me.radbtnVolumePlacementBottomLeft.Checked = True
            Case My.App.SettingsType.Placement.LeftCenterBottom : Me.radbtnVolumePlacementLeftCenterBottom.Checked = True
            Case My.App.SettingsType.Placement.LeftCenter : Me.radbtnVolumePlacementLeftCenter.Checked = True
            Case My.App.SettingsType.Placement.LeftCenterTop : Me.radbtnVolumePlacementLeftCenterTop.Checked = True
            Case My.App.SettingsType.Placement.Center : Me.radbtnVolumePlacementCenter.Checked = True
            Case My.App.SettingsType.Placement.Manual : Me.radbtnVolumePlacementManual.Checked = True
        End Select
        If My.FrmPlayer IsNot Nothing Then : Me.grbxPlayerPlacement.Enabled = True
        Else : Me.grbxPlayerPlacement.Enabled = False
        End If
        Select Case My.Settings.PlacementPlayer
            Case My.App.SettingsType.Placement.TopLeft : Me.radbtnPlayerPlacementTopLeft.Checked = True
            Case My.App.SettingsType.Placement.TopCenterLeft : Me.radbtnPlayerPlacementTopCenterLeft.Checked = True
            Case My.App.SettingsType.Placement.TopCenter : Me.radbtnPlayerPlacementTopCenter.Checked = True
            Case My.App.SettingsType.Placement.TopCenterRight : Me.radbtnPlayerPlacementTopCenterRight.Checked = True
            Case My.App.SettingsType.Placement.TopRight : Me.radbtnPlayerPlacementTopRight.Checked = True
            Case My.App.SettingsType.Placement.RightCenterTop : Me.radbtnPlayerPlacementRightCenterTop.Checked = True
            Case My.App.SettingsType.Placement.RightCenter : Me.radbtnPlayerPlacementRightCenter.Checked = True
            Case My.App.SettingsType.Placement.RightCenterBottom : Me.radbtnPlayerPlacementRightCenterBottom.Checked = True
            Case My.App.SettingsType.Placement.BottomRight : Me.radbtnPlayerPlacementBottomRight.Checked = True
            Case My.App.SettingsType.Placement.BottomCenterRight : Me.radbtnPlayerPlacementBottomCenterRight.Checked = True
            Case My.App.SettingsType.Placement.BottomCenter : Me.radbtnPlayerPlacementBottomCenter.Checked = True
            Case My.App.SettingsType.Placement.BottomCenterLeft : Me.radbtnPlayerPlacementBottomCenterLeft.Checked = True
            Case My.App.SettingsType.Placement.BottomLeft : Me.radbtnPlayerPlacementBottomLeft.Checked = True
            Case My.App.SettingsType.Placement.LeftCenterBottom : Me.radbtnPlayerPlacementLeftCenterBottom.Checked = True
            Case My.App.SettingsType.Placement.LeftCenter : Me.radbtnPlayerPlacementLeftCenter.Checked = True
            Case My.App.SettingsType.Placement.LeftCenterTop : Me.radbtnPlayerPlacementLeftCenterTop.Checked = True
            Case My.App.SettingsType.Placement.Center : Me.radbtnPlayerPlacementCenter.Checked = True
            Case My.App.SettingsType.Placement.Manual : Me.radbtnPlayerPlacementManual.Checked = True
        End Select
        Dim RegKey As RegistryKey = My.Computer.Registry.LocalMachine.OpenSubKey(DisableLockKeysRegPath, False)
        If RegKey Is Nothing Then
            DisableLockKeys = False
            Me.btnDisableLockKeys.Checked = False
        Else
            Try
                If RegKey.GetValue(DisableLockKeysRegValue) Is Nothing Then
                    DisableLockKeys = False
                    Me.btnDisableLockKeys.Checked = False
                Else
                    DisableLockKeys = True
                    Me.btnDisableLockKeys.Checked = True
                End If
            Catch ex As Exception
            Finally
                RegKey.Close()
                RegKey.Dispose()
            End Try
        End If
        ' Theme
        CoBoxTheme.Items.Clear()
        CoBoxTheme.Items.AddRange([Enum].GetNames(Of Theme)())
        CoBoxTheme.SelectedItem = App.Settings.SelectedTheme.ToString
        Select Case App.Settings.UseSystemTheme
            Case True
                ChBoxTheme.Checked = True
                CoBoxTheme.Enabled = False
            Case False
                ChBoxTheme.Checked = False
                CoBoxTheme.Enabled = True
        End Select
    End Sub
    Private Sub UpdateAutoHide()
        If My.Settings.AutoHideVolume Then
            Me.txbxAutoHideIntervalVolume.Enabled = True
            Me.chbxAutoHideWithFadeVolume.Enabled = True
            If My.Settings.AutoHideWithFadeVolume Then : Me.txbxAutoHideRateVolume.Enabled = True
            Else : Me.txbxAutoHideRateVolume.Enabled = False
            End If
        Else
            Me.txbxAutoHideIntervalVolume.Enabled = False
            Me.chbxAutoHideWithFadeVolume.Enabled = False
            Me.txbxAutoHideRateVolume.Enabled = False
        End If
        If My.Settings.AutoHidePlayer Then
            Me.txbxAutoHideIntervalPlayer.Enabled = True
            Me.chbxAutoHideWithFadePlayer.Enabled = True
            If My.Settings.AutoHideWithFadePlayer Then : Me.txbxAutoHideRatePlayer.Enabled = True
            Else : Me.txbxAutoHideRatePlayer.Enabled = False
            End If
        Else
            Me.txbxAutoHideIntervalPlayer.Enabled = False
            Me.chbxAutoHideWithFadePlayer.Enabled = False
            Me.txbxAutoHideRatePlayer.Enabled = False
        End If
    End Sub
    Private Sub SetViewerPathError(errorstate As Boolean)
        Select Case errorstate
            Case True
                Me.txbxViewerPath.ForeColor = Color.Firebrick
                Me.TipSettingsEX.SetText(Me.txbxViewerPath, "Invalid Path")
            Case False
                Me.txbxViewerPath.ResetForeColor()
                Me.TipSettingsEX.SetText(Me.txbxViewerPath, "Path To Viewer")
        End Select
    End Sub
    Private Sub SetSysVCPathError(errorstate As Boolean)
        Select Case errorstate
            Case True
                Me.txbxSysVCPath.ForeColor = Color.Firebrick
                Me.TipSettingsEX.SetText(Me.txbxSysVCPath, "Invalid Path")
            Case False
                Me.txbxSysVCPath.ResetForeColor()
                Me.TipSettingsEX.SetText(Me.txbxSysVCPath, "Path To System Volume Control")
        End Select
    End Sub
    Private Sub SetMPCPathError(errorstate As Boolean)
        Select Case errorstate
            Case True
                Me.txbxMPCPath.ForeColor = Color.Firebrick
                Me.TipSettingsEX.SetText(Me.txbxMPCPath, "Invalid Path")
            Case False
                Me.txbxMPCPath.ResetForeColor()
                Me.TipSettingsEX.SetText(Me.txbxMPCPath, "Path To MPC-HC")
        End Select
    End Sub
    Private Sub SetVLCPathError(errorstate As Boolean)
        Select Case errorstate
            Case True
                Me.txbxVLCPath.ForeColor = Color.Firebrick
                Me.TipSettingsEX.SetText(Me.txbxVLCPath, "Invalid Path")
            Case False
                Me.txbxVLCPath.ResetForeColor()
                Me.TipSettingsEX.SetText(Me.txbxVLCPath, "Path To VLC")
        End Select
    End Sub
    Private Sub SetWAPathError(errorstate As Boolean)
        Select Case errorstate
            Case True
                Me.txbxWAPath.ForeColor = Color.Firebrick
                Me.TipSettingsEX.SetText(Me.txbxWAPath, "Invalid Path")
            Case False
                Me.txbxWAPath.ResetForeColor()
                Me.TipSettingsEX.SetText(Me.txbxWAPath, "Path To Winamp")
        End Select
    End Sub
    Private Sub SetSMPathError(errorstate As Boolean)
        Select Case errorstate
            Case True
                Me.txbxSMPath.ForeColor = Color.Firebrick
                Me.TipSettingsEX.SetText(Me.txbxSMPath, "Invalid Path")
            Case False
                Me.txbxSMPath.ResetForeColor()
                Me.TipSettingsEX.SetText(Me.txbxSMPath, "Path To Skye Music")
        End Select
    End Sub
    Private Sub SetPlayerOutputCurrentPathError(errorstate As Boolean)
        Select Case errorstate
            Case True
                Me.txbxPlayerOutputCurrentPath.ForeColor = Color.Firebrick
                Me.TipSettingsEX.SetText(Me.txbxPlayerOutputCurrentPath, "Invalid Path")
            Case False
                Me.txbxPlayerOutputCurrentPath.ResetForeColor()
                Me.TipSettingsEX.SetText(Me.txbxPlayerOutputCurrentPath, "Current Selection Save Path")
        End Select
    End Sub
    Private Function CheckBlueZone(z As Integer) As Byte
        If z < 1 Then : Return 1
        ElseIf z > 99 Then
            z = 99
            If z >= My.Settings.vRedZone Then : Return CByte(My.Settings.vRedZone - 1)
            Else : Return CByte(z)
            End If
        ElseIf z >= My.Settings.vRedZone Then : Return CByte(My.Settings.vRedZone - 1)
        Else : Return CByte(z)
        End If
    End Function
    Private Function CheckRedZone(z As Integer) As Byte
        If z < 2 Then
            z = 2
            If z <= My.Settings.vBlueZone Then : Return CByte(My.Settings.vBlueZone + 1)
            Else : Return CByte(z)
            End If
        ElseIf z > 100 Then : Return 100
        ElseIf z <= My.Settings.vBlueZone Then : Return CByte(My.Settings.vBlueZone + 1)
        Else : Return CByte(z)
        End If
    End Function
    Private Function CheckHideIntervalVolume(interval As UShort) As UShort
        If interval < My.Settings.Defaults.AutoHideIntervalVolumeMin Then : Return My.Settings.Defaults.AutoHideIntervalVolumeMin
        ElseIf interval > My.Settings.Defaults.AutoHideIntervalVolumeMax Then : Return My.Settings.Defaults.AutoHideIntervalVolumeMax
        Else : Return interval
        End If
    End Function
    Private Function CheckHideIntervalPlayer(interval As UShort) As UShort
        If interval < My.Settings.Defaults.AutoHideIntervalPlayerMin Then : Return My.Settings.Defaults.AutoHideIntervalPlayerMin
        ElseIf interval > My.Settings.Defaults.AutoHideIntervalPlayerMax Then : Return My.Settings.Defaults.AutoHideIntervalPlayerMax
        Else : Return interval
        End If
    End Function
    Private Function CheckHideRateVolume(interval As UShort) As UShort
        If interval < My.Settings.Defaults.AutoHideRateVolumeMin Then : Return My.Settings.Defaults.AutoHideRateVolumeMin
        ElseIf interval > My.Settings.Defaults.AutoHideRateVolumeMax Then : Return My.Settings.Defaults.AutoHideRateVolumeMax
        Else : Return interval
        End If
    End Function
    Private Function CheckHideRatePlayer(interval As UShort) As UShort
        If interval < My.Settings.Defaults.AutoHideRatePlayerMin Then : Return My.Settings.Defaults.AutoHideRatePlayerMin
        ElseIf interval > My.Settings.Defaults.AutoHideRatePlayerMax Then : Return My.Settings.Defaults.AutoHideRatePlayerMax
        Else : Return interval
        End If
    End Function
    Private Function CheckSaveEarsVolume(v As Byte) As Byte
        If v < 0 Then : Return 0
        ElseIf v >= My.Settings.vBlueZone Then : Return CByte(My.Settings.vBlueZone - 1)
        Else : Return v
        End If
    End Function
    Private Function CheckSaveEarsInterval(interval As Integer) As Byte
        If interval < 0 Then : Return 0
        ElseIf interval > 180 Then : Return 180
        Else : Return CByte(interval)
        End If
    End Function
    Private Sub ApplyTheme()
        If App.Settings.UseSystemTheme Then
            App.ApplyTheme(App.GetWindowsTheme())
        Else
            App.ApplyTheme(App.Settings.SelectedTheme)
        End If
    End Sub

End Class
