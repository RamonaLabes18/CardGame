using System;
using System.Collections.Generic;
using System.Text;

namespace Card_game.Games
{
    public abstract class GameFactory
    {
        protected abstract IGame MakeGame(CardDeck deck, List<Player> players);
        public IGame CreateGame(CardDeck deck, List<Player> players)
        {
            return this.MakeGame(deck, players);
        }
    }
}
