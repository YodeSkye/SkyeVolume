
Imports SkyeVolume.My

Partial Public Class MainForm

    ' FORM EVENTS
    Protected Overrides Sub WndProc(ByRef m As Message)
        Try
            Select Case m.Msg
                Case Skye.WinAPI.WM_HOTKEY
                    App.PerformHotKeyAction(m.WParam.ToInt32)
                Case Skye.WinAPI.WM_SETTINGCHANGE ' Windows theme changed
                    If App.Settings.UseSystemTheme Then
                        App.ApplyTheme(App.GetWindowsTheme())
                    End If
            End Select
        Catch ex As Exception
            Skye.Common.Log.Write("WndProc Handler Error" & vbCrLf & ex.ToString)
        Finally
            MyBase.WndProc(m)
        End Try
    End Sub
    Friend Sub New()
        InitializeComponent()
        Opacity = 0
    End Sub
    Private Sub Frm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Hide()
    End Sub

End Class
