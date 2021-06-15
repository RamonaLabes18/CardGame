using Card_game.Games;
using Cards;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Card_game
{

    class Macaoua : ComunGameAction
    {
        public CardDeck CardDeck { get; set; }
        public List<Player> PlayerList { get; set; }
        public List<Card> PileCards { get; set; }

        private LinkedList<Player> linkPlayers;
        private Dictionary<Player, bool> takeCards;
        private Card lastCard;
        private Player turnWinner;
        private Player lastPlayerOfList;
        private LinkedListNode<Player> lastPlayer;
        private LinkedListNode<Player> currentPlayer;

        //operatii pt joc 
        public Macaoua()
        { }
        public Macaoua(CardDeck deck, List<Player> players)
        {
            this.CardDeck = deck;
            this.PlayerList = players;
            this.PileCards = new List<Card>();
            this.linkPlayers = new LinkedList<Player>(players);
            takeCards = new Dictionary<Player, bool>();
            foreach (Player player in PlayerList)
            {
                takeCards.Add(player, false);
            }

        }
        //METODA PLAY PT ALGORITM
        
        public void ShowHand()
        {
            foreach (var player in PlayerList)
            {
                player.ShowHand();
            }

            //Console.ReadLine();
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
                if (card.Value == lastCard.Value || card.Suit == lastCard.Suit)
                {
                    cardsFind.Push(card);
                }
            }

            return cardsFind;
        }

        public Card CheckSpecialCard(Card lastCard, Player playerTurn, bool control)
        {

            if ((lastCard.Value == CardValue.Four || lastCard.Value == CardValue.Two || lastCard.Value == CardValue.Three) & control == false)
            {
                {
                    Boolean result = CompareCardsValue(lastCard, playerTurn.Hand);
                    if (result)
                    {
                        Stack<Card> stack = new Stack<Card>();
                        stack = findCardsValue(lastCard, playerTurn.Hand);
                        lastCard = stack.Pop();
                        playerTurn.Hand.Remove(lastCard);
                    }
                    else
                    {
                        takeCards[playerTurn] = true;
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
                                    playerTurn.Hand.Add(CardDeck.Deal());
                                }
                            }
                        }
                    }
                }
            }
            else
            {

                Boolean result = CompareCardValueOrSuit(lastCard, playerTurn.Hand);

                if (result)
                {
                    Stack<Card> stack = new Stack<Card>();
                    stack = findCardsValueOrSuit(lastCard, playerTurn.Hand);
                    lastCard = stack.Pop();
                    playerTurn.Hand.Remove(lastCard);
                  //  takeCards[playerTurn] = true;

                    if (lastCard.Value == CardValue.Ace && playerTurn.Hand.Count>1)
                    {
                        lastCard.Suit = DominantSuit(playerTurn.Hand);
                    }
              
                }
                else
                {
                    playerTurn.Hand.Add(CardDeck.Deal());
                }
            }

            return lastCard;
        }

        public CardSuit DominantSuit(List<Card> Hand)
        { 
            var suit = Hand.GroupBy(x => x.Suit).OrderByDescending(x => x.Count());
            return suit.First().First().Suit;
        }

        public Card CheckPileCard(Card lastCard)
        {
            if (lastCard.Value == CardValue.Ace || lastCard.Value == CardValue.Four || lastCard.Value == CardValue.Three || lastCard.Value == CardValue.Two)
            {
                lastCard = CardDeck.Deal();

            }
            return lastCard;
        }

        public bool CheckEmptyHand(Player currentPlayer)
        {
            bool result = false;
            if (currentPlayer.Hand.Count() == 0)
            {
                turnWinner = currentPlayer;
                result = true;
            }
            return result;
        }

        public bool ReturnControl(LinkedListNode<Player> currentPlayer, LinkedListNode<Player> lastPlayer)
        {
            bool control;
            if (currentPlayer.Previous == null)
            {
                control = takeCards[lastPlayer.Value];
            }
            else
            {
                control = takeCards[currentPlayer.Previous.Value];
            }

            return control;
        }

        public void ResetTakeCard(LinkedListNode<Player> currentPlayer, LinkedListNode<Player> lastPlayer)
        {
            if (currentPlayer.Previous == null)
            {
                takeCards[lastPlayer.Value] = false;
            }
            else
            {
                takeCards[currentPlayer.Previous.Value] = false;
            }
        }
  
        public CardDeck CreateNewCardDeck(List<Card> PileCards)
        {
            var currentCard = PileCards.First();
            CardDeck newDeck = new CardDeck(PileCards);
            newDeck.Shuffle();
            PileCards.Clear();
            PileCards.Add(currentCard);
            return newDeck;
        }

        public override Player play(CardDeck deck, List<Player> players)
        {
            CardDeck = deck;
            PlayerList = players;
            DealCard();
            lastCard = CardDeck.Deal();
            lastCard = CheckPileCard(lastCard);
            PileCards.Add(lastCard);
            Console.WriteLine("Pile Card is : " + lastCard);
            ShowHand();
            turnWinner = PlayerList[0];
            lastPlayerOfList = PlayerList.Last();
            currentPlayer = linkPlayers.Find(turnWinner);
            lastPlayer = linkPlayers.Find(lastPlayerOfList);
            do
            {

                if (CardDeck.Cards.Count < 2)
                {
                    CardDeck = CreateNewCardDeck(PileCards);
                }

                turnWinner = null;
                bool control = ReturnControl(currentPlayer, lastPlayer);
                Player playerTurn = currentPlayer.Value;
                lastCard = CheckSpecialCard(lastCard, playerTurn, control);
                PileCards.Add(lastCard);
                Console.WriteLine("Pile Card is : " + lastCard);
                ShowHand();
                if (lastCard.Value != CardValue.Three || lastCard.Value != CardValue.Two || lastCard.Value != CardValue.Four)
                {
                    ResetTakeCard(currentPlayer, lastPlayer);

                }
                if (CheckEmptyHand(currentPlayer.Value) == false)
                {
                    if (currentPlayer.Next == null)
                    {
                        currentPlayer = linkPlayers.First;
                    }
                    else
                    {
                        currentPlayer = currentPlayer.Next;
                    }
                }
                else
                {
                    turnWinner = currentPlayer.Value;
                    Console.WriteLine("Winner is player  " + turnWinner.Position);
                }
            }
            while (turnWinner == null);

            return turnWinner;
        }

        public override string GetGameType()
        {
            return "Macaoua";
        }

       
    }
}


