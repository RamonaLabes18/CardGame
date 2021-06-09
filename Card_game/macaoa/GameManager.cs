using Cards;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Card_game
{

    class GameManager
    {

        //operatii pt joc 

        public void ShowHand(List<Player> playerList)
        {
            foreach (var player in playerList)
            {
                player.ShowHand();
            }

            Console.ReadLine();
        }

        public void DealCard(List<Player> playerList, int numPlayers, CardDeck drawPile)
        {
            int maxCards = 5 * playerList.Count;
            int dealtCards = 0;

            while (dealtCards < maxCards)
            {
                for (int i = 0; i < numPlayers; i++)
                {
                    playerList[i].Hand.Add(drawPile.Cards.First());
                    drawPile.Cards.RemoveAt(0);
                    dealtCards++;
                }
            }
        }

        //Add a single card to the discard pile
        public void AddCardToDiscardPile(List<Card> DiscardPile, CardDeck drawPile)

        {
            DiscardPile.Add(drawPile.Cards.First());
            drawPile.Cards.RemoveAt(0);
        }


    }
}
