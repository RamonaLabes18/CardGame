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

        private LinkedList<Player> linkPlayers;
        private Card lastCard;
        private Player turnWinner;

        //operatii pt joc 

        public GameManager(CardDeck deck, List<Player> players)
        {
            this.CardDeck = deck;
            this.PlayerList = players;
            this.PileCards = new List<Card>();
            this.linkPlayers = new LinkedList<Player>(players);
        }

        //METODA PLAY PT ALGORITM
        public void PlayGame()
        {
            DealCard();
            lastCard = CardDeck.Deal();
            PileCards.Add(lastCard);
            ShowHand();
            turnWinner = PlayerList[0];
            var currentPlayer = linkPlayers.Find(turnWinner);

            do
            {
                Console.WriteLine("Pile Card is : " + lastCard);
                lastCard =  CheckSpecialCard(lastCard);
                ShowHand();
                
                if (currentPlayer.Next == null)
                {
                    currentPlayer = linkPlayers.First;
                }
                else
                {
                    currentPlayer = currentPlayer.Next;
                }
            }
            while (currentPlayer.Value != turnWinner);



        }
        //playturn(player)
        //verificare dupa fiecare jucator
        //{


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

            foreach (var player in PlayerList)
            {
                for (int i = 0; i < 5; i++)
                {
                    player.Hand.Add(CardDeck.Deal());
                }
            }

        }

        public Boolean CompareCardsValue(Card lastCard, List<Card> Hand)
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

        public Boolean CompareCardValueOrSuit(Card lastCard, List<Card> Hand)
        {
            foreach (var card in Hand)
            {
                if (card.Suit == lastCard.Suit || card.Value == lastCard.Value)
                {
                    return true;
                }
            }

            return false;
        }

        public Stack<Card> findCardsValue(Card lastCard, List<Card> Hand)
        {
            Stack<Card> cardsFind = new Stack<Card>();
            foreach (var card in Hand)
            {
                if (card.Value == lastCard.Value)
                {
                    cardsFind.Push(card);
                }
            }

            return cardsFind;
        }

        public Stack<Card> findCardsValueOrSuit(Card lastCard, List<Card> Hand)
        {
            Stack<Card> cardsFind = new Stack<Card>();
            foreach (var card in Hand)
            {
                if (card.Value == lastCard.Value || card.Suit== lastCard.Suit)
                {
                    cardsFind.Push(card);
                }
            }

            return cardsFind;
        }

        public Card CheckSpecialCard(Card lastCard)
        {
            if (lastCard.Value == CardValue.Four || lastCard.Value == CardValue.Two || lastCard.Value == CardValue.Three)
            {
                Boolean result = CompareCardsValue(lastCard, turnWinner.Hand);
                if (result)
                {
                    Stack<Card> stack = new Stack<Card>();
                    stack = findCardsValue(lastCard, turnWinner.Hand);
                    lastCard = stack.Pop();
                    turnWinner.Hand.Remove(lastCard);
                }

                else
                {
                    if (lastCard.Value == CardValue.Four)
                    {
                        lastCard.Value = CardValue.Four;
                    }
                    else
                    {
                        int number;
                        if (lastCard.Value == CardValue.Two)
                        {
                            number = 2;
                        }
                        else
                        {
                            number = 3;
                        }

                        for (int i = 0; i < number; i++)
                        {
                            turnWinner.Hand.Add(CardDeck.Deal());
                        }
                    }
                }
            }
            else
            {
                Boolean result = CompareCardValueOrSuit(lastCard, turnWinner.Hand);

                if (result)
                {
                    Stack<Card> stack = new Stack<Card>();
                    stack = findCardsValueOrSuit(lastCard, turnWinner.Hand);
                    lastCard = stack.Pop();
                    turnWinner.Hand.Remove(lastCard);

                    if (lastCard.Value == CardValue.Ace)
                    {
                        lastCard.Suit = DominantSuit(turnWinner.Hand);
                    }
                }
                else
                {
                    turnWinner.Hand.Add(CardDeck.Deal());
                }
            }

            return lastCard;
        }

        
        public CardSuit DominantSuit(List<Card> Hand)
        {
            var suit = Hand.GroupBy(x => x.Suit).OrderByDescending(x => x.Count());
            return suit.First().First().Suit;
        }


    }
}


