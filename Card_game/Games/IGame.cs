using Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace Card_game.Games
{
    public interface IGame
    {
        string GetGameType();
        CardDeck GetCardDeck();
        List<Player> GetPlayerList();
        Player play(CardDeck cardDeck, List<Player> players);
       
        
        //pachet de carti 
        //lista de jucatori
        //metoda de play 

    }
}
