using System;
using System.Collections.Generic;
using System.Text;

namespace Card_game.Games
{
    class Razboi : AbstractCardGame

    {
        public Razboi(CardDeck deck, List<Player> players) : base(deck, players)
        {

        }
        public override string GetGameType()
        {
            return "Razboi";
        }


        public override Player Play()
        {
            throw new NotImplementedException();
        }
    }
}
