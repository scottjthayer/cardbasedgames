
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CardBasedGames
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary> 
    public partial class MainWindow : Window
    {
        public bool backed { get; set; }
        private static string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        private Deck deck = new Deck();
        private static List<Card> playerHand = new List<Card>();
        private static List<Card> splitHand = new List<Card>();
        private static List<Card> dealerHand = new List<Card>();
        private static string rootPath = @$"{projectDirectory}\CardImages";

        //added dependency properties so that these values could live update as the game is being played. 
        public int handValue
        {
            get { return (int)GetValue(HandValueProperty); }
            set { SetValue(HandValueProperty, value); }
        }
        public int dealerValue
        {
            get { return (int)GetValue(DealerValueProperty); }
            set { SetValue(DealerValueProperty, value); }
        }

        public static readonly DependencyProperty HandValueProperty =
                DependencyProperty.Register("handValue", typeof(int), typeof(MainWindow), new UIPropertyMetadata(0));

        public static readonly DependencyProperty DealerValueProperty =
            DependencyProperty.Register("dealerValue", typeof(int), typeof(MainWindow), new UIPropertyMetadata(0));


        public MainWindow()
        {
            this.DataContext = this;
            InitializeComponent();
            //FileStream fs = File.Open(@$"{projectDirectory}\CardImages\ace_of_clubs.png", FileMode.Open);
            // Console.WriteLine();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            NewGame();
        }

        private void NewGame()
        {
            ClearNewHand();
            deck.LoadDeck();
            deck.ShuffleDeck();
            Hit.IsEnabled = false;
            Stand.IsEnabled = false;
        }
        private void Deal_Click(object sender, RoutedEventArgs e)
        {
            //end of "shoe"
            if (deck.deck.Count < 20)
            {
                MessageBox.Show("Whoops! Not enough cards. Loading new deck");
                NewGame();

            }

            for (int i = 0; i < 2; i++)
            {
                Card tempCard = deck.deck[0];
                playerHand.Add(tempCard);
                deck.deck.Remove(tempCard);

            }
            for (int i = 0; i < 2; i++)
            {
                Card tempCard = deck.deck[0];
                dealerHand.Add(tempCard);
                deck.deck.Remove(tempCard);

            }

            //loads inital image sources for first cards dealt.
            playerCardOne.Source = LoadSource(0);
            playerCardTwo.Source = LoadSource(1);
            dealerCardOne.Source = LoadDealerSource(0);
            //this is a back until player stops hitting or stands or busts
            BitmapImage back = new BitmapImage();
            back.BeginInit();
            back.UriSource = new Uri(@$"{rootPath}\back.png", UriKind.Absolute);
            back.EndInit();

            dealerCardTwo.Source = back;
            backed = true;
            UpdateHandValues();

            if (handValue < 21)
            {
                Hit.IsEnabled = true;
            }

            Deal.IsEnabled = false;
            Stand.IsEnabled = true;

        }

        public void ClearNewHand()
        {
            //clear player's image sources
            playerCardOne.Source = null;
            playerCardTwo.Source = null;
            playerCardThree.Source = null;
            playerCardFour.Source = null;
            playerCardFive.Source = null;
            playerCardSix.Source = null;
            playerCardSeven.Source = null;
            playerCardEight.Source = null;

            //dealer's image sources
            dealerCardOne.Source = null;
            dealerCardTwo.Source = null;
            dealerCardThree.Source = null;
            dealerCardFour.Source = null;
            dealerCardFive.Source = null;
            dealerCardSix.Source = null;
            dealerCardSeven.Source = null;
            dealerCardEight.Source = null;
            //empty hands.  
            playerHand.RemoveAll(x => x.Face > 0);
            dealerHand.RemoveAll(x => x.Face > 0);

            //refresh buttons
            Stand.IsEnabled = false;
            Hit.IsEnabled = false;
            Deal.IsEnabled = true;

            backed = true;
        }
        //this could be refactored, lots of repetitive code. Tim Corey would be upset. 
        public void CheckWinConditions()
        {
            if (handValue > 21)
            {
                Hit.IsEnabled = false;
                Stand.IsEnabled = false;
                MessageBox.Show("You busted!");
                handValue = 0;
                dealerValue = 0;
                ClearNewHand();
            }
            else if (handValue == 21)
            {
                Hit.IsEnabled = false;
                Stand.IsEnabled = false;
                MessageBox.Show("Blackjack! Congratulations!");
                handValue = 0;
                dealerValue = 0;
                ClearNewHand();
            }
            else if (dealerValue == 21 && handValue != 21)
            {
                Hit.IsEnabled = false;
                Stand.IsEnabled = false;
                MessageBox.Show("You lose!");
                handValue = 0;
                dealerValue = 0;
                ClearNewHand();
            }
            else if (dealerValue > 21)
            {
                Hit.IsEnabled = false;
                Stand.IsEnabled = false;
                MessageBox.Show("Dealer busts! YOU WIN!");
                handValue = 0;
                dealerValue = 0;
                ClearNewHand();

            }
            else if (handValue > dealerValue && dealerValue >= 17)
            {
                Hit.IsEnabled = false;
                Stand.IsEnabled = false;
                MessageBox.Show("You win!");
                handValue = 0;
                dealerValue = 0;
                ClearNewHand();
            }
            else if (handValue < 17 && dealerValue >= 17 && dealerValue < 22 || (dealerValue > handValue && dealerValue >= 17))
            {
                Hit.IsEnabled = false;
                Stand.IsEnabled = false;
                MessageBox.Show("You lose :(");
                handValue = 0;
                dealerValue = 0;
                ClearNewHand();
            }

        }
        public void UpdateHandValues()
        {
            handValue = 0;
            dealerValue = 0;
            foreach (Card card in playerHand)
            {
                handValue += Convert.ToInt32(card.Face);
            }
            foreach (Card card in dealerHand)
            {
                dealerValue += Convert.ToInt32(card.Face);

            }
            if (backed) //hides value of dealer down card. 
            { dealerValue -= Convert.ToInt32(dealerHand[1].Face); }
        }

        public static BitmapImage LoadSource(int indexOfCard)
        {
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(@$"{rootPath}{playerHand[indexOfCard].ImageSource}", UriKind.Absolute);
            image.EndInit();
            return image;

        }
        //has to be separate from player load method. 
        public static BitmapImage LoadDealerSource(int indexOfCard)
        {
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(@$"{rootPath}{dealerHand[indexOfCard].ImageSource}", UriKind.Absolute);
            image.EndInit();
            return image;

        }

        private void Hit_Click(object sender, RoutedEventArgs e)
        {
            Card tempCard = deck.deck[0];
            playerHand.Add(tempCard);
            deck.deck.Remove(tempCard);

            //checks all img spaces on window. fills accordingly to how many times the hit button is pressed. 
            if (playerCardThree.Source == null)
            {
                playerCardThree.Source = LoadSource(2);
            }
            else if (playerCardFour.Source == null)
            {
                playerCardFour.Source = LoadSource(3);
            }
            else if (playerCardFive.Source == null)
            {
                playerCardFive.Source = LoadSource(4);
            }
            else if (playerCardSix.Source == null)
            {
                playerCardSix.Source = LoadSource(5);
            }
            else if (playerCardSeven.Source == null)
            {
                playerCardSeven.Source = LoadSource(6);
            }
            else if (playerCardEight.Source == null)
            {
                playerCardEight.Source = LoadSource(7);
            }
            UpdateHandValues();
            CheckWinConditions();
        }

        private void Stand_Click(object sender, RoutedEventArgs e)
        {
            backed = false;

            DrawForDealer();
            CheckWinConditions();

        }

        private void DrawForDealer()
        {
            while (dealerValue < 17)
            {
                Card tempCard = deck.deck[0];
                dealerHand.Add(tempCard);
                deck.deck.Remove(tempCard);
                dealerCardTwo.Source = LoadDealerSource(1);

                if (dealerCardThree.Source == null)
                {
                    dealerCardThree.Source = LoadDealerSource(2);
                }
                else if (dealerCardFour.Source == null)
                {
                    dealerCardFour.Source = LoadDealerSource(3);
                }
                else if (dealerCardFive.Source == null)
                {
                    dealerCardFive.Source = LoadDealerSource(4);
                }
                else if (dealerCardSix.Source == null)
                {
                    dealerCardSix.Source = LoadDealerSource(5);
                }
                else if (dealerCardSeven.Source == null)
                {
                    playerCardSeven.Source = LoadDealerSource(6);
                }
                else if (dealerCardEight.Source == null)
                {
                    dealerCardEight.Source = LoadDealerSource(7);
                }
                UpdateHandValues();
            }

        }
    }
}
