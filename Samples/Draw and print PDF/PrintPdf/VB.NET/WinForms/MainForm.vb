﻿Imports System
Imports System.Windows.Forms
Imports BitMiracle.Docotic.Pdf

Namespace BitMiracle.Docotic.Pdf.Samples
    Partial Public Class MainForm
        Inherits Form

        Private Const FitPageIndex = 0

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Function getPrintSize() As PrintSize
            Return If(printSize.SelectedIndex = FitPageIndex, Samples.PrintSize.FitPage, Samples.PrintSize.ActualSize)
        End Function

        Private Sub printButton_Click(sender As Object, e As EventArgs) Handles printButton.Click
            processExistingPdfDocument(New Func(Of PdfDocument, PrintSize, DialogResult)(AddressOf ShowPrintDialog))
        End Sub

        Private Sub previewButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles previewButton.Click
            processExistingPdfDocument(New Func(Of PdfDocument, PrintSize, DialogResult)(AddressOf ShowPrintPreview))
        End Sub

        Private Sub processExistingPdfDocument(ByVal action As Func(Of PdfDocument, PrintSize, DialogResult))
            Using dlg As OpenFileDialog = New OpenFileDialog()
                dlg.Filter = "PDF files (*.pdf)|*.pdf"

                If dlg.ShowDialog() = DialogResult.OK Then
                    ' NOTE:
                    ' When used in trial mode, the library imposes some restrictions.
                    ' Please visit http://bitmiracle.com/pdf-library/trial-restrictions.aspx
                    ' for more information.

                    Using pdf As PdfDocument = New PdfDocument(dlg.FileName)
                        action(pdf, getPrintSize())
                    End Using
                End If
            End Using
        End Sub
    End Class
End Namespace
