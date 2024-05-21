using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrfuProject.Controllers;

namespace UrfuProject.Models
{
    public class Game
    {
        internal MovementController MovementController { get; }

        internal FrameController FrameController { get; }

        internal Snake Snake { get; private set; }

        internal Food Food { get; private set; }

        internal Form1 Form { get; set; }

        internal float Radius { get; set; }

        internal void SetForm(Form1 form)
        {
            Form = form;
            Food = new Food();
        }

        public Game(double step, int radius = 20)
        {
            Snake = new Snake(new Direction(1, 0, 0), step);

            Radius = radius;
            MovementController = new MovementController(this);
            FrameController = new FrameController(this);
        }

        public void Restart()
        {
            Snake = new Snake(new Direction(1, 0, 0), Snake.stepAngle);
            Food = new Food();
        }
    }
}
