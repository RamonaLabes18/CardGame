using Cards;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Card_game
{

    class GameManager
    {
        public CardDeck CardDeck { get; set; }
        public List<Player> PlayerList { get; set; }
        public List<Card> PileCards { get; set; }

        //operatii pt joc 

        public GameManager(CardDeck deck,List<Player> players)
        {
            this.CardDeck = deck;
            this.PlayerList = players;
            this.PileCards = new List<Card>();
        }


        //MAETODA PLAY PT ALGORITM
        public void PlayGame()
        {
            DealCard();
            ShowHand();
        }

        public void ShowHand()
        {
            foreach (var player in PlayerList)
            {
                player.ShowHand();
            }

            Console.ReadLine();
        }

        public void DealCard()
        {

            foreach(var player in PlayerList)
            {
                for(int i=0; i<5; i++)
                {
                    player.Hand.Add(CardDeck.Deal());
                }
            }

        }

        //Add a single card to the discard pile
        //public void AddCardToDiscardPile(List<Card> DiscardPile, CardDeck drawPile)

        //{
        //    DiscardPile.Add(drawPile.Cards.First());
        //    drawPile.Cards.RemoveAt(0);
        //}


    }
}
