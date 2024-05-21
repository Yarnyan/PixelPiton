using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrfuProject.Models;

namespace UrfuProject.Views
{
    internal class SnakeView
    {
        private static Color _color { get; } = Color.Blue;

        private static Color _headColor { get; } = Color.Orange;

        private static Brush _brush { get; } = new SolidBrush(_color);

        private static Brush _headBrush { get; } = new SolidBrush(_headColor);

        public static void Draw(Snake snake, Graphics graphics)
        {
            foreach (var piece in snake.Pieces)
            {
                var c = (float)(Program.Game.Radius / 2);
                var a = (float)(piece.X - c);

                graphics.FillRectangle(new SolidBrush(Color.Green), (float)(piece.X), (float)(piece.Y),3, 3);
                
                if (!piece.IsHead(snake))
                    graphics.FillEllipse(_brush, (float)(piece.X - c), (float)(piece.Y - c), Program.Game.Radius, Program.Game.Radius);
                else
                    graphics.FillEllipse(_headBrush, (float)(piece.X - c), (float)(piece.Y - c), Program.Game.Radius, Program.Game.Radius);
            }
        }
    }
}
