using System;
using System.Collections.Generic;
using System.Text;

namespace Card_game.Games
{
    class Septica : AbstractCardGame
    {
        public Septica(CardDeck deck, List<Player> players) : base(deck, players)
        {

        }
      
        public override string GetGameType()
        {
            return "Septica";
        }
        public override Player Play()
        {
            throw new NotImplementedException();
        }
    }
}
