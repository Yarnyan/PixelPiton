using System;
using System.Windows.Forms;
using UrfuProject.Models;

namespace UrfuProject
{
    internal static class Program
    {
        public static Game Game { get; set; }

        [STAThread]
        static void Main()
        {
            double angle = Math.PI/18;

            Game = new Game(angle);
            Form1 form = new Form1(Game);
            Game.SetForm(form);
            
            Application.Run(form);
        }
    }
}