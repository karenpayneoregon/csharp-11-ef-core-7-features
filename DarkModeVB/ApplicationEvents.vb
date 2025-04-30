Imports Microsoft.VisualBasic.ApplicationServices


Namespace My
      Partial Friend Class MyApplication
        Private Sub MyApplication_ApplyApplicationDefaults(sender As Object, e As ApplyApplicationDefaultsEventArgs) Handles Me.ApplyApplicationDefaults
#Disable Warning WFO5001
            e.ColorMode = AppColorMode.CurrentMode
#Enable Warning WFO5001
        End Sub
    End Class
End Namespace
