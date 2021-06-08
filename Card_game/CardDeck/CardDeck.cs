using Card_game;
using Cards;
using System;
using System.Collections.Generic;

namespace CardDeck
{
    public class CardDeck
    {
        public List<Card> Cards { get; private set; }

        public void Shuffle()
        {
            //method of the Fisher-Yates
            Random r = new Random();
            List<Card> cards = Cards;

            for (int n = cards.Count - 1; n > 0; --n)
            {
                int k = r.Next(n + 1); //max value
                Card temp = cards[n];
                cards[n] = cards[k];
                cards[k] = temp;
            }
        }
        public CardDeck()
        {
            Cards = new List<Card>();

            //For every color we have defined
            foreach (CardColor color in Enum.GetValues(typeof(CardColor)))
            {
                foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
                {
                    foreach (CardValue val in Enum.GetValues(typeof(CardValue)))
                    {

                        switch (val)
                        {
                            case CardValue.Two:
                            case CardValue.Three:
                            case CardValue.Four:
                            case CardValue.Five:
                            case CardValue.Six:
                            case CardValue.Seven:
                            case CardValue.Eight:
                            case CardValue.Nine:
                            case CardValue.Ten:
                            case CardValue.Jack:
                            case CardValue.Queen:
                            case CardValue.King:
                            case CardValue.Ace:
                                //FOREATCH COLOR CREATE A CARD 
                                Cards.Add(new Card()
                                {
                                    Color = color,
                                    Value = val,
                                    Suit = suit
                                });
                                break;
                        }
                    }
                }
            }

        }
    }
 }
    

