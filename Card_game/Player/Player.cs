using Cards;
using System.Collections.Generic;

namespace Card_game
{
    public class Player
    {
        public List<Card> Hand { get; set; }
        public int Position { get; set; }
        public Player()
        {
            Hand = new List<Card>();
        }
    }
}
