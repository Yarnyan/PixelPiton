using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using UrfuProject.Controllers;
using UrfuProject.Views;

namespace UrfuProject.Models
{
    internal class Snake
    {
        internal double HeadX => Pieces.Last().X;

        internal double HeadY => Pieces.Last().Y;

        private Direction _direction { get; set; }

        private double move = 10;

        internal readonly double stepAngle;

        internal Queue<Piece> Pieces { get; set; }

        internal Snake(Direction direction, double angle)
        {
            stepAngle = angle;

            _direction = direction;

            Pieces = new Queue<Piece>();
            Pieces.Enqueue(new Piece(0.00000001, 0.00000001));
        }

        internal (double, double) GetNextMove()
        {
            var y = HeadY + _direction.kY;
            return (HeadX + _direction.kX, y);
        }

        public void PieceHandle(double x, double y)
        {
            Pieces.Enqueue(new Piece(x, y));
            Pieces.Dequeue();
        }

        public void AddPiece(double x, double y)
        {
            Pieces.Enqueue(new Piece(x, y));
        }

        public bool IsPiece(double x, double y)
        {
            return Pieces.Any(p => p.X == x && p.Y == y);
        }

        internal void View(Graphics g) => SnakeView.Draw(this, g);


        internal void ChangeAngle(int kstep, double? angle1 = null, double? angle2 = null)
        {
            var angle = AdjustAngle(_direction.Angle, stepAngle * kstep * MovementController.Boost, 0, 2*Math.PI, angle1, angle2);

            if (angle < 0) angle = 2*Math.PI + angle;

            _direction = new Direction(Math.Cos(angle) * move, Math.Sin(angle) * move, angle);
        }

        private double AdjustAngle(double angle, double step, double minAngle, double maxAngle, double? angle1 = null, double? angle2 = null)
        {
            if (angle >= maxAngle) angle = angle-2*Math.PI;

            var newAngle = angle;

            if (angle1.HasValue && angle2.HasValue)
            {
                if ((angle < angle1 && angle >= 0) || (angle <= maxAngle && angle > angle2)) newAngle += step;
                else if (angle < angle2 && angle > angle1) newAngle -= step;
            }
            else
            {
                if (angle <= Math.PI && angle > 0) newAngle -= step;
                else if (angle <= 2*Math.PI && angle > Math.PI) newAngle += step;
            }
            var a = (Math.Truncate(newAngle / Math.PI)) * Math.PI;
            return newAngle - a;
        }
    }
}
