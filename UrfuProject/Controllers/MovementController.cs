using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UrfuProject.Models;

namespace UrfuProject.Controllers
{
    internal class MovementController : ControllerBase
    {
        private static int _boost;

        private static int _acc { get; set; } = 0;

        public static int Boost {
            get => _boost; 
            set {
                _boost = value < 0 ? 0 : value;
                Program.Game.Form.Text = $"Управление стрелками. Ускорение/Замедление - CTRL/SHIFT. Ускорение = {_boost}";
            }}

        public MovementController(Game game) : base(game)
        { }

        internal void OnKeyDown(object? sender, KeyEventArgs? e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    _snake.ChangeAngle(-1);
                    break;
                case Keys.Right:
                    _snake.ChangeAngle(1);
                    break;
                case Keys.Up:
                    _snake.ChangeAngle(-1, Math.PI/2, 3*Math.PI/2);
                    break;
                case Keys.Down:
                    _snake.ChangeAngle(1, Math.PI / 2, 3*Math.PI/2);
                    break;
                case Keys.ControlKey:
                    Boost += 1 + _acc;
                    _acc++;
                    break;
                case Keys.ShiftKey:
                    Boost -= (1+_acc);
                    _acc++;
                    break;
                default:
                    return;
            }
        }

        internal void OnMove(object? sender, EventArgs? e)
        {
            var coords = _snake.GetNextMove();

            if (_food.CanEat(coords.Item1, coords.Item2, _game.Radius))
            {
                _snake.AddPiece(coords.Item1, coords.Item2);
                _food.GenerateFoodCoord(_game.Snake);
            }
            else
            {
                _snake.PieceHandle(coords.Item1, coords.Item2);
            }

            _game.Form.Invalidate();
        }

        internal void OnKeyUp(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey || e.KeyCode == Keys.ControlKey)
                _acc = 0;
        }
    }
}
