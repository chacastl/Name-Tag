Imports System.IO
Imports System.Text
Imports System.Drawing.Printing
Imports System.Windows.Forms
Imports Microsoft.Office.Interop
Public Class Form1

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
               My.Computer.FileSystem.SpecialDirectories.MyDocuments, "Names.csv")
            If (RadioButton2.Checked = True) Then
                My.Computer.FileSystem.WriteAllText(filePath, TextBox1.Text + ",", True)
                My.Computer.FileSystem.WriteAllText(filePath, TextBox2.Text + ",", True)
                My.Computer.FileSystem.WriteAllText(filePath, ComboBox1.Text + vbNewLine, True)
            Else
                My.Computer.FileSystem.WriteAllText(filePath, TextBox1.Text + ",", True)
                My.Computer.FileSystem.WriteAllText(filePath, TextBox2.Text + ",", True)
                My.Computer.FileSystem.WriteAllText(filePath, "Alumni" + vbNewLine, True)
            End If
        Catch fileException As Exception
            Throw fileException
        End Try
        DymoSDKLabel.GetPreviewLabel()
        ' DymoPrint.Instance.PrintLabel(DymoSDKLabel, "DYMO LabelWriter 450", 1)
        TextBox1.Clear()
        TextBox2.Clear()
        ComboBox1.SelectedIndex = 0
        RadioButton1.Checked = False
        RadioButton2.Checked = True
        ComboBox1.Enabled = True

    End Sub


    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        ComboBox1.Enabled = True
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        ComboBox1.Enabled = False
    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

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


        Dim myimage As Image
        Dim ms As System.IO.MemoryStream = New System.IO.MemoryStream(DymoSDKLabel.GetPreviewLabel())
        myimage = System.Drawing.Image.FromStream(ms)

        PictureBox2.Image = myimage

    End Sub

    Private Sub PrintPreviewDialog1_Load(sender As Object, e As EventArgs) Handles PrintPreviewDialog1.Load

    End Sub
End Class