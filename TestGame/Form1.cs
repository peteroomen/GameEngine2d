using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GameEngine2d.Game;

namespace TestGame
{
    public partial class Form1 : Form
    {
        private GameEngine2d.Graphics2d.GameCanvas gameCanvas;
        Game game;

        public Form1()
        {
            InitializeComponent();
            game = new Game(gameCanvas);
            game.StartGame();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            game.StopGame();
        }

        private void InitializeComponent()
        {
            this.gameCanvas = new GameEngine2d.Graphics2d.GameCanvas();
            this.SuspendLayout();
            // 
            // gameCanvas
            // 
            this.gameCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameCanvas.Location = new System.Drawing.Point(0, 0);
            this.gameCanvas.Name = "gameCanvas";
            this.gameCanvas.Size = new System.Drawing.Size(1264, 681);
            this.gameCanvas.TabIndex = 0;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.gameCanvas);
            this.Name = "Form1";
            this.ResumeLayout(false);

        }
    }
}
