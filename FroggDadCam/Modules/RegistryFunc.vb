Imports Microsoft.Win32

Module RegistryFunc

    '/// <summary>
    '/// Renames a subkey of the passed in registry key since 
    '/// the Framework totally forgot to include such a handy feature.
    '/// </summary>
    '/// <param name="regKey">The RegistryKey that contains the subkey 
    '/// you want to rename (must be writeable)</param>
    '/// <param name="subKeyName">The name of the subkey that you want to rename
    '/// </param>
    '/// <param name="newSubKeyName">The new name of the RegistryKey</param>
    '/// <returns>True if succeeds</returns>
    Public Function RenameSubKey(parentKey As RegistryKey, subKeyName As String, newSubKeyName As String) As Boolean
        CopyKey(parentKey, subKeyName, newSubKeyName)
        parentKey.DeleteSubKeyTree(subKeyName)
        Return True
    End Function

    '/// <summary>
    '/// Copy a registry key.  The parentKey must be writeable.
    '/// </summary>
    '/// <param name="parentKey"></param>
    '/// <param name="keyNameToCopy"></param>
    '/// <param name="newKeyName"></param>
    '/// <returns></returns>
    Public Function CopyKey(parentKey As RegistryKey, keyNameToCopy As String, newKeyName As String) As Boolean
        '//Create new key
        Dim destinationKey = parentKey.CreateSubKey(newKeyName)
        '//Open the sourceKey we are copying from
        Dim sourceKey = parentKey.OpenSubKey(keyNameToCopy)
        RecurseCopyKey(sourceKey, destinationKey)
        Return True
    End Function

    Private Sub RecurseCopyKey(sourceKey As RegistryKey, destinationKey As RegistryKey)

        '//copy all the values
        For Each valueName As String In sourceKey.GetValueNames()
            Dim objValue As Object = sourceKey.GetValue(valueName)
            Dim valKind As RegistryValueKind = sourceKey.GetValueKind(valueName)
            destinationKey.SetValue(valueName, objValue, valKind)
        Next

        '//For Each subKey 
        '//Create a new subKey in destinationKey 
        '//Call myself 
        For Each sourceSubKeyName In sourceKey.GetSubKeyNames()
            Dim sourceSubKey As RegistryKey = sourceKey.OpenSubKey(sourceSubKeyName)
            Dim destSubKey As RegistryKey = destinationKey.CreateSubKey(sourceSubKeyName)
            RecurseCopyKey(sourceSubKey, destSubKey)
        Next

    End Sub

End Module
