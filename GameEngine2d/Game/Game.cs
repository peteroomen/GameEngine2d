using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using GameEngine2d.Graphics2d;

namespace GameEngine2d.Game
{
    public class Game
    {
        private GameEngine gEngine;
        private GameCanvas canvas;

        public Game(GameCanvas canvas)
        {
            this.canvas = canvas;
        }

        public void StartGame() {
            gEngine = new GameEngine(canvas.CreateGraphics(), canvas.Width, canvas.Height);
            gEngine.StartRender();
        }

        public void StopGame()
        {
            gEngine.StopRender();
        }
    }
}
