using Card_game;

namespace Cards
{
      public class Card
    {
       // public CardColor Color { get; set; }
        public CardValue Value { get;  set; }
        public CardSuit Suit { get; set; }


        public override string ToString() /// aici tostring
        {
            
               return Value.ToString() + " " + Suit.ToString();
            
        }

    }
}
