using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Pdf2Jpg
{
    class Program
    {
        private static string _ghostScriptLibPath = "unknown";
        private static string _pdfFullFilename = "unknown";
        private static string _outputImageFileName = "unknown";

        static void Main(string[] args)
        {
            PrintIntro();


            Assembly ass = Assembly.GetExecutingAssembly();
            _ghostScriptLibPath = System.IO.Path.GetDirectoryName(ass.Location);
            _ghostScriptLibPath = _ghostScriptLibPath + @"\gsdll32.dll";

            if (args.Length != 1)
            {
                PrintHelp();
                Environment.Exit(0);
            }

            if (args.Length == 1)
            {
                _pdfFullFilename = args[0];
                _outputImageFileName = _pdfFullFilename.Substring(0, _pdfFullFilename.LastIndexOf('.')) + ".jpg";
            }

            Console.WriteLine("GhostScriptlibPath=" + _ghostScriptLibPath);
            Console.WriteLine("PdfFullFn=" + _pdfFullFilename);
            Console.WriteLine("OutputImageFileName=" + _outputImageFileName);
            
            ConvertPdf2Jpg rasterizer = new ConvertPdf2Jpg();
            rasterizer.Start(_ghostScriptLibPath, _pdfFullFilename, _outputImageFileName);
        }

        static private void PrintIntro()
        {
            Console.WriteLine("Pdf2Jpg.exe  A handy tool to convert a pdf file to jpg");

        }
        static private void PrintHelp()
        {
            Console.WriteLine("Pdf2Jpg requires 1 parameter, ie the full pathname to the pdf to convert.");
            Console.WriteLine("The output jpg file will be in the same folder, with the same base filename as the source pdf file.");
            Console.WriteLine("The output jpg file will have the fileextension .jpg");
            Console.WriteLine();
            Console.WriteLine("Example:");
            Console.WriteLine("pdf2jpg c:\test\brochure.pdf");
            Console.WriteLine("Output : c:\test\brochure.jpg");
            Console.WriteLine("Multi-page pdfs will be stored in the same pdf.");
            Console.WriteLine();
            Console.WriteLine("See the documentation on github for installation and configuration info.");
            Console.WriteLine("Recommended usage is to add pdf2jpg to the fileexplorer contextmenu");
        }
    }
}
