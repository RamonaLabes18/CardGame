using System;
using System.Collections.Generic;
using System.Text;

namespace Card_game.Games
{
    class Razboi : ComunGameAction

    {
    
        public override string GetGameType()
        {
            return "Razboi";
        }

        public override Player play(CardDeck cardDeck, List<Player> players)
        {
            return players[0];
        }
    }
}
