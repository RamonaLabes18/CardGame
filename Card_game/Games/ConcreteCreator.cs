using System;
using System.Collections.Generic;
using System.Text;

namespace Card_game.Games
{
    public class SepticaFactory : GameFactory
    {
        protected override IGame MakeGame(CardDeck deck, List< Player> players)
        {
            IGame game = new Septica(deck, players);
            return game;
        }
    }
    public class RazboiFactory : GameFactory
    {
        protected override IGame MakeGame(CardDeck deck, List<Player> players)
        {
            IGame game = new Razboi(deck, players);
            return game;
        }
    }
    public class MacaouaFactory : GameFactory
    {
        protected override IGame MakeGame(CardDeck deck, List<Player> players)
        {
            IGame game = new Macaoua(deck, players);
            return game;
        }
    }
}
