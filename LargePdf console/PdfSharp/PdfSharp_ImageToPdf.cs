using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pdf = PdfSharp.Pdf;

namespace LargePdf_console.PdfSharp
{
    public class PdfSharp_ImageToPdf : ImageToPdfBase, IImageToPdf
    {
        public PdfSharp_ImageToPdf()
        {
            StartUp();
        }

        public PdfSharp_ImageToPdf(ImageToPdfOptions options)
        {
            // Fill all the options, then decide on calling on StartUp.

            Console.WriteLine("As of now this hasn't been implemented. Looks like PDF sharp doesn't have image handlers.");
            return;

            //outputPdfFileName = options.FileName;
            //CurrentDirectory = options.FilePath;
            //FillFilesInPath(CurrentDirectory);
            //if(FilesInPath == null)
            //{
            //    StartUp();
            //}
        }

        public override bool TryConvertingImageToPdf()
        {
            throw new NotImplementedException();
        }
    }
}
