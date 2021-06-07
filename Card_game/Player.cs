using System;
using System.Collections.Generic;
using System.Text;

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
