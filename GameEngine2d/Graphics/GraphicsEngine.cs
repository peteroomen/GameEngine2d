using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Drawing.Imaging;
using System.Threading;

namespace GameEngine2d.Graphics2d
{
    class GameEngine
    {
        #region Grapics engine settings

        /* General settings */
        private Color backgroundColor;

        /* Quality settings */
        // Lowest settings
        /*
        private InterpolationMode interpolationMode = InterpolationMode.NearestNeighbor;
        private SmoothingMode smoothingMode = SmoothingMode.None;
        private PixelOffsetMode pixelOffsetMode = PixelOffsetMode.None;
        private CompositingQuality compositingQuality = CompositingQuality.HighSpeed;
        private TextRenderingHint textRenderingHint = TextRenderingHint.SingleBitPerPixel;
        */
         
        // Highest settings
        private InterpolationMode interpolationMode = InterpolationMode.High;
        private SmoothingMode smoothingMode = SmoothingMode.HighQuality;
        private PixelOffsetMode pixelOffsetMode = PixelOffsetMode.HighQuality;
        private CompositingQuality compositingQuality = CompositingQuality.HighQuality;
        private TextRenderingHint textRenderingHint = TextRenderingHint.AntiAlias;

        #endregion

        private Graphics graphics;
        private Thread renderThread;

        public int Width { get; private set; }
        public int Height { get; private set; }
        public int FPS { get; private set; }

        public GameEngine(Graphics grapics, int width, int height)
        {
            this.graphics = grapics;
            Width = width;
            Height = height;
            backgroundColor = Color.LightBlue;
            grapics.InterpolationMode = interpolationMode;
            grapics.SmoothingMode = smoothingMode;
            graphics.PixelOffsetMode = pixelOffsetMode;
            grapics.CompositingQuality = compositingQuality;
            grapics.TextRenderingHint = textRenderingHint;

        }

        public void StartRender()
        {
            renderThread = new Thread(new ThreadStart(render));
            renderThread.Start();
        }

        public void StopRender()
        {
            renderThread.Abort();
        }

        private void render() {
            int framesRendered = 0;
            long startTime = Environment.TickCount;

            Bitmap frame = new Bitmap(Width, Height, PixelFormat.Format32bppPArgb);
            Graphics frameGraphics = Graphics.FromImage(frame);
            frameGraphics.InterpolationMode = interpolationMode;
            frameGraphics.SmoothingMode = smoothingMode;
            frameGraphics.PixelOffsetMode = pixelOffsetMode;
            frameGraphics.CompositingQuality = compositingQuality;
            frameGraphics.TextRenderingHint = textRenderingHint;

            while (true)
            {
                frameGraphics.Clear(backgroundColor);
                frameGraphics.DrawLine(new Pen(Color.Blue), new Point(10, 10), new Point(100, 100));
                graphics.DrawImage(frame, 0, 0);

                // Benchmarking
                framesRendered++;
                if (Environment.TickCount >= startTime + 1000) {
                    FPS = framesRendered;
                    Console.WriteLine("GraphicsEngine: " + FPS + " fps");
                    framesRendered = 0;
                    startTime = Environment.TickCount;
                }

            }
        }
    }
}
