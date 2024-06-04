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
    }
}
