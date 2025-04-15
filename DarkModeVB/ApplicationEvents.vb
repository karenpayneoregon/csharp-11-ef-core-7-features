Imports Microsoft.VisualBasic.ApplicationServices
Imports WinFormsSystemColorModeLibrary


Namespace My
      Partial Friend Class MyApplication
        Private Sub MyApplication_ApplyApplicationDefaults(sender As Object, e As ApplyApplicationDefaultsEventArgs) Handles Me.ApplyApplicationDefaults
            e.ColorMode = AppColorMode.CurrentMode
        End Sub
    End Class
End Namespace
