# Use GoTo actions in PDF documents
This sample shows how to use Go-To actions in PDF documents with [Docotic.Pdf library](https://bitmiracle.com/pdf-library/).

A Go-To (or jump) action can be created using [PdfDocument.CreateGoToPageAction methods](https://bitmiracle.com/pdf-library/help/pdfdocument.creategotopageaction.html).
CreateGoToPageAction method returns an instance of [PdfGoToAction class](https://bitmiracle.com/pdf-library/help/pdfgotoaction.html).

Use methods and properties of PdfGoToAction class to specify a target page to be shown as the result of the action. You can also specify the upper-left corner of the target page to be positioned at the upper-left corner of the window using PdfGoToAction.Offset property.

A Go-To action (and a number of other action types) can be used for widget event handlers. For example, for [PdfButton.OnMouseDown property](https://bitmiracle.com/pdf-library/help/pdfcontrol.onmousedown.html).

## See also
* [Get free time-limited license key](https://bitmiracle.com/pdf-library/download-pdf-library.aspx)
* [Add annotations, actions and scripts to PDF in C# and VB.NET](https://bitmiracle.com/pdf-library/annotations-and-actions.aspx) article