using System;

namespace CardBasedGames
{
    public class Shoe
    {
        public Deck Deck { get; set; }
        public Shoe (Deck deck)
        {
            Deck = deck;
        }
    }
}
