Public Class AppColorMode

    'SystemColorMode is experimental, add to project file in PropertyGroup:
    '<NoWarn>$(NoWarn);WFO5001</NoWarn>

    'Application user setting: ColorMode as String (Classic/System/Dark)

    'Application event ApplyApplicationDefaults: e.ColorMode = AppColorMode.CurrentMode

    Public Shared Property CurrentMode As SystemColorMode
        Get
            Dim value As SystemColorMode
            If System.Enum.TryParse(My.Settings.ColorMode, value) Then
                Return value
            Else
                Return SystemColorMode.System
            End If
        End Get
        Set(value As SystemColorMode)
            My.Settings.ColorMode = value.ToString
        End Set
    End Property

    Public Shared Sub SelectMode()
        Dim current = CurrentMode
        Dim selected = ShowDialog(current)
        If current <> selected Then
            CurrentMode = selected
            Application.Restart()
        End If
    End Sub

#Disable Warning WFO5001
    Public Shared Function ShowDialog(Optional defaultMode As SystemColorMode = SystemColorMode.System) As SystemColorMode
#Disable Warning IDE0079 ' Remove unnecessary suppression

        Dim page As New TaskDialogPage With {
            .Caption = Application.ProductName,
            .Heading = "Application color mode",
            .Text = "Select a mode, press OK to restart."
        }
#Enable Warning IDE0079 ' Remove unnecessary suppression

        For Each mode In System.Enum.GetValues(Of SystemColorMode)
            page.RadioButtons.Add(New TaskDialogRadioButton With {
                .Text = mode.ToString,
                .Tag = mode,
                .Checked = (mode = defaultMode)
            })
        Next

        page.Buttons.Add(TaskDialogButton.OK)
        page.Buttons.Add(TaskDialogButton.Cancel)

        If TaskDialog.ShowDialog(Form.ActiveForm, page) = TaskDialogButton.OK Then
            Return DirectCast(page.RadioButtons.First(Function(radio) radio.Checked).Tag, SystemColorMode)
        Else
            Return defaultMode
        End If
    End Function

    Public Shared ReadOnly Property SystemIsDark As Boolean
        Get
            Dim key = "HKEY_CURRENT_USER\SOFTWARE\Microsoft\\Windows\CurrentVersion\Themes\Personalize"
            Return CInt(Microsoft.Win32.Registry.GetValue(key, "AppsUseLightTheme", -1)) = 0
            '0 dark, 1 light, -1 not set (light)
        End Get
    End Property

    Public Shared ReadOnly Property UseDark As Boolean
        Get
            Dim mode = CurrentMode
            Return mode = SystemColorMode.Dark OrElse (mode = SystemColorMode.System AndAlso SystemIsDark)
        End Get
    End Property

End Class