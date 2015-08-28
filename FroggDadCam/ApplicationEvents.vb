Namespace My
    ' Les événements suivants sont disponibles pour MyApplication :
    ' 
    ' Startup : déclenché au démarrage de l'application avant la création du formulaire de démarrage.
    ' Shutdown : déclenché après la fermeture de tous les formulaires de l'application. Cet événement n'est pas déclenché si l'application se termine de façon anormale.
    ' UnhandledException : déclenché si l'application rencontre une exception non gérée.
    ' StartupNextInstance : déclenché lors du lancement d'une application à instance unique et si cette application est déjà active. 
    ' NetworkAvailabilityChanged : déclenché lorsque la connexion réseau est connectée ou déconnectée.
    Partial Friend Class MyApplication

        Private Sub AppStart(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            AddHandler AppDomain.CurrentDomain.AssemblyResolve, AddressOf ResolveAssemblies
        End Sub

        Private Function ResolveAssemblies(sender As Object, e As System.ResolveEventArgs) As Reflection.Assembly
            Dim desiredAssembly = New Reflection.AssemblyName(e.Name)

            'Load dll form .exe ressource if requiered
            Select Case desiredAssembly.Name
                Case "FroggDadCam.resources"
                    Return Nothing
                Case "Interop.WMPLib"
                    Return Reflection.Assembly.Load(My.Resources.Interop_WMPLib)
                Case "AxInterop.WMPLib"
                    Return Reflection.Assembly.Load(My.Resources.AxInterop_WMPLib)
                Case Else
                    Return Nothing
            End Select

        End Function

    End Class

End Namespace

