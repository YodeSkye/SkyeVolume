
Imports Skye.UI

Namespace My

	Public Module App

		' DECLARATIONS
		Friend Class SettingsType

			Friend Enum UnMuteOnVolumeChangeWhen
				Never
				OnIncrease
				OnDecrease
				Always
			End Enum
			Friend Shared Function UnMuteOnVolumeChangeWhenToString(val As UnMuteOnVolumeChangeWhen) As String
				Select Case val
					Case UnMuteOnVolumeChangeWhen.Never : UnMuteOnVolumeChangeWhenToString = "Never"
					Case UnMuteOnVolumeChangeWhen.OnIncrease : UnMuteOnVolumeChangeWhenToString = "On Increase"
					Case UnMuteOnVolumeChangeWhen.OnDecrease : UnMuteOnVolumeChangeWhenToString = "On Decrease"
					Case UnMuteOnVolumeChangeWhen.Always : UnMuteOnVolumeChangeWhenToString = "Always"
					Case Else : UnMuteOnVolumeChangeWhenToString = "UnKnown Value"
				End Select
			End Function
			Friend Enum Placement
				Center
				TopLeft
				TopCenterLeft
				TopCenter
				TopCenterRight
				TopRight
				RightCenterTop
				RightCenter
				RightCenterBottom
				BottomRight
				BottomCenterRight
				BottomCenter
				BottomCenterLeft
				BottomLeft
				LeftCenterBottom
				LeftCenter
				LeftCenterTop
				Manual
			End Enum
			Friend Enum PlayerSizes
				Small
				Medium
				Large
			End Enum
			Friend Structure HotKey
				Dim WinID As Integer
				Dim Description As String
				Dim Key As Keys
				Dim KeyCode As Byte
				Dim KeyMod As Byte
				ReadOnly Property KeyText As String
					Get
						Dim kc As New System.Windows.Forms.KeysConverter
						KeyText = kc.ConvertToString(Key)
					End Get
				End Property
				Sub New(id As Integer, description As String, key As Keys, keycode As Byte, keymod As Byte)
					Me.WinID = id
					Me.Description = description
					Me.Key = key
					Me.KeyCode = keycode
					Me.KeyMod = keymod
				End Sub
			End Structure
			Friend Class DefaultsType
				Public ReadOnly SystemVolumeControlPath As String = My.Application.GetEnvironmentVariable("WINDIR") + "\SYSTEM32\SndVol.exe"
				Public ReadOnly ShowMeters As Boolean = True
				Public ReadOnly vStep As Byte = 10
				Public ReadOnly vStepMin As Byte = 5
				Public ReadOnly vStepMax As Byte = 30
				Public ReadOnly vBabyStep As Byte = 1
				Public ReadOnly vBabyStepMin As Byte = 1
				Public ReadOnly vBabyStepMax As Byte = 10
				Public ReadOnly vBlueZone As Byte = 30
				Public ReadOnly vBlueZoneMin As Byte = 1
				Public ReadOnly vBlueZoneMax As Byte = 99
				Public ReadOnly vRedZone As Byte = 71
				Public ReadOnly vRedZoneMin As Byte = 2
				Public ReadOnly vRedZoneMax As Byte = 100
				Public ReadOnly cGreenZone As Color = Color.Teal
				Public ReadOnly cBlueZone As Color = Color.RoyalBlue
				Public ReadOnly cRedZone As Color = Color.Firebrick
				Public ReadOnly vSaveEars As Byte = 3
				Public ReadOnly SaveEarsInterval As Byte = 10
				Public ReadOnly SaveEarsIntervalMin As Byte = 0
				Public ReadOnly SaveEarsIntervalMax As Byte = 180
				Public ReadOnly SaveEarsApps As Collections.ObjectModel.ReadOnlyCollection(Of String)
				Public ReadOnly UnMuteOnVolumeChange As UnMuteOnVolumeChangeWhen = UnMuteOnVolumeChangeWhen.OnIncrease
				Public ReadOnly AlwaysHideOnClickVolume As Boolean = False
				Public ReadOnly AutoHideVolume As Boolean = True
				Public ReadOnly AutoHidePlayer As Boolean = True
				Public ReadOnly AutoHideIntervalVolume As UShort = 4
				Public ReadOnly AutoHideIntervalVolumeMin As UShort = 1
				Public ReadOnly AutoHideIntervalVolumeMax As UShort = 600
				Public ReadOnly AutoHideIntervalPlayer As UShort = 4
				Public ReadOnly AutoHideIntervalPlayerMin As UShort = 1
				Public ReadOnly AutoHideIntervalPlayerMax As UShort = 600
				Public ReadOnly AutoHideWithFadeVolume As Boolean = False
				Public ReadOnly AutoHideWithFadePlayer As Boolean = False
				Public ReadOnly AutoHideRateVolume As UShort = 5
				Public ReadOnly AutoHideRateVolumeMin As UShort = 1
				Public ReadOnly AutoHideRateVolumeMax As UShort = 100
				Public ReadOnly AutoHideRatePlayer As UShort = 5
				Public ReadOnly AutoHideRatePlayerMin As UShort = 1
				Public ReadOnly AutoHideRatePlayerMax As UShort = 100
				Public ReadOnly PlacementVolume As Placement = Placement.BottomCenter
				Public ReadOnly PlacementPlayer As Placement = Placement.TopRight
				Public ReadOnly LocationVolume As New Point(100, 100)
				Public ReadOnly LocationPlayer As New Point(100, 200)
				Public ReadOnly PlayerAutoShow As Boolean = True
				Public ReadOnly PlayerOutputCurrent As Boolean = False
				Public ReadOnly PlayerOutputCurrentPath As String = App.UserPath + My.Application.Info.ProductName + "CurrentSelection.txt"
				Public ReadOnly AppPathMPC As String = "C:\Program Files\MPC-HC\mpc-hc64.exe"
				Public ReadOnly AppPathVLC As String = "C:\Program Files\VLC\vlc.exe"
				Public ReadOnly AppPathWA As String = "C:\Program Files\Winamp\winamp.exe"
				Public ReadOnly AppPathSM As String = "C:\Program Files\Skye\SkyeMusic\SkyeMusic.exe"
				Public ReadOnly ViewerName As String = "SkyeTag"
				Public ReadOnly ViewerPath As String = "C:\Program Files\Skye\SkyeTag\SkyeTag.exe"
				Public ReadOnly PlayerSize As PlayerSizes = PlayerSizes.Medium
				Public ReadOnly HotKeysEnabled As Boolean = True
				Public ReadOnly HotKeyVolume As New HotKey(1, "Show Volume", Keys.Alt Or Keys.V, CByte(Keys.V), Skye.WinAPI.MOD_ALT)
				Public ReadOnly HotKeyPlayer As New HotKey(2, "Show Player Info", Keys.Control Or Keys.OemQuestion, CByte(Keys.OemQuestion), Skye.WinAPI.MOD_CONTROL)
				Public ReadOnly HotKeyViewer As New HotKey(3, "Show Viewer", Keys.Alt Or Keys.OemQuestion, CByte(Keys.OemQuestion), Skye.WinAPI.MOD_ALT)
				Public ReadOnly HotKeys As Collections.ObjectModel.ReadOnlyCollection(Of HotKey)
				Public ReadOnly UseSystemTheme As Boolean = True
				Public ReadOnly SelectedTheme As Theme = Theme.Light
				Private ReadOnly SaveEarsAppList As New Collections.Generic.List(Of String)
				Private ReadOnly HotKeysList As New Collections.Generic.List(Of HotKey)
				Public Sub New()
					SaveEarsAppList.Add("SKYEMUSIC.EXE".ToUpper)
					SaveEarsAppList.Add("WINAMP.EXE".ToUpper)
					SaveEarsAppList.Add("MPC-HC.EXE".ToUpper)
					SaveEarsAppList.Add("VLC.EXE".ToUpper)
					SaveEarsApps = SaveEarsAppList.AsReadOnly
					HotKeysList.Add(HotKeyVolume)
					HotKeysList.Add(HotKeyPlayer)
					HotKeysList.Add(HotKeyViewer)
					HotKeys = HotKeysList.AsReadOnly
				End Sub
			End Class
			Friend Defaults As New DefaultsType
			Friend HotKeys As New Collections.Generic.List(Of HotKey)
			Friend NeedsSaved As Boolean = False
			Friend Sub SetSave()
				NeedsSaved = True
				ShowSave()
			End Sub
			<CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static")>
			Friend Sub ShowSave()
				If FrmSettings IsNot Nothing Then FrmSettings.ShowSave()
				If FrmVolume IsNot Nothing Then FrmVolume.ShowSave()
			End Sub

			' Saved Settings
			Friend SystemVolumeControlPath As String
			Friend ShowMeters As Boolean
			Friend vStep As Byte 'Range = 5-30
			Friend vBabyStep As Byte 'Range = 1-10
			Friend vBlueZone As Byte 'Start Of Blue Zone, Range = 1-99, < vRedZone
			Friend vRedZone As Byte 'Start Of Red Zone, Range = 2-100, > vBlueZone
			Friend cGreenZone As Color
			Friend cBlueZone As Color
			Friend cRedZone As Color
			Friend vSaveEars As Byte 'Range = 0 To vBlueZone - 1
			Friend SaveEarsInterval As Byte 'In Minutes, Range = 0 To 180, 0 = Disabled
			Friend SaveEarsApps As New Collections.Generic.List(Of String)
			Friend UnMuteOnVolumeChange As UnMuteOnVolumeChangeWhen
			Friend AlwaysHideOnClickVolume As Boolean
			Friend AutoHideVolume As Boolean
			Friend AutoHidePlayer As Boolean
			Friend AutoHideIntervalVolume As UShort 'In Seconds, Range = 0 To 600, 0 = Disabled
			Friend AutoHideIntervalPlayer As UShort 'In Seconds, Range = 0 To 600, 0 = Disabled
			Friend AutoHideWithFadeVolume As Boolean
			Friend AutoHideWithFadePlayer As Boolean
			Friend AutoHideRateVolume As UShort 'Range = 2 - 2000
			Friend AutoHideRatePlayer As UShort 'Range = 2 - 2000
			Friend PlacementVolume As Placement
			Friend PlacementPlayer As Placement
			Friend LocationVolume As Point
			Friend LocationPlayer As Point
			Friend PlayerAutoShow As Boolean
			Friend PlayerOutputCurrent As Boolean
			Friend PlayerOutputCurrentPath As String
			Friend AppPathMPC As String
			Friend AppPathVLC As String
			Friend AppPathWA As String
			Friend AppPathSM As String
			Friend ViewerName As String
			Friend ViewerPath As String
			Friend PlayerSize As PlayerSizes
			Friend HotKeysEnabled As Boolean
			Friend HotKeyVolume As New HotKey
			Friend HotKeyPlayer As New HotKey
			Friend HotKeyViewer As New HotKey
			Friend UseSystemTheme As Boolean
			Friend SelectedTheme As Theme

		End Class
		Friend Settings As SettingsType
		Friend CurrentSelectionPath As String
		Friend FrmMain As MainForm
		Friend FrmVolume As Volume
		Friend FrmPlayer As Player
		Friend FrmSettings As Settings
		Private FrmHelp As Help
		Friend FrmLog As Log
		Friend Enum Theme
			Light
			Dark
		End Enum
		Friend CurrentTheme As Theme
		Friend Event ThemeChanged(theme As Theme)
		Private cChangeTimeForSaveEars As DateTime
		Private ReadOnly TimerSaveEars As New System.Timers.Timer
		Friend Const AdjustScreenBoundsNormalWindow As Byte = 8
		Friend Const AdjustScreenBoundsDialogWindow As Byte = 10
		Friend ReadOnly TipFont As New Font("Segoe UI", 12, FontStyle.Regular) 'Font for custom drawing of tooltips
		Friend ReadOnly TipBackColor As Color = Color.WhiteSmoke
		Friend ReadOnly TipTextColor As Color = Color.Black
		Friend ReadOnly TipBorderColor As Color = Color.White
		Friend ReadOnly PlacementMargin As Integer = 20
		Private ReadOnly UserPath As String = Skye.Common.StorageManager.GetAppDirectory 'UserPath is the base path for user-specific files.

		' HANDLERS
		Private Sub TimerSaveEarsTick(sender As Object, e As EventArgs)
			If FrmVolume?.GetVolume >= My.Settings.vRedZone Then
				If cChangeTimeForSaveEars.AddMinutes(My.Settings.SaveEarsInterval) <= My.Computer.Clock.LocalTime Then 'Works based on time of last change to Volume or any of the Locks.
					If Skye.WinAPI.GetIdleTime >= TimeSpan.FromMinutes(My.Settings.SaveEarsInterval).TotalMilliseconds Then 'Works based on system idle tiMe. 'Both are required because changing the volume does not reset the Windoze Idle Timer.
						If Not CheckFullScreen() Then 'Works based on whether the Foreground Window is in FullScreen Mode and is one of the Apps in SaveEarsApps.
							If My.Settings.vSaveEars < My.Settings.vBlueZone Then : FrmVolume.SetVolume(My.Settings.vSaveEars)
							Else : FrmVolume.SetVolume(CByte(My.Settings.vBlueZone - 1))
							End If
							Skye.Common.Log.Write("SaveEars Executed")
						End If
					End If
				End If
			End If
		End Sub

		' METHODS
		Friend Sub Initialize()
#If DEBUG Then
			Skye.Common.Log.Initialize(My.Application.Info.ProductName + "DEV") ' Initialize the logging system with a specific name for the debug version.
			Skye.Common.RegistryHelper.BaseKey = "Software\\" + My.Application.Info.ProductName + "DEV" ' Set the base registry key for the debug version.
#Else
            Skye.Common.Log.Initialize(My.Application.Info.ProductName) ' Initialize the logging system with a specific name.
            Skye.Common.RegistryHelper.BaseKey = "Software\\" + My.Application.Info.ProductName ' Set the base registry key.
#End If
			Skye.Common.Log.Write(My.Application.Info.ProductName + " Started")

			' Check for storage lockout
			If String.IsNullOrEmpty(App.UserPath) Then
				MessageBox.Show(
				$"Critical Error: {My.Application.Info.ProductName} was unable to access its local storage directory." & vbCrLf & vbCrLf &
				"This is usually caused by temporary file locks, security software, or folder permission issues." & vbCrLf & vbCrLf &
				"The application will now exit.",
				$"{My.Application.Info.ProductName} - Storage Access Error",
				MessageBoxButtons.OK,
				MessageBoxIcon.Stop
			)
				' Cleanly terminate startup before any modules try to load broken paths
				Environment.Exit(1)
				Return
			End If

			GetSettings()
			If Settings.UseSystemTheme Then
				ApplyTheme(GetWindowsTheme())
			Else
				ApplyTheme(Settings.SelectedTheme)
			End If
			FrmMain = New MainForm
			ShowVolume()
			If My.Settings.PlayerAutoShow Then ShowPlayer()
			If Settings.HotKeysEnabled Then RegisterHotKeys(True)
			TimerSaveEars.Interval = 1000
			AddHandler TimerSaveEars.Elapsed, AddressOf TimerSaveEarsTick
			SetSaveEars()
#If DEBUG Then
			ShowSettings()
#Else
#End If
		End Sub
		Friend Sub Finalize(Optional restart As Boolean = False)
			If Settings.HotKeysEnabled Then RegisterHotKeys(False)
			If FrmHelp IsNot Nothing Then FrmHelp.Close()
			If FrmLog IsNot Nothing Then FrmLog.Close()
			CloseSettings()
			ClosePlayer()
			CloseVolume()
			FrmMain.Close()
			Skye.Common.Log.Write(My.Application.Info.ProductName + " Closed")
			If restart Then System.Windows.Forms.Application.Restart()
		End Sub
		Friend Sub GetSettings()
			Dim starttime As TimeSpan = Computer.Clock.LocalTime.TimeOfDay
			Settings = New SettingsType
			Try

				Settings.SystemVolumeControlPath = Skye.Common.RegistryHelper.GetString("SystemVolumeControlPath", Settings.Defaults.SystemVolumeControlPath)
				Settings.ShowMeters = Skye.Common.RegistryHelper.GetBool("ShowMeters", Settings.Defaults.ShowMeters)

				' Volume steps
				Settings.vStep = CByte(Skye.Common.RegistryHelper.GetInt("vStep", Settings.Defaults.vStep))
				If Settings.vStep < Settings.Defaults.vStepMin Then Settings.vStep = Settings.Defaults.vStepMin
				If Settings.vStep > Settings.Defaults.vStepMax Then Settings.vStep = Settings.Defaults.vStepMax
				Settings.vBabyStep = CByte(Skye.Common.RegistryHelper.GetInt("vBabyStep", Settings.Defaults.vBabyStep))
				If Settings.vBabyStep < Settings.Defaults.vBabyStepMin Then Settings.vBabyStep = Settings.Defaults.vBabyStepMin
				If Settings.vBabyStep > Settings.Defaults.vBabyStepMax Then Settings.vBabyStep = Settings.Defaults.vBabyStepMax
				Settings.vBlueZone = CByte(Skye.Common.RegistryHelper.GetInt("vBlueZone", Settings.Defaults.vBlueZone))
				If Settings.vBlueZone < Settings.Defaults.vBlueZoneMin Then Settings.vBlueZone = Settings.Defaults.vBlueZoneMin
				If Settings.vBlueZone > Settings.Defaults.vBlueZoneMax Then Settings.vBlueZone = Settings.Defaults.vBlueZoneMax
				Settings.vRedZone = CByte(Skye.Common.RegistryHelper.GetInt("vRedZone", Settings.Defaults.vRedZone))
				If Settings.vRedZone < Settings.Defaults.vRedZoneMin Then Settings.vRedZone = Settings.Defaults.vRedZoneMin
				If Settings.vRedZone > Settings.Defaults.vRedZoneMax Then Settings.vRedZone = Settings.Defaults.vRedZoneMax
				If Settings.vBlueZone >= Settings.vRedZone Then
					Settings.vBlueZone = CByte(Settings.vRedZone - 1)
				End If

				' Colors (ARGB)
				Try
					Settings.cGreenZone = Color.FromArgb(Skye.Common.RegistryHelper.GetInt("cGreenZone", Settings.Defaults.cGreenZone.ToArgb))
				Catch
					Settings.cGreenZone = Settings.Defaults.cGreenZone
				End Try
				Try
					Settings.cBlueZone = Color.FromArgb(Skye.Common.RegistryHelper.GetInt("cBlueZone", Settings.Defaults.cBlueZone.ToArgb))
				Catch
					Settings.cBlueZone = Settings.Defaults.cBlueZone
				End Try
				Try
					Settings.cRedZone = Color.FromArgb(Skye.Common.RegistryHelper.GetInt("cRedZone", Settings.Defaults.cRedZone.ToArgb))
				Catch
					Settings.cRedZone = Settings.Defaults.cRedZone
				End Try

				' SaveEars
				Settings.vSaveEars = CByte(Skye.Common.RegistryHelper.GetInt("vSaveEars", Settings.Defaults.vSaveEars))
				If Settings.vSaveEars >= Settings.vBlueZone Then
					Settings.vSaveEars = CByte(Settings.vBlueZone - 1)
				End If
				Settings.SaveEarsInterval = CByte(Skye.Common.RegistryHelper.GetInt("SaveEarsInterval", Settings.Defaults.SaveEarsInterval))
				If Settings.SaveEarsInterval < Settings.Defaults.SaveEarsIntervalMin Then Settings.SaveEarsInterval = Settings.Defaults.SaveEarsIntervalMin
				If Settings.SaveEarsInterval > Settings.Defaults.SaveEarsIntervalMax Then Settings.SaveEarsInterval = Settings.Defaults.SaveEarsIntervalMax
				Dim arr = Skye.Common.RegistryHelper.GetStringArray("SaveEarsApps", Nothing)
				Settings.SaveEarsApps.Clear()
				If arr IsNot Nothing AndAlso arr.Length > 0 Then
					For Each s In arr
						Settings.SaveEarsApps.Add(s.ToUpperInvariant())
					Next
				Else
					Settings.SaveEarsApps.AddRange(Settings.Defaults.SaveEarsApps.Select(Function(x) x.ToUpperInvariant()))
				End If
				Settings.SaveEarsApps.Sort()

				' UnMuteOnVolumeChange
				Dim rawUnMute = Skye.Common.RegistryHelper.GetString("UnMuteOnVolumeChange", Settings.Defaults.UnMuteOnVolumeChange.ToString)
				Dim parsedUnMute As SettingsType.UnMuteOnVolumeChangeWhen
				If [Enum].TryParse(rawUnMute, parsedUnMute) Then
					Settings.UnMuteOnVolumeChange = parsedUnMute
				Else
					Settings.UnMuteOnVolumeChange = Settings.Defaults.UnMuteOnVolumeChange
				End If

				' Auto-hide
				Settings.AlwaysHideOnClickVolume = Skye.Common.RegistryHelper.GetBool("AlwaysHideOnClickVolume", Settings.Defaults.AlwaysHideOnClickVolume)
				Settings.AutoHideVolume = Skye.Common.RegistryHelper.GetBool("AutoHideVolume", Settings.Defaults.AutoHideVolume)
				Settings.AutoHidePlayer = Skye.Common.RegistryHelper.GetBool("AutoHidePlayer", Settings.Defaults.AutoHidePlayer)
				Settings.AutoHideIntervalVolume = CUShort(Skye.Common.RegistryHelper.GetInt("AutoHideIntervalVolume", Settings.Defaults.AutoHideIntervalVolume))
				If Settings.AutoHideIntervalVolume < Settings.Defaults.AutoHideIntervalVolumeMin Then Settings.AutoHideIntervalVolume = Settings.Defaults.AutoHideIntervalVolumeMin
				If Settings.AutoHideIntervalVolume > Settings.Defaults.AutoHideIntervalVolumeMax Then Settings.AutoHideIntervalVolume = Settings.Defaults.AutoHideIntervalVolumeMax
				Settings.AutoHideIntervalPlayer = CUShort(Skye.Common.RegistryHelper.GetInt("AutoHideIntervalPlayer", Settings.Defaults.AutoHideIntervalPlayer))
				If Settings.AutoHideIntervalPlayer < Settings.Defaults.AutoHideIntervalPlayerMin Then Settings.AutoHideIntervalPlayer = Settings.Defaults.AutoHideIntervalPlayerMin
				If Settings.AutoHideIntervalPlayer > Settings.Defaults.AutoHideIntervalPlayerMax Then Settings.AutoHideIntervalPlayer = Settings.Defaults.AutoHideIntervalPlayerMax
				Settings.AutoHideWithFadeVolume = Skye.Common.RegistryHelper.GetBool("AutoHideWithFadeVolume", Settings.Defaults.AutoHideWithFadeVolume)
				Settings.AutoHideWithFadePlayer = Skye.Common.RegistryHelper.GetBool("AutoHideWithFadePlayer", Settings.Defaults.AutoHideWithFadePlayer)
				Settings.AutoHideRateVolume = CUShort(Skye.Common.RegistryHelper.GetInt("AutoHideRateVolume", Settings.Defaults.AutoHideRateVolume))
				If Settings.AutoHideRateVolume < Settings.Defaults.AutoHideRateVolumeMin Then Settings.AutoHideRateVolume = Settings.Defaults.AutoHideRateVolumeMin
				If Settings.AutoHideRateVolume > Settings.Defaults.AutoHideRateVolumeMax Then Settings.AutoHideRateVolume = Settings.Defaults.AutoHideRateVolumeMax
				Settings.AutoHideRatePlayer = CUShort(Skye.Common.RegistryHelper.GetInt("AutoHideRatePlayer", Settings.Defaults.AutoHideRatePlayer))
				If Settings.AutoHideRatePlayer < Settings.Defaults.AutoHideRatePlayerMin Then Settings.AutoHideRatePlayer = Settings.Defaults.AutoHideRatePlayerMin
				If Settings.AutoHideRatePlayer > Settings.Defaults.AutoHideRatePlayerMax Then Settings.AutoHideRatePlayer = Settings.Defaults.AutoHideRatePlayerMax

				' Placement enums
				Dim rawPlacementVolume = Skye.Common.RegistryHelper.GetString("PlacementVolume", Settings.Defaults.PlacementVolume.ToString)
				Dim parsedPlacementVolume As SettingsType.Placement
				If [Enum].TryParse(rawPlacementVolume, parsedPlacementVolume) Then
					Settings.PlacementVolume = parsedPlacementVolume
				Else
					Settings.PlacementVolume = Settings.Defaults.PlacementVolume
				End If
				Dim rawPlacementPlayer = Skye.Common.RegistryHelper.GetString("PlacementPlayer", Settings.Defaults.PlacementPlayer.ToString)
				Dim parsedPlacementPlayer As SettingsType.Placement
				If [Enum].TryParse(rawPlacementPlayer, parsedPlacementPlayer) Then
					Settings.PlacementPlayer = parsedPlacementPlayer
				Else
					Settings.PlacementPlayer = Settings.Defaults.PlacementPlayer
				End If

				' Window locations
				Settings.LocationVolume.X = Skye.Common.RegistryHelper.GetInt("LocationVolumeX", Settings.Defaults.LocationVolume.X)
				If Settings.LocationVolume.X < My.Computer.Screen.WorkingArea.Left OrElse Settings.LocationVolume.X > My.Computer.Screen.WorkingArea.Right Then
					Settings.LocationVolume.X = Settings.Defaults.LocationVolume.X
				End If
				Settings.LocationVolume.Y = Skye.Common.RegistryHelper.GetInt("LocationVolumeY", Settings.Defaults.LocationVolume.Y)
				If Settings.LocationVolume.Y < My.Computer.Screen.WorkingArea.Top OrElse Settings.LocationVolume.Y > My.Computer.Screen.WorkingArea.Bottom Then
					Settings.LocationVolume.Y = Settings.Defaults.LocationVolume.Y
				End If
				Settings.LocationPlayer.X = Skye.Common.RegistryHelper.GetInt("LocationPlayerX", Settings.Defaults.LocationPlayer.X)
				If Settings.LocationPlayer.X < My.Computer.Screen.WorkingArea.Left OrElse Settings.LocationPlayer.X > My.Computer.Screen.WorkingArea.Right Then
					Settings.LocationPlayer.X = Settings.Defaults.LocationPlayer.X
				End If
				Settings.LocationPlayer.Y = Skye.Common.RegistryHelper.GetInt("LocationPlayerY", Settings.Defaults.LocationPlayer.Y)
				If Settings.LocationPlayer.Y < My.Computer.Screen.WorkingArea.Top OrElse Settings.LocationPlayer.Y > My.Computer.Screen.WorkingArea.Bottom Then
					Settings.LocationPlayer.Y = Settings.Defaults.LocationPlayer.Y
				End If

				' Player auto-show
				Settings.PlayerAutoShow = Skye.Common.RegistryHelper.GetBool("PlayerAutoShow", Settings.Defaults.PlayerAutoShow)

				' Player output
				Settings.PlayerOutputCurrent = Skye.Common.RegistryHelper.GetBool("PlayerOutputCurrent", Settings.Defaults.PlayerOutputCurrent)
				Settings.PlayerOutputCurrentPath = Skye.Common.RegistryHelper.GetString("PlayerOutputCurrentPath", Settings.Defaults.PlayerOutputCurrentPath)

				' App paths
				Settings.AppPathMPC = Skye.Common.RegistryHelper.GetString("AppPathMPC", Settings.Defaults.AppPathMPC)
				Settings.AppPathVLC = Skye.Common.RegistryHelper.GetString("AppPathVLC", Settings.Defaults.AppPathVLC)
				Settings.AppPathWA = Skye.Common.RegistryHelper.GetString("AppPathWA", Settings.Defaults.AppPathWA)
				Settings.AppPathSM = Skye.Common.RegistryHelper.GetString("AppPathSM", Settings.Defaults.AppPathSM)
				Settings.ViewerName = Skye.Common.RegistryHelper.GetString("ViewerName", Settings.Defaults.ViewerName)
				Settings.ViewerPath = Skye.Common.RegistryHelper.GetString("ViewerPath", Settings.Defaults.ViewerPath)

				' Player size (enum)
				Dim rawPlayerSize = Skye.Common.RegistryHelper.GetString("PlayerSize", Settings.Defaults.PlayerSize.ToString)
				Dim parsedPlayerSize As SettingsType.PlayerSizes
				If [Enum].TryParse(rawPlayerSize, parsedPlayerSize) Then
					Settings.PlayerSize = parsedPlayerSize
				Else
					Settings.PlayerSize = Settings.Defaults.PlayerSize
				End If

				' HotKeys
				Settings.HotKeysEnabled = Skye.Common.RegistryHelper.GetBool("HotKeysEnabled", Settings.Defaults.HotKeysEnabled)
				' HotKeyVolume
				Settings.HotKeyVolume = Settings.Defaults.HotKeyVolume
				Try
					Settings.HotKeyVolume.Key = CType(Skye.Common.RegistryHelper.GetInt("HotKeyVolumeKey", Settings.Defaults.HotKeyVolume.Key), Keys)
				Catch
					Settings.HotKeyVolume.Key = Settings.Defaults.HotKeyVolume.Key
				End Try
				Try
					Settings.HotKeyVolume.KeyCode = CByte(Skye.Common.RegistryHelper.GetInt("HotKeyVolumeKeyCode", Settings.Defaults.HotKeyVolume.KeyCode))
				Catch
					Settings.HotKeyVolume.KeyCode = Settings.Defaults.HotKeyVolume.KeyCode
				End Try
				Try
					Settings.HotKeyVolume.KeyMod = CByte(Skye.Common.RegistryHelper.GetInt("HotKeyVolumeKeyMod", Settings.Defaults.HotKeyVolume.KeyMod))
				Catch
					Settings.HotKeyVolume.KeyMod = Settings.Defaults.HotKeyVolume.KeyMod
				End Try
				' HotKeyPlayer
				Settings.HotKeyPlayer = Settings.Defaults.HotKeyPlayer
				Try
					Settings.HotKeyPlayer.Key = CType(Skye.Common.RegistryHelper.GetInt("HotKeyPlayerKey", Settings.Defaults.HotKeyPlayer.Key), Keys)
				Catch
					Settings.HotKeyPlayer.Key = Settings.Defaults.HotKeyPlayer.Key
				End Try
				Try
					Settings.HotKeyPlayer.KeyCode = CByte(Skye.Common.RegistryHelper.GetInt("HotKeyPlayerKeyCode", Settings.Defaults.HotKeyPlayer.KeyCode))
				Catch
					Settings.HotKeyPlayer.KeyCode = Settings.Defaults.HotKeyPlayer.KeyCode
				End Try
				Try
					Settings.HotKeyPlayer.KeyMod = CByte(Skye.Common.RegistryHelper.GetInt("HotKeyPlayerKeyMod", Settings.Defaults.HotKeyPlayer.KeyMod))
				Catch
					Settings.HotKeyPlayer.KeyMod = Settings.Defaults.HotKeyPlayer.KeyMod
				End Try
				' HotKeyViewer
				Settings.HotKeyViewer = Settings.Defaults.HotKeyViewer
				Try
					Settings.HotKeyViewer.Key = CType(Skye.Common.RegistryHelper.GetInt("HotKeyViewerKey", Settings.Defaults.HotKeyViewer.Key), Keys)
				Catch
					Settings.HotKeyViewer.Key = Settings.Defaults.HotKeyViewer.Key
				End Try
				Try
					Settings.HotKeyViewer.KeyCode = CByte(Skye.Common.RegistryHelper.GetInt("HotKeyViewerKeyCode", Settings.Defaults.HotKeyViewer.KeyCode))
				Catch
					Settings.HotKeyViewer.KeyCode = Settings.Defaults.HotKeyViewer.KeyCode
				End Try
				Try
					Settings.HotKeyViewer.KeyMod = CByte(Skye.Common.RegistryHelper.GetInt("HotKeyViewerKeyMod", Settings.Defaults.HotKeyViewer.KeyMod))
				Catch
					Settings.HotKeyViewer.KeyMod = Settings.Defaults.HotKeyViewer.KeyMod
				End Try
				GenerateHotKeyList()

				'Theme
				Settings.UseSystemTheme = Skye.Common.RegistryHelper.GetBool("UseSystemTheme", Settings.Defaults.UseSystemTheme)
				Dim rawTheme = Skye.Common.RegistryHelper.GetString("SelectedTheme", Settings.Defaults.SelectedTheme.ToString)
				Dim parsedTheme As Theme
				If [Enum].TryParse(rawTheme, parsedTheme) Then
					Settings.SelectedTheme = parsedTheme
				Else
					Settings.SelectedTheme = Settings.Defaults.SelectedTheme
				End If

				' Finalize
				GetSettingsDebug()
				Skye.Common.Log.Write("Settings Loaded (" + Skye.Common.GenerateLogTime(starttime, My.Computer.Clock.LocalTime.TimeOfDay, True) + ")")

			Catch ex As Exception
				Skye.Common.Log.Write("Error Loading Settings" & vbCrLf & ex.Message)
			End Try
		End Sub
		Friend Sub GetDefaults()
			Try
				Settings = New SettingsType
				Settings.SystemVolumeControlPath = Settings.Defaults.SystemVolumeControlPath
				Settings.ShowMeters = Settings.Defaults.ShowMeters
				Settings.vStep = Settings.Defaults.vStep
				Settings.vBabyStep = Settings.Defaults.vBabyStep
				Settings.vBlueZone = Settings.Defaults.vBlueZone
				Settings.vRedZone = Settings.Defaults.vRedZone
				Settings.cGreenZone = Settings.Defaults.cGreenZone
				Settings.cBlueZone = Settings.Defaults.cBlueZone
				Settings.cRedZone = Settings.Defaults.cRedZone
				Settings.vSaveEars = Settings.Defaults.vSaveEars
				Settings.SaveEarsInterval = Settings.Defaults.SaveEarsInterval
				Settings.SaveEarsApps.AddRange(Settings.Defaults.SaveEarsApps)
				Settings.UnMuteOnVolumeChange = Settings.Defaults.UnMuteOnVolumeChange
				Settings.AlwaysHideOnClickVolume = Settings.Defaults.AlwaysHideOnClickVolume
				Settings.AutoHideVolume = Settings.Defaults.AutoHideVolume
				Settings.AutoHidePlayer = Settings.Defaults.AutoHidePlayer
				Settings.AutoHideIntervalVolume = Settings.Defaults.AutoHideIntervalVolume
				Settings.AutoHideIntervalPlayer = Settings.Defaults.AutoHideIntervalPlayer
				Settings.AutoHideWithFadeVolume = Settings.Defaults.AutoHideWithFadeVolume
				Settings.AutoHideWithFadePlayer = Settings.Defaults.AutoHideWithFadePlayer
				Settings.AutoHideRateVolume = Settings.Defaults.AutoHideRateVolume
				Settings.AutoHideRatePlayer = Settings.Defaults.AutoHideRatePlayer
				Settings.PlacementVolume = Settings.Defaults.PlacementVolume
				Settings.PlacementPlayer = Settings.Defaults.PlacementPlayer
				Settings.LocationVolume = Settings.Defaults.LocationVolume
				Settings.LocationPlayer = Settings.Defaults.LocationPlayer
				Settings.AppPathMPC = Settings.Defaults.AppPathMPC
				Settings.AppPathVLC = Settings.Defaults.AppPathVLC
				Settings.AppPathWA = Settings.Defaults.AppPathWA
				Settings.AppPathSM = Settings.Defaults.AppPathSM
				Settings.PlayerAutoShow = Settings.Defaults.PlayerAutoShow
				Settings.PlayerOutputCurrent = Settings.Defaults.PlayerOutputCurrent
				Settings.PlayerOutputCurrentPath = Settings.Defaults.PlayerOutputCurrentPath
				Settings.ViewerName = Settings.Defaults.ViewerName
				Settings.ViewerPath = Settings.Defaults.ViewerPath
				Settings.PlayerSize = Settings.Defaults.PlayerSize
				Settings.HotKeysEnabled = Settings.Defaults.HotKeysEnabled
				Settings.HotKeyVolume = Settings.Defaults.HotKeyVolume
				Settings.HotKeyPlayer = Settings.Defaults.HotKeyPlayer
				Settings.HotKeyViewer = Settings.Defaults.HotKeyViewer
				Settings.HotKeys.AddRange(Settings.Defaults.HotKeys)
				Settings.UseSystemTheme = Settings.Defaults.UseSystemTheme
				Settings.SelectedTheme = Settings.Defaults.SelectedTheme
				Skye.Common.Log.Write("Settings Returned To Defaults")
			Catch ex As Exception
				Skye.Common.Log.Write("Error Loading Defaults" + vbCr + ex.Message)
			End Try
		End Sub
		<Diagnostics.ConditionalAttribute("DEBUG")> Private Sub GetSettingsDebug()
			Settings.PlacementVolume = My.App.SettingsType.Placement.BottomLeft
			Settings.AutoHideIntervalVolume = 2
			Settings.AutoHideWithFadeVolume = True
			Settings.PlayerSize = SettingsType.PlayerSizes.Large
		End Sub
		Friend Sub SaveSettings()
			Dim starttime As TimeSpan = Computer.Clock.LocalTime.TimeOfDay
			Try

				Skye.Common.RegistryHelper.SetString("SystemVolumeControlPath", Settings.SystemVolumeControlPath)
				Skye.Common.RegistryHelper.SetBool("ShowMeters", Settings.ShowMeters)

				' Volume steps
				Skye.Common.RegistryHelper.SetInt("vStep", Settings.vStep)
				Skye.Common.RegistryHelper.SetInt("vBabyStep", Settings.vBabyStep)
				Skye.Common.RegistryHelper.SetInt("vBlueZone", Settings.vBlueZone)
				Skye.Common.RegistryHelper.SetInt("vRedZone", Settings.vRedZone)

				' Colors (ARGB)
				Skye.Common.RegistryHelper.SetInt("cGreenZone", Settings.cGreenZone.ToArgb)
				Skye.Common.RegistryHelper.SetInt("cBlueZone", Settings.cBlueZone.ToArgb)
				Skye.Common.RegistryHelper.SetInt("cRedZone", Settings.cRedZone.ToArgb)

				' SaveEars
				Skye.Common.RegistryHelper.SetInt("vSaveEars", Settings.vSaveEars)
				Skye.Common.RegistryHelper.SetInt("SaveEarsInterval", Settings.SaveEarsInterval)
				Skye.Common.RegistryHelper.SetStringArray("SaveEarsApps", Settings.SaveEarsApps.ToArray)

				Skye.Common.RegistryHelper.SetString("UnMuteOnVolumeChange", Settings.UnMuteOnVolumeChange.ToString)

				' Auto-hide booleans
				Skye.Common.RegistryHelper.SetBool("AlwaysHideOnClickVolume", Settings.AlwaysHideOnClickVolume)
				Skye.Common.RegistryHelper.SetBool("AutoHideVolume", Settings.AutoHideVolume)
				Skye.Common.RegistryHelper.SetBool("AutoHidePlayer", Settings.AutoHidePlayer)

				' Auto-hide intervals
				Skye.Common.RegistryHelper.SetInt("AutoHideIntervalVolume", Settings.AutoHideIntervalVolume)
				Skye.Common.RegistryHelper.SetInt("AutoHideIntervalPlayer", Settings.AutoHideIntervalPlayer)

				' Auto-hide fade
				Skye.Common.RegistryHelper.SetBool("AutoHideWithFadeVolume", Settings.AutoHideWithFadeVolume)
				Skye.Common.RegistryHelper.SetBool("AutoHideWithFadePlayer", Settings.AutoHideWithFadePlayer)
				Skye.Common.RegistryHelper.SetInt("AutoHideRateVolume", Settings.AutoHideRateVolume)
				Skye.Common.RegistryHelper.SetInt("AutoHideRatePlayer", Settings.AutoHideRatePlayer)

				' Placement enums
				Skye.Common.RegistryHelper.SetString("PlacementVolume", Settings.PlacementVolume.ToString)
				Skye.Common.RegistryHelper.SetString("PlacementPlayer", Settings.PlacementPlayer.ToString)

				' Window locations
				Skye.Common.RegistryHelper.SetInt("LocationVolumeX", Settings.LocationVolume.X)
				Skye.Common.RegistryHelper.SetInt("LocationVolumeY", Settings.LocationVolume.Y)
				Skye.Common.RegistryHelper.SetInt("LocationPlayerX", Settings.LocationPlayer.X)
				Skye.Common.RegistryHelper.SetInt("LocationPlayerY", Settings.LocationPlayer.Y)

				Skye.Common.RegistryHelper.SetBool("PlayerAutoShow", Settings.PlayerAutoShow)

				Skye.Common.RegistryHelper.SetBool("PlayerOutputCurrent", Settings.PlayerOutputCurrent)
				Skye.Common.RegistryHelper.SetString("PlayerOutputCurrentPath", Settings.PlayerOutputCurrentPath)

				' App paths
				Skye.Common.RegistryHelper.SetString("AppPathMPC", Settings.AppPathMPC)
				Skye.Common.RegistryHelper.SetString("AppPathVLC", Settings.AppPathVLC)
				Skye.Common.RegistryHelper.SetString("AppPathWA", Settings.AppPathWA)
				Skye.Common.RegistryHelper.SetString("AppPathSM", Settings.AppPathSM)
				Skye.Common.RegistryHelper.SetString("ViewerName", Settings.ViewerName)
				Skye.Common.RegistryHelper.SetString("ViewerPath", Settings.ViewerPath)

				Skye.Common.RegistryHelper.SetString("PlayerSize", Settings.PlayerSize.ToString)

				' HotKeys
				Skye.Common.RegistryHelper.SetBool("HotKeysEnabled", Settings.HotKeysEnabled)
				' HotKeyVolume
				Skye.Common.RegistryHelper.SetInt("HotKeyVolumeKey", CInt(Settings.HotKeyVolume.Key))
				Skye.Common.RegistryHelper.SetInt("HotKeyVolumeKeyCode", Settings.HotKeyVolume.KeyCode)
				Skye.Common.RegistryHelper.SetInt("HotKeyVolumeKeyMod", Settings.HotKeyVolume.KeyMod)
				' HotKeyPlayer
				Skye.Common.RegistryHelper.SetInt("HotKeyPlayerKey", CInt(Settings.HotKeyPlayer.Key))
				Skye.Common.RegistryHelper.SetInt("HotKeyPlayerKeyCode", Settings.HotKeyPlayer.KeyCode)
				Skye.Common.RegistryHelper.SetInt("HotKeyPlayerKeyMod", Settings.HotKeyPlayer.KeyMod)
				' HotKeyViewer
				Skye.Common.RegistryHelper.SetInt("HotKeyViewerKey", CInt(Settings.HotKeyViewer.Key))
				Skye.Common.RegistryHelper.SetInt("HotKeyViewerKeyCode", Settings.HotKeyViewer.KeyCode)
				Skye.Common.RegistryHelper.SetInt("HotKeyViewerKeyMod", Settings.HotKeyViewer.KeyMod)

				'Theme
				Skye.Common.RegistryHelper.SetBool("UseSystemTheme", Settings.UseSystemTheme)
				Skye.Common.RegistryHelper.SetString("SelectedTheme", Settings.SelectedTheme.ToString)

				' Finalize
				Settings.NeedsSaved = False
				Settings.ShowSave()
				Skye.Common.Log.Write("Settings Saved (" + Skye.Common.GenerateLogTime(starttime, My.Computer.Clock.LocalTime.TimeOfDay, True) + ")")

			Catch ex As Exception
				Skye.Common.Log.Write("Error Saving Settings" & vbCrLf & ex.ToString)
			End Try
		End Sub
		Friend Sub ShowVolume()
			If FrmVolume Is Nothing Then FrmVolume = New Volume
			FrmVolume.ShowInstant()
		End Sub
		Friend Sub HideVolume()
			FrmVolume?.Hide()
		End Sub
		Friend Sub CloseVolume()
			If FrmVolume IsNot Nothing Then
				FrmVolume.Close()
				FrmVolume = Nothing
			End If
		End Sub
		Friend Sub ShowPlayer()
			If FrmPlayer Is Nothing Then
				FrmPlayer = New Player
				FrmPlayer.ShowInstant()
				FrmVolume.MIPlayerInfo.Checked = True
			Else
				FrmPlayer.ShowInstant()
			End If
		End Sub
		Friend Sub HidePlayer()
			FrmPlayer?.Hide()
		End Sub
		Friend Sub ClosePlayer()
			If FrmPlayer IsNot Nothing Then
				FrmPlayer.Close()
				FrmPlayer = Nothing
				FrmVolume.MIPlayerInfo.Checked = False
			End If
		End Sub
		Friend Sub ShowSettings()
			If FrmSettings Is Nothing Then
				FrmSettings = New Settings
				FrmSettings.Show()
			Else
				FrmSettings.WindowState = FormWindowState.Normal
				FrmSettings.BringToFront()
			End If
			FrmVolume.MISettings.Checked = True
		End Sub
		Friend Sub CloseSettings()
			If FrmSettings IsNot Nothing Then
				FrmSettings.Close()
				FrmSettings = Nothing
				FrmVolume.MISettings.Checked = False
			End If
		End Sub
		Friend Sub ShowHelp()
			Dim logtext =
<text>
Volume Info

LeftClick anywhere, except the Percent Display or Mute Button, or EscapeKey anywhere, immediately hides <%= My.Application.Info.ProductName %>. RightClick anywhere shows the Menu.

LeftClick on Volume Bar to set the volume to that percent.

LeftClick on Volume Bar and hold to drag and set the volume.

The Save Ears feature will reduce the volume to the specified amount after the Save Ears Interval has been reached and there has been no user activity, if the volume is in the red zone, unless one of the Save Ears Apps is running fullscreen.


Player Info

These players are currently supported: MPC-HC, VLC, Winamp, and Skye Music.


HotKeys

CtrlW closes the window.

CtrlShiftW minimizes the window.

</text>.Value
			If My.Settings.HotKeysEnabled Then
				logtext &= vbCr & "Global HotKeys" & vbCr
				For Each key In My.Settings.HotKeys
					logtext &= vbCr & key.Description & " = " & key.KeyText & vbCr
				Next
			End If
			FrmHelp = New Help
			FrmHelp.Text = My.Application.Info.ProductName + " " + FrmHelp.Text
			FrmHelp.RTxBoxHelp.Text = logtext
			FrmHelp.LblVersion.Text = "v" + My.Application.Info.Version.Major.ToString + "." + My.Application.Info.Version.Minor.ToString
			logtext = String.Empty
			FrmHelp.Show()
		End Sub
		Friend Sub ShowLog()
			If FrmLog Is Nothing Then
				FrmLog = New Log
				FrmLog.Text = My.Application.Info.ProductName + " " + FrmLog.Text
				FrmLog.Show()
			Else
				FrmLog.WindowState = FormWindowState.Normal
				FrmLog.BringToFront()
				FrmLog.Focus()
			End If
		End Sub
		Friend Sub ShowViewer()
			If FrmPlayer IsNot Nothing AndAlso Not String.IsNullOrEmpty(CurrentSelectionPath) AndAlso Not String.IsNullOrEmpty(Settings.ViewerPath) Then
				Dim pInfo As New Diagnostics.ProcessStartInfo With {
					.UseShellExecute = False,
					.FileName = Settings.ViewerPath,
					.Arguments = """" + CurrentSelectionPath + """"}
				Try
					Diagnostics.Process.Start(pInfo)
					Skye.Common.Log.Write(Settings.ViewerName + " Opened '" + CurrentSelectionPath + "'")
				Catch : Skye.Common.Log.Write("Cannot Open Viewer (" + Settings.ViewerName + " @" + My.Settings.ViewerPath + ")")
				Finally : pInfo = Nothing
				End Try
			End If
		End Sub
		Friend Sub OpenFileLocation(Optional filename As String = Nothing)
			Dim psi As New Diagnostics.ProcessStartInfo("EXPLORER.EXE")
			If filename Is Nothing Then
				psi.Arguments = "/SELECT," + """" + CurrentSelectionPath + """"
			Else
				psi.Arguments = "/SELECT," + """" + filename + """"
			End If
			Try
				Diagnostics.Process.Start(psi)
				Skye.Common.Log.Write("File Location Opened (" + If(filename, CurrentSelectionPath).ToString + ")")
			Catch ex As Exception
				Skye.Common.Log.Write("Error Opening File Location (" + If(filename, CurrentSelectionPath).ToString + ")" + vbCr + ex.Message)
			End Try
		End Sub
		Friend Sub OpenSystemVolumeControl()
			Dim p As Diagnostics.Process
			p = Diagnostics.Process.Start(My.Settings.SystemVolumeControlPath)
			p.Dispose()
		End Sub
		Friend Sub OpenPlayer(player As String)
			Dim p As Diagnostics.Process
			Try
				Select Case player
					Case "MPC-HC"
						p = Diagnostics.Process.Start(My.Settings.AppPathMPC)
						p.Dispose()
					Case "VLC"
						p = Diagnostics.Process.Start(My.Settings.AppPathVLC)
						p.Dispose()
					Case "Winamp"
						p = Diagnostics.Process.Start(My.Settings.AppPathWA)
						p.Dispose()
					Case "Skye Music"
						p = Diagnostics.Process.Start(My.Settings.AppPathSM)
						p.Dispose()
				End Select
			Catch ex As Exception
				Skye.Common.Log.Write("Error Opening Player (" + player + ")" + vbCr + ex.Message)
			End Try
		End Sub

		' HotKeys
		''' <summary>
		''' Register / UNRegister HotKeys with Windows.
		''' </summary>
		''' <param name="mode">True = Register, False = UNRegister, Default = True</param>
		Friend Sub RegisterHotKeys(Optional mode As Boolean = True)
			If Settings.HotKeysEnabled Then
				Dim status As Boolean
				Select Case mode
					Case True 'Register All HotKeys Where Key Is Not 'NONE'
						For Each key As SettingsType.HotKey In Settings.HotKeys
							If Not key.Key = Keys.None Then
								status = Skye.WinAPI.RegisterHotKey(FrmMain.Handle, key.WinID, key.KeyMod, key.KeyCode)
								Skye.Common.Log.Write("HotKey '" + key.Description + " (" + key.WinID.ToString + ") (" + key.Key.ToString + ") (" + key.KeyCode.ToString + " mod " + key.KeyMod.ToString + ")' " + If(status, "Successfully Registered", "Failed To Register").ToString)
							End If
						Next
					Case False 'UnRegister All HotKeys
						For Each key As SettingsType.HotKey In Settings.HotKeys
							If Not key.Key = Keys.None Then
								status = Skye.WinAPI.UnregisterHotKey(FrmMain.Handle, key.WinID)
								Skye.Common.Log.Write("HotKey '" + key.Description + " (" + key.WinID.ToString + ")' " + If(status, "Successfully UNRegistered", "Failed To UNRegister").ToString)
							End If
						Next
				End Select
			End If
		End Sub
		Friend Sub PerformHotKeyAction(hotkey As Integer)
			Select Case hotkey
				Case Settings.HotKeyVolume.WinID
					FrmMain.Show()
					FrmVolume.ShowInstant()
				Case Settings.HotKeyPlayer.WinID
					FrmPlayer.ShowInstant()
				Case Settings.HotKeyViewer.WinID
					ShowViewer()
			End Select
		End Sub
		Friend Sub GenerateHotKeyList()
			Settings.HotKeys.Clear()
			Settings.HotKeys.Add(Settings.HotKeyVolume)
			Settings.HotKeys.Add(Settings.HotKeyPlayer)
			Settings.HotKeys.Add(Settings.HotKeyViewer)
		End Sub
		Friend Function GenerateUsedKeyList() As Collections.Generic.List(Of Keys)
			GenerateUsedKeyList = New List(Of Keys) From {
				Keys.Control Or Keys.A,   ' Select All
				Keys.Control Or Keys.C,   ' Copy
				Keys.Control Or Keys.X,   ' Cut / Clear
				Keys.Control Or Keys.V,   ' Paste
				Keys.Control Or Keys.S    ' Save As
			}
			For Each hKey As SettingsType.HotKey In Settings.HotKeys
				GenerateUsedKeyList.Add(hKey.Key)
			Next
		End Function

		' Themes
		Friend Sub ApplyTheme(theme As Theme)
			CurrentTheme = theme
			Skye.UI.ThemeManager.SetTheme(Skye.UI.SkyeThemes.GetTheme(theme.ToString))
			RaiseEvent ThemeChanged(theme)
		End Sub
		Friend Function GetWindowsTheme() As Theme
			Const keyPath As String = "Software\Microsoft\Windows\CurrentVersion\Themes\Personalize"
			Using key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(keyPath)
				If key Is Nothing Then Return Theme.Light
				Dim v = CInt(key.GetValue("AppsUseLightTheme", 1))
				Return If(v = 1, Theme.Light, Theme.Dark)
			End Using
		End Function

		' Save Ears
		Friend Sub SetSaveEars()
			If TimerSaveEars.Enabled Then TimerSaveEars.Stop()
			If Settings.SaveEarsInterval > 0 Then TimerSaveEars.Start()
		End Sub
		Friend Sub SetChangeTimeForSaveEars()
			cChangeTimeForSaveEars = My.Computer.Clock.LocalTime
		End Sub
		Private Function CheckFullScreen() As Boolean
			Dim fgWindow As IntPtr = Skye.WinAPI.GetForegroundWindow
			Dim rect As Skye.WinAPI.RECT

			If Not Skye.WinAPI.GetWindowRect(fgWindow, rect) Then
				Return False
			End If

			' Multi-monitor aware working area
			Dim wa = Screen.FromHandle(fgWindow).WorkingArea

			' Check if window width >= working area width
			If (rect.Right - rect.Left) < wa.Width Then
				Return False
			End If

			' Get process
			Dim pID As UInteger
			Dim hresult = Skye.WinAPI.GetWindowThreadProcessId(fgWindow, pID)

			Try
				Using p As Process = Process.GetProcessById(CInt(pID))
					Debug.Print("CheckFullScreen: " & rect.Left & " / " & rect.Right)
					Debug.Print("CheckFullScreen: " & p.MainModule.FileName)

					For Each s As String In My.Settings.SaveEarsApps
						If p.MainModule.FileName.EndsWith(s, StringComparison.OrdinalIgnoreCase) Then
							SetChangeTimeForSaveEars()
							Return True
						End If
					Next
				End Using
			Catch
				' Process might have exited — ignore
			End Try

			Return False
		End Function

		' Custom ContextMenu ToolTips
		Friend Sub HookTSItemsForCMTooltip(ts As ToolStrip, tip As ToolTipEX)
			For Each item As ToolStripItem In ts.Items
				AddHandler item.MouseEnter,
					Sub(sender, e)
						Dim it = CType(sender, ToolStripItem)
						If String.IsNullOrWhiteSpace(it.ToolTipText) Then Exit Sub

						' Delay one UI tick so ToolStrip finishes layout
						ts.BeginInvoke(Sub()
										   ShowTSItemTooltip(ts, it, tip)
									   End Sub)
					End Sub
				AddHandler item.MouseLeave,
					Sub(sender, e)
						tip.HideTooltip()
					End Sub
			Next
		End Sub
		Private Sub ShowTSItemTooltip(ts As ToolStrip, it As ToolStripItem, tip As ToolTipEX)

			' Get item bounds in screen coordinates
			Dim itemScreenRect As New Rectangle(ts.PointToScreen(it.Bounds.Location), it.Bounds.Size)

			' Measure tooltip size
			Dim textSize As Size = TextRenderer.MeasureText(it.ToolTipText, tip.Font)
			Dim tipWidth As Integer = textSize.Width + tip.TextPadding * 2
			Dim tipHeight As Integer = textSize.Height + tip.TextPadding * 2

			' Default: show to the right of the item
			Dim pos As New Point(itemScreenRect.Right + 1, itemScreenRect.Top + (itemScreenRect.Height - tipHeight) \ 2 - 1)

			' Clamp horizontally using working area
			Dim wa As Rectangle = Screen.FromPoint(pos).WorkingArea
			If pos.X + tipWidth > wa.Right Then
				pos.X = itemScreenRect.Left - tipWidth
			End If

			tip.ShowTooltipAt(pos, it.ToolTipText)
		End Sub

	End Module

End Namespace
