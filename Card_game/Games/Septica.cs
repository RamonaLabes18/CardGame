using System;
using System.Collections.Generic;
using System.Text;

namespace Card_game.Games
{
    class Septica : ComunGameAction
    {
      
        public override string GetGameType()
        {
            return "Septica";
        }

        public override Player play(CardDeck cardDeck, List<Player> players)
        {
            return players[0];
        }
    }
}
