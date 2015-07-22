using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TopLib.WebLib;
namespace Json2Html
{
    public class Json2HtmlConvertor
    {
        public void ConvertFiles(String path, String fileNameWithWildcards)
        {
            String[] files = Directory.GetFiles(path, fileNameWithWildcards);
            for (int i = 0; i < files.Length; i++)
            {
                ConvertFile(files[i]);
            }
        }
        public void ConvertFile(String srcFileName)
        {

            String destFileName = srcFileName;
            Int32 pos = destFileName.LastIndexOf('.');
            if (pos >= 0)
                destFileName = destFileName.Substring(0, pos);

            destFileName = destFileName + ".html";

            String json = File.ReadAllText(srcFileName);

            JSon2HtmlConverter jc = new JSon2HtmlConverter();
            String html = jc.ConvertJson2HtmlString(json);
            
            File.WriteAllText(destFileName, html);
        }

    }
}
