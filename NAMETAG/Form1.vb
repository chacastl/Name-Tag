Imports System.IO
Imports System.Text
Public Class Form1

    Private Sub TextBox1_Click(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1_Click(Nothing, Nothing)
        End If

    End Sub
    Private Sub TextBox2_Click(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1_Click(Nothing, Nothing)
        End If

    End Sub

    Private Sub ComboBox1_Click(sender As Object, e As KeyEventArgs) Handles ComboBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1_Click(Nothing, Nothing)
        End If

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' All Code was referenced from https://github.com/dymosoftware/DCD-SDK-Sample for printing from a Dymo printer
        Dim DymoPrint As DymoSDK.Implementations.DymoPrinter
        Dim DymoSDKLabel As DymoSDK.Implementations.DymoLabel
        Dim LabelTextObject1 As DymoSDK.Interfaces.ILabelObject
        Dim LabelTextObject2 As DymoSDK.Interfaces.ILabelObject
        Dim LabelTextObject3 As DymoSDK.Interfaces.ILabelObject
        DymoSDKLabel = New DymoSDK.Implementations.DymoLabel()

        DymoSDKLabel.LoadLabelFromFilePath("Name_Tags.dymo")
        LabelTextObject1 = DymoSDKLabel.GetLabelObject("NAME")
        LabelTextObject2 = DymoSDKLabel.GetLabelObject("MAJOR")
        LabelTextObject3 = DymoSDKLabel.GetLabelObject("YEAR")

        DymoSDKLabel.UpdateLabelObject(LabelTextObject1, TextBox1.Text)
        DymoSDKLabel.UpdateLabelObject(LabelTextObject2, TextBox2.Text)
        If (RadioButton2.Checked = True) Then
            DymoSDKLabel.UpdateLabelObject(LabelTextObject3, ComboBox1.Text)
        Else
            DymoSDKLabel.UpdateLabelObject(LabelTextObject3, "Alumni")
        End If


        Try
            Dim filePath As String
            filePath = System.IO.Path.Combine(
               My.Computer.FileSystem.SpecialDirectories.MyDocuments, "Names.txt")
            If (RadioButton2.Checked = True) Then
                My.Computer.FileSystem.WriteAllText(filePath, "Name: " + TextBox1.Text + " Major: " + TextBox2.Text + " Year: " + ComboBox1.Text + vbNewLine, True)
            Else
                My.Computer.FileSystem.WriteAllText(filePath, "Name: " + TextBox1.Text + " Major: " + TextBox2.Text + " Year: Alumni" + vbNewLine, True)
            End If
        Catch fileException As Exception
            Throw fileException
        End Try
        DymoPrint.Instance.PrintLabel(DymoSDKLabel, "DYMO LabelWriter 450", 1)
        TextBox1.Clear()
        TextBox2.Clear()
        ComboBox1.SelectedIndex = 0
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        ComboBox1.Enabled = True

    End Sub


    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        ComboBox1.Enabled = True
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        ComboBox1.Enabled = False
    End Sub

End Class