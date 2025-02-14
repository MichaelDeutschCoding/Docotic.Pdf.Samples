﻿Imports BitMiracle.Docotic.Pdf.HtmlToPdf

Class MainWindow
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        textBoxUrl.Text = "https://bitmiracle.com"
        setConvertingMode(False)
    End Sub

    Private Sub setConvertingMode(convertingMode As Boolean)
        textBoxUrl.IsEnabled = Not convertingMode
        buttonConvert.IsEnabled = Not convertingMode
        progressBarConverting.Visibility = If(convertingMode, Visibility.Visible, Visibility.Hidden)
    End Sub

    Private Async Sub Button_Click(sender As Object, e As RoutedEventArgs)
        setConvertingMode(True)

        Try
            Await convertUrlToPdfAsync(textBoxUrl.Text, "HtmlToPdfWpf.pdf")
        Catch ex As HtmlConverterException
            MessageBox.Show(ex.Message, "Conversion failed")
            setConvertingMode(False)
        End Try
    End Sub

    Private Async Function convertUrlToPdfAsync(ByVal urlString As String, ByVal pdfFileName As String) As Task
        Using converter = Await HtmlConverter.CreateAsync()

            Using pdf = Await converter.CreatePdfAsync(New Uri(urlString))
                pdf.Save(pdfFileName)
            End Using
        End Using

        setConvertingMode(False)
        MessageBox.Show(Me, $"The output is located in {Environment.CurrentDirectory}")

        Process.Start(New ProcessStartInfo(pdfFileName) With {.UseShellExecute = True})
    End Function
End Class
