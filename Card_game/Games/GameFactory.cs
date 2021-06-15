using System;
using System.Collections.Generic;
using System.Text;

namespace Card_game.Games
{
    public abstract class GameFactory
    {
        protected abstract IGame MakeGame();
        public IGame CreateGame()
        {
            return this.MakeGame();
        }
    }
}
