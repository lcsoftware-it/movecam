
Imports System.Configuration

Module Configuration

    Sub Main()
        ReadAllSettings()
        ReadSetting("Setting1")
        ReadSetting("NotValid")
        AddUpdateAppSettings("NewSetting", "May 7, 2014")
        AddUpdateAppSettings("Setting1", "May 8, 2014")
        ReadAllSettings()
    End Sub

    Sub ReadAllSettings()
        Try
            Dim appSettings = ConfigurationManager.AppSettings

            If appSettings.Count = 0 Then
                Console.WriteLine("AppSettings is empty.")
            Else
                For Each key As String In appSettings.AllKeys
                    Console.WriteLine("Key: {0} Value: {1}", key, appSettings(key))
                Next
            End If
        Catch e As ConfigurationErrorsException
            Console.WriteLine("Error reading app settings")
        End Try
    End Sub

    Sub ReadSetting(key As String)
        Try
            Dim appSettings = ConfigurationManager.AppSettings
            Dim result As String = appSettings(key)
            If IsNothing(result) Then
                result = "Not found"
            End If
            Console.WriteLine(result)
        Catch e As ConfigurationErrorsException
            Console.WriteLine("Error reading app settings")
        End Try
    End Sub

    Sub AddUpdateAppSettings(key As String, value As String)
        Try
            Dim configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
            Dim settings = configFile.AppSettings.Settings
            If IsNothing(settings(key)) Then
                settings.Add(key, value)
            Else
                settings(key).Value = value
            End If
            configFile.Save(ConfigurationSaveMode.Modified)
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name)
        Catch e As ConfigurationErrorsException
            Console.WriteLine("Error writing app settings")
        End Try
    End Sub

End Module
End Module
