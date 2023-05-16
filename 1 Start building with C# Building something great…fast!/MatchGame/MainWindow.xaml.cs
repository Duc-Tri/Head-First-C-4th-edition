using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace MatchGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        int tenthsOfSecondsElapsed;
        int matchesFound;

        public MainWindow()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromSeconds(.1);
            timer.Tick += Timer_Tick;
            SetUpGame();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tenthsOfSecondsElapsed++;
            timeTextBlock.Text = (tenthsOfSecondsElapsed / 10F).ToString("0.0s");

            if (matchesFound == 8)
            {
                timer.Stop();
                timeTextBlock.Text = timeTextBlock.Text + " - Play again ?";
            }
        }

        private void SetUpGame()
        {
            // Create a list of eight pairs of emoji
            List<string> animalEmoji = new List<string>()
            { "🐙","🐙", "🐠","🐠", "🐘","🐘", "🐳","🐳", "🐪","🐪", "🦕","🦕", "🦘","🦘", "🦔","🦔" };

            // Create a new random number generator
            Random random = new Random();

            // Find every TextBlock in the main grid and repeat the following statements for each of them
            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {
                if (textBlock.Name != "timeTextBlock")
                {
                    textBlock.Visibility= Visibility.Visible;

                    // Pick a random number between 0 and the number of emoji left in the list and call it “index”
                    int index = random.Next(animalEmoji.Count);

                    // Use the random number called “index” to get a random emoji from the list
                    string nextEmoji = animalEmoji[index];

                    // Update the TextBlock with the random emoji from the list
                    textBlock.Text = nextEmoji;

                    // Remove the random emoji from the list
                    animalEmoji.RemoveAt(index);
                }
            }

            timer.Start();
            tenthsOfSecondsElapsed= 0;
            matchesFound= 0;

        }

        TextBlock lastTextBlockClicked;

        // keeps track of whether or not the player just clicked on the first animal in a pair and is now trying to find its match
        bool findingMatch = false;
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            if (findingMatch == false)
            {
                // the player just clicked the first animal in a pair, so it makes that animal invisible and keeps track of its TExtBlock in case it needs to make it visible again
                textBlock.Visibility = Visibility.Hidden;
                lastTextBlockClicked = textBlock;
                findingMatch = true;
            }
            else if (textBlock.Text == lastTextBlockClicked.Text)
            {
                // the player found a match ! so it makes the second animal in the pair invisible (and unclickable) too, and resets findingMatch so the next animal clicked on is the first one in a pair again
                matchesFound++;
                textBlock.Visibility = Visibility.Hidden;
                findingMatch = false;
            }
            else
            {
                // the player clicked on an animal that doesn't match, so it makes the first animal that was clicked visible again and resets findingMatch
                lastTextBlockClicked.Visibility = Visibility.Visible;
                findingMatch = false;
            }

        }

        private void TimeTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (matchesFound == 8)
            {
                // resets the game if all 8 matched pairs have been found (otherwise it does nothing because the game is still running
                SetUpGame();
            }
        }
    }

}
