using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrfuProject.Models
{
    internal class Piece
    {
        internal readonly double X;

        internal readonly double Y;

        internal Piece(double x, double y)
        {
            X = x;
            Y = y;
        }

        internal bool IsHead(Snake snake) => X == snake.HeadX && Y == snake.HeadY;
    }
}
