using Cards;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Card_game
{
    public class CardDeck
    {
        public List<Card> Cards { get; private set; }
        public CardDeck()
        {
            Cards = new List<Card>();

            foreach (CardValue val in Enum.GetValues(typeof(CardValue)))
            {
                foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
                {

                    //FOREATCH COLOR CREATE A CARD 
                    Cards.Add(new Card()
                    {
                        Value = val,
                        Suit = suit
                    });

                }
            }
            //}

        }
        public List<Card> Draw(int count)
        {
            var drawnCards = Cards.Take(count).ToList();

            //Remove the drawn cards from the draw pile
            Cards.RemoveAll(x => drawnCards.Contains(x));

            return drawnCards;
        }
        public void Shuffle()
        {
            //method of the Fisher-Yates
            Random r = new Random();

            for (int n = Cards.Count - 1; n > 0; --n)
            {
                int k = r.Next(n + 1); //max value
                Card temp = Cards[n];
                Cards[n] = Cards[k];
                Cards[k] = temp;
            }
        }
        public void DisplaytheDeck()
        {
            foreach(var card in Cards)
            {
                Console.Write(Enum.GetName(typeof(CardSuit), card.Suit) + " " + Enum.GetName(typeof(CardValue), card.Value) + Environment.NewLine);
            }
        }


        
    }
 }
    

