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

        private Card lastCard;

        private Player turnWinner;

        //operatii pt joc 

        public GameManager(CardDeck deck,List<Player> players)
        {
            this.CardDeck = deck;
            this.PlayerList = players;
            this.PileCards = new List<Card>();
        }


        //METODA PLAY PT ALGORITM
        public void PlayGame()
        {
            DealCard();
            lastCard = CardDeck.Deal();
            PileCards.Add(lastCard);
            ShowHand();
            //turnWinner = PlayerList[0];
            var numberOfPlayers = PlayerList.Count();

            for (var i = 0; i < numberOfPlayers; i++)
            {
                turnWinner = PlayerList[i];
                while (!PlayerList.Any(x => !x.Hand.Any()))
                {

                    if (lastCard.Value == CardValue.Four)
                        {
                            lastCard.Value = CardValue.Four;
                            turnWinner = PlayerList[i+1];
                    }

                    if (lastCard.Value == CardValue.Two)
                    {
                        Boolean result = CompareCards(lastCard , turnWinner.Hand);
                        if (result)
                        {

                        }
                        else
                        {
                            for (i = 0; i < 2; i++)
                            {
                                turnWinner.Hand.Add(CardDeck.Deal());
                            }
                        }
                    }

                    if (lastCard.Value == CardValue.Three)
                    {
                        Boolean result = CompareCards(lastCard, turnWinner.Hand);
                        if (result)
                        {

                        }
                        else
                        {
                            for (i = 0; i < 2; i++)
                            {
                                turnWinner.Hand.Add(CardDeck.Deal());
                            }
                        }
                    }

                }
            }


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

        public Boolean CompareCards(Card lastCard, List<Card> Hand)
        {
            foreach (var card in Hand)
            {
                if (card.Value == lastCard.Value)
                {
                    return true;
                }
            }

            return false;
        }









    }
}
