using System;
using System.Windows.Forms;
using UrfuProject.Controllers;
using UrfuProject.Models;
using UrfuProject.Views;

namespace UrfuProject
{
    public partial class Form1 : Form
    {
        public Form1(Game game)
        {
            InitializeComponent();

            this.DoubleBuffered = true;

            this.GameTimer.Tick += game.MovementController.OnMove;
            this.Paint += game.FrameController.UpdateFrame;
            this.KeyDown += game.MovementController.OnKeyDown;
            this.KeyUp += game.MovementController.OnKeyUp;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
