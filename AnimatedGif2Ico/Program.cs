using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace AnimatedGif2Ico
{
    class Program
    {
        private static string _animatedGifFullPath = "unknown";
        private static string _animatedIcoFullPath = "unknown";

        static void Main(string[] args)
        {
            PrintIntro();

            if (args.Length != 1)
            {
                PrintHelp();
                StopApp();
            }

            if (args.Length == 1)
            {
                _animatedGifFullPath = args[0];
                _animatedIcoFullPath = _animatedGifFullPath.Substring(0, _animatedGifFullPath.LastIndexOf('.')) + ".ico";
            }

            Console.WriteLine("AnimatedGifFullPath=" + _animatedGifFullPath);
            Console.WriteLine("AnimatedIcoFullPath=" + _animatedIcoFullPath);

            AnimatedGif2Ico converter = new AnimatedGif2Ico();
            converter.Start(_animatedGifFullPath, _animatedIcoFullPath);

            StopApp();
        }

        static private void PrintIntro()
        {
            Console.WriteLine("Pdf2Jpg.exe  A handy tool to convert a pdf file to jpg");

        }
        static private void PrintHelp()
        {
            Console.WriteLine("AnimatedGif2Ico requires 1 parameter, ie the full pathname to the pdf to convert.");
            Console.WriteLine("The output ico file will be in the same folder, with the same base filename as the source gif file.");
            Console.WriteLine("The output ico file will have the fileextension .ico");
            Console.WriteLine();
            Console.WriteLine("Example:");
        }

        static private void StopApp()
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                Console.WriteLine();
                Console.WriteLine("Press any key to quit");
                Console.ReadKey();
                // You are debugging 
            }
            Environment.Exit(0);
        }

    }
}
