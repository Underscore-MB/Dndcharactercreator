Public Class frmHome
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Dim newCharForm As New NewCharacter()
        newCharForm.Show()
        Me.Hide()
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Dim newCharForm As New NewCharacter()
        newCharForm.Show()
        newCharForm.LoadCharacterFromFile()
        Me.Hide()
    End Sub

    Private Sub btnHomeQ_Click(sender As Object, e As EventArgs) Handles btnHomeQ.Click
        MessageBox.Show("Any questions or feedback? Contact Underscore_ or 'cheesejuice' on discord.", "Questions?", MessageBoxButtons.OK)
    End Sub

    ' Opens the folder where the character file is saved (selects file if present)
    ' NOTE: Add a button in the Designer named `btnOpenSave` and wire its Click event to this handler.
    Private Sub btnOpenSave_Click(sender As Object, e As EventArgs) Handles btnOpenSave.Click
        Try
            Dim folder As String = Application.StartupPath
            Dim filePath As String = IO.Path.Combine(folder, "CharacterInfo.txt")

            If IO.File.Exists(filePath) Then
                ' Open Explorer and select the file
                System.Diagnostics.Process.Start("explorer.exe", "/select," & Chr(34) & filePath & Chr(34))
            Else
                ' Open the folder
                System.Diagnostics.Process.Start("explorer.exe", folder)
            End If
        Catch ex As Exception
            MessageBox.Show("Unable to open save location: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
