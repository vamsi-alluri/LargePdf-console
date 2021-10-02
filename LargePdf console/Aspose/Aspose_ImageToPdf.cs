using Aspose.Pdf;
using System;
using System.Diagnostics;
using static LargePdf_console.Extensions;

namespace LargePdf_console.Aspose
{
    public class Aspose_ImageToPdf : ImageToPdfBase, IImageToPdf
    {
        public Aspose_ImageToPdf()
        {
            StartUp();
            TryConvertingImageToPdf();
        }

        public Aspose_ImageToPdf(ImageToPdfOptions options)
        {
            outputPdfFileName = options.FileName;
            CurrentDirectory = options.FilePath;
            FillFilesInPath(CurrentDirectory);
            if (FilesInPath == null)
            {
                StartUp();
            }
        }

        public override bool TryConvertingImageToPdf()
        {
            if (FilesInPath == null)
                throw new NoFilesFound();

            //Document doc1 = new Document();
            //foreach(var fileName in FilesInPath)
            //{

            //    doc1.Pages.Add();
            //    var image = new Image()
            //    {
            //        File = fileName
            //    };
            //    Page page1 = doc1.Pages.Add();
            //    page1.PageInfo = Pages.A4;
            //    page1.Paragraphs.Add(image);
            //    doc1.Pages.Add(page1);
            //}
            //doc1.Save($"{CurrentDirectory}\\Test {outputPdfFileName}");


            Document doc = new Document();
            Page page = doc.Pages.Add();

            Console.WriteLine();
            foreach (var fileName in FilesInPath)
            {
                try
                {
                    var image = new Image
                    {
                        File = fileName
                    };
                    page.PageInfo = Pages.A4;
                    page.Paragraphs.Add(image);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Excluded " + fileName+ ", as this is not an image.");
#if DEBUG
                    Console.WriteLine(ex);
#endif  
                    continue;
                }
            }

            doc.Save($"{CurrentDirectory}\\{outputPdfFileName}");
            Process.Start("explorer.exe", CurrentDirectory);
            return true;
        }
    }
}
