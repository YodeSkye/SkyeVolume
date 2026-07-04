Partial Class Settings
Inherits System.Windows.Forms.Form
	Private components As System.ComponentModel.IContainer
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing Then
			If components IsNot Nothing Then
				components.Dispose
			End If
		End If
		MyBase.Dispose(disposing)
	End Sub
    Private Sub InitializeComponent
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Settings))
        btnClose = New Button()
        btnRestore = New Button()
        btnDefaults = New Button()
        btnHotKeyPlayerInfoDisable = New Button()
        btnHotKeyViewerDisable = New Button()
        btnHotKeysUndo = New Button()
        btnHotKeysSet = New Button()
        btnViewerPath = New Button()
        txbxViewerName = New TextBox()
        btnSaveEarsAppsAdd = New Button()
        btnSaveEarsAppsRemove = New Button()
        tbarZoneBlue = New TrackBar()
        tbarZoneRed = New TrackBar()
        txbxSaveEarsInterval = New TextBox()
        txbxSaveEarsVolume = New TextBox()
        txbxAutoHideIntervalPlayer = New TextBox()
        txbxAutoHideIntervalVolume = New TextBox()
        btnSysVCPath = New Button()
        btnWAPath = New Button()
        txbxAutoHideRateVolume = New TextBox()
        txbxAutoHideRatePlayer = New TextBox()
        btnPlayerOutputCurrentPath = New Button()
        btnSMPath = New Button()
        btnDisableLockKeys = New RadioButton()
        btnVLCPath = New Button()
        btnMPCPath = New Button()
        btnLog = New Button()
        btnHelp = New Button()
        btnHotKeyVolumeInfoDisable = New Button()
        txbxWAPath = New TextBox()
        txbxSysVCPath = New TextBox()
        txbxViewerPath = New TextBox()
        lblSaveEarsVolume = New Label()
        lblSaveEarsInterval = New Label()
        btnSave = New Button()
        grbxVolumePlacement = New GroupBox()
        radbtnVolumePlacementManual = New RadioButton()
        radbtnVolumePlacementCenter = New RadioButton()
        radbtnVolumePlacementLeftCenterTop = New RadioButton()
        radbtnVolumePlacementBottomLeft = New RadioButton()
        radbtnVolumePlacementRightCenterTop = New RadioButton()
        radbtnVolumePlacementRightCenterBottom = New RadioButton()
        radbtnVolumePlacementBottomCenterRight = New RadioButton()
        radbtnVolumePlacementBottomCenterLeft = New RadioButton()
        radbtnVolumePlacementBottomRight = New RadioButton()
        radbtnVolumePlacementLeftCenterBottom = New RadioButton()
        radbtnVolumePlacementBottomCenter = New RadioButton()
        radbtnVolumePlacementLeftCenter = New RadioButton()
        radbtnVolumePlacementRightCenter = New RadioButton()
        radbtnVolumePlacementTopCenterLeft = New RadioButton()
        radbtnVolumePlacementTopCenter = New RadioButton()
        radbtnVolumePlacementTopRight = New RadioButton()
        radbtnVolumePlacementTopCenterRight = New RadioButton()
        radbtnVolumePlacementTopLeft = New RadioButton()
        lblZones = New Label()
        grbxPlayerPlacement = New GroupBox()
        radbtnPlayerPlacementManual = New RadioButton()
        radbtnPlayerPlacementCenter = New RadioButton()
        radbtnPlayerPlacementLeftCenterTop = New RadioButton()
        radbtnPlayerPlacementBottomLeft = New RadioButton()
        radbtnPlayerPlacementRightCenterTop = New RadioButton()
        radbtnPlayerPlacementRightCenterBottom = New RadioButton()
        radbtnPlayerPlacementBottomCenterRight = New RadioButton()
        radbtnPlayerPlacementBottomCenterLeft = New RadioButton()
        radbtnPlayerPlacementBottomRight = New RadioButton()
        radbtnPlayerPlacementLeftCenterBottom = New RadioButton()
        radbtnPlayerPlacementBottomCenter = New RadioButton()
        radbtnPlayerPlacementLeftCenter = New RadioButton()
        radbtnPlayerPlacementTopCenterLeft = New RadioButton()
        radbtnPlayerPlacementTopCenter = New RadioButton()
        radbtnPlayerPlacementTopRight = New RadioButton()
        radbtnPlayerPlacementTopCenterRight = New RadioButton()
        radbtnPlayerPlacementRightCenter = New RadioButton()
        radbtnPlayerPlacementTopLeft = New RadioButton()
        txbxZoneBlue = New TextBox()
        txbxZoneRed = New TextBox()
        cobxUnMuteOnVolumeChange = New ComboBox()
        lblUnMuteOnVolumeChange = New Label()
        chbxAutoHideWithFadeVolume = New CheckBox()
        chbxAutoShowPlayer = New CheckBox()
        grbxHotKeys = New GroupBox()
        txbxHotKeyVolumeInfo = New TextBox()
        txbxHotKeyPlayerInfo = New TextBox()
        txbxHotKeyViewer = New TextBox()
        lblHotKeyViewer = New Label()
        lblHotKeyPlayerInfo = New Label()
        lblHotKeyVolumeInfo = New Label()
        chbxHotKeys = New CheckBox()
        lblViewer = New Label()
        lblSaveEarsApps = New Label()
        cmSaveEarsApps = New ContextMenuStrip(components)
        cmiSaveEarsAppsAddApp = New ToolStripMenuItem()
        cmiSaveEarsAppsRemoveApp = New ToolStripMenuItem()
        lsbxSaveEarsApps = New ListBox()
        lblSysVC = New Label()
        lblWA = New Label()
        chbxShowMeters = New CheckBox()
        chbxAutoHideWithFadePlayer = New CheckBox()
        chbxAutoHideVolume = New CheckBox()
        lblVolume = New Label()
        chbxAutoHidePlayer = New CheckBox()
        lblPlayer = New Label()
        chbxAlwaysHideOnClickVolume = New CheckBox()
        txbxPlayerOutputCurrentPath = New TextBox()
        lblPlayerOutputCurrentPath = New Label()
        chbxPlayerOutputCurrent = New CheckBox()
        txbxSMPath = New TextBox()
        lblSM = New Label()
        txbxVLCPath = New TextBox()
        lblVLC = New Label()
        txbxMPCPath = New TextBox()
        lblMPC = New Label()
        LblSaveEars = New Label()
        TipSettingsEX = New Skye.UI.ToolTipEX(components)
        CoBoxTheme = New Skye.UI.ComboBox()
        LblTheme = New Skye.UI.Label()
        ChBoxTheme = New CheckBox()
        CType(tbarZoneBlue, ComponentModel.ISupportInitialize).BeginInit()
        CType(tbarZoneRed, ComponentModel.ISupportInitialize).BeginInit()
        grbxVolumePlacement.SuspendLayout()
        grbxPlayerPlacement.SuspendLayout()
        grbxHotKeys.SuspendLayout()
        cmSaveEarsApps.SuspendLayout()
        SuspendLayout()
        ' 
        ' btnClose
        ' 
        btnClose.Anchor = AnchorStyles.Bottom
        btnClose.BackColor = Color.Transparent
        btnClose.FlatAppearance.BorderColor = SystemColors.Info
        btnClose.FlatAppearance.BorderSize = 2
        btnClose.FlatAppearance.MouseDownBackColor = Color.GhostWhite
        btnClose.FlatAppearance.MouseOverBackColor = SystemColors.Info
        btnClose.Image = My.Resources.Resources.ImageOK64
        TipSettingsEX.SetImage(btnClose, My.Resources.Resources.ImageOK64)
        btnClose.Location = New Point(592, 588)
        btnClose.Margin = New Padding(4)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(64, 64)
        btnClose.TabIndex = 1008
        TipSettingsEX.SetText(btnClose, "Close (Esc)")
        btnClose.TextAlign = ContentAlignment.MiddleRight
        btnClose.UseMnemonic = False
        btnClose.UseVisualStyleBackColor = False
        ' 
        ' btnRestore
        ' 
        btnRestore.Anchor = AnchorStyles.Bottom
        btnRestore.BackColor = Color.Transparent
        btnRestore.FlatAppearance.BorderColor = SystemColors.Info
        btnRestore.FlatAppearance.BorderSize = 2
        btnRestore.FlatAppearance.MouseDownBackColor = Color.GhostWhite
        btnRestore.FlatAppearance.MouseOverBackColor = SystemColors.Info
        btnRestore.Image = My.Resources.Resources.ImageRestore32
        TipSettingsEX.SetImage(btnRestore, My.Resources.Resources.ImageRestore32)
        btnRestore.Location = New Point(69, 596)
        btnRestore.Margin = New Padding(4)
        btnRestore.Name = "btnRestore"
        btnRestore.Size = New Size(48, 48)
        btnRestore.TabIndex = 1006
        TipSettingsEX.SetText(btnRestore, "Restore Settings To Original Values")
        btnRestore.TextAlign = ContentAlignment.MiddleRight
        btnRestore.UseVisualStyleBackColor = False
        ' 
        ' btnDefaults
        ' 
        btnDefaults.Anchor = AnchorStyles.Bottom
        btnDefaults.BackColor = Color.Transparent
        btnDefaults.FlatAppearance.BorderColor = SystemColors.Info
        btnDefaults.FlatAppearance.BorderSize = 2
        btnDefaults.FlatAppearance.MouseDownBackColor = Color.GhostWhite
        btnDefaults.FlatAppearance.MouseOverBackColor = SystemColors.Info
        btnDefaults.Image = My.Resources.Resources.ImageDefaults32
        TipSettingsEX.SetImage(btnDefaults, My.Resources.Resources.ImageDefaults32)
        btnDefaults.Location = New Point(125, 596)
        btnDefaults.Margin = New Padding(4)
        btnDefaults.Name = "btnDefaults"
        btnDefaults.Size = New Size(48, 48)
        btnDefaults.TabIndex = 1007
        TipSettingsEX.SetText(btnDefaults, "Return Settings To Default Values")
        btnDefaults.TextAlign = ContentAlignment.MiddleRight
        btnDefaults.UseVisualStyleBackColor = False
        ' 
        ' btnHotKeyPlayerInfoDisable
        ' 
        btnHotKeyPlayerInfoDisable.BackColor = Color.Transparent
        btnHotKeyPlayerInfoDisable.FlatAppearance.BorderColor = SystemColors.Info
        btnHotKeyPlayerInfoDisable.FlatAppearance.BorderSize = 0
        btnHotKeyPlayerInfoDisable.FlatAppearance.MouseDownBackColor = Color.GhostWhite
        btnHotKeyPlayerInfoDisable.FlatAppearance.MouseOverBackColor = SystemColors.Info
        btnHotKeyPlayerInfoDisable.Image = My.Resources.Resources.imageClear
        TipSettingsEX.SetImage(btnHotKeyPlayerInfoDisable, My.Resources.Resources.imageClear)
        btnHotKeyPlayerInfoDisable.Location = New Point(202, 87)
        btnHotKeyPlayerInfoDisable.Margin = New Padding(4)
        btnHotKeyPlayerInfoDisable.Name = "btnHotKeyPlayerInfoDisable"
        btnHotKeyPlayerInfoDisable.Size = New Size(32, 32)
        btnHotKeyPlayerInfoDisable.TabIndex = 0
        btnHotKeyPlayerInfoDisable.TabStop = False
        TipSettingsEX.SetText(btnHotKeyPlayerInfoDisable, "No HotKey")
        btnHotKeyPlayerInfoDisable.UseVisualStyleBackColor = False
        ' 
        ' btnHotKeyViewerDisable
        ' 
        btnHotKeyViewerDisable.BackColor = Color.Transparent
        btnHotKeyViewerDisable.FlatAppearance.BorderColor = SystemColors.Info
        btnHotKeyViewerDisable.FlatAppearance.BorderSize = 0
        btnHotKeyViewerDisable.FlatAppearance.MouseDownBackColor = Color.GhostWhite
        btnHotKeyViewerDisable.FlatAppearance.MouseOverBackColor = SystemColors.Info
        btnHotKeyViewerDisable.Image = My.Resources.Resources.imageClear
        TipSettingsEX.SetImage(btnHotKeyViewerDisable, My.Resources.Resources.imageClear)
        btnHotKeyViewerDisable.Location = New Point(202, 139)
        btnHotKeyViewerDisable.Margin = New Padding(4)
        btnHotKeyViewerDisable.Name = "btnHotKeyViewerDisable"
        btnHotKeyViewerDisable.Size = New Size(32, 32)
        btnHotKeyViewerDisable.TabIndex = 0
        btnHotKeyViewerDisable.TabStop = False
        TipSettingsEX.SetText(btnHotKeyViewerDisable, "No HotKey")
        btnHotKeyViewerDisable.UseVisualStyleBackColor = False
        ' 
        ' btnHotKeysUndo
        ' 
        btnHotKeysUndo.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnHotKeysUndo.BackColor = Color.Transparent
        btnHotKeysUndo.FlatAppearance.BorderColor = SystemColors.Info
        btnHotKeysUndo.FlatAppearance.MouseDownBackColor = Color.GhostWhite
        btnHotKeysUndo.FlatAppearance.MouseOverBackColor = SystemColors.Info
        btnHotKeysUndo.Image = My.Resources.Resources.ImageRestore32
        TipSettingsEX.SetImage(btnHotKeysUndo, My.Resources.Resources.ImageRestore32)
        btnHotKeysUndo.ImageAlign = ContentAlignment.MiddleLeft
        btnHotKeysUndo.Location = New Point(8, 183)
        btnHotKeysUndo.Margin = New Padding(4)
        btnHotKeysUndo.Name = "btnHotKeysUndo"
        btnHotKeysUndo.Size = New Size(135, 48)
        btnHotKeysUndo.TabIndex = 32
        btnHotKeysUndo.TabStop = False
        TipSettingsEX.SetText(btnHotKeysUndo, "Undo HotKey Changes")
        btnHotKeysUndo.Text = "Undo"
        btnHotKeysUndo.TextAlign = ContentAlignment.MiddleRight
        btnHotKeysUndo.UseVisualStyleBackColor = False
        ' 
        ' btnHotKeysSet
        ' 
        btnHotKeysSet.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnHotKeysSet.BackColor = Color.Transparent
        btnHotKeysSet.FlatAppearance.BorderColor = SystemColors.Info
        btnHotKeysSet.FlatAppearance.MouseDownBackColor = Color.GhostWhite
        btnHotKeysSet.FlatAppearance.MouseOverBackColor = SystemColors.Info
        btnHotKeysSet.Image = My.Resources.Resources.ImageSet32
        TipSettingsEX.SetImage(btnHotKeysSet, My.Resources.Resources.ImageSet32)
        btnHotKeysSet.ImageAlign = ContentAlignment.MiddleLeft
        btnHotKeysSet.Location = New Point(148, 183)
        btnHotKeysSet.Margin = New Padding(4)
        btnHotKeysSet.Name = "btnHotKeysSet"
        btnHotKeysSet.Size = New Size(81, 48)
        btnHotKeysSet.TabIndex = 34
        btnHotKeysSet.TabStop = False
        TipSettingsEX.SetText(btnHotKeysSet, "Activate HotKey Changes")
        btnHotKeysSet.Text = "Set"
        btnHotKeysSet.TextAlign = ContentAlignment.MiddleRight
        btnHotKeysSet.UseVisualStyleBackColor = False
        ' 
        ' btnViewerPath
        ' 
        btnViewerPath.BackColor = Color.Transparent
        btnViewerPath.FlatAppearance.BorderColor = SystemColors.Info
        btnViewerPath.FlatAppearance.BorderSize = 0
        btnViewerPath.FlatAppearance.MouseDownBackColor = Color.GhostWhite
        btnViewerPath.FlatAppearance.MouseOverBackColor = SystemColors.Info
        btnViewerPath.Image = My.Resources.Resources.imageSelect
        TipSettingsEX.SetImage(btnViewerPath, My.Resources.Resources.imageSelect)
        btnViewerPath.Location = New Point(1210, 64)
        btnViewerPath.Margin = New Padding(4)
        btnViewerPath.Name = "btnViewerPath"
        btnViewerPath.Size = New Size(32, 32)
        btnViewerPath.TabIndex = 154
        btnViewerPath.TabStop = False
        TipSettingsEX.SetText(btnViewerPath, "Select An App...")
        btnViewerPath.UseVisualStyleBackColor = False
        ' 
        ' txbxViewerName
        ' 
        txbxViewerName.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        TipSettingsEX.SetImage(txbxViewerName, Nothing)
        txbxViewerName.Location = New Point(824, 35)
        txbxViewerName.Margin = New Padding(4)
        txbxViewerName.Name = "txbxViewerName"
        txbxViewerName.ShortcutsEnabled = False
        txbxViewerName.Size = New Size(180, 29)
        txbxViewerName.TabIndex = 150
        TipSettingsEX.SetText(txbxViewerName, Nothing)
        txbxViewerName.Text = "ViewerName"
        ' 
        ' btnSaveEarsAppsAdd
        ' 
        btnSaveEarsAppsAdd.BackColor = Color.Transparent
        btnSaveEarsAppsAdd.FlatAppearance.BorderColor = SystemColors.Info
        btnSaveEarsAppsAdd.FlatAppearance.BorderSize = 0
        btnSaveEarsAppsAdd.FlatAppearance.MouseDownBackColor = Color.GhostWhite
        btnSaveEarsAppsAdd.FlatAppearance.MouseOverBackColor = SystemColors.Info
        btnSaveEarsAppsAdd.Image = My.Resources.Resources.imageSelect
        TipSettingsEX.SetImage(btnSaveEarsAppsAdd, My.Resources.Resources.imageSelect)
        btnSaveEarsAppsAdd.Location = New Point(725, 473)
        btnSaveEarsAppsAdd.Margin = New Padding(4)
        btnSaveEarsAppsAdd.Name = "btnSaveEarsAppsAdd"
        btnSaveEarsAppsAdd.Size = New Size(32, 32)
        btnSaveEarsAppsAdd.TabIndex = 196
        btnSaveEarsAppsAdd.TabStop = False
        TipSettingsEX.SetText(btnSaveEarsAppsAdd, "Add App")
        btnSaveEarsAppsAdd.UseVisualStyleBackColor = False
        ' 
        ' btnSaveEarsAppsRemove
        ' 
        btnSaveEarsAppsRemove.BackColor = Color.Transparent
        btnSaveEarsAppsRemove.Enabled = False
        btnSaveEarsAppsRemove.FlatAppearance.BorderColor = SystemColors.Info
        btnSaveEarsAppsRemove.FlatAppearance.BorderSize = 0
        btnSaveEarsAppsRemove.FlatAppearance.MouseDownBackColor = Color.GhostWhite
        btnSaveEarsAppsRemove.FlatAppearance.MouseOverBackColor = SystemColors.Info
        btnSaveEarsAppsRemove.Image = My.Resources.Resources.imageClear
        TipSettingsEX.SetImage(btnSaveEarsAppsRemove, My.Resources.Resources.imageClear)
        btnSaveEarsAppsRemove.Location = New Point(725, 531)
        btnSaveEarsAppsRemove.Margin = New Padding(4)
        btnSaveEarsAppsRemove.Name = "btnSaveEarsAppsRemove"
        btnSaveEarsAppsRemove.Size = New Size(32, 32)
        btnSaveEarsAppsRemove.TabIndex = 198
        btnSaveEarsAppsRemove.TabStop = False
        TipSettingsEX.SetText(btnSaveEarsAppsRemove, "Remove App")
        btnSaveEarsAppsRemove.UseVisualStyleBackColor = False
        ' 
        ' tbarZoneBlue
        ' 
        tbarZoneBlue.AutoSize = False
        TipSettingsEX.SetImage(tbarZoneBlue, Nothing)
        tbarZoneBlue.Location = New Point(18, 35)
        tbarZoneBlue.Margin = New Padding(4)
        tbarZoneBlue.Maximum = 100
        tbarZoneBlue.Name = "tbarZoneBlue"
        tbarZoneBlue.Size = New Size(242, 25)
        tbarZoneBlue.TabIndex = 5
        tbarZoneBlue.TabStop = False
        TipSettingsEX.SetText(tbarZoneBlue, "Start Of Blue Zone")
        tbarZoneBlue.TickFrequency = 5
        tbarZoneBlue.TickStyle = TickStyle.None
        ' 
        ' tbarZoneRed
        ' 
        tbarZoneRed.AutoSize = False
        TipSettingsEX.SetImage(tbarZoneRed, Nothing)
        tbarZoneRed.Location = New Point(18, 59)
        tbarZoneRed.Margin = New Padding(0)
        tbarZoneRed.Maximum = 100
        tbarZoneRed.Name = "tbarZoneRed"
        tbarZoneRed.Size = New Size(242, 25)
        tbarZoneRed.TabIndex = 15
        tbarZoneRed.TabStop = False
        TipSettingsEX.SetText(tbarZoneRed, "Start Of Red Zone")
        tbarZoneRed.TickFrequency = 5
        tbarZoneRed.TickStyle = TickStyle.None
        ' 
        ' txbxSaveEarsInterval
        ' 
        TipSettingsEX.SetImage(txbxSaveEarsInterval, Nothing)
        txbxSaveEarsInterval.Location = New Point(338, 530)
        txbxSaveEarsInterval.Margin = New Padding(4)
        txbxSaveEarsInterval.MaxLength = 3
        txbxSaveEarsInterval.Name = "txbxSaveEarsInterval"
        txbxSaveEarsInterval.ShortcutsEnabled = False
        txbxSaveEarsInterval.Size = New Size(40, 29)
        txbxSaveEarsInterval.TabIndex = 192
        TipSettingsEX.SetText(txbxSaveEarsInterval, "0-180, 0 = Disabled")
        txbxSaveEarsInterval.Text = "188"
        txbxSaveEarsInterval.TextAlign = HorizontalAlignment.Center
        ' 
        ' txbxSaveEarsVolume
        ' 
        TipSettingsEX.SetImage(txbxSaveEarsVolume, Nothing)
        txbxSaveEarsVolume.Location = New Point(338, 475)
        txbxSaveEarsVolume.Margin = New Padding(4)
        txbxSaveEarsVolume.MaxLength = 2
        txbxSaveEarsVolume.Name = "txbxSaveEarsVolume"
        txbxSaveEarsVolume.ShortcutsEnabled = False
        txbxSaveEarsVolume.Size = New Size(30, 29)
        txbxSaveEarsVolume.TabIndex = 190
        TipSettingsEX.SetText(txbxSaveEarsVolume, "Within Green Zone; Less Than Blue Zone")
        txbxSaveEarsVolume.Text = "88"
        txbxSaveEarsVolume.TextAlign = HorizontalAlignment.Center
        ' 
        ' txbxAutoHideIntervalPlayer
        ' 
        TipSettingsEX.SetImage(txbxAutoHideIntervalPlayer, Nothing)
        txbxAutoHideIntervalPlayer.Location = New Point(503, 305)
        txbxAutoHideIntervalPlayer.Margin = New Padding(4)
        txbxAutoHideIntervalPlayer.MaxLength = 3
        txbxAutoHideIntervalPlayer.Name = "txbxAutoHideIntervalPlayer"
        txbxAutoHideIntervalPlayer.ShortcutsEnabled = False
        txbxAutoHideIntervalPlayer.Size = New Size(40, 29)
        txbxAutoHideIntervalPlayer.TabIndex = 132
        TipSettingsEX.SetText(txbxAutoHideIntervalPlayer, "Hide Interval" & vbCrLf & "1 - 600 seconds")
        txbxAutoHideIntervalPlayer.Text = "888"
        txbxAutoHideIntervalPlayer.TextAlign = HorizontalAlignment.Center
        ' 
        ' txbxAutoHideIntervalVolume
        ' 
        TipSettingsEX.SetImage(txbxAutoHideIntervalVolume, Nothing)
        txbxAutoHideIntervalVolume.Location = New Point(502, 76)
        txbxAutoHideIntervalVolume.Margin = New Padding(4)
        txbxAutoHideIntervalVolume.MaxLength = 3
        txbxAutoHideIntervalVolume.Name = "txbxAutoHideIntervalVolume"
        txbxAutoHideIntervalVolume.ShortcutsEnabled = False
        txbxAutoHideIntervalVolume.Size = New Size(40, 29)
        txbxAutoHideIntervalVolume.TabIndex = 111
        TipSettingsEX.SetText(txbxAutoHideIntervalVolume, "Hide Interval" & vbCrLf & "1 - 600 seconds")
        txbxAutoHideIntervalVolume.Text = "888"
        txbxAutoHideIntervalVolume.TextAlign = HorizontalAlignment.Center
        ' 
        ' btnSysVCPath
        ' 
        btnSysVCPath.BackColor = Color.Transparent
        btnSysVCPath.FlatAppearance.BorderColor = SystemColors.Info
        btnSysVCPath.FlatAppearance.BorderSize = 0
        btnSysVCPath.FlatAppearance.MouseDownBackColor = Color.GhostWhite
        btnSysVCPath.FlatAppearance.MouseOverBackColor = SystemColors.Info
        btnSysVCPath.Image = My.Resources.Resources.imageSelect
        TipSettingsEX.SetImage(btnSysVCPath, My.Resources.Resources.imageSelect)
        btnSysVCPath.Location = New Point(1210, 135)
        btnSysVCPath.Margin = New Padding(4)
        btnSysVCPath.Name = "btnSysVCPath"
        btnSysVCPath.Size = New Size(32, 32)
        btnSysVCPath.TabIndex = 162
        btnSysVCPath.TabStop = False
        TipSettingsEX.SetText(btnSysVCPath, "Select An App...")
        btnSysVCPath.UseVisualStyleBackColor = False
        ' 
        ' btnWAPath
        ' 
        btnWAPath.BackColor = Color.Transparent
        btnWAPath.FlatAppearance.BorderColor = SystemColors.Info
        btnWAPath.FlatAppearance.BorderSize = 0
        btnWAPath.FlatAppearance.MouseDownBackColor = Color.GhostWhite
        btnWAPath.FlatAppearance.MouseOverBackColor = SystemColors.Info
        btnWAPath.Image = My.Resources.Resources.imageSelect
        TipSettingsEX.SetImage(btnWAPath, My.Resources.Resources.imageSelect)
        btnWAPath.Location = New Point(1210, 292)
        btnWAPath.Margin = New Padding(4)
        btnWAPath.Name = "btnWAPath"
        btnWAPath.Size = New Size(32, 32)
        btnWAPath.TabIndex = 172
        btnWAPath.TabStop = False
        TipSettingsEX.SetText(btnWAPath, "Select An App...")
        btnWAPath.UseVisualStyleBackColor = False
        ' 
        ' txbxAutoHideRateVolume
        ' 
        TipSettingsEX.SetImage(txbxAutoHideRateVolume, Nothing)
        txbxAutoHideRateVolume.Location = New Point(502, 106)
        txbxAutoHideRateVolume.Margin = New Padding(4)
        txbxAutoHideRateVolume.MaxLength = 4
        txbxAutoHideRateVolume.Name = "txbxAutoHideRateVolume"
        txbxAutoHideRateVolume.ShortcutsEnabled = False
        txbxAutoHideRateVolume.Size = New Size(40, 29)
        txbxAutoHideRateVolume.TabIndex = 121
        TipSettingsEX.SetText(txbxAutoHideRateVolume, "Hide Rate" & vbCrLf & "1(Slow) - 100(Fast)")
        txbxAutoHideRateVolume.Text = "888"
        txbxAutoHideRateVolume.TextAlign = HorizontalAlignment.Center
        ' 
        ' txbxAutoHideRatePlayer
        ' 
        TipSettingsEX.SetImage(txbxAutoHideRatePlayer, Nothing)
        txbxAutoHideRatePlayer.Location = New Point(503, 335)
        txbxAutoHideRatePlayer.Margin = New Padding(4)
        txbxAutoHideRatePlayer.MaxLength = 4
        txbxAutoHideRatePlayer.Name = "txbxAutoHideRatePlayer"
        txbxAutoHideRatePlayer.ShortcutsEnabled = False
        txbxAutoHideRatePlayer.Size = New Size(40, 29)
        txbxAutoHideRatePlayer.TabIndex = 137
        TipSettingsEX.SetText(txbxAutoHideRatePlayer, "Hide Rate" & vbCrLf & "1(Slow) - 100(Fast)")
        txbxAutoHideRatePlayer.Text = "888"
        txbxAutoHideRatePlayer.TextAlign = HorizontalAlignment.Center
        ' 
        ' btnPlayerOutputCurrentPath
        ' 
        btnPlayerOutputCurrentPath.BackColor = Color.Transparent
        btnPlayerOutputCurrentPath.FlatAppearance.BorderColor = SystemColors.Info
        btnPlayerOutputCurrentPath.FlatAppearance.BorderSize = 0
        btnPlayerOutputCurrentPath.FlatAppearance.MouseDownBackColor = Color.GhostWhite
        btnPlayerOutputCurrentPath.FlatAppearance.MouseOverBackColor = SystemColors.Info
        btnPlayerOutputCurrentPath.Image = My.Resources.Resources.imageSelect
        TipSettingsEX.SetImage(btnPlayerOutputCurrentPath, My.Resources.Resources.imageSelect)
        btnPlayerOutputCurrentPath.Location = New Point(1210, 421)
        btnPlayerOutputCurrentPath.Margin = New Padding(4)
        btnPlayerOutputCurrentPath.Name = "btnPlayerOutputCurrentPath"
        btnPlayerOutputCurrentPath.Size = New Size(32, 32)
        btnPlayerOutputCurrentPath.TabIndex = 1024
        btnPlayerOutputCurrentPath.TabStop = False
        TipSettingsEX.SetText(btnPlayerOutputCurrentPath, "Select An App...")
        btnPlayerOutputCurrentPath.UseVisualStyleBackColor = False
        ' 
        ' btnSMPath
        ' 
        btnSMPath.BackColor = Color.Transparent
        btnSMPath.FlatAppearance.BorderColor = SystemColors.Info
        btnSMPath.FlatAppearance.BorderSize = 0
        btnSMPath.FlatAppearance.MouseDownBackColor = Color.GhostWhite
        btnSMPath.FlatAppearance.MouseOverBackColor = SystemColors.Info
        btnSMPath.Image = My.Resources.Resources.imageSelect
        TipSettingsEX.SetImage(btnSMPath, My.Resources.Resources.imageSelect)
        btnSMPath.Location = New Point(1210, 344)
        btnSMPath.Margin = New Padding(4)
        btnSMPath.Name = "btnSMPath"
        btnSMPath.Size = New Size(32, 32)
        btnSMPath.TabIndex = 1027
        btnSMPath.TabStop = False
        TipSettingsEX.SetText(btnSMPath, "Select An App...")
        btnSMPath.UseVisualStyleBackColor = False
        ' 
        ' btnDisableLockKeys
        ' 
        btnDisableLockKeys.Appearance = Appearance.Button
        btnDisableLockKeys.FlatStyle = FlatStyle.Flat
        btnDisableLockKeys.Font = New Font("Segoe UI", 12F, FontStyle.Bold Or FontStyle.Underline, GraphicsUnit.Point, CByte(0))
        TipSettingsEX.SetImage(btnDisableLockKeys, Nothing)
        btnDisableLockKeys.Location = New Point(12, 509)
        btnDisableLockKeys.Margin = New Padding(4)
        btnDisableLockKeys.Name = "btnDisableLockKeys"
        btnDisableLockKeys.Size = New Size(238, 40)
        btnDisableLockKeys.TabIndex = 50
        TipSettingsEX.SetText(btnDisableLockKeys, "Disables both CapsLock and NumLock keys." & vbCrLf & "App must be run as Administrator.")
        btnDisableLockKeys.Text = "Disable Lock Keys"
        btnDisableLockKeys.TextAlign = ContentAlignment.MiddleCenter
        btnDisableLockKeys.UseVisualStyleBackColor = True
        ' 
        ' btnVLCPath
        ' 
        btnVLCPath.BackColor = Color.Transparent
        btnVLCPath.FlatAppearance.BorderColor = SystemColors.Info
        btnVLCPath.FlatAppearance.BorderSize = 0
        btnVLCPath.FlatAppearance.MouseDownBackColor = Color.GhostWhite
        btnVLCPath.FlatAppearance.MouseOverBackColor = SystemColors.Info
        btnVLCPath.Image = My.Resources.Resources.imageSelect
        TipSettingsEX.SetImage(btnVLCPath, My.Resources.Resources.imageSelect)
        btnVLCPath.Location = New Point(1209, 239)
        btnVLCPath.Margin = New Padding(4)
        btnVLCPath.Name = "btnVLCPath"
        btnVLCPath.Size = New Size(32, 32)
        btnVLCPath.TabIndex = 167
        btnVLCPath.TabStop = False
        TipSettingsEX.SetText(btnVLCPath, "Select An App...")
        btnVLCPath.UseVisualStyleBackColor = False
        ' 
        ' btnMPCPath
        ' 
        btnMPCPath.BackColor = Color.Transparent
        btnMPCPath.FlatAppearance.BorderColor = SystemColors.Info
        btnMPCPath.FlatAppearance.BorderSize = 0
        btnMPCPath.FlatAppearance.MouseDownBackColor = Color.GhostWhite
        btnMPCPath.FlatAppearance.MouseOverBackColor = SystemColors.Info
        btnMPCPath.Image = My.Resources.Resources.imageSelect
        TipSettingsEX.SetImage(btnMPCPath, My.Resources.Resources.imageSelect)
        btnMPCPath.Location = New Point(1209, 188)
        btnMPCPath.Margin = New Padding(4)
        btnMPCPath.Name = "btnMPCPath"
        btnMPCPath.Size = New Size(32, 32)
        btnMPCPath.TabIndex = 164
        btnMPCPath.TabStop = False
        TipSettingsEX.SetText(btnMPCPath, "Select An App...")
        btnMPCPath.UseVisualStyleBackColor = False
        ' 
        ' btnLog
        ' 
        btnLog.Anchor = AnchorStyles.Bottom
        btnLog.BackColor = Color.Transparent
        btnLog.FlatAppearance.BorderColor = SystemColors.Info
        btnLog.FlatAppearance.BorderSize = 2
        btnLog.FlatAppearance.MouseDownBackColor = Color.GhostWhite
        btnLog.FlatAppearance.MouseOverBackColor = SystemColors.Info
        btnLog.Image = My.Resources.Resources.ImageLog32
        TipSettingsEX.SetImage(btnLog, My.Resources.Resources.ImageLog32)
        btnLog.Location = New Point(1187, 596)
        btnLog.Margin = New Padding(4)
        btnLog.Name = "btnLog"
        btnLog.Size = New Size(48, 48)
        btnLog.TabIndex = 1010
        TipSettingsEX.SetText(btnLog, "Show Log")
        btnLog.TextAlign = ContentAlignment.MiddleRight
        btnLog.UseMnemonic = False
        btnLog.UseVisualStyleBackColor = False
        ' 
        ' btnHelp
        ' 
        btnHelp.Anchor = AnchorStyles.Bottom
        btnHelp.BackColor = Color.Transparent
        btnHelp.FlatAppearance.BorderColor = SystemColors.Info
        btnHelp.FlatAppearance.BorderSize = 2
        btnHelp.FlatAppearance.MouseDownBackColor = Color.GhostWhite
        btnHelp.FlatAppearance.MouseOverBackColor = SystemColors.Info
        btnHelp.Image = My.Resources.Resources.ImageHelp32
        TipSettingsEX.SetImage(btnHelp, My.Resources.Resources.ImageHelp32)
        btnHelp.Location = New Point(1131, 596)
        btnHelp.Margin = New Padding(4)
        btnHelp.Name = "btnHelp"
        btnHelp.Size = New Size(48, 48)
        btnHelp.TabIndex = 1009
        TipSettingsEX.SetText(btnHelp, "Show Help")
        btnHelp.TextAlign = ContentAlignment.MiddleRight
        btnHelp.UseMnemonic = False
        btnHelp.UseVisualStyleBackColor = False
        ' 
        ' btnHotKeyVolumeInfoDisable
        ' 
        btnHotKeyVolumeInfoDisable.BackColor = Color.Transparent
        btnHotKeyVolumeInfoDisable.FlatAppearance.BorderColor = SystemColors.Info
        btnHotKeyVolumeInfoDisable.FlatAppearance.BorderSize = 0
        btnHotKeyVolumeInfoDisable.FlatAppearance.MouseDownBackColor = Color.GhostWhite
        btnHotKeyVolumeInfoDisable.FlatAppearance.MouseOverBackColor = SystemColors.Info
        btnHotKeyVolumeInfoDisable.Image = My.Resources.Resources.imageClear
        TipSettingsEX.SetImage(btnHotKeyVolumeInfoDisable, My.Resources.Resources.imageClear)
        btnHotKeyVolumeInfoDisable.Location = New Point(202, 35)
        btnHotKeyVolumeInfoDisable.Margin = New Padding(4)
        btnHotKeyVolumeInfoDisable.Name = "btnHotKeyVolumeInfoDisable"
        btnHotKeyVolumeInfoDisable.Size = New Size(32, 32)
        btnHotKeyVolumeInfoDisable.TabIndex = 0
        btnHotKeyVolumeInfoDisable.TabStop = False
        TipSettingsEX.SetText(btnHotKeyVolumeInfoDisable, "No HotKey")
        btnHotKeyVolumeInfoDisable.UseVisualStyleBackColor = False
        ' 
        ' txbxWAPath
        ' 
        TipSettingsEX.SetImage(txbxWAPath, Nothing)
        txbxWAPath.Location = New Point(824, 293)
        txbxWAPath.Margin = New Padding(4)
        txbxWAPath.Name = "txbxWAPath"
        txbxWAPath.ShortcutsEnabled = False
        txbxWAPath.Size = New Size(386, 29)
        txbxWAPath.TabIndex = 170
        TipSettingsEX.SetText(txbxWAPath, "Path")
        txbxWAPath.Text = "WAPath"
        ' 
        ' txbxSysVCPath
        ' 
        TipSettingsEX.SetImage(txbxSysVCPath, Nothing)
        txbxSysVCPath.Location = New Point(824, 136)
        txbxSysVCPath.Margin = New Padding(4)
        txbxSysVCPath.Name = "txbxSysVCPath"
        txbxSysVCPath.ShortcutsEnabled = False
        txbxSysVCPath.Size = New Size(386, 29)
        txbxSysVCPath.TabIndex = 160
        TipSettingsEX.SetText(txbxSysVCPath, "Path")
        txbxSysVCPath.Text = "SysVCPath"
        ' 
        ' txbxViewerPath
        ' 
        TipSettingsEX.SetImage(txbxViewerPath, Nothing)
        txbxViewerPath.Location = New Point(824, 65)
        txbxViewerPath.Margin = New Padding(4)
        txbxViewerPath.Name = "txbxViewerPath"
        txbxViewerPath.ShortcutsEnabled = False
        txbxViewerPath.Size = New Size(386, 29)
        txbxViewerPath.TabIndex = 152
        TipSettingsEX.SetText(txbxViewerPath, "Path")
        txbxViewerPath.Text = "ViewerPath"
        ' 
        ' lblSaveEarsVolume
        ' 
        lblSaveEarsVolume.Font = New Font("Segoe UI", 12F)
        TipSettingsEX.SetImage(lblSaveEarsVolume, Nothing)
        lblSaveEarsVolume.Location = New Point(336, 450)
        lblSaveEarsVolume.Margin = New Padding(4, 0, 4, 0)
        lblSaveEarsVolume.Name = "lblSaveEarsVolume"
        lblSaveEarsVolume.Size = New Size(161, 21)
        lblSaveEarsVolume.TabIndex = 0
        lblSaveEarsVolume.Text = "Save Ears Volume"
        TipSettingsEX.SetText(lblSaveEarsVolume, Nothing)
        lblSaveEarsVolume.TextAlign = ContentAlignment.BottomLeft
        ' 
        ' lblSaveEarsInterval
        ' 
        lblSaveEarsInterval.Font = New Font("Segoe UI", 12F)
        TipSettingsEX.SetImage(lblSaveEarsInterval, Nothing)
        lblSaveEarsInterval.Location = New Point(336, 506)
        lblSaveEarsInterval.Margin = New Padding(4, 0, 4, 0)
        lblSaveEarsInterval.Name = "lblSaveEarsInterval"
        lblSaveEarsInterval.Size = New Size(161, 21)
        lblSaveEarsInterval.TabIndex = 0
        lblSaveEarsInterval.Text = "Save Ears Interval"
        TipSettingsEX.SetText(lblSaveEarsInterval, Nothing)
        lblSaveEarsInterval.TextAlign = ContentAlignment.BottomLeft
        ' 
        ' btnSave
        ' 
        btnSave.Anchor = AnchorStyles.Bottom
        btnSave.BackColor = Color.Transparent
        btnSave.FlatAppearance.BorderColor = SystemColors.Info
        btnSave.FlatAppearance.BorderSize = 2
        btnSave.FlatAppearance.MouseDownBackColor = Color.GhostWhite
        btnSave.FlatAppearance.MouseOverBackColor = SystemColors.Info
        btnSave.Image = My.Resources.Resources.ImageSave32
        TipSettingsEX.SetImage(btnSave, My.Resources.Resources.ImageSave32)
        btnSave.Location = New Point(13, 596)
        btnSave.Margin = New Padding(4)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(48, 48)
        btnSave.TabIndex = 1005
        TipSettingsEX.SetText(btnSave, "Save")
        btnSave.TextAlign = ContentAlignment.MiddleRight
        btnSave.UseVisualStyleBackColor = False
        ' 
        ' grbxVolumePlacement
        ' 
        grbxVolumePlacement.Controls.Add(radbtnVolumePlacementManual)
        grbxVolumePlacement.Controls.Add(radbtnVolumePlacementCenter)
        grbxVolumePlacement.Controls.Add(radbtnVolumePlacementLeftCenterTop)
        grbxVolumePlacement.Controls.Add(radbtnVolumePlacementBottomLeft)
        grbxVolumePlacement.Controls.Add(radbtnVolumePlacementRightCenterTop)
        grbxVolumePlacement.Controls.Add(radbtnVolumePlacementRightCenterBottom)
        grbxVolumePlacement.Controls.Add(radbtnVolumePlacementBottomCenterRight)
        grbxVolumePlacement.Controls.Add(radbtnVolumePlacementBottomCenterLeft)
        grbxVolumePlacement.Controls.Add(radbtnVolumePlacementBottomRight)
        grbxVolumePlacement.Controls.Add(radbtnVolumePlacementLeftCenterBottom)
        grbxVolumePlacement.Controls.Add(radbtnVolumePlacementBottomCenter)
        grbxVolumePlacement.Controls.Add(radbtnVolumePlacementLeftCenter)
        grbxVolumePlacement.Controls.Add(radbtnVolumePlacementRightCenter)
        grbxVolumePlacement.Controls.Add(radbtnVolumePlacementTopCenterLeft)
        grbxVolumePlacement.Controls.Add(radbtnVolumePlacementTopCenter)
        grbxVolumePlacement.Controls.Add(radbtnVolumePlacementTopRight)
        grbxVolumePlacement.Controls.Add(radbtnVolumePlacementTopCenterRight)
        grbxVolumePlacement.Controls.Add(radbtnVolumePlacementTopLeft)
        grbxVolumePlacement.Cursor = Cursors.Hand
        grbxVolumePlacement.Font = New Font("Segoe UI", 12F, FontStyle.Bold Or FontStyle.Underline, GraphicsUnit.Point, CByte(0))
        grbxVolumePlacement.ForeColor = SystemColors.ControlText
        TipSettingsEX.SetImage(grbxVolumePlacement, Nothing)
        grbxVolumePlacement.Location = New Point(553, 8)
        grbxVolumePlacement.Margin = New Padding(4)
        grbxVolumePlacement.Name = "grbxVolumePlacement"
        grbxVolumePlacement.Padding = New Padding(4)
        grbxVolumePlacement.Size = New Size(216, 194)
        grbxVolumePlacement.TabIndex = 500
        grbxVolumePlacement.TabStop = False
        TipSettingsEX.SetText(grbxVolumePlacement, Nothing)
        ' 
        ' radbtnVolumePlacementManual
        ' 
        radbtnVolumePlacementManual.CheckAlign = ContentAlignment.BottomCenter
        radbtnVolumePlacementManual.Cursor = Cursors.Hand
        radbtnVolumePlacementManual.Font = New Font("Segoe UI", 12F)
        TipSettingsEX.SetImage(radbtnVolumePlacementManual, Nothing)
        radbtnVolumePlacementManual.Location = New Point(68, 100)
        radbtnVolumePlacementManual.Margin = New Padding(4)
        radbtnVolumePlacementManual.Name = "radbtnVolumePlacementManual"
        radbtnVolumePlacementManual.Size = New Size(84, 40)
        radbtnVolumePlacementManual.TabIndex = 0
        TipSettingsEX.SetText(radbtnVolumePlacementManual, Nothing)
        radbtnVolumePlacementManual.Text = "Manual"
        radbtnVolumePlacementManual.TextAlign = ContentAlignment.MiddleCenter
        radbtnVolumePlacementManual.UseVisualStyleBackColor = True
        ' 
        ' radbtnVolumePlacementCenter
        ' 
        radbtnVolumePlacementCenter.CheckAlign = ContentAlignment.BottomCenter
        radbtnVolumePlacementCenter.Cursor = Cursors.Hand
        radbtnVolumePlacementCenter.Font = New Font("Segoe UI", 12F)
        TipSettingsEX.SetImage(radbtnVolumePlacementCenter, Nothing)
        radbtnVolumePlacementCenter.Location = New Point(68, 53)
        radbtnVolumePlacementCenter.Margin = New Padding(4)
        radbtnVolumePlacementCenter.Name = "radbtnVolumePlacementCenter"
        radbtnVolumePlacementCenter.Size = New Size(84, 40)
        radbtnVolumePlacementCenter.TabIndex = 17
        TipSettingsEX.SetText(radbtnVolumePlacementCenter, Nothing)
        radbtnVolumePlacementCenter.Text = "Center"
        radbtnVolumePlacementCenter.TextAlign = ContentAlignment.MiddleCenter
        radbtnVolumePlacementCenter.UseVisualStyleBackColor = True
        ' 
        ' radbtnVolumePlacementLeftCenterTop
        ' 
        radbtnVolumePlacementLeftCenterTop.CheckAlign = ContentAlignment.MiddleCenter
        radbtnVolumePlacementLeftCenterTop.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TipSettingsEX.SetImage(radbtnVolumePlacementLeftCenterTop, Nothing)
        radbtnVolumePlacementLeftCenterTop.Location = New Point(10, 51)
        radbtnVolumePlacementLeftCenterTop.Margin = New Padding(4)
        radbtnVolumePlacementLeftCenterTop.Name = "radbtnVolumePlacementLeftCenterTop"
        radbtnVolumePlacementLeftCenterTop.Size = New Size(22, 30)
        radbtnVolumePlacementLeftCenterTop.TabIndex = 16
        TipSettingsEX.SetText(radbtnVolumePlacementLeftCenterTop, Nothing)
        radbtnVolumePlacementLeftCenterTop.Text = "  "
        radbtnVolumePlacementLeftCenterTop.UseVisualStyleBackColor = True
        ' 
        ' radbtnVolumePlacementBottomLeft
        ' 
        radbtnVolumePlacementBottomLeft.CheckAlign = ContentAlignment.MiddleCenter
        radbtnVolumePlacementBottomLeft.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TipSettingsEX.SetImage(radbtnVolumePlacementBottomLeft, Nothing)
        radbtnVolumePlacementBottomLeft.Location = New Point(10, 159)
        radbtnVolumePlacementBottomLeft.Margin = New Padding(4)
        radbtnVolumePlacementBottomLeft.Name = "radbtnVolumePlacementBottomLeft"
        radbtnVolumePlacementBottomLeft.Size = New Size(22, 30)
        radbtnVolumePlacementBottomLeft.TabIndex = 13
        TipSettingsEX.SetText(radbtnVolumePlacementBottomLeft, Nothing)
        radbtnVolumePlacementBottomLeft.Text = "  "
        radbtnVolumePlacementBottomLeft.UseVisualStyleBackColor = True
        ' 
        ' radbtnVolumePlacementRightCenterTop
        ' 
        radbtnVolumePlacementRightCenterTop.CheckAlign = ContentAlignment.MiddleCenter
        radbtnVolumePlacementRightCenterTop.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TipSettingsEX.SetImage(radbtnVolumePlacementRightCenterTop, Nothing)
        radbtnVolumePlacementRightCenterTop.Location = New Point(186, 51)
        radbtnVolumePlacementRightCenterTop.Margin = New Padding(4)
        radbtnVolumePlacementRightCenterTop.Name = "radbtnVolumePlacementRightCenterTop"
        radbtnVolumePlacementRightCenterTop.Size = New Size(22, 30)
        radbtnVolumePlacementRightCenterTop.TabIndex = 6
        TipSettingsEX.SetText(radbtnVolumePlacementRightCenterTop, Nothing)
        radbtnVolumePlacementRightCenterTop.Text = "  "
        radbtnVolumePlacementRightCenterTop.UseVisualStyleBackColor = True
        ' 
        ' radbtnVolumePlacementRightCenterBottom
        ' 
        radbtnVolumePlacementRightCenterBottom.CheckAlign = ContentAlignment.MiddleCenter
        radbtnVolumePlacementRightCenterBottom.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TipSettingsEX.SetImage(radbtnVolumePlacementRightCenterBottom, Nothing)
        radbtnVolumePlacementRightCenterBottom.Location = New Point(186, 123)
        radbtnVolumePlacementRightCenterBottom.Margin = New Padding(4)
        radbtnVolumePlacementRightCenterBottom.Name = "radbtnVolumePlacementRightCenterBottom"
        radbtnVolumePlacementRightCenterBottom.Size = New Size(22, 30)
        radbtnVolumePlacementRightCenterBottom.TabIndex = 8
        TipSettingsEX.SetText(radbtnVolumePlacementRightCenterBottom, Nothing)
        radbtnVolumePlacementRightCenterBottom.Text = "  "
        radbtnVolumePlacementRightCenterBottom.UseVisualStyleBackColor = True
        ' 
        ' radbtnVolumePlacementBottomCenterRight
        ' 
        radbtnVolumePlacementBottomCenterRight.CheckAlign = ContentAlignment.MiddleCenter
        radbtnVolumePlacementBottomCenterRight.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TipSettingsEX.SetImage(radbtnVolumePlacementBottomCenterRight, Nothing)
        radbtnVolumePlacementBottomCenterRight.Location = New Point(149, 159)
        radbtnVolumePlacementBottomCenterRight.Margin = New Padding(4)
        radbtnVolumePlacementBottomCenterRight.Name = "radbtnVolumePlacementBottomCenterRight"
        radbtnVolumePlacementBottomCenterRight.Size = New Size(22, 30)
        radbtnVolumePlacementBottomCenterRight.TabIndex = 10
        TipSettingsEX.SetText(radbtnVolumePlacementBottomCenterRight, Nothing)
        radbtnVolumePlacementBottomCenterRight.Text = "  "
        radbtnVolumePlacementBottomCenterRight.UseVisualStyleBackColor = True
        ' 
        ' radbtnVolumePlacementBottomCenterLeft
        ' 
        radbtnVolumePlacementBottomCenterLeft.CheckAlign = ContentAlignment.MiddleCenter
        radbtnVolumePlacementBottomCenterLeft.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TipSettingsEX.SetImage(radbtnVolumePlacementBottomCenterLeft, Nothing)
        radbtnVolumePlacementBottomCenterLeft.Location = New Point(54, 159)
        radbtnVolumePlacementBottomCenterLeft.Margin = New Padding(4)
        radbtnVolumePlacementBottomCenterLeft.Name = "radbtnVolumePlacementBottomCenterLeft"
        radbtnVolumePlacementBottomCenterLeft.Size = New Size(22, 30)
        radbtnVolumePlacementBottomCenterLeft.TabIndex = 12
        TipSettingsEX.SetText(radbtnVolumePlacementBottomCenterLeft, Nothing)
        radbtnVolumePlacementBottomCenterLeft.Text = "  "
        radbtnVolumePlacementBottomCenterLeft.UseVisualStyleBackColor = True
        ' 
        ' radbtnVolumePlacementBottomRight
        ' 
        radbtnVolumePlacementBottomRight.CheckAlign = ContentAlignment.MiddleCenter
        radbtnVolumePlacementBottomRight.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TipSettingsEX.SetImage(radbtnVolumePlacementBottomRight, Nothing)
        radbtnVolumePlacementBottomRight.Location = New Point(186, 159)
        radbtnVolumePlacementBottomRight.Margin = New Padding(4)
        radbtnVolumePlacementBottomRight.Name = "radbtnVolumePlacementBottomRight"
        radbtnVolumePlacementBottomRight.Size = New Size(22, 30)
        radbtnVolumePlacementBottomRight.TabIndex = 8
        TipSettingsEX.SetText(radbtnVolumePlacementBottomRight, Nothing)
        radbtnVolumePlacementBottomRight.Text = "  "
        radbtnVolumePlacementBottomRight.UseVisualStyleBackColor = True
        ' 
        ' radbtnVolumePlacementLeftCenterBottom
        ' 
        radbtnVolumePlacementLeftCenterBottom.CheckAlign = ContentAlignment.MiddleCenter
        radbtnVolumePlacementLeftCenterBottom.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TipSettingsEX.SetImage(radbtnVolumePlacementLeftCenterBottom, Nothing)
        radbtnVolumePlacementLeftCenterBottom.Location = New Point(10, 123)
        radbtnVolumePlacementLeftCenterBottom.Margin = New Padding(4)
        radbtnVolumePlacementLeftCenterBottom.Name = "radbtnVolumePlacementLeftCenterBottom"
        radbtnVolumePlacementLeftCenterBottom.Size = New Size(22, 30)
        radbtnVolumePlacementLeftCenterBottom.TabIndex = 14
        TipSettingsEX.SetText(radbtnVolumePlacementLeftCenterBottom, Nothing)
        radbtnVolumePlacementLeftCenterBottom.Text = "  "
        radbtnVolumePlacementLeftCenterBottom.UseVisualStyleBackColor = True
        ' 
        ' radbtnVolumePlacementBottomCenter
        ' 
        radbtnVolumePlacementBottomCenter.CheckAlign = ContentAlignment.MiddleCenter
        radbtnVolumePlacementBottomCenter.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TipSettingsEX.SetImage(radbtnVolumePlacementBottomCenter, Nothing)
        radbtnVolumePlacementBottomCenter.Location = New Point(99, 159)
        radbtnVolumePlacementBottomCenter.Margin = New Padding(4)
        radbtnVolumePlacementBottomCenter.Name = "radbtnVolumePlacementBottomCenter"
        radbtnVolumePlacementBottomCenter.Size = New Size(22, 30)
        radbtnVolumePlacementBottomCenter.TabIndex = 11
        TipSettingsEX.SetText(radbtnVolumePlacementBottomCenter, Nothing)
        radbtnVolumePlacementBottomCenter.Text = "  "
        radbtnVolumePlacementBottomCenter.UseVisualStyleBackColor = True
        ' 
        ' radbtnVolumePlacementLeftCenter
        ' 
        radbtnVolumePlacementLeftCenter.CheckAlign = ContentAlignment.MiddleCenter
        radbtnVolumePlacementLeftCenter.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TipSettingsEX.SetImage(radbtnVolumePlacementLeftCenter, Nothing)
        radbtnVolumePlacementLeftCenter.Location = New Point(10, 87)
        radbtnVolumePlacementLeftCenter.Margin = New Padding(4)
        radbtnVolumePlacementLeftCenter.Name = "radbtnVolumePlacementLeftCenter"
        radbtnVolumePlacementLeftCenter.Size = New Size(22, 30)
        radbtnVolumePlacementLeftCenter.TabIndex = 15
        TipSettingsEX.SetText(radbtnVolumePlacementLeftCenter, Nothing)
        radbtnVolumePlacementLeftCenter.Text = "  "
        radbtnVolumePlacementLeftCenter.UseVisualStyleBackColor = True
        ' 
        ' radbtnVolumePlacementRightCenter
        ' 
        radbtnVolumePlacementRightCenter.CheckAlign = ContentAlignment.MiddleCenter
        radbtnVolumePlacementRightCenter.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TipSettingsEX.SetImage(radbtnVolumePlacementRightCenter, Nothing)
        radbtnVolumePlacementRightCenter.Location = New Point(186, 87)
        radbtnVolumePlacementRightCenter.Margin = New Padding(4)
        radbtnVolumePlacementRightCenter.Name = "radbtnVolumePlacementRightCenter"
        radbtnVolumePlacementRightCenter.Size = New Size(22, 30)
        radbtnVolumePlacementRightCenter.TabIndex = 7
        TipSettingsEX.SetText(radbtnVolumePlacementRightCenter, Nothing)
        radbtnVolumePlacementRightCenter.Text = "  "
        radbtnVolumePlacementRightCenter.UseVisualStyleBackColor = True
        ' 
        ' radbtnVolumePlacementTopCenterLeft
        ' 
        radbtnVolumePlacementTopCenterLeft.CheckAlign = ContentAlignment.MiddleCenter
        radbtnVolumePlacementTopCenterLeft.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TipSettingsEX.SetImage(radbtnVolumePlacementTopCenterLeft, Nothing)
        radbtnVolumePlacementTopCenterLeft.Location = New Point(54, 16)
        radbtnVolumePlacementTopCenterLeft.Margin = New Padding(4)
        radbtnVolumePlacementTopCenterLeft.Name = "radbtnVolumePlacementTopCenterLeft"
        radbtnVolumePlacementTopCenterLeft.Size = New Size(22, 30)
        radbtnVolumePlacementTopCenterLeft.TabIndex = 2
        TipSettingsEX.SetText(radbtnVolumePlacementTopCenterLeft, Nothing)
        radbtnVolumePlacementTopCenterLeft.Text = "  "
        radbtnVolumePlacementTopCenterLeft.UseVisualStyleBackColor = True
        ' 
        ' radbtnVolumePlacementTopCenter
        ' 
        radbtnVolumePlacementTopCenter.CheckAlign = ContentAlignment.MiddleCenter
        radbtnVolumePlacementTopCenter.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TipSettingsEX.SetImage(radbtnVolumePlacementTopCenter, Nothing)
        radbtnVolumePlacementTopCenter.Location = New Point(99, 16)
        radbtnVolumePlacementTopCenter.Margin = New Padding(4)
        radbtnVolumePlacementTopCenter.Name = "radbtnVolumePlacementTopCenter"
        radbtnVolumePlacementTopCenter.Size = New Size(22, 30)
        radbtnVolumePlacementTopCenter.TabIndex = 3
        TipSettingsEX.SetText(radbtnVolumePlacementTopCenter, Nothing)
        radbtnVolumePlacementTopCenter.Text = "  "
        radbtnVolumePlacementTopCenter.UseVisualStyleBackColor = True
        ' 
        ' radbtnVolumePlacementTopRight
        ' 
        radbtnVolumePlacementTopRight.CheckAlign = ContentAlignment.MiddleCenter
        radbtnVolumePlacementTopRight.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TipSettingsEX.SetImage(radbtnVolumePlacementTopRight, Nothing)
        radbtnVolumePlacementTopRight.Location = New Point(186, 16)
        radbtnVolumePlacementTopRight.Margin = New Padding(4)
        radbtnVolumePlacementTopRight.Name = "radbtnVolumePlacementTopRight"
        radbtnVolumePlacementTopRight.Size = New Size(22, 30)
        radbtnVolumePlacementTopRight.TabIndex = 5
        TipSettingsEX.SetText(radbtnVolumePlacementTopRight, Nothing)
        radbtnVolumePlacementTopRight.Text = "  "
        radbtnVolumePlacementTopRight.UseVisualStyleBackColor = True
        ' 
        ' radbtnVolumePlacementTopCenterRight
        ' 
        radbtnVolumePlacementTopCenterRight.CheckAlign = ContentAlignment.MiddleCenter
        radbtnVolumePlacementTopCenterRight.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TipSettingsEX.SetImage(radbtnVolumePlacementTopCenterRight, Nothing)
        radbtnVolumePlacementTopCenterRight.Location = New Point(143, 16)
        radbtnVolumePlacementTopCenterRight.Margin = New Padding(4)
        radbtnVolumePlacementTopCenterRight.Name = "radbtnVolumePlacementTopCenterRight"
        radbtnVolumePlacementTopCenterRight.Size = New Size(22, 30)
        radbtnVolumePlacementTopCenterRight.TabIndex = 4
        TipSettingsEX.SetText(radbtnVolumePlacementTopCenterRight, Nothing)
        radbtnVolumePlacementTopCenterRight.Text = "  "
        radbtnVolumePlacementTopCenterRight.UseVisualStyleBackColor = True
        ' 
        ' radbtnVolumePlacementTopLeft
        ' 
        radbtnVolumePlacementTopLeft.CheckAlign = ContentAlignment.MiddleCenter
        radbtnVolumePlacementTopLeft.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TipSettingsEX.SetImage(radbtnVolumePlacementTopLeft, Nothing)
        radbtnVolumePlacementTopLeft.Location = New Point(10, 16)
        radbtnVolumePlacementTopLeft.Margin = New Padding(4)
        radbtnVolumePlacementTopLeft.Name = "radbtnVolumePlacementTopLeft"
        radbtnVolumePlacementTopLeft.Size = New Size(22, 30)
        radbtnVolumePlacementTopLeft.TabIndex = 1
        TipSettingsEX.SetText(radbtnVolumePlacementTopLeft, Nothing)
        radbtnVolumePlacementTopLeft.Text = "  "
        radbtnVolumePlacementTopLeft.UseVisualStyleBackColor = True
        ' 
        ' lblZones
        ' 
        lblZones.Font = New Font("Segoe UI", 12F, FontStyle.Bold Or FontStyle.Underline, GraphicsUnit.Point, CByte(0))
        TipSettingsEX.SetImage(lblZones, Nothing)
        lblZones.Location = New Point(15, 12)
        lblZones.Margin = New Padding(4, 0, 4, 0)
        lblZones.Name = "lblZones"
        lblZones.Size = New Size(167, 21)
        lblZones.TabIndex = 0
        lblZones.Text = "Zones"
        TipSettingsEX.SetText(lblZones, Nothing)
        lblZones.TextAlign = ContentAlignment.BottomLeft
        ' 
        ' grbxPlayerPlacement
        ' 
        grbxPlayerPlacement.Controls.Add(radbtnPlayerPlacementManual)
        grbxPlayerPlacement.Controls.Add(radbtnPlayerPlacementCenter)
        grbxPlayerPlacement.Controls.Add(radbtnPlayerPlacementLeftCenterTop)
        grbxPlayerPlacement.Controls.Add(radbtnPlayerPlacementBottomLeft)
        grbxPlayerPlacement.Controls.Add(radbtnPlayerPlacementRightCenterTop)
        grbxPlayerPlacement.Controls.Add(radbtnPlayerPlacementRightCenterBottom)
        grbxPlayerPlacement.Controls.Add(radbtnPlayerPlacementBottomCenterRight)
        grbxPlayerPlacement.Controls.Add(radbtnPlayerPlacementBottomCenterLeft)
        grbxPlayerPlacement.Controls.Add(radbtnPlayerPlacementBottomRight)
        grbxPlayerPlacement.Controls.Add(radbtnPlayerPlacementLeftCenterBottom)
        grbxPlayerPlacement.Controls.Add(radbtnPlayerPlacementBottomCenter)
        grbxPlayerPlacement.Controls.Add(radbtnPlayerPlacementLeftCenter)
        grbxPlayerPlacement.Controls.Add(radbtnPlayerPlacementTopCenterLeft)
        grbxPlayerPlacement.Controls.Add(radbtnPlayerPlacementTopCenter)
        grbxPlayerPlacement.Controls.Add(radbtnPlayerPlacementTopRight)
        grbxPlayerPlacement.Controls.Add(radbtnPlayerPlacementTopCenterRight)
        grbxPlayerPlacement.Controls.Add(radbtnPlayerPlacementRightCenter)
        grbxPlayerPlacement.Controls.Add(radbtnPlayerPlacementTopLeft)
        grbxPlayerPlacement.Cursor = Cursors.Hand
        grbxPlayerPlacement.Font = New Font("Segoe UI", 12F, FontStyle.Bold Or FontStyle.Underline, GraphicsUnit.Point, CByte(0))
        grbxPlayerPlacement.ForeColor = SystemColors.ControlText
        TipSettingsEX.SetImage(grbxPlayerPlacement, Nothing)
        grbxPlayerPlacement.Location = New Point(553, 210)
        grbxPlayerPlacement.Margin = New Padding(4)
        grbxPlayerPlacement.Name = "grbxPlayerPlacement"
        grbxPlayerPlacement.Padding = New Padding(4)
        grbxPlayerPlacement.Size = New Size(216, 194)
        grbxPlayerPlacement.TabIndex = 510
        grbxPlayerPlacement.TabStop = False
        TipSettingsEX.SetText(grbxPlayerPlacement, Nothing)
        ' 
        ' radbtnPlayerPlacementManual
        ' 
        radbtnPlayerPlacementManual.CheckAlign = ContentAlignment.BottomCenter
        radbtnPlayerPlacementManual.Cursor = Cursors.Hand
        radbtnPlayerPlacementManual.Font = New Font("Segoe UI", 12F)
        TipSettingsEX.SetImage(radbtnPlayerPlacementManual, Nothing)
        radbtnPlayerPlacementManual.Location = New Point(67, 103)
        radbtnPlayerPlacementManual.Margin = New Padding(4)
        radbtnPlayerPlacementManual.Name = "radbtnPlayerPlacementManual"
        radbtnPlayerPlacementManual.Size = New Size(84, 40)
        radbtnPlayerPlacementManual.TabIndex = 0
        TipSettingsEX.SetText(radbtnPlayerPlacementManual, Nothing)
        radbtnPlayerPlacementManual.Text = "Manual"
        radbtnPlayerPlacementManual.TextAlign = ContentAlignment.MiddleCenter
        radbtnPlayerPlacementManual.UseVisualStyleBackColor = True
        ' 
        ' radbtnPlayerPlacementCenter
        ' 
        radbtnPlayerPlacementCenter.CheckAlign = ContentAlignment.BottomCenter
        radbtnPlayerPlacementCenter.Cursor = Cursors.Hand
        radbtnPlayerPlacementCenter.Font = New Font("Segoe UI", 12F)
        TipSettingsEX.SetImage(radbtnPlayerPlacementCenter, Nothing)
        radbtnPlayerPlacementCenter.Location = New Point(67, 56)
        radbtnPlayerPlacementCenter.Margin = New Padding(4)
        radbtnPlayerPlacementCenter.Name = "radbtnPlayerPlacementCenter"
        radbtnPlayerPlacementCenter.Size = New Size(84, 40)
        radbtnPlayerPlacementCenter.TabIndex = 17
        TipSettingsEX.SetText(radbtnPlayerPlacementCenter, Nothing)
        radbtnPlayerPlacementCenter.Text = "Center"
        radbtnPlayerPlacementCenter.TextAlign = ContentAlignment.MiddleCenter
        radbtnPlayerPlacementCenter.UseVisualStyleBackColor = True
        ' 
        ' radbtnPlayerPlacementLeftCenterTop
        ' 
        radbtnPlayerPlacementLeftCenterTop.CheckAlign = ContentAlignment.MiddleCenter
        radbtnPlayerPlacementLeftCenterTop.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TipSettingsEX.SetImage(radbtnPlayerPlacementLeftCenterTop, Nothing)
        radbtnPlayerPlacementLeftCenterTop.Location = New Point(10, 51)
        radbtnPlayerPlacementLeftCenterTop.Margin = New Padding(4)
        radbtnPlayerPlacementLeftCenterTop.Name = "radbtnPlayerPlacementLeftCenterTop"
        radbtnPlayerPlacementLeftCenterTop.Size = New Size(22, 30)
        radbtnPlayerPlacementLeftCenterTop.TabIndex = 16
        TipSettingsEX.SetText(radbtnPlayerPlacementLeftCenterTop, Nothing)
        radbtnPlayerPlacementLeftCenterTop.Text = "  "
        radbtnPlayerPlacementLeftCenterTop.UseVisualStyleBackColor = True
        ' 
        ' radbtnPlayerPlacementBottomLeft
        ' 
        radbtnPlayerPlacementBottomLeft.CheckAlign = ContentAlignment.MiddleCenter
        radbtnPlayerPlacementBottomLeft.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TipSettingsEX.SetImage(radbtnPlayerPlacementBottomLeft, Nothing)
        radbtnPlayerPlacementBottomLeft.Location = New Point(10, 159)
        radbtnPlayerPlacementBottomLeft.Margin = New Padding(4)
        radbtnPlayerPlacementBottomLeft.Name = "radbtnPlayerPlacementBottomLeft"
        radbtnPlayerPlacementBottomLeft.Size = New Size(22, 30)
        radbtnPlayerPlacementBottomLeft.TabIndex = 13
        TipSettingsEX.SetText(radbtnPlayerPlacementBottomLeft, Nothing)
        radbtnPlayerPlacementBottomLeft.Text = "  "
        radbtnPlayerPlacementBottomLeft.UseVisualStyleBackColor = True
        ' 
        ' radbtnPlayerPlacementRightCenterTop
        ' 
        radbtnPlayerPlacementRightCenterTop.CheckAlign = ContentAlignment.MiddleCenter
        radbtnPlayerPlacementRightCenterTop.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TipSettingsEX.SetImage(radbtnPlayerPlacementRightCenterTop, Nothing)
        radbtnPlayerPlacementRightCenterTop.Location = New Point(186, 51)
        radbtnPlayerPlacementRightCenterTop.Margin = New Padding(4)
        radbtnPlayerPlacementRightCenterTop.Name = "radbtnPlayerPlacementRightCenterTop"
        radbtnPlayerPlacementRightCenterTop.Size = New Size(22, 30)
        radbtnPlayerPlacementRightCenterTop.TabIndex = 6
        TipSettingsEX.SetText(radbtnPlayerPlacementRightCenterTop, Nothing)
        radbtnPlayerPlacementRightCenterTop.Text = "  "
        radbtnPlayerPlacementRightCenterTop.UseVisualStyleBackColor = True
        ' 
        ' radbtnPlayerPlacementRightCenterBottom
        ' 
        radbtnPlayerPlacementRightCenterBottom.CheckAlign = ContentAlignment.MiddleCenter
        radbtnPlayerPlacementRightCenterBottom.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TipSettingsEX.SetImage(radbtnPlayerPlacementRightCenterBottom, Nothing)
        radbtnPlayerPlacementRightCenterBottom.Location = New Point(186, 123)
        radbtnPlayerPlacementRightCenterBottom.Margin = New Padding(4)
        radbtnPlayerPlacementRightCenterBottom.Name = "radbtnPlayerPlacementRightCenterBottom"
        radbtnPlayerPlacementRightCenterBottom.Size = New Size(22, 30)
        radbtnPlayerPlacementRightCenterBottom.TabIndex = 8
        TipSettingsEX.SetText(radbtnPlayerPlacementRightCenterBottom, Nothing)
        radbtnPlayerPlacementRightCenterBottom.Text = "  "
        radbtnPlayerPlacementRightCenterBottom.UseVisualStyleBackColor = True
        ' 
        ' radbtnPlayerPlacementBottomCenterRight
        ' 
        radbtnPlayerPlacementBottomCenterRight.CheckAlign = ContentAlignment.MiddleCenter
        radbtnPlayerPlacementBottomCenterRight.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TipSettingsEX.SetImage(radbtnPlayerPlacementBottomCenterRight, Nothing)
        radbtnPlayerPlacementBottomCenterRight.Location = New Point(142, 159)
        radbtnPlayerPlacementBottomCenterRight.Margin = New Padding(4)
        radbtnPlayerPlacementBottomCenterRight.Name = "radbtnPlayerPlacementBottomCenterRight"
        radbtnPlayerPlacementBottomCenterRight.Size = New Size(22, 30)
        radbtnPlayerPlacementBottomCenterRight.TabIndex = 10
        TipSettingsEX.SetText(radbtnPlayerPlacementBottomCenterRight, Nothing)
        radbtnPlayerPlacementBottomCenterRight.Text = "  "
        radbtnPlayerPlacementBottomCenterRight.UseVisualStyleBackColor = True
        ' 
        ' radbtnPlayerPlacementBottomCenterLeft
        ' 
        radbtnPlayerPlacementBottomCenterLeft.CheckAlign = ContentAlignment.MiddleCenter
        radbtnPlayerPlacementBottomCenterLeft.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TipSettingsEX.SetImage(radbtnPlayerPlacementBottomCenterLeft, Nothing)
        radbtnPlayerPlacementBottomCenterLeft.Location = New Point(54, 159)
        radbtnPlayerPlacementBottomCenterLeft.Margin = New Padding(4)
        radbtnPlayerPlacementBottomCenterLeft.Name = "radbtnPlayerPlacementBottomCenterLeft"
        radbtnPlayerPlacementBottomCenterLeft.Size = New Size(22, 30)
        radbtnPlayerPlacementBottomCenterLeft.TabIndex = 12
        TipSettingsEX.SetText(radbtnPlayerPlacementBottomCenterLeft, Nothing)
        radbtnPlayerPlacementBottomCenterLeft.Text = "  "
        radbtnPlayerPlacementBottomCenterLeft.UseVisualStyleBackColor = True
        ' 
        ' radbtnPlayerPlacementBottomRight
        ' 
        radbtnPlayerPlacementBottomRight.CheckAlign = ContentAlignment.MiddleCenter
        radbtnPlayerPlacementBottomRight.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TipSettingsEX.SetImage(radbtnPlayerPlacementBottomRight, Nothing)
        radbtnPlayerPlacementBottomRight.Location = New Point(186, 159)
        radbtnPlayerPlacementBottomRight.Margin = New Padding(4)
        radbtnPlayerPlacementBottomRight.Name = "radbtnPlayerPlacementBottomRight"
        radbtnPlayerPlacementBottomRight.Size = New Size(22, 30)
        radbtnPlayerPlacementBottomRight.TabIndex = 8
        TipSettingsEX.SetText(radbtnPlayerPlacementBottomRight, Nothing)
        radbtnPlayerPlacementBottomRight.Text = "  "
        radbtnPlayerPlacementBottomRight.UseVisualStyleBackColor = True
        ' 
        ' radbtnPlayerPlacementLeftCenterBottom
        ' 
        radbtnPlayerPlacementLeftCenterBottom.CheckAlign = ContentAlignment.MiddleCenter
        radbtnPlayerPlacementLeftCenterBottom.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TipSettingsEX.SetImage(radbtnPlayerPlacementLeftCenterBottom, Nothing)
        radbtnPlayerPlacementLeftCenterBottom.Location = New Point(10, 123)
        radbtnPlayerPlacementLeftCenterBottom.Margin = New Padding(4)
        radbtnPlayerPlacementLeftCenterBottom.Name = "radbtnPlayerPlacementLeftCenterBottom"
        radbtnPlayerPlacementLeftCenterBottom.Size = New Size(22, 30)
        radbtnPlayerPlacementLeftCenterBottom.TabIndex = 14
        TipSettingsEX.SetText(radbtnPlayerPlacementLeftCenterBottom, Nothing)
        radbtnPlayerPlacementLeftCenterBottom.Text = "  "
        radbtnPlayerPlacementLeftCenterBottom.UseVisualStyleBackColor = True
        ' 
        ' radbtnPlayerPlacementBottomCenter
        ' 
        radbtnPlayerPlacementBottomCenter.CheckAlign = ContentAlignment.MiddleCenter
        radbtnPlayerPlacementBottomCenter.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TipSettingsEX.SetImage(radbtnPlayerPlacementBottomCenter, Nothing)
        radbtnPlayerPlacementBottomCenter.Location = New Point(98, 159)
        radbtnPlayerPlacementBottomCenter.Margin = New Padding(4)
        radbtnPlayerPlacementBottomCenter.Name = "radbtnPlayerPlacementBottomCenter"
        radbtnPlayerPlacementBottomCenter.Size = New Size(22, 30)
        radbtnPlayerPlacementBottomCenter.TabIndex = 11
        TipSettingsEX.SetText(radbtnPlayerPlacementBottomCenter, Nothing)
        radbtnPlayerPlacementBottomCenter.Text = "  "
        radbtnPlayerPlacementBottomCenter.UseVisualStyleBackColor = True
        ' 
        ' radbtnPlayerPlacementLeftCenter
        ' 
        radbtnPlayerPlacementLeftCenter.CheckAlign = ContentAlignment.MiddleCenter
        radbtnPlayerPlacementLeftCenter.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TipSettingsEX.SetImage(radbtnPlayerPlacementLeftCenter, Nothing)
        radbtnPlayerPlacementLeftCenter.Location = New Point(10, 87)
        radbtnPlayerPlacementLeftCenter.Margin = New Padding(4)
        radbtnPlayerPlacementLeftCenter.Name = "radbtnPlayerPlacementLeftCenter"
        radbtnPlayerPlacementLeftCenter.Size = New Size(22, 30)
        radbtnPlayerPlacementLeftCenter.TabIndex = 15
        TipSettingsEX.SetText(radbtnPlayerPlacementLeftCenter, Nothing)
        radbtnPlayerPlacementLeftCenter.Text = "  "
        radbtnPlayerPlacementLeftCenter.UseVisualStyleBackColor = True
        ' 
        ' radbtnPlayerPlacementTopCenterLeft
        ' 
        radbtnPlayerPlacementTopCenterLeft.CheckAlign = ContentAlignment.MiddleCenter
        radbtnPlayerPlacementTopCenterLeft.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TipSettingsEX.SetImage(radbtnPlayerPlacementTopCenterLeft, Nothing)
        radbtnPlayerPlacementTopCenterLeft.Location = New Point(54, 16)
        radbtnPlayerPlacementTopCenterLeft.Margin = New Padding(4)
        radbtnPlayerPlacementTopCenterLeft.Name = "radbtnPlayerPlacementTopCenterLeft"
        radbtnPlayerPlacementTopCenterLeft.Size = New Size(22, 30)
        radbtnPlayerPlacementTopCenterLeft.TabIndex = 2
        TipSettingsEX.SetText(radbtnPlayerPlacementTopCenterLeft, Nothing)
        radbtnPlayerPlacementTopCenterLeft.Text = "  "
        radbtnPlayerPlacementTopCenterLeft.UseVisualStyleBackColor = True
        ' 
        ' radbtnPlayerPlacementTopCenter
        ' 
        radbtnPlayerPlacementTopCenter.CheckAlign = ContentAlignment.MiddleCenter
        radbtnPlayerPlacementTopCenter.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TipSettingsEX.SetImage(radbtnPlayerPlacementTopCenter, Nothing)
        radbtnPlayerPlacementTopCenter.Location = New Point(98, 16)
        radbtnPlayerPlacementTopCenter.Margin = New Padding(4)
        radbtnPlayerPlacementTopCenter.Name = "radbtnPlayerPlacementTopCenter"
        radbtnPlayerPlacementTopCenter.Size = New Size(22, 30)
        radbtnPlayerPlacementTopCenter.TabIndex = 3
        TipSettingsEX.SetText(radbtnPlayerPlacementTopCenter, Nothing)
        radbtnPlayerPlacementTopCenter.Text = "  "
        radbtnPlayerPlacementTopCenter.UseVisualStyleBackColor = True
        ' 
        ' radbtnPlayerPlacementTopRight
        ' 
        radbtnPlayerPlacementTopRight.CheckAlign = ContentAlignment.MiddleCenter
        radbtnPlayerPlacementTopRight.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TipSettingsEX.SetImage(radbtnPlayerPlacementTopRight, Nothing)
        radbtnPlayerPlacementTopRight.Location = New Point(186, 16)
        radbtnPlayerPlacementTopRight.Margin = New Padding(4)
        radbtnPlayerPlacementTopRight.Name = "radbtnPlayerPlacementTopRight"
        radbtnPlayerPlacementTopRight.Size = New Size(22, 30)
        radbtnPlayerPlacementTopRight.TabIndex = 5
        TipSettingsEX.SetText(radbtnPlayerPlacementTopRight, Nothing)
        radbtnPlayerPlacementTopRight.Text = "  "
        radbtnPlayerPlacementTopRight.UseVisualStyleBackColor = True
        ' 
        ' radbtnPlayerPlacementTopCenterRight
        ' 
        radbtnPlayerPlacementTopCenterRight.CheckAlign = ContentAlignment.MiddleCenter
        radbtnPlayerPlacementTopCenterRight.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TipSettingsEX.SetImage(radbtnPlayerPlacementTopCenterRight, Nothing)
        radbtnPlayerPlacementTopCenterRight.Location = New Point(142, 16)
        radbtnPlayerPlacementTopCenterRight.Margin = New Padding(4)
        radbtnPlayerPlacementTopCenterRight.Name = "radbtnPlayerPlacementTopCenterRight"
        radbtnPlayerPlacementTopCenterRight.Size = New Size(22, 30)
        radbtnPlayerPlacementTopCenterRight.TabIndex = 4
        TipSettingsEX.SetText(radbtnPlayerPlacementTopCenterRight, Nothing)
        radbtnPlayerPlacementTopCenterRight.Text = "  "
        radbtnPlayerPlacementTopCenterRight.UseVisualStyleBackColor = True
        ' 
        ' radbtnPlayerPlacementRightCenter
        ' 
        radbtnPlayerPlacementRightCenter.CheckAlign = ContentAlignment.MiddleCenter
        radbtnPlayerPlacementRightCenter.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TipSettingsEX.SetImage(radbtnPlayerPlacementRightCenter, Nothing)
        radbtnPlayerPlacementRightCenter.Location = New Point(186, 87)
        radbtnPlayerPlacementRightCenter.Margin = New Padding(4)
        radbtnPlayerPlacementRightCenter.Name = "radbtnPlayerPlacementRightCenter"
        radbtnPlayerPlacementRightCenter.Size = New Size(22, 30)
        radbtnPlayerPlacementRightCenter.TabIndex = 7
        TipSettingsEX.SetText(radbtnPlayerPlacementRightCenter, Nothing)
        radbtnPlayerPlacementRightCenter.Text = "  "
        radbtnPlayerPlacementRightCenter.UseVisualStyleBackColor = True
        ' 
        ' radbtnPlayerPlacementTopLeft
        ' 
        radbtnPlayerPlacementTopLeft.CheckAlign = ContentAlignment.MiddleCenter
        radbtnPlayerPlacementTopLeft.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TipSettingsEX.SetImage(radbtnPlayerPlacementTopLeft, Nothing)
        radbtnPlayerPlacementTopLeft.Location = New Point(10, 16)
        radbtnPlayerPlacementTopLeft.Margin = New Padding(4)
        radbtnPlayerPlacementTopLeft.Name = "radbtnPlayerPlacementTopLeft"
        radbtnPlayerPlacementTopLeft.Size = New Size(22, 30)
        radbtnPlayerPlacementTopLeft.TabIndex = 1
        TipSettingsEX.SetText(radbtnPlayerPlacementTopLeft, Nothing)
        radbtnPlayerPlacementTopLeft.UseVisualStyleBackColor = True
        ' 
        ' txbxZoneBlue
        ' 
        txbxZoneBlue.BackColor = SystemColors.Control
        txbxZoneBlue.BorderStyle = BorderStyle.None
        TipSettingsEX.SetImage(txbxZoneBlue, Nothing)
        txbxZoneBlue.Location = New Point(254, 32)
        txbxZoneBlue.Margin = New Padding(4)
        txbxZoneBlue.MaxLength = 3
        txbxZoneBlue.Name = "txbxZoneBlue"
        txbxZoneBlue.ShortcutsEnabled = False
        txbxZoneBlue.Size = New Size(39, 22)
        txbxZoneBlue.TabIndex = 10
        TipSettingsEX.SetText(txbxZoneBlue, Nothing)
        txbxZoneBlue.Text = "188"
        txbxZoneBlue.TextAlign = HorizontalAlignment.Center
        ' 
        ' txbxZoneRed
        ' 
        txbxZoneRed.BackColor = SystemColors.Control
        txbxZoneRed.BorderStyle = BorderStyle.None
        TipSettingsEX.SetImage(txbxZoneRed, Nothing)
        txbxZoneRed.Location = New Point(254, 56)
        txbxZoneRed.Margin = New Padding(4)
        txbxZoneRed.MaxLength = 3
        txbxZoneRed.Name = "txbxZoneRed"
        txbxZoneRed.ShortcutsEnabled = False
        txbxZoneRed.Size = New Size(39, 22)
        txbxZoneRed.TabIndex = 12
        TipSettingsEX.SetText(txbxZoneRed, Nothing)
        txbxZoneRed.Text = "188"
        txbxZoneRed.TextAlign = HorizontalAlignment.Center
        ' 
        ' cobxUnMuteOnVolumeChange
        ' 
        cobxUnMuteOnVolumeChange.DropDownStyle = ComboBoxStyle.DropDownList
        cobxUnMuteOnVolumeChange.FormattingEnabled = True
        TipSettingsEX.SetImage(cobxUnMuteOnVolumeChange, Nothing)
        cobxUnMuteOnVolumeChange.Location = New Point(13, 162)
        cobxUnMuteOnVolumeChange.Margin = New Padding(4)
        cobxUnMuteOnVolumeChange.Name = "cobxUnMuteOnVolumeChange"
        cobxUnMuteOnVolumeChange.Size = New Size(197, 29)
        cobxUnMuteOnVolumeChange.TabIndex = 20
        TipSettingsEX.SetText(cobxUnMuteOnVolumeChange, Nothing)
        ' 
        ' lblUnMuteOnVolumeChange
        ' 
        lblUnMuteOnVolumeChange.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TipSettingsEX.SetImage(lblUnMuteOnVolumeChange, Nothing)
        lblUnMuteOnVolumeChange.Location = New Point(10, 138)
        lblUnMuteOnVolumeChange.Margin = New Padding(4, 0, 4, 0)
        lblUnMuteOnVolumeChange.Name = "lblUnMuteOnVolumeChange"
        lblUnMuteOnVolumeChange.Size = New Size(227, 21)
        lblUnMuteOnVolumeChange.TabIndex = 0
        lblUnMuteOnVolumeChange.Text = "UnMute On Volume Change"
        TipSettingsEX.SetText(lblUnMuteOnVolumeChange, Nothing)
        lblUnMuteOnVolumeChange.TextAlign = ContentAlignment.BottomLeft
        ' 
        ' chbxAutoHideWithFadeVolume
        ' 
        TipSettingsEX.SetImage(chbxAutoHideWithFadeVolume, Nothing)
        chbxAutoHideWithFadeVolume.Location = New Point(338, 109)
        chbxAutoHideWithFadeVolume.Margin = New Padding(4)
        chbxAutoHideWithFadeVolume.Name = "chbxAutoHideWithFadeVolume"
        chbxAutoHideWithFadeVolume.Size = New Size(143, 28)
        chbxAutoHideWithFadeVolume.TabIndex = 120
        TipSettingsEX.SetText(chbxAutoHideWithFadeVolume, Nothing)
        chbxAutoHideWithFadeVolume.Text = "Hide With Fade"
        chbxAutoHideWithFadeVolume.UseVisualStyleBackColor = True
        ' 
        ' chbxAutoShowPlayer
        ' 
        TipSettingsEX.SetImage(chbxAutoShowPlayer, Nothing)
        chbxAutoShowPlayer.Location = New Point(338, 370)
        chbxAutoShowPlayer.Margin = New Padding(4)
        chbxAutoShowPlayer.Name = "chbxAutoShowPlayer"
        chbxAutoShowPlayer.Size = New Size(208, 28)
        chbxAutoShowPlayer.TabIndex = 139
        TipSettingsEX.SetText(chbxAutoShowPlayer, Nothing)
        chbxAutoShowPlayer.Text = "AutoShow Player Info"
        chbxAutoShowPlayer.UseVisualStyleBackColor = True
        ' 
        ' grbxHotKeys
        ' 
        grbxHotKeys.Controls.Add(btnHotKeysSet)
        grbxHotKeys.Controls.Add(btnHotKeysUndo)
        grbxHotKeys.Controls.Add(txbxHotKeyVolumeInfo)
        grbxHotKeys.Controls.Add(txbxHotKeyPlayerInfo)
        grbxHotKeys.Controls.Add(txbxHotKeyViewer)
        grbxHotKeys.Controls.Add(lblHotKeyViewer)
        grbxHotKeys.Controls.Add(btnHotKeyVolumeInfoDisable)
        grbxHotKeys.Controls.Add(btnHotKeyViewerDisable)
        grbxHotKeys.Controls.Add(btnHotKeyPlayerInfoDisable)
        grbxHotKeys.Controls.Add(lblHotKeyPlayerInfo)
        grbxHotKeys.Controls.Add(lblHotKeyVolumeInfo)
        grbxHotKeys.ForeColor = SystemColors.ControlText
        TipSettingsEX.SetImage(grbxHotKeys, Nothing)
        grbxHotKeys.Location = New Point(13, 241)
        grbxHotKeys.Margin = New Padding(4)
        grbxHotKeys.Name = "grbxHotKeys"
        grbxHotKeys.Padding = New Padding(4)
        grbxHotKeys.Size = New Size(237, 239)
        grbxHotKeys.TabIndex = 40
        grbxHotKeys.TabStop = False
        TipSettingsEX.SetText(grbxHotKeys, Nothing)
        ' 
        ' txbxHotKeyVolumeInfo
        ' 
        TipSettingsEX.SetImage(txbxHotKeyVolumeInfo, Nothing)
        txbxHotKeyVolumeInfo.Location = New Point(9, 36)
        txbxHotKeyVolumeInfo.Margin = New Padding(4)
        txbxHotKeyVolumeInfo.Name = "txbxHotKeyVolumeInfo"
        txbxHotKeyVolumeInfo.ShortcutsEnabled = False
        txbxHotKeyVolumeInfo.Size = New Size(193, 29)
        txbxHotKeyVolumeInfo.TabIndex = 10
        txbxHotKeyVolumeInfo.TabStop = False
        TipSettingsEX.SetText(txbxHotKeyVolumeInfo, Nothing)
        txbxHotKeyVolumeInfo.TextAlign = HorizontalAlignment.Center
        txbxHotKeyVolumeInfo.WordWrap = False
        ' 
        ' txbxHotKeyPlayerInfo
        ' 
        TipSettingsEX.SetImage(txbxHotKeyPlayerInfo, Nothing)
        txbxHotKeyPlayerInfo.Location = New Point(9, 88)
        txbxHotKeyPlayerInfo.Margin = New Padding(4)
        txbxHotKeyPlayerInfo.Name = "txbxHotKeyPlayerInfo"
        txbxHotKeyPlayerInfo.ShortcutsEnabled = False
        txbxHotKeyPlayerInfo.Size = New Size(193, 29)
        txbxHotKeyPlayerInfo.TabIndex = 20
        txbxHotKeyPlayerInfo.TabStop = False
        TipSettingsEX.SetText(txbxHotKeyPlayerInfo, Nothing)
        txbxHotKeyPlayerInfo.TextAlign = HorizontalAlignment.Center
        txbxHotKeyPlayerInfo.WordWrap = False
        ' 
        ' txbxHotKeyViewer
        ' 
        TipSettingsEX.SetImage(txbxHotKeyViewer, Nothing)
        txbxHotKeyViewer.Location = New Point(9, 140)
        txbxHotKeyViewer.Margin = New Padding(4)
        txbxHotKeyViewer.Name = "txbxHotKeyViewer"
        txbxHotKeyViewer.ShortcutsEnabled = False
        txbxHotKeyViewer.Size = New Size(193, 29)
        txbxHotKeyViewer.TabIndex = 30
        txbxHotKeyViewer.TabStop = False
        TipSettingsEX.SetText(txbxHotKeyViewer, Nothing)
        txbxHotKeyViewer.TextAlign = HorizontalAlignment.Center
        txbxHotKeyViewer.WordWrap = False
        ' 
        ' lblHotKeyViewer
        ' 
        lblHotKeyViewer.BackColor = Color.Transparent
        lblHotKeyViewer.ForeColor = SystemColors.ControlText
        TipSettingsEX.SetImage(lblHotKeyViewer, Nothing)
        lblHotKeyViewer.Location = New Point(9, 112)
        lblHotKeyViewer.Margin = New Padding(4, 0, 4, 0)
        lblHotKeyViewer.Name = "lblHotKeyViewer"
        lblHotKeyViewer.Size = New Size(194, 31)
        lblHotKeyViewer.TabIndex = 0
        lblHotKeyViewer.Text = "Viewer"
        TipSettingsEX.SetText(lblHotKeyViewer, Nothing)
        lblHotKeyViewer.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' lblHotKeyPlayerInfo
        ' 
        lblHotKeyPlayerInfo.BackColor = Color.Transparent
        lblHotKeyPlayerInfo.ForeColor = SystemColors.ControlText
        TipSettingsEX.SetImage(lblHotKeyPlayerInfo, Nothing)
        lblHotKeyPlayerInfo.Location = New Point(9, 63)
        lblHotKeyPlayerInfo.Margin = New Padding(4, 0, 4, 0)
        lblHotKeyPlayerInfo.Name = "lblHotKeyPlayerInfo"
        lblHotKeyPlayerInfo.Size = New Size(194, 28)
        lblHotKeyPlayerInfo.TabIndex = 0
        lblHotKeyPlayerInfo.Text = "Player Info"
        TipSettingsEX.SetText(lblHotKeyPlayerInfo, Nothing)
        lblHotKeyPlayerInfo.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' lblHotKeyVolumeInfo
        ' 
        lblHotKeyVolumeInfo.BackColor = Color.Transparent
        lblHotKeyVolumeInfo.ForeColor = SystemColors.ControlText
        TipSettingsEX.SetImage(lblHotKeyVolumeInfo, Nothing)
        lblHotKeyVolumeInfo.Location = New Point(9, 11)
        lblHotKeyVolumeInfo.Margin = New Padding(4, 0, 4, 0)
        lblHotKeyVolumeInfo.Name = "lblHotKeyVolumeInfo"
        lblHotKeyVolumeInfo.Size = New Size(194, 28)
        lblHotKeyVolumeInfo.TabIndex = 0
        lblHotKeyVolumeInfo.Text = "Volume Info"
        TipSettingsEX.SetText(lblHotKeyVolumeInfo, Nothing)
        lblHotKeyVolumeInfo.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' chbxHotKeys
        ' 
        chbxHotKeys.Font = New Font("Segoe UI", 12F, FontStyle.Bold Or FontStyle.Underline, GraphicsUnit.Point, CByte(0))
        TipSettingsEX.SetImage(chbxHotKeys, Nothing)
        chbxHotKeys.Location = New Point(18, 222)
        chbxHotKeys.Margin = New Padding(4)
        chbxHotKeys.Name = "chbxHotKeys"
        chbxHotKeys.Size = New Size(132, 30)
        chbxHotKeys.TabIndex = 30
        TipSettingsEX.SetText(chbxHotKeys, Nothing)
        chbxHotKeys.Text = "HotKeys"
        chbxHotKeys.UseVisualStyleBackColor = True
        ' 
        ' lblViewer
        ' 
        lblViewer.Font = New Font("Segoe UI", 12F, FontStyle.Bold Or FontStyle.Underline, GraphicsUnit.Point, CByte(0))
        TipSettingsEX.SetImage(lblViewer, Nothing)
        lblViewer.Location = New Point(823, 12)
        lblViewer.Margin = New Padding(4, 0, 4, 0)
        lblViewer.Name = "lblViewer"
        lblViewer.Size = New Size(213, 21)
        lblViewer.TabIndex = 1008
        lblViewer.Text = "Viewer"
        TipSettingsEX.SetText(lblViewer, Nothing)
        lblViewer.TextAlign = ContentAlignment.BottomLeft
        ' 
        ' lblSaveEarsApps
        ' 
        lblSaveEarsApps.ContextMenuStrip = cmSaveEarsApps
        lblSaveEarsApps.Font = New Font("Segoe UI", 12F)
        TipSettingsEX.SetImage(lblSaveEarsApps, Nothing)
        lblSaveEarsApps.Location = New Point(496, 450)
        lblSaveEarsApps.Margin = New Padding(4, 0, 4, 0)
        lblSaveEarsApps.Name = "lblSaveEarsApps"
        lblSaveEarsApps.Size = New Size(134, 21)
        lblSaveEarsApps.TabIndex = 0
        lblSaveEarsApps.Text = "Save Ears Apps"
        TipSettingsEX.SetText(lblSaveEarsApps, Nothing)
        lblSaveEarsApps.TextAlign = ContentAlignment.BottomLeft
        ' 
        ' cmSaveEarsApps
        ' 
        TipSettingsEX.SetImage(cmSaveEarsApps, Nothing)
        cmSaveEarsApps.Items.AddRange(New ToolStripItem() {cmiSaveEarsAppsAddApp, cmiSaveEarsAppsRemoveApp})
        cmSaveEarsApps.Name = "contextMenuStrip1"
        cmSaveEarsApps.Size = New Size(143, 48)
        TipSettingsEX.SetText(cmSaveEarsApps, Nothing)
        ' 
        ' cmiSaveEarsAppsAddApp
        ' 
        cmiSaveEarsAppsAddApp.Image = My.Resources.Resources.imageSelect
        cmiSaveEarsAppsAddApp.Name = "cmiSaveEarsAppsAddApp"
        cmiSaveEarsAppsAddApp.Size = New Size(142, 22)
        cmiSaveEarsAppsAddApp.Text = "Add App"
        ' 
        ' cmiSaveEarsAppsRemoveApp
        ' 
        cmiSaveEarsAppsRemoveApp.Image = My.Resources.Resources.imageClear
        cmiSaveEarsAppsRemoveApp.Name = "cmiSaveEarsAppsRemoveApp"
        cmiSaveEarsAppsRemoveApp.Size = New Size(142, 22)
        cmiSaveEarsAppsRemoveApp.Text = "Remove App"
        ' 
        ' lsbxSaveEarsApps
        ' 
        lsbxSaveEarsApps.BorderStyle = BorderStyle.FixedSingle
        lsbxSaveEarsApps.ContextMenuStrip = cmSaveEarsApps
        lsbxSaveEarsApps.FormattingEnabled = True
        TipSettingsEX.SetImage(lsbxSaveEarsApps, Nothing)
        lsbxSaveEarsApps.Location = New Point(499, 475)
        lsbxSaveEarsApps.Margin = New Padding(4)
        lsbxSaveEarsApps.Name = "lsbxSaveEarsApps"
        lsbxSaveEarsApps.Size = New Size(225, 86)
        lsbxSaveEarsApps.TabIndex = 194
        TipSettingsEX.SetText(lsbxSaveEarsApps, Nothing)
        ' 
        ' lblSysVC
        ' 
        lblSysVC.Font = New Font("Segoe UI", 12F, FontStyle.Bold Or FontStyle.Underline)
        TipSettingsEX.SetImage(lblSysVC, Nothing)
        lblSysVC.Location = New Point(823, 113)
        lblSysVC.Margin = New Padding(4, 0, 4, 0)
        lblSysVC.Name = "lblSysVC"
        lblSysVC.Size = New Size(213, 21)
        lblSysVC.TabIndex = 1012
        lblSysVC.Text = "System Volume Control"
        TipSettingsEX.SetText(lblSysVC, Nothing)
        lblSysVC.TextAlign = ContentAlignment.BottomLeft
        ' 
        ' lblWA
        ' 
        lblWA.Font = New Font("Segoe UI", 12F, FontStyle.Bold Or FontStyle.Underline)
        TipSettingsEX.SetImage(lblWA, Nothing)
        lblWA.Location = New Point(823, 270)
        lblWA.Margin = New Padding(4, 0, 4, 0)
        lblWA.Name = "lblWA"
        lblWA.Size = New Size(213, 21)
        lblWA.TabIndex = 1015
        lblWA.Text = "Winamp"
        TipSettingsEX.SetText(lblWA, Nothing)
        lblWA.TextAlign = ContentAlignment.BottomLeft
        ' 
        ' chbxShowMeters
        ' 
        TipSettingsEX.SetImage(chbxShowMeters, Nothing)
        chbxShowMeters.Location = New Point(338, 169)
        chbxShowMeters.Margin = New Padding(4)
        chbxShowMeters.Name = "chbxShowMeters"
        chbxShowMeters.Size = New Size(143, 28)
        chbxShowMeters.TabIndex = 5
        TipSettingsEX.SetText(chbxShowMeters, Nothing)
        chbxShowMeters.Text = "Show Meters"
        chbxShowMeters.UseVisualStyleBackColor = True
        ' 
        ' chbxAutoHideWithFadePlayer
        ' 
        TipSettingsEX.SetImage(chbxAutoHideWithFadePlayer, Nothing)
        chbxAutoHideWithFadePlayer.Location = New Point(338, 338)
        chbxAutoHideWithFadePlayer.Margin = New Padding(4)
        chbxAutoHideWithFadePlayer.Name = "chbxAutoHideWithFadePlayer"
        chbxAutoHideWithFadePlayer.Size = New Size(149, 28)
        chbxAutoHideWithFadePlayer.TabIndex = 135
        TipSettingsEX.SetText(chbxAutoHideWithFadePlayer, Nothing)
        chbxAutoHideWithFadePlayer.Text = "Hide With Fade"
        chbxAutoHideWithFadePlayer.UseVisualStyleBackColor = True
        ' 
        ' chbxAutoHideVolume
        ' 
        TipSettingsEX.SetImage(chbxAutoHideVolume, Nothing)
        chbxAutoHideVolume.Location = New Point(338, 78)
        chbxAutoHideVolume.Margin = New Padding(4)
        chbxAutoHideVolume.Name = "chbxAutoHideVolume"
        chbxAutoHideVolume.Size = New Size(162, 28)
        chbxAutoHideVolume.TabIndex = 110
        TipSettingsEX.SetText(chbxAutoHideVolume, Nothing)
        chbxAutoHideVolume.Text = "Auto Hide Volume"
        chbxAutoHideVolume.UseVisualStyleBackColor = True
        ' 
        ' lblVolume
        ' 
        lblVolume.Font = New Font("Segoe UI", 12F, FontStyle.Bold Or FontStyle.Underline)
        TipSettingsEX.SetImage(lblVolume, Nothing)
        lblVolume.Location = New Point(338, 24)
        lblVolume.Margin = New Padding(4, 0, 4, 0)
        lblVolume.Name = "lblVolume"
        lblVolume.Size = New Size(77, 21)
        lblVolume.TabIndex = 1020
        lblVolume.Text = "Volume"
        TipSettingsEX.SetText(lblVolume, Nothing)
        lblVolume.TextAlign = ContentAlignment.BottomLeft
        ' 
        ' chbxAutoHidePlayer
        ' 
        TipSettingsEX.SetImage(chbxAutoHidePlayer, Nothing)
        chbxAutoHidePlayer.Location = New Point(338, 307)
        chbxAutoHidePlayer.Margin = New Padding(4)
        chbxAutoHidePlayer.Name = "chbxAutoHidePlayer"
        chbxAutoHidePlayer.Size = New Size(158, 28)
        chbxAutoHidePlayer.TabIndex = 130
        TipSettingsEX.SetText(chbxAutoHidePlayer, Nothing)
        chbxAutoHidePlayer.Text = "Auto Hide Player"
        chbxAutoHidePlayer.UseVisualStyleBackColor = True
        ' 
        ' lblPlayer
        ' 
        lblPlayer.Font = New Font("Segoe UI", 12F, FontStyle.Bold Or FontStyle.Underline)
        TipSettingsEX.SetImage(lblPlayer, Nothing)
        lblPlayer.Location = New Point(338, 218)
        lblPlayer.Margin = New Padding(4, 0, 4, 0)
        lblPlayer.Name = "lblPlayer"
        lblPlayer.Size = New Size(60, 21)
        lblPlayer.TabIndex = 1022
        lblPlayer.Text = "Player"
        TipSettingsEX.SetText(lblPlayer, Nothing)
        lblPlayer.TextAlign = ContentAlignment.BottomLeft
        ' 
        ' chbxAlwaysHideOnClickVolume
        ' 
        TipSettingsEX.SetImage(chbxAlwaysHideOnClickVolume, Nothing)
        chbxAlwaysHideOnClickVolume.Location = New Point(338, 139)
        chbxAlwaysHideOnClickVolume.Margin = New Padding(4)
        chbxAlwaysHideOnClickVolume.Name = "chbxAlwaysHideOnClickVolume"
        chbxAlwaysHideOnClickVolume.Size = New Size(186, 28)
        chbxAlwaysHideOnClickVolume.TabIndex = 129
        TipSettingsEX.SetText(chbxAlwaysHideOnClickVolume, Nothing)
        chbxAlwaysHideOnClickVolume.Text = "Always Hide On Click"
        chbxAlwaysHideOnClickVolume.UseVisualStyleBackColor = True
        ' 
        ' txbxPlayerOutputCurrentPath
        ' 
        TipSettingsEX.SetImage(txbxPlayerOutputCurrentPath, Nothing)
        txbxPlayerOutputCurrentPath.Location = New Point(824, 422)
        txbxPlayerOutputCurrentPath.Margin = New Padding(4)
        txbxPlayerOutputCurrentPath.Name = "txbxPlayerOutputCurrentPath"
        txbxPlayerOutputCurrentPath.ShortcutsEnabled = False
        txbxPlayerOutputCurrentPath.Size = New Size(386, 29)
        txbxPlayerOutputCurrentPath.TabIndex = 183
        TipSettingsEX.SetText(txbxPlayerOutputCurrentPath, "Path")
        txbxPlayerOutputCurrentPath.Text = "OutputCurrentSelectionPath"
        ' 
        ' lblPlayerOutputCurrentPath
        ' 
        lblPlayerOutputCurrentPath.Font = New Font("Segoe UI", 12F, FontStyle.Bold Or FontStyle.Underline, GraphicsUnit.Point, CByte(0))
        TipSettingsEX.SetImage(lblPlayerOutputCurrentPath, Nothing)
        lblPlayerOutputCurrentPath.Location = New Point(841, 398)
        lblPlayerOutputCurrentPath.Margin = New Padding(4, 0, 4, 0)
        lblPlayerOutputCurrentPath.Name = "lblPlayerOutputCurrentPath"
        lblPlayerOutputCurrentPath.Size = New Size(213, 21)
        lblPlayerOutputCurrentPath.TabIndex = 1025
        lblPlayerOutputCurrentPath.Text = "Output Current Selection"
        TipSettingsEX.SetText(lblPlayerOutputCurrentPath, Nothing)
        lblPlayerOutputCurrentPath.TextAlign = ContentAlignment.BottomLeft
        ' 
        ' chbxPlayerOutputCurrent
        ' 
        TipSettingsEX.SetImage(chbxPlayerOutputCurrent, Nothing)
        chbxPlayerOutputCurrent.Location = New Point(824, 398)
        chbxPlayerOutputCurrent.Margin = New Padding(4)
        chbxPlayerOutputCurrent.Name = "chbxPlayerOutputCurrent"
        chbxPlayerOutputCurrent.Size = New Size(21, 28)
        chbxPlayerOutputCurrent.TabIndex = 182
        TipSettingsEX.SetText(chbxPlayerOutputCurrent, Nothing)
        chbxPlayerOutputCurrent.UseVisualStyleBackColor = True
        ' 
        ' txbxSMPath
        ' 
        TipSettingsEX.SetImage(txbxSMPath, Nothing)
        txbxSMPath.Location = New Point(824, 345)
        txbxSMPath.Margin = New Padding(4)
        txbxSMPath.Name = "txbxSMPath"
        txbxSMPath.ShortcutsEnabled = False
        txbxSMPath.Size = New Size(386, 29)
        txbxSMPath.TabIndex = 175
        TipSettingsEX.SetText(txbxSMPath, "Path")
        txbxSMPath.Text = "SMPath"
        ' 
        ' lblSM
        ' 
        lblSM.Font = New Font("Segoe UI", 12F, FontStyle.Bold Or FontStyle.Underline)
        TipSettingsEX.SetImage(lblSM, Nothing)
        lblSM.Location = New Point(823, 322)
        lblSM.Margin = New Padding(4, 0, 4, 0)
        lblSM.Name = "lblSM"
        lblSM.Size = New Size(213, 21)
        lblSM.TabIndex = 1028
        lblSM.Text = "Skye Music"
        TipSettingsEX.SetText(lblSM, Nothing)
        lblSM.TextAlign = ContentAlignment.BottomLeft
        ' 
        ' txbxVLCPath
        ' 
        TipSettingsEX.SetImage(txbxVLCPath, Nothing)
        txbxVLCPath.Location = New Point(823, 240)
        txbxVLCPath.Margin = New Padding(4)
        txbxVLCPath.Name = "txbxVLCPath"
        txbxVLCPath.ShortcutsEnabled = False
        txbxVLCPath.Size = New Size(386, 29)
        txbxVLCPath.TabIndex = 166
        TipSettingsEX.SetText(txbxVLCPath, "Path")
        txbxVLCPath.Text = "VLCPath"
        ' 
        ' lblVLC
        ' 
        lblVLC.Font = New Font("Segoe UI", 12F, FontStyle.Bold Or FontStyle.Underline)
        TipSettingsEX.SetImage(lblVLC, Nothing)
        lblVLC.Location = New Point(821, 217)
        lblVLC.Margin = New Padding(4, 0, 4, 0)
        lblVLC.Name = "lblVLC"
        lblVLC.Size = New Size(213, 21)
        lblVLC.TabIndex = 1036
        lblVLC.Text = "VLC"
        TipSettingsEX.SetText(lblVLC, Nothing)
        lblVLC.TextAlign = ContentAlignment.BottomLeft
        ' 
        ' txbxMPCPath
        ' 
        TipSettingsEX.SetImage(txbxMPCPath, Nothing)
        txbxMPCPath.Location = New Point(823, 189)
        txbxMPCPath.Margin = New Padding(4)
        txbxMPCPath.Name = "txbxMPCPath"
        txbxMPCPath.ShortcutsEnabled = False
        txbxMPCPath.Size = New Size(386, 29)
        txbxMPCPath.TabIndex = 163
        TipSettingsEX.SetText(txbxMPCPath, "Path")
        txbxMPCPath.Text = "MPCPath"
        ' 
        ' lblMPC
        ' 
        lblMPC.Font = New Font("Segoe UI", 12F, FontStyle.Bold Or FontStyle.Underline)
        TipSettingsEX.SetImage(lblMPC, Nothing)
        lblMPC.Location = New Point(821, 166)
        lblMPC.Margin = New Padding(4, 0, 4, 0)
        lblMPC.Name = "lblMPC"
        lblMPC.Size = New Size(213, 21)
        lblMPC.TabIndex = 1034
        lblMPC.Text = "MPC-HC"
        TipSettingsEX.SetText(lblMPC, Nothing)
        lblMPC.TextAlign = ContentAlignment.BottomLeft
        ' 
        ' LblSaveEars
        ' 
        LblSaveEars.Font = New Font("Segoe UI", 12F, FontStyle.Bold Or FontStyle.Underline, GraphicsUnit.Point, CByte(0))
        TipSettingsEX.SetImage(LblSaveEars, Nothing)
        LblSaveEars.Location = New Point(334, 429)
        LblSaveEars.Margin = New Padding(4, 0, 4, 0)
        LblSaveEars.Name = "LblSaveEars"
        LblSaveEars.Size = New Size(213, 21)
        LblSaveEars.TabIndex = 1037
        LblSaveEars.Text = "Save Ears"
        TipSettingsEX.SetText(LblSaveEars, Nothing)
        LblSaveEars.TextAlign = ContentAlignment.BottomLeft
        ' 
        ' TipSettingsEX
        ' 
        TipSettingsEX.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TipSettingsEX.ShadowAlpha = 0
        TipSettingsEX.ShadowThickness = 0
        ' 
        ' CoBoxTheme
        ' 
        CoBoxTheme.BorderStyle = Skye.UI.ComboBox.ComboBorderStyle.Fixed3D
        CoBoxTheme.DropDownStyle = ComboBoxStyle.DropDownList
        CoBoxTheme.FormattingEnabled = True
        TipSettingsEX.SetImage(CoBoxTheme, Nothing)
        CoBoxTheme.Location = New Point(823, 519)
        CoBoxTheme.Name = "CoBoxTheme"
        CoBoxTheme.Size = New Size(155, 30)
        CoBoxTheme.TabIndex = 302
        TipSettingsEX.SetText(CoBoxTheme, Nothing)
        ' 
        ' LblTheme
        ' 
        LblTheme.Font = New Font("Segoe UI", 12F, FontStyle.Bold Or FontStyle.Underline, GraphicsUnit.Point, CByte(0))
        TipSettingsEX.SetImage(LblTheme, Nothing)
        LblTheme.Location = New Point(824, 471)
        LblTheme.Name = "LblTheme"
        LblTheme.Size = New Size(154, 23)
        LblTheme.TabIndex = 1039
        LblTheme.Text = "Theme"
        TipSettingsEX.SetText(LblTheme, Nothing)
        LblTheme.TextAlign = ContentAlignment.BottomLeft
        ' 
        ' ChBoxTheme
        ' 
        ChBoxTheme.AutoSize = True
        TipSettingsEX.SetImage(ChBoxTheme, Nothing)
        ChBoxTheme.Location = New Point(824, 494)
        ChBoxTheme.Name = "ChBoxTheme"
        ChBoxTheme.Size = New Size(161, 25)
        ChBoxTheme.TabIndex = 300
        TipSettingsEX.SetText(ChBoxTheme, Nothing)
        ChBoxTheme.Text = "Use System Theme"
        ChBoxTheme.UseVisualStyleBackColor = True
        ' 
        ' Settings
        ' 
        AutoScaleDimensions = New SizeF(9F, 21F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1248, 657)
        Controls.Add(chbxHotKeys)
        Controls.Add(CoBoxTheme)
        Controls.Add(grbxVolumePlacement)
        Controls.Add(grbxPlayerPlacement)
        Controls.Add(LblSaveEars)
        Controls.Add(tbarZoneBlue)
        Controls.Add(tbarZoneRed)
        Controls.Add(txbxZoneRed)
        Controls.Add(txbxZoneBlue)
        Controls.Add(btnHelp)
        Controls.Add(btnLog)
        Controls.Add(btnDisableLockKeys)
        Controls.Add(chbxAlwaysHideOnClickVolume)
        Controls.Add(txbxViewerPath)
        Controls.Add(lblPlayer)
        Controls.Add(txbxAutoHideRatePlayer)
        Controls.Add(txbxAutoHideRateVolume)
        Controls.Add(lblVolume)
        Controls.Add(txbxAutoHideIntervalVolume)
        Controls.Add(grbxHotKeys)
        Controls.Add(chbxShowMeters)
        Controls.Add(lblSysVC)
        Controls.Add(txbxSysVCPath)
        Controls.Add(btnSysVCPath)
        Controls.Add(lsbxSaveEarsApps)
        Controls.Add(btnSaveEarsAppsAdd)
        Controls.Add(txbxSaveEarsInterval)
        Controls.Add(txbxSaveEarsVolume)
        Controls.Add(lblSaveEarsVolume)
        Controls.Add(lblViewer)
        Controls.Add(txbxViewerName)
        Controls.Add(txbxAutoHideIntervalPlayer)
        Controls.Add(lblUnMuteOnVolumeChange)
        Controls.Add(cobxUnMuteOnVolumeChange)
        Controls.Add(btnDefaults)
        Controls.Add(lblZones)
        Controls.Add(btnSave)
        Controls.Add(btnRestore)
        Controls.Add(btnClose)
        Controls.Add(btnViewerPath)
        Controls.Add(lblSaveEarsInterval)
        Controls.Add(btnSaveEarsAppsRemove)
        Controls.Add(chbxAutoShowPlayer)
        Controls.Add(chbxAutoHideWithFadePlayer)
        Controls.Add(chbxAutoHideWithFadeVolume)
        Controls.Add(lblSaveEarsApps)
        Controls.Add(chbxAutoHideVolume)
        Controls.Add(chbxAutoHidePlayer)
        Controls.Add(txbxPlayerOutputCurrentPath)
        Controls.Add(btnPlayerOutputCurrentPath)
        Controls.Add(chbxPlayerOutputCurrent)
        Controls.Add(lblPlayerOutputCurrentPath)
        Controls.Add(txbxVLCPath)
        Controls.Add(btnVLCPath)
        Controls.Add(txbxMPCPath)
        Controls.Add(btnMPCPath)
        Controls.Add(lblMPC)
        Controls.Add(txbxSMPath)
        Controls.Add(btnSMPath)
        Controls.Add(txbxWAPath)
        Controls.Add(btnWAPath)
        Controls.Add(lblWA)
        Controls.Add(lblVLC)
        Controls.Add(lblSM)
        Controls.Add(LblTheme)
        Controls.Add(ChBoxTheme)
        DoubleBuffered = True
        Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        FormBorderStyle = FormBorderStyle.Fixed3D
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        TipSettingsEX.SetImage(Me, Nothing)
        KeyPreview = True
        Margin = New Padding(4)
        MaximizeBox = False
        Name = "Settings"
        StartPosition = FormStartPosition.CenterScreen
        TipSettingsEX.SetText(Me, Nothing)
        CType(tbarZoneBlue, ComponentModel.ISupportInitialize).EndInit()
        CType(tbarZoneRed, ComponentModel.ISupportInitialize).EndInit()
        grbxVolumePlacement.ResumeLayout(False)
        grbxPlayerPlacement.ResumeLayout(False)
        grbxHotKeys.ResumeLayout(False)
        grbxHotKeys.PerformLayout()
        cmSaveEarsApps.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Private WithEvents chbxPlayerOutputCurrent As System.Windows.Forms.CheckBox
    Private lblPlayerOutputCurrentPath As System.Windows.Forms.Label
    Private WithEvents btnPlayerOutputCurrentPath As System.Windows.Forms.Button
    Private WithEvents txbxPlayerOutputCurrentPath As System.Windows.Forms.TextBox
    Private WithEvents chbxAlwaysHideOnClickVolume As System.Windows.Forms.CheckBox
    Private WithEvents txbxAutoHideIntervalPlayer As System.Windows.Forms.TextBox
    Private WithEvents txbxAutoHideIntervalVolume As System.Windows.Forms.TextBox
    Private WithEvents chbxAutoHideWithFadeVolume As System.Windows.Forms.CheckBox
    Private WithEvents chbxAutoHideWithFadePlayer As System.Windows.Forms.CheckBox
    Private WithEvents txbxAutoHideRateVolume As System.Windows.Forms.TextBox
    Private WithEvents txbxAutoHideRatePlayer As System.Windows.Forms.TextBox
    Private WithEvents chbxAutoHideVolume As System.Windows.Forms.CheckBox
    Private WithEvents chbxAutoHidePlayer As System.Windows.Forms.CheckBox
    Private lblPlayer As System.Windows.Forms.Label
	Private lblVolume As System.Windows.Forms.Label
	Private lblSysVC As System.Windows.Forms.Label
    Private WithEvents txbxSysVCPath As System.Windows.Forms.TextBox
    Private WithEvents btnSysVCPath As System.Windows.Forms.Button
    Private lblWA As System.Windows.Forms.Label
    Private WithEvents txbxWAPath As System.Windows.Forms.TextBox
    Private WithEvents btnWAPath As System.Windows.Forms.Button
    Private WithEvents chbxShowMeters As System.Windows.Forms.CheckBox
    Private WithEvents cmSaveEarsApps As System.Windows.Forms.ContextMenuStrip
    Private WithEvents cmiSaveEarsAppsRemoveApp As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents cmiSaveEarsAppsAddApp As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents btnSaveEarsAppsRemove As System.Windows.Forms.Button
    Private WithEvents btnSaveEarsAppsAdd As System.Windows.Forms.Button
    Private WithEvents lsbxSaveEarsApps As System.Windows.Forms.ListBox
    Private WithEvents txbxSaveEarsInterval As System.Windows.Forms.TextBox
    Private WithEvents txbxSaveEarsVolume As System.Windows.Forms.TextBox
    Private lblSaveEarsApps As System.Windows.Forms.Label
	Private lblSaveEarsInterval As System.Windows.Forms.Label
	Private lblSaveEarsVolume As System.Windows.Forms.Label
    Private WithEvents btnViewerPath As System.Windows.Forms.Button
    Private WithEvents txbxViewerPath As System.Windows.Forms.TextBox
    Private WithEvents txbxViewerName As System.Windows.Forms.TextBox
    Private lblViewer As System.Windows.Forms.Label
    Private WithEvents btnHotKeysSet As System.Windows.Forms.Button
    Private WithEvents btnHotKeysUndo As System.Windows.Forms.Button
    Private WithEvents btnHotKeyPlayerInfoDisable As System.Windows.Forms.Button
    Private WithEvents btnHotKeyViewerDisable As System.Windows.Forms.Button
    Private WithEvents btnHotKeyVolumeInfoDisable As System.Windows.Forms.Button
    Private WithEvents chbxHotKeys As System.Windows.Forms.CheckBox
    Private lblHotKeyViewer As System.Windows.Forms.Label
    Private WithEvents txbxHotKeyViewer As System.Windows.Forms.TextBox
    Private lblHotKeyPlayerInfo As System.Windows.Forms.Label
    Private WithEvents txbxHotKeyPlayerInfo As System.Windows.Forms.TextBox
    Private WithEvents txbxHotKeyVolumeInfo As System.Windows.Forms.TextBox
    Private lblHotKeyVolumeInfo As System.Windows.Forms.Label
	Private grbxHotKeys As System.Windows.Forms.GroupBox
    Private WithEvents chbxAutoShowPlayer As System.Windows.Forms.CheckBox
    Private lblUnMuteOnVolumeChange As System.Windows.Forms.Label
    Private WithEvents cobxUnMuteOnVolumeChange As System.Windows.Forms.ComboBox
    Private WithEvents radbtnPlayerPlacementManual As System.Windows.Forms.RadioButton
    Private WithEvents radbtnPlayerPlacementCenter As System.Windows.Forms.RadioButton
    Private WithEvents radbtnPlayerPlacementLeftCenterTop As System.Windows.Forms.RadioButton
    Private WithEvents radbtnPlayerPlacementBottomLeft As System.Windows.Forms.RadioButton
    Private WithEvents radbtnPlayerPlacementRightCenterTop As System.Windows.Forms.RadioButton
    Private WithEvents radbtnPlayerPlacementRightCenterBottom As System.Windows.Forms.RadioButton
    Private WithEvents radbtnPlayerPlacementBottomCenterRight As System.Windows.Forms.RadioButton
    Private WithEvents radbtnPlayerPlacementBottomCenterLeft As System.Windows.Forms.RadioButton
    Private WithEvents radbtnPlayerPlacementBottomRight As System.Windows.Forms.RadioButton
    Private WithEvents radbtnPlayerPlacementLeftCenterBottom As System.Windows.Forms.RadioButton
    Private WithEvents radbtnPlayerPlacementBottomCenter As System.Windows.Forms.RadioButton
    Private WithEvents radbtnPlayerPlacementTopCenterLeft As System.Windows.Forms.RadioButton
    Private WithEvents radbtnPlayerPlacementTopCenter As System.Windows.Forms.RadioButton
    Private WithEvents radbtnPlayerPlacementTopRight As System.Windows.Forms.RadioButton
    Private WithEvents radbtnPlayerPlacementTopCenterRight As System.Windows.Forms.RadioButton
    Private WithEvents radbtnPlayerPlacementRightCenter As System.Windows.Forms.RadioButton
    Private WithEvents radbtnPlayerPlacementTopLeft As System.Windows.Forms.RadioButton
    Private WithEvents radbtnPlayerPlacementLeftCenter As System.Windows.Forms.RadioButton
    Private grbxPlayerPlacement As System.Windows.Forms.GroupBox
    Private WithEvents tbarZoneBlue As System.Windows.Forms.TrackBar
    Private WithEvents tbarZoneRed As System.Windows.Forms.TrackBar
    Private WithEvents txbxZoneBlue As System.Windows.Forms.TextBox
    Private WithEvents txbxZoneRed As System.Windows.Forms.TextBox
    Private WithEvents radbtnVolumePlacementLeftCenterTop As System.Windows.Forms.RadioButton
    Private WithEvents radbtnVolumePlacementBottomLeft As System.Windows.Forms.RadioButton
    Private WithEvents radbtnVolumePlacementRightCenterTop As System.Windows.Forms.RadioButton
    Private WithEvents radbtnVolumePlacementRightCenterBottom As System.Windows.Forms.RadioButton
    Private WithEvents radbtnVolumePlacementBottomCenterRight As System.Windows.Forms.RadioButton
    Private WithEvents radbtnVolumePlacementBottomCenterLeft As System.Windows.Forms.RadioButton
    Private WithEvents radbtnVolumePlacementBottomRight As System.Windows.Forms.RadioButton
    Private WithEvents radbtnVolumePlacementLeftCenterBottom As System.Windows.Forms.RadioButton
    Private WithEvents radbtnVolumePlacementBottomCenter As System.Windows.Forms.RadioButton
    Private WithEvents radbtnVolumePlacementLeftCenter As System.Windows.Forms.RadioButton
    Private WithEvents radbtnVolumePlacementTopCenterLeft As System.Windows.Forms.RadioButton
    Private WithEvents radbtnVolumePlacementTopCenter As System.Windows.Forms.RadioButton
    Private WithEvents radbtnVolumePlacementTopRight As System.Windows.Forms.RadioButton
    Private WithEvents radbtnVolumePlacementTopCenterRight As System.Windows.Forms.RadioButton
    Private WithEvents radbtnVolumePlacementRightCenter As System.Windows.Forms.RadioButton
    Private WithEvents radbtnVolumePlacementTopLeft As System.Windows.Forms.RadioButton
    Private WithEvents radbtnVolumePlacementManual As System.Windows.Forms.RadioButton
    Private WithEvents radbtnVolumePlacementCenter As System.Windows.Forms.RadioButton
    Private grbxVolumePlacement As System.Windows.Forms.GroupBox
	Private lblZones As System.Windows.Forms.Label
    Private WithEvents btnDefaults As System.Windows.Forms.Button
    Private WithEvents btnRestore As System.Windows.Forms.Button
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents txbxSMPath As TextBox
	Private WithEvents btnSMPath As Button
	Private WithEvents lblSM As Label
    Friend WithEvents btnDisableLockKeys As RadioButton
    Private WithEvents txbxVLCPath As TextBox
    Private WithEvents btnVLCPath As Button
    Private WithEvents lblVLC As Label
    Private WithEvents txbxMPCPath As TextBox
    Private WithEvents btnMPCPath As Button
    Private WithEvents lblMPC As Label
    Private WithEvents btnLog As Button
    Private WithEvents btnHelp As Button
    Private WithEvents LblSaveEars As Label
    Friend WithEvents TipSettingsEX As Skye.UI.ToolTipEX
    Friend WithEvents CoBoxTheme As Skye.UI.ComboBox
    Friend WithEvents LblTheme As Skye.UI.Label
    Friend WithEvents ChBoxTheme As CheckBox
End Class