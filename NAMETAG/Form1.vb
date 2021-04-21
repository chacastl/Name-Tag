
Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' All Code was referenced from https://github.com/dymosoftware/DCD-SDK-Sample for printing from a Dymo printer
        Dim DymoPrint As DymoSDK.Implementations.DymoPrinter
        Dim DymoSDKLabel As DymoSDK.Implementations.DymoLabel
        Dim LabelTextObject1 As DymoSDK.Interfaces.ILabelObject
        Dim LabelTextObject2 As DymoSDK.Interfaces.ILabelObject
        Dim LabelTextObject3 As DymoSDK.Interfaces.ILabelObject
        DymoSDKLabel = New DymoSDK.Implementations.DymoLabel()

        DymoSDKLabel.LoadLabelFromFilePath("C:\Users\chacastl\Documents\Name_Tags.dymo")
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
        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter("C:\Users\chacastl\Desktop\test.txt", True)
        file.WriteLine(" Student Name: " + TextBox1.Text + " Major: " + TextBox2.Text + " Year: " + ComboBox1.Text)
        file.Close()

        DymoPrint.Instance.PrintLabel(DymoSDKLabel, "DYMO LabelWriter 450", 1)
        TextBox1.Clear()
        TextBox2.Clear()
        ComboBox1.SelectedIndex = 0

    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        ComboBox1.Enabled = True
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        ComboBox1.Enabled = False
    End Sub
End Class