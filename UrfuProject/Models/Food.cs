using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrfuProject.Views;

namespace UrfuProject.Models
{
    internal class Food
    {
        internal double X { get; private set; } = 38;
        internal double Y { get; private set; } = 435;

        private static Random _random { get; set; } = new Random();

        internal void View(Graphics g) => FoodView.Draw(this, g);

        public Food()
        {
            GenerateFoodCoord();
        }

        public bool CanEat(double x, double y, double radius)
        {
            double dx = x - X;
            double dy = y - Y;

            return Math.Sqrt(dx * dx + dy * dy) <= radius;
        }

        public void GenerateFoodCoord(Snake snake)
        {
            double x = _random.Next(4, Program.Game.Form.Size.Width-4);
            double y = _random.Next(4, Program.Game.Form.Size.Height-4);

            if (snake.IsPiece(x, y))
            {
                GenerateFoodCoord(snake);
            }
            else
            {
                X = x; Y = y;
            }
        }

        public void GenerateFoodCoord()
        {
            double x = _random.Next(0, Program.Game.Form.Size.Width - 2);
            double y = _random.Next(0, Program.Game.Form.Size.Height - 2);
            X = x; Y = y;
        }
    }
}
