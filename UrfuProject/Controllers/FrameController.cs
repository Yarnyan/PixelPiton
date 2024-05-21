using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UrfuProject.Models;

namespace UrfuProject.Controllers
{
    internal class FrameController : ControllerBase
    {
        public FrameController(Game game) : base(game)
        { }

        public void UpdateFrame(object? sender, PaintEventArgs e)
        {
            _snake.View(e.Graphics);
            _food.View(e.Graphics);

            CheckBackground();
        }

        public void CheckBackground()
        {
            int maxX = _game.Form.Width;
            var r = Program.Game.Radius;
            int maxY = _game.Form.Height;

            var sc = (x: _snake.HeadX, y: _snake.HeadY);

            if (sc.x <= 0 || sc.x >= maxX-r || sc.y >= maxY-r || sc.y <= 0)
            {
                _game.Restart();
            }
        }
    }
}
