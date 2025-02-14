using System;

namespace BitMiracle.Docotic.Pdf.Samples
{
    public static class CheckConformanceToPdfA
    {
        public static void Main()
        {
            // NOTE: 
            // When used in trial mode, the library imposes some restrictions.
            // Please visit http://bitmiracle.com/pdf-library/trial-restrictions.aspx
            // for more information.
            
            using (PdfDocument pdf = new PdfDocument(@"..\Sample Data\PDF-A.pdf"))
            {
                PdfaConformance level = pdf.GetPdfaConformance();
                Console.WriteLine("PDF/A conformance level: " + level);
            }
        }
    }
}
