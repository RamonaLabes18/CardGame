using Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace Card_game.Games
{
    public interface IGame
    {
        string GetGameType();
        public CardDeck CardDeck { get; set; }
        public List<Player> PlayerList { get; set; }
        Player Play();
       
        
        //pachet de carti 
        //lista de jucatori
        //metoda de play 

    }
}
