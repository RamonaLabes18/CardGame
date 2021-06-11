using Card_game;
using System.Collections.Generic;

namespace Cards
{
      public class Card
    { 
        public CardValue Value { get;  set; }
        public CardSuit Suit { get; set; }


        public override string ToString() // aici tostring
        {
            
               return Value.ToString() + " " + Suit.ToString();
            
        }

        

    }
}
