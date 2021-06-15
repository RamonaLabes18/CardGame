using System;
using System.Collections.Generic;
using System.Text;

namespace Card_game.Games
{
    public class SepticaFactory : GameFactory
    {
        protected override IGame MakeGame()
        {
            IGame game = new Septica();
            return game;
        }
    }
    public class RazboiFactory : GameFactory
    {
        protected override IGame MakeGame()
        {
            IGame game = new Razboi();
            return game;
        }
    }
    public class MacaouaFactory : GameFactory
    {
        protected override IGame MakeGame()
        {
            IGame game = new Macaoua();
            return game;
        }
    }
}
