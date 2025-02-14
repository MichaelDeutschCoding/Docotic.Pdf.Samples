Imports BitMiracle.Docotic.Pdf

Namespace BitMiracle.Docotic.Pdf.Samples
    Public NotInheritable Class HeaderAndFooter
        Public Shared Sub Main()
            ' NOTE:
            ' When used in trial mode, the library imposes some restrictions.
            ' Please visit http://bitmiracle.com/pdf-library/trial-restrictions.aspx
            ' for more information.

            Const PathToFile As String = "HeaderAndFooter.pdf"

            Using pdf = New PdfDocument("..\Sample Data\BRAILLE CODES WITH TRANSLATION.pdf")
                Dim font As PdfFont = pdf.AddFont(PdfBuiltInFont.Helvetica)

                For i As Integer = 0 To pdf.PageCount - 1
                    Dim page As PdfPage = pdf.Pages(i)
                    drawHeader(page, font)
                    drawFooter(i, page, font)
                Next

                pdf.Save(PathToFile)
            End Using

            Console.WriteLine($"The output is located in {Environment.CurrentDirectory}")

            Process.Start(New ProcessStartInfo(PathToFile) With {.UseShellExecute = True})
        End Sub

        Private Shared Sub drawHeader(ByVal page As PdfPage, ByVal font As PdfFont)
            Dim canvas = page.Canvas
            canvas.Font = font
            canvas.FontSize = 30

            Const HeaderText As String = "Header"
            Dim textWidth As Double = canvas.GetTextWidth(HeaderText)
            Dim rotatedPageWidth As Double = getRotatedPageSize(page).Width
            Dim headerPosition = New PdfPoint((rotatedPageWidth - textWidth) / 2, 10)

            showTextAtRotatedPage(HeaderText, headerPosition, page)
        End Sub

        Private Shared Sub drawFooter(ByVal pageIndex As Integer, ByVal page As PdfPage, ByVal font As PdfFont)
            Dim canvas = page.Canvas
            canvas.Font = font
            canvas.FontSize = 14

            Dim rotatedPageSize As PdfSize = getRotatedPageSize(page)
            Dim paddingFromCorner = New PdfSize(30, 30)
            Dim positionRightBottom = New PdfPoint(rotatedPageSize.Width - paddingFromCorner.Width, rotatedPageSize.Height - paddingFromCorner.Height)

            showTextAtRotatedPage((pageIndex + 1).ToString(), positionRightBottom, page)
        End Sub

        Private Shared Function getRotatedPageSize(ByVal page As PdfPage) As PdfSize
            If page.Rotation = PdfRotation.Rotate90 OrElse page.Rotation = PdfRotation.Rotate270 Then
                Return New PdfSize(page.Height, page.Width)
            End If

            Return New PdfSize(page.Width, page.Height)
        End Function

        Private Shared Sub showTextAtRotatedPage(ByVal text As String, ByVal position As PdfPoint, ByVal page As PdfPage)
            Dim canvas As PdfCanvas = page.Canvas

            If page.Rotation = PdfRotation.None Then
                canvas.DrawString(position.X, position.Y, text)
                Return
            End If

            canvas.SaveState()

            Select Case page.Rotation
                Case PdfRotation.Rotate90
                    canvas.TranslateTransform(position.Y, page.Height - position.X)
                Case PdfRotation.Rotate180
                    canvas.TranslateTransform(page.Width - position.X, page.Height - position.Y)
                Case PdfRotation.Rotate270
                    canvas.TranslateTransform(page.Width - position.Y, position.X)
            End Select

            canvas.RotateTransform(CInt(page.Rotation) * 90)
            canvas.DrawString(0, 0, text)

            canvas.RestoreState()
        End Sub
    End Class
End Namespace