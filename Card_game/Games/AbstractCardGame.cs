using Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace Card_game.Games
{
    public abstract class AbstractCardGame : IGame //AbstractCardGame
    {
        
        public CardDeck CardDeck { get; set; }
        public List<Player> PlayerList { get; set; }

        public AbstractCardGame(CardDeck deck, List<Player> players)
        {
            this.CardDeck = deck;
            this.PlayerList = players;
        }

        public abstract Player Play();
        public abstract string GetGameType();


    }
}
