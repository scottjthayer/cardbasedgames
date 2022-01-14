using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace CardBasedGames
{
    public class Deck
    {
        public List<Card> deck = new List<Card>();

        public void LoadDeck()
        {
           
            deck.Add(new Card(Values.ace, Suits.Clubs, @"\ace_of_clubs.png"));
            deck.Add(new Card(Values.ace, Suits.Hearts, @"\ace_of_hearts.png"));
            deck.Add(new Card(Values.ace, Suits.Diamonds, @"\ace_of_diamonds.png"));
            deck.Add(new Card(Values.ace, Suits.Spades, @"\ace_of_spades.png"));

            deck.Add(new Card(Values.Two, Suits.Clubs, @"\2_of_clubs.png"));
            deck.Add(new Card(Values.Two, Suits.Hearts, @"\2_of_hearts.png"));
            deck.Add(new Card(Values.Two, Suits.Diamonds, @"\2_of_diamonds.png"));
            deck.Add(new Card(Values.Two, Suits.Spades, @"\2_of_spades.png"));

            deck.Add(new Card(Values.Three, Suits.Clubs, @"\3_of_clubs.png"));
            deck.Add(new Card(Values.Three, Suits.Hearts, @"\3_of_hearts.png"));
            deck.Add(new Card(Values.Three, Suits.Diamonds, @"\3_of_diamonds.png"));
            deck.Add(new Card(Values.Three, Suits.Spades, @"\3_of_spades.png"));

            deck.Add(new Card(Values.Four, Suits.Clubs, @"\4_of_clubs.png"));
            deck.Add(new Card(Values.Four, Suits.Hearts, @"\4_of_hearts.png"));
            deck.Add(new Card(Values.Four, Suits.Diamonds, @"\4_of_diamonds.png"));
            deck.Add(new Card(Values.Four, Suits.Spades, @"\4_of_spades.png"));

            deck.Add(new Card(Values.Five, Suits.Clubs, @"\5_of_clubs.png"));
            deck.Add(new Card(Values.Five, Suits.Hearts, @"\5_of_hearts.png"));
            deck.Add(new Card(Values.Five, Suits.Diamonds, @"\5_of_diamonds.png"));
            deck.Add(new Card(Values.Five, Suits.Spades, @"\5_of_spades.png"));

            deck.Add(new Card(Values.Six, Suits.Clubs, @"\6_of_clubs.png"));
            deck.Add(new Card(Values.Six, Suits.Hearts, @"\6_of_hearts.png"));
            deck.Add(new Card(Values.Six, Suits.Diamonds, @"\6_of_diamonds.png"));
            deck.Add(new Card(Values.Six, Suits.Spades, @"\6_of_spades.png"));

            deck.Add(new Card(Values.Seven, Suits.Clubs, @"\7_of_clubs.png"));
            deck.Add(new Card(Values.Seven, Suits.Hearts, @"\7_of_hearts.png"));
            deck.Add(new Card(Values.Seven, Suits.Diamonds, @"\7_of_diamonds.png"));
            deck.Add(new Card(Values.Seven, Suits.Spades, @"\7_of_spades.png"));

            deck.Add(new Card(Values.Eight, Suits.Clubs, @"\8_of_clubs.png"));
            deck.Add(new Card(Values.Eight, Suits.Hearts, @"\8_of_hearts.png"));
            deck.Add(new Card(Values.Eight, Suits.Diamonds, @"\8_of_diamonds.png"));
            deck.Add(new Card(Values.Eight, Suits.Spades, @"\8_of_spades.png"));

            deck.Add(new Card(Values.Nine, Suits.Clubs, @"\9_of_clubs.png"));
            deck.Add(new Card(Values.Nine, Suits.Hearts, @"\9_of_hearts.png"));
            deck.Add(new Card(Values.Nine, Suits.Diamonds, @"\9_of_diamonds.png"));
            deck.Add(new Card(Values.Nine, Suits.Spades, @"\9_of_spades.png"));

            deck.Add(new Card(Values.Ten, Suits.Clubs, @"\10_of_clubs.png"));
            deck.Add(new Card(Values.Ten, Suits.Hearts, @"\10_of_hearts.png"));
            deck.Add(new Card(Values.Ten, Suits.Diamonds, @"\10_of_diamonds.png"));
            deck.Add(new Card(Values.Ten, Suits.Spades, @"\10_of_spades.png"));

            deck.Add(new Card(Values.jack, Suits.Clubs, @"\jack_of_clubs.png"));
            deck.Add(new Card(Values.jack, Suits.Hearts, @"\jack_of_hearts.png"));
            deck.Add(new Card(Values.jack, Suits.Diamonds, @"\jack_of_diamonds.png"));
            deck.Add(new Card(Values.jack, Suits.Spades, @"\jack_of_spades.png"));

            deck.Add(new Card(Values.queen, Suits.Clubs, @"\queen_of_clubs.png"));
            deck.Add(new Card(Values.queen, Suits.Hearts, @"\queen_of_hearts.png"));
            deck.Add(new Card(Values.queen, Suits.Diamonds, @"\queen_of_diamonds.png"));
            deck.Add(new Card(Values.queen, Suits.Spades, @"\queen_of_spades.png"));

            deck.Add(new Card(Values.king, Suits.Clubs, @"\king_of_clubs.png"));
            deck.Add(new Card(Values.king, Suits.Hearts, @"\king_of_hearts.png"));
            deck.Add(new Card(Values.king, Suits.Diamonds, @"\king_of_diamonds.png"));
            deck.Add(new Card(Values.king, Suits.Spades, @"\king_of_spades.png"));

        }

        public void ShuffleDeck()
        {
            Random r = new Random();
            for (int i = 0; i < deck.Count; i++)
            {
                //FisherYates in-place shuffle
                var temp = deck[i];
                var index = r.Next(0, deck.Count);
                deck[i] = deck[index];
                deck[index] = temp;
            }

        }

    
    }
}
