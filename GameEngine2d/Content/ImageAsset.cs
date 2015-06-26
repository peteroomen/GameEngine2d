using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace GameEngine2d.Content
{
    class ImageAsset : Asset<Bitmap>
    {
        public override void Load()
        {
            Bitmap orig = new Bitmap(assetPath);
            theAsset = orig.Clone(new Rectangle(0, 0, orig.Width, orig.Height), PixelFormat.Format32bppPArgb);
            Console.WriteLine("AssetManager: Image format is " + theAsset.PixelFormat);
        }
    }
}
