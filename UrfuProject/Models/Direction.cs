using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrfuProject.Models
{
    internal class Direction
    {
        internal readonly double kX;

        internal readonly double kY;

        internal readonly double Angle;

        public Direction(double kX, double kY, double angle)
        {
            this.kX = kX;
            this.kY = kY;
            Angle = angle;
        }
    }
}
