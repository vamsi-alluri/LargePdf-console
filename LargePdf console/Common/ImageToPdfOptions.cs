using LargePdf_console.Common;
using System;
using System.Collections.Generic;

namespace LargePdf_console
{
    public class ImageToPdfOptions : IEquatable<ImageToPdfOptions>
    {
        public ImageToPdfOptions()
        {
        }

        public ImageToPdfOptions (ImageToPdfOptions other)
        {
            if (other == null)
                return;

            FileName = other.FileName;
            FilePath = other.FilePath;
            FullFilePath = other.FullFilePath;
            FolderName = other.FolderName;
            FullFolderPath = other.FullFolderPath;
            PageType = other.PageType;
        }

        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FullFilePath { get; set; }
        public string FolderName { get; set; }
        public string FullFolderPath { get; set; }
        public PageTypes PageType { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                return false;
            return Equals(obj as ImageToPdfOptions);
        }

        public bool Equals(ImageToPdfOptions other)
        {
            return other != null &&
                   FileName == other.FileName &&
                   FilePath == other.FilePath &&
                   FullFilePath == other.FullFilePath &&
                   FolderName == other.FolderName &&
                   FullFolderPath == other.FullFolderPath &&
                   PageType == other.PageType;
        }

        public override int GetHashCode()
        {
            int hashCode = -1857136776;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FileName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FilePath);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FullFilePath);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FolderName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FullFolderPath);
            hashCode = hashCode * -1521134295 + PageType.GetHashCode();
            return hashCode;
        }
    }
}
