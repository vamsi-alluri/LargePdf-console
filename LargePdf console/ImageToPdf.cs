using System;

namespace LargePdf_console
{
    public class ImageToPdf : ImageToPdfBase
    {
        public ImageToPdf()
        {
        }

        public ImageToPdf(ImageToPdfOptions options)
        {
            outputPdfFileName = options.FileName;
        }

        public ImageToPdf(string pdfFileName) => outputPdfFileName = pdfFileName ?? string.Empty;

        public override bool TryConvertingImageToPdf()
        {
            try
            {
                Aspose.Aspose_ImageToPdf asposeConverter = new Aspose.Aspose_ImageToPdf();
            }
            catch (Exception ex)
            {
                try
                {
                    PdfSharp.PdfSharp_ImageToPdf pdfSharpConverter = new PdfSharp.PdfSharp_ImageToPdf();
                }
                catch (Exception ex2)
                {
                    Console.WriteLine(ex2.Message + ex.Message);
                    return false;
                }
                return false;
            }
            return true;
        }
    }
}
