using System;
using static LargePdf_console.Extensions;

namespace LargePdf_console
{
    public class Program
    {

        [STAThread]
        public static void Main()
        {

            Console.ResetColor();
            exceptionCount = 0;


            using (var converter = new ImageToPdf())
            {
                do
                {
                    if (!converter.TryConvertingImageToPdf())
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n****** Converting failed with exceptions. ******\n");
                        Console.ResetColor();
                        exceptionCount++;
                    }

                } while (ShouldProgramContinue(exceptionCount >= 4));
            }
        }

        private static bool ShouldProgramContinue(bool? value = null)
        {
            Console.Clear();
            if (value == false)
            {
                Console.WriteLine("Force shutdown. Might had more than 3 exceptions.");
                return false;
            }
            Console.WriteLine("\nAnother pdf? (Y/N)");
            return value ?? IsYes(Console.ReadKey().KeyChar);
        }
    }
}
