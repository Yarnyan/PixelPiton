using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrfuProject.Models;

namespace UrfuProject.Views
{
    internal class FoodView
    {
        private static Color _color { get; } = Color.Red;

        public static void Draw(Food food, Graphics graphics)
        {
            Brush brush = new SolidBrush(_color);
            graphics.FillEllipse(brush, (float)(food.X - Program.Game.Radius / 2), (float)(food.Y - Program.Game.Radius / 2), Program.Game.Radius, Program.Game.Radius);
        }
    }
}
