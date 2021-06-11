using Cards;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Card_game
{
    public class CardDeck
    {
        public Stack<Card> Cards { get; private set; }  
        public CardDeck()
        {
            var initialList = new List<Card>();

            foreach (CardValue val in Enum.GetValues(typeof(CardValue)))
            {
                foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
                {

                    //FOREATCH COLOR CREATE A CARD 
                    initialList.Add(new Card()
                    {
                        Value = val,
                        Suit = suit
                    });

                }
            }

            Cards = new Stack<Card>(initialList);

        }
        public Card Deal()
        {
            return Cards.Pop();
        }
        public void Shuffle()
        {
            List<Card> cardlist = Cards.ToList();
            //method of the Fisher-Yates
            Random r = new Random();

            for (int n = Cards.Count - 1; n > 0; --n)
            {
                int k = r.Next(n + 1); //max value
                Card temp = cardlist[n];
                cardlist[n] = cardlist[k];
                cardlist[k] = temp;
            }

            Cards = new Stack<Card>(cardlist);
        }
        public void DisplaytheDeck()
        {
            foreach(var card in Cards)
            {
                Console.WriteLine(card);
               
            }
        }


        
    }
 }
    

