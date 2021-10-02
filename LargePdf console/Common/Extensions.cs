using System.Collections.Generic;
using System.IO;
using Aspose.Pdf;

namespace LargePdf_console
{
    public static class Extensions
    {
        public static readonly List<string> YesClassifiers = new List<string>() { "Y", "y", "Yes", "yes" }; 

        public static string AddPdfExtension(string value)
        {
            if (Path.GetExtension(value).Equals(string.Empty))
                return Path.GetFileName(value).ExtensionAsPdf();

            return Path.GetFileNameWithoutExtension(value).ExtensionAsPdf();
        }

        public static string CreatePdfSaveDirectory(string currentDirectory, string fileName) => $"{currentDirectory}\\{fileName}";

        static string ExtensionAsPdf(this string name) => $"{name}.pdf";

        public static bool IsYes(char value) => YesClassifiers.Contains(value.ToString());

        /// <summary>
        /// Current Directory + File Name
        /// </summary>
        /// <param name="document"></param>
        /// <param name="saveDirectory"></param>
        /// <param name="outPdfFileName"></param>
        public static void Save(this Document document, string saveDirectory = null, string outPdfFileName = null) => document.Save(CreatePdfSaveDirectory(saveDirectory, outPdfFileName));

        public static int exceptionCount { get; set; }
    }
}
