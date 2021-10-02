using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static LargePdf_console.Extensions;

namespace LargePdf_console
{
    public abstract class ImageToPdfBase : IDisposable
    {
        public const string ImagesToPdf = "Images to PDF";
        private const string ValidFileName = @"^[\w\-. ]+$";
        public static string outputPdfFileName;
        public static List<string> FilesInPath = new List<string>();
        public static string CurrentDirectory = PreviouslyUsedPath ?? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string PreviouslyUsedPath { get; set; }

        protected ImageToPdfBase() { }

        ~ImageToPdfBase()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Destroying all used data from memory....");
        }

        public abstract bool TryConvertingImageToPdf();

        protected void StartUp()
        {
            Console.WriteLine(ImagesToPdf);
            Console.WriteLine("Menu:");

            Console.WriteLine("1. File to PDF(Select a file.)");
            Console.WriteLine("2. Folder to PDF(Select a folder.) Gets files in alphabetical order.");

            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                    FileSelect();
                    break;
                case '2':
                    FolderSelect();
                    break;
                default:
                    Console.WriteLine("Enter a valid option. Try again.");
                    break;
            }

            if (FilesInPath == null)
                throw new NoFilesFound();
            else
                PreviouslyUsedPath = CurrentDirectory;

            
            return;
        }

        public void FileSelect()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                InitialDirectory = CurrentDirectory,
                Title = "Open an image",
                DefaultExt = "jpg",
                Filter = "image files (*.jpg)|*.jpg|All files (*.*)|*.*",
                FilterIndex = 2,
                CheckFileExists = true,
                CheckPathExists = true,
                Multiselect = true,
                ReadOnlyChecked = true,
                ShowReadOnly = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.FileNames == null)
                    throw new NoFilesFound();

                CurrentDirectory = Path.GetDirectoryName(openFileDialog.FileNames[0]);
                FillFilesInPath(CurrentDirectory, openFileDialog.FileNames.ToList());

                Console.WriteLine("\nEnter a custom output filename, if it's empty or invalid, the name of the first file in alphabetical order will be used.");
                var outputFilename = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(outputFilename) && new Regex(ValidFileName).IsMatch(outputFilename))
                    outputPdfFileName = AddPdfExtension(outputFilename);
                else
                    outputPdfFileName = AddPdfExtension(openFileDialog.FileNames.FirstOrDefault());
            }
        }

        public void FolderSelect()
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
            {
                SelectedPath = CurrentDirectory
            };

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                CurrentDirectory = folderBrowserDialog.SelectedPath;
                FillFilesInPath(CurrentDirectory);

                outputPdfFileName = AddPdfExtension(folderBrowserDialog.SelectedPath);
            }
        }

        protected void FillFilesInPath(string CurrentDirectory, List<string> files = null)
        {
            FilesInPath.AddRange(files ?? Directory.GetFiles(CurrentDirectory)?.ToList());

        }

        public void Dispose()
        {
            FilesInPath = null;
            CurrentDirectory = null;
        }
    }
}