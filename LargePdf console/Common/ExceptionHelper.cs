using System;
using System.Runtime.Serialization;

namespace LargePdf_console
{
    public class ExceptionHelper : Exception
    {
        // Test class

    }

    public class NoFilesFound : Exception
    {
        /// <summary>
        /// No Files Found
        /// </summary>
        public NoFilesFound()
        {
            Console.WriteLine("No files found in this directory or the Directory is not accessible. Elevate program's permissions to access this.");
        }

        public NoFilesFound(string message) : base(message)
        {
            Console.WriteLine("No files found in this directory or the Directory is not accessible. Elevate program's permissions to access this.");
            Console.WriteLine(message);
        }

        public NoFilesFound(string message, Exception innerException) : base(message, innerException)
        {
            Console.WriteLine("No files found in this directory or the Directory is not accessible. Elevate program's permissions to access this.");
        }

        protected NoFilesFound(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            Console.WriteLine("No files found in this directory or the Directory is not accessible. Elevate program's permissions to access this.");
        }
    }
}
