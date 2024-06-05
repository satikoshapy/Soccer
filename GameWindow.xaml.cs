using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Soccer
{
    /// <summary>
    /// Interaction logic for WedstrijdWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        Team Team1;
        Team Team2;
        public GameWindow(Team team1, Team team2)
        {
            InitializeComponent();
            Team1 = team1;
            Team2 = team2;
            scoreT1Label.Content = team1.Points;
            scoreT2Label.Content = team2.Points;
            team1Label.Content = team1.Name;
            team2Label.Content = team2.Name;

         


            foreach(Player player in  team1.Players)
            {
                ListBoxItem listItem = new ListBoxItem {Content = player.FirstName + " " + player.LastName };
                listItem.IsEnabled = true;
                listItem.MouseDoubleClick += playersTeam1Scored_Click;
                playersTeam1ListBox.Items.Add(listItem);
            }

            foreach (Player player in team2.Players)
            {
                ListBoxItem listItem = new ListBoxItem { Content = player.FirstName + " " + player.LastName };
                listItem.IsEnabled = true;
                listItem.MouseDoubleClick += playerTeam2Scored_Click;
                playersTeam2ListBox.Items.Add(listItem);
            }


        }

        private void playerTeam2Scored_Click(object sender, MouseButtonEventArgs e)
        {
            Team2.Points += 1;
            scoreT2Label.Content = Team2.Points;
        }

        private void playersTeam1Scored_Click(object sender, MouseButtonEventArgs e)
        {
            Team1.Points += 1;
            scoreT1Label.Content = Team1.Points;
        }

        private void stopButton_Click(object sender, RoutedEventArgs e)
        {
            if (Team1.Points > Team2.Points)
            {
                Team1.Points = 3;
                Team2.Points = 0;
            }
            else if (Team1.Points == Team2.Points)
            {
                Team1.Points = 1;
                Team2.Points = 1;
            }
            else
            {
                Team1.Points = 0;
                Team2.Points = 3;
            }

            this.Close();

        }
    }
}
