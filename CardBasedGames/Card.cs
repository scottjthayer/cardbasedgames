using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Media.Imaging;

namespace CardBasedGames
{
    public class Card
    {
        public Values Face { get; set; }
        public Suits Suit { get; set; }
        public string ImageSource { get; set; }

        public Card(Values face, Suits suit, string imageSource)
        {
            Face = face;
            Suit = suit;
            ImageSource = imageSource;
        }

    }
}
