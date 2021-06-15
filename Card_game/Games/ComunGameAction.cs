using Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace Card_game.Games
{
    public abstract class ComunGameAction : IGame
    {
        public CardDeck GetCardDeck()
        {
            CardDeck cardsDeck = new CardDeck();
            cardsDeck.Shuffle();
            return cardsDeck;
        }

        public List<Player> GetPlayerList()
        {
            Console.WriteLine("How many players are you ?");
            int numPlayers = Convert.ToInt32(Console.ReadLine());

            List<Player> playerList = new List<Player>();
            //Create the players
            for (int i = 1; i <= numPlayers; i++)
            {
                playerList.Add(new Player()
                {
                    Position = i
                });
            }
            return playerList;
        }

        public abstract Player play(CardDeck cardDeck, List<Player> players);
        public abstract string GetGameType();


    }
}
