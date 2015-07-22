using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimatedGif2Ico
{
    public class AnimatedGif2Ico
    {
        public void Start(String animatedGifFullPath, String animatedIcoFullPath)
        {

            Icon icon = new Icon(animatedIcoFullPath, 32, 32);
            
            icon.Save();


            Bitmap bmp = new Bitmap(animatedGifFullPath);
            bmp.
            bmp.Save(animatedIcoFullPath, ImageFormat.Icon);
        }
    }
}
