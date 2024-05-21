using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrfuProject.Models;

namespace UrfuProject.Controllers
{
    internal class ControllerBase
    {
        protected Game _game { get; private set; }

        protected Snake _snake => _game.Snake;

        protected Food _food => _game.Food;

        public ControllerBase(Game game) {
            _game = game;
        }
    }
}
