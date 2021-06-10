using Cards;
using System;
using System.Collections.Generic;

namespace Card_game
{
    class Program
    {
        static void Main(string[] args)
        {

            CardDeck cardsDeck = new CardDeck();
            List<Card> DiscardPile = new List<Card>();
            cardsDeck.Shuffle();


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


            GameManager game = new GameManager(cardsDeck,playerList);
            game.PlayGame();














        }
    }
}
