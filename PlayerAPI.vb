
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Text.Json

Namespace My

	Public Module PlayerAPI

		' Declarations
		Friend Enum PlayState
			Playing
			Paused
			Stopped
			UnKnown
		End Enum
		Friend Const MPC_CLASSNAME As String = "MediaPlayerClassicW" 'MPC-HC Class Name
		Private MPC_MainHwnd As IntPtr = IntPtr.Zero
		Friend Const VLC_CLASSNAME As String = "QWidget" 'VLC Class Name
		Friend Const VLC_Name As String = "vlc" 'without .exe
		Friend Const VLC_TitleSuffix As String = " - VLC media player"
		Private VLC_MainHwnd As IntPtr = IntPtr.Zero
		Friend Const WA_CLASSNAME As String = "Winamp v1.x" 'Winamp Class Name
		''' <summary>
		''' To tell Winamp that we are sending it a WM_USER, it needs the hex code 0x0400 (H400)
		''' </summary>
		Friend Const WA_IPC As Integer = 1024 '&H400
		''' <summary>
		''' #define IPC_ISPLAYING 104;
		''' int res = SendMessage(hwnd_winamp,WM_WA_IPC,0,IPC_ISPLAYING);
		''' This is sent to retrieve the current playback state of Winamp.
		''' If it returns 1, Winamp is playing.
		''' If it returns 3, Winamp is paused.
		''' If it returns 0, Winamp is not playing.
		''' </summary>
		Friend Const WA_IPC_ISPLAYING As Integer = 104 '&H68 
		Friend Const WA_TITLESUFFIX As String = " - Winamp"
		Private WA_MainHwnd As IntPtr = IntPtr.Zero
		Friend Const SM_CLASSNAME As String = "WindowsForms10.Window.8.app.0.784086_r3_ad1" 'Skye Music Class Name
		Friend Const SM_TITLE As String = "Skye Music"
		Friend Const SM_NAME As String = "SkyeMusic" 'without .exe
		Friend Const SM_TITLEPREFIX As String = "Skye Music - "

		' Methods
		Friend Function GetHandleMPC() As IntPtr

			'If we already have a handle but the window has closed, reset
			If MPC_MainHwnd <> IntPtr.Zero AndAlso Not Skye.WinAPI.IsWindow(MPC_MainHwnd) Then
				MPC_MainHwnd = IntPtr.Zero
			End If

			'If no cached handle, look up via Process.MainWindowHandle
			If MPC_MainHwnd = IntPtr.Zero Then
				MPC_MainHwnd = Skye.WinAPI.FindWindow(My.PlayerAPI.MPC_CLASSNAME, Nothing)
			End If

			Return MPC_MainHwnd
		End Function
		Friend Function GetHandleVLC() As IntPtr

			'If we already have a handle but the window has closed, reset
			If VLC_MainHwnd <> IntPtr.Zero AndAlso Not Skye.WinAPI.IsWindow(VLC_MainHwnd) Then
				VLC_MainHwnd = IntPtr.Zero
			End If

			'If no cached handle, look up via Process.MainWindowHandle
			If VLC_MainHwnd = IntPtr.Zero Then
				Dim procs = Process.GetProcessesByName(VLC_Name)
				If procs.Length > 0 Then
					VLC_MainHwnd = procs(0).MainWindowHandle
				End If
			End If

			Return VLC_MainHwnd
		End Function
		Friend Function GetHandleWA() As IntPtr
			'GetHandleWA = Skye.WinAPI.FindWindow(My.PlayerAPI.WA_CLASSNAME, Nothing)

			'If we already have a handle but the window has closed, reset
			If WA_MainHwnd <> IntPtr.Zero AndAlso Not Skye.WinAPI.IsWindow(WA_MainHwnd) Then
				WA_MainHwnd = IntPtr.Zero
			End If

			'If no cached handle, look up via Process.MainWindowHandle
			If WA_MainHwnd = IntPtr.Zero Then
				WA_MainHwnd = Skye.WinAPI.FindWindow(My.PlayerAPI.WA_CLASSNAME, Nothing)
			End If

			Return WA_MainHwnd
		End Function
		''' <summary>
		''' Returns the true main window handle for Skye Music, caching it and revalidating if it’s closed/reopened.
		''' Attempts to locate the correct Skye Music window handle.
		''' Strategy:
		'''   1. Enumerate all top-level windows belonging to the Skye Music process.
		'''   2. Prefer the "Player" form (caption starts with "Skye Music - ..." or contains "@").
		'''   3. If no player form is found yet (e.g. at startup), fall back to the first window
		'''      we saw (usually the Library or bare "Skye Music" window).
		''' </summary>
		Friend Function GetHandleSM() As IntPtr

			'Find the Skye Music process
			Dim procs = Process.GetProcessesByName(SM_NAME)
			If procs.Length = 0 Then Return IntPtr.Zero

			'Grab its PID so we can filter windows by process
			Dim pid = procs(0).Id

			'Ask SkyeLibrary.WinAPI helper to enumerate all windows for this PID
			Dim handlessm = Skye.WinAPI.GetWindowsForProcess(pid)

			'Track the first window we encounter as a fallback
			Dim fallback As IntPtr = IntPtr.Zero

			'Walk through each window handle
			For Each hWnd In handlessm
				'If this is the first window we’ve seen, remember it as fallback
				If fallback = IntPtr.Zero Then
					fallback = hWnd
				End If

				'Read the caption text for this window
				Dim title As String = Skye.WinAPI.GetCaption(hWnd)

				'If the caption looks like the playback form (track info present),
				'immediately return this handle — this is the one we want.
				If title.StartsWith(SM_TITLEPREFIX, StringComparison.Ordinal) OrElse title.Contains("@"c) Then
					Return hWnd
				End If
			Next

			' If we didn’t find a playback form, return the first window we saw.
			' This ensures we always return *something* (Library or bare Skye Music)
			' instead of IntPtr.Zero, so the toast can still show a placeholder.
			Return fallback

		End Function

		Friend Function GetSelectionMPC(hWnd As IntPtr) As String
			If hWnd = IntPtr.Zero Then
				Return String.Empty
			End If

			' Use StringBuilder as the buffer for GetWindowText
			Dim sb As New StringBuilder(512) ' capacity can be adjusted or sized dynamically
			Dim result As Integer = Skye.WinAPI.GetWindowText(hWnd, sb, sb.Capacity)

			' Trim trailing nulls/whitespace and return
			Return sb.ToString().TrimEnd()
		End Function
		Friend Function GetSelectionVLC(hWnd As IntPtr) As String
			If hWnd = IntPtr.Zero Then
				Return String.Empty
			End If

			' Use StringBuilder as the buffer for GetWindowText
			Dim sb As New StringBuilder(512) ' safe default capacity
			Dim result As Integer = Skye.WinAPI.GetWindowText(hWnd, sb, sb.Capacity)
			Dim caption As String = sb.ToString()

			' If the caption contains the VLC suffix, strip it off
			If caption.Contains(VLC_TitleSuffix) Then
				Dim idx As Integer = caption.IndexOf(VLC_TitleSuffix)
				Return caption.Remove(idx).TrimEnd()
			Else
				' Otherwise just trim trailing whitespace/nulls
				Return caption.TrimEnd()
			End If
		End Function
		Friend Function GetSelectionWA(hWnd As IntPtr) As String
			If hWnd = IntPtr.Zero Then
				Return String.Empty
			End If

			' Use StringBuilder as the buffer for GetWindowText
			Dim sb As New StringBuilder(512) ' safe default capacity
			Dim result As Integer = Skye.WinAPI.GetWindowText(hWnd, sb, sb.Capacity)
			Dim caption As String = sb.ToString()

			' If the caption contains the WA suffix, strip it off
			If caption.Contains(My.PlayerAPI.WA_TITLESUFFIX) Then
				Dim idx As Integer = caption.IndexOf(My.PlayerAPI.WA_TITLESUFFIX)
				Return caption.Remove(idx).TrimEnd()
			Else
				' Otherwise just trim trailing whitespace/nulls
				Return caption.TrimEnd()
			End If
		End Function
		Friend Function GetSelectionSM(hWnd As IntPtr) As String
			If hWnd = IntPtr.Zero Then
				Return String.Empty
			End If

			' Use StringBuilder as the buffer for GetWindowText
			Dim sb As New StringBuilder(512) ' safe default capacity
			Dim result As Integer = Skye.WinAPI.GetWindowText(hWnd, sb, sb.Capacity)
			Dim caption As String = sb.ToString().TrimEnd()

			' If the caption is empty, fall back to the default Skye Music title
			If String.IsNullOrEmpty(caption) Then
				Return SM_TITLE
			End If

			Return caption
		End Function

		Friend Function GetPlayStateVLC(hWnd As IntPtr) As PlayState
			If hWnd = IntPtr.Zero Then Return PlayState.UnKnown

			Try
				'Synchronously unwrap the Task with GetAwaiter
				Dim resp As String = HttpHelper.VLCClient.GetStringAsync("/requests/status.json").GetAwaiter().GetResult()

				If String.IsNullOrWhiteSpace(resp) Then
					Return PlayState.UnKnown
				End If

				Dim root = JsonDocument.Parse(resp).RootElement
				Dim stateValue = root.GetProperty("state").GetString()

				Select Case stateValue
					Case "playing" : Return PlayState.Playing
					Case "paused" : Return PlayState.Paused
					Case "stopped" : Return PlayState.Stopped
					Case Else : Return PlayState.UnKnown
				End Select
			Catch hre As HttpRequestException
				Debug.WriteLine($"VLC HTTP error: {hre.Message}")
			Catch je As JsonException
				Debug.WriteLine($"VLC JSON parse error: {je.Message}")
			Catch ex As Exception
				Debug.WriteLine($"Unexpected error: {ex.Message}")
			End Try

			Return PlayState.UnKnown
		End Function
		Friend Function GetPlayStateWA(hWnd As IntPtr) As PlayState
			Static waPlayState As Integer
			If hWnd = IntPtr.Zero Then : GetPlayStateWA = PlayState.UnKnown
			Else
				waPlayState = CInt(Skye.WinAPI.SendMessage(hWnd, WA_IPC, IntPtr.Zero, New IntPtr(WA_IPC_ISPLAYING)))
				Select Case waPlayState
					Case 0 : GetPlayStateWA = PlayState.Stopped
					Case 1 : GetPlayStateWA = PlayState.Playing
					Case 3 : GetPlayStateWA = PlayState.Paused
					Case Else : GetPlayStateWA = PlayState.UnKnown
				End Select
			End If
		End Function
		Friend Function GetPlayStateSM(hWnd As IntPtr) As PlayState
			Static smPlayState As Integer
            If hWnd = IntPtr.Zero Then : GetPlayStateSM = PlayState.UnKnown
            Else
                smPlayState = CInt(Skye.WinAPI.SendMessage(hWnd, Skye.WinAPI.WM_GET_CUSTOM_DATA, IntPtr.Zero, IntPtr.Zero))
                'Debug.Print(smPlayState.ToString)
                Select Case smPlayState
                    Case 0 : GetPlayStateSM = PlayState.Stopped
                    Case 1 : GetPlayStateSM = PlayState.Paused
                    Case 2 : GetPlayStateSM = PlayState.Playing
                    Case Else : GetPlayStateSM = PlayState.UnKnown
                End Select
            End If
			'Debug.Print("GetPlayStateSM: " & GetPlayStateSM)
		End Function

	End Module

	Module HttpHelper
		Public ReadOnly VLCClient As HttpClient
		Sub New()
			VLCClient = New HttpClient With {
				.BaseAddress = New Uri("http://localhost:8080"),
				.Timeout = TimeSpan.FromSeconds(2)}
			Dim creds = Convert.ToBase64String(Text.Encoding.ASCII.GetBytes(":" & "7132"))
			VLCClient.DefaultRequestHeaders.Authorization = New System.Net.Http.Headers.AuthenticationHeaderValue("Basic", creds)
		End Sub
	End Module

End Namespace
