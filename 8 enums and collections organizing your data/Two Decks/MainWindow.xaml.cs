using System.Windows;
using System.Windows.Input;

namespace Two_Decks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            (Resources["rightDeck"] as Deck)?.Clear();

            Deck.TestDeckLINQ();
        }

        private void MoveCard(bool leftToRight)
        {
            if ((Resources["rightDeck"] is Deck rightDeck) && (Resources["leftDeck"] is Deck leftDeck))
            {
                if (leftToRight)
                {
                    if (leftDeckListBox.SelectedItem is Card card)
                    {
                        leftDeck.Remove(card);
                        rightDeck.Add(card);
                    }
                }
                else
                {
                    if (rightDeckListBox.SelectedItem is Card card)
                    {
                        rightDeck.Remove(card);
                        leftDeck.Add(card);
                    }
                }
            }
        }

        private void resetLeftDeck_Click(object sender, RoutedEventArgs e)
        {
            (Resources["leftDeck"] as Deck)?.Reset();
        }

        private void shuffleLeftDeck_Click(object sender, RoutedEventArgs e)
        {
            (Resources["leftDeck"] as Deck)?.Shuffle();
        }

        private void clearRightDeck_Click(object sender, RoutedEventArgs e)
        {
            (Resources["rightDeck"] as Deck)?.Clear();
        }

        private void sortRightDeck_Click(object sender, RoutedEventArgs e)
        {
            (Resources["rightDeck"] as Deck)?.Sort();
        }

        private void leftDeckListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                MoveCard(true);
            }
        }

        private void leftDeckListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MoveCard(true);
        }

        private void rightDeckListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                MoveCard(false);
            }

        }

        private void rightDeckListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MoveCard(false);
        }

    }
}
