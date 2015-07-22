using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Json2Html
{
    class Program
    {
        static void Main(string[] args)
        {
            if ((args == null) || (args.Length != 1))
            {
                Console.Write("Invalid parms ... specify 1 filename. Wildcards are allowed.");
                Console.Write("Json2Html exits.");
                return;
            }

            String filenameSelector = args[0];
            Boolean isSingleFile = true;
            if (filenameSelector.IndexOf("*") >= 0)
                isSingleFile = false;
            if (filenameSelector.IndexOf("?") >= 0)
                isSingleFile = false;

            Json2HtmlConvertor j2hConverter = new Json2Html.Json2HtmlConvertor();
            if (isSingleFile)
            {
                j2hConverter.ConvertFile(filenameSelector);
            }
            else
            {
                Int32 posLastSlash = filenameSelector.LastIndexOf('\\');

                String path = "";
                String fnWithWildcards = filenameSelector;
                if (posLastSlash < 0)
                {
                    path = Directory.GetCurrentDirectory();
                }
                else
                {
                    path = filenameSelector.Substring(0, posLastSlash);
                    fnWithWildcards = filenameSelector.Substring(0, posLastSlash);
                }

                j2hConverter.ConvertFiles(path, fnWithWildcards);
            }

        }
        private static Boolean ConvertJsonFile2Html(String fileName)
        {
            return true;
        }
    }
}
