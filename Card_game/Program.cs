using Cards;
using System;
using System.Collections.Generic;

namespace Card_game
{
    class Program
    {
        static void Main(string[] args)
        {

            CardDeck drawPile = new CardDeck();
            List<Card> DiscardPile = new List<Card>();
            drawPile.Shuffle();
            drawPile.DisplaytheDeck();


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

            //Deal 5 cards to each player

            GameManager game = new GameManager();
            Player players = new Player();

            game.DealCard(playerList, numPlayers, drawPile);
            
            //cartili jucatorului din mana
            foreach (var player in playerList)
            {
                player.ShowHand();
            }

            Console.ReadLine();

            game.AddCardToDiscardPile(DiscardPile, drawPile);














        }
    }
}
