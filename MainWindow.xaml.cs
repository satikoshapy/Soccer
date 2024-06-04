using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Soccer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int MaximumNumberOfPlayers = 11;
        private List<Player> players = new List<Player>();
        private List<Team> teams = new List<Team>();
        private List<MatchDay> matchDays = new List<MatchDay>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SwitchTeams()
        {

        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            ReadButton.Visibility = Visibility.Visible;
        }

        private void ReadButton_Click(object sender, RoutedEventArgs e)
        {

            ReadTeams();
            ReadPlayers();
            CompetitionButton.IsEnabled = true;
        }

        public void AssignPlayerToTeamBy(int id, Player player)
        {
            Team team = teams.First(team => team.Id == id);
            team.Players.Add(player);
        }

        public void ReadTeams()
        {
            string filePath = @"C:\Users\Sati\OneDrive - PXL\Bureaublad\Switch2IT\1-e jaar\SECOND SEMESTER\.NET\Soccer\Soccer\Teams.txt";
            StreamReader reader = new StreamReader(filePath, System.Text.Encoding.Default);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] splitLine = line.Split(",");
                teams.Add(new Team(int.Parse(splitLine[0]), splitLine[1], splitLine[2]));
            }
        }

        public void ReadPlayers()
        {
            string filePath = @"C:\Users\Sati\OneDrive - PXL\Bureaublad\Switch2IT\1-e jaar\SECOND SEMESTER\.NET\Soccer\Soccer\Players.txt";
            StreamReader reader = new StreamReader(filePath, System.Text.Encoding.Default);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] splitLine = line.Split(",");
                PlayerFunction function = GetFunction(splitLine[4]);
                Player player = new Player(int.Parse(splitLine[0]),
                    int.Parse(splitLine[1]),
                    splitLine[2],
                    splitLine[3],
                    function
                    );
                AssignPlayerToTeamBy(int.Parse(splitLine[0]), player);
                players.Add(player);
                
            }
            
        }

        private void CompetitionButton_Click(object sender, RoutedEventArgs e)
        {
            CompetitionMenu.Visibility = Visibility.Visible;
        }

        private static PlayerFunction GetFunction(string functionChar)
        {

            return char.Parse( functionChar) switch
            {
                'G' => PlayerFunction.Goalkeeper,
                'D' => PlayerFunction.Defender,
                'M' => PlayerFunction.Midfielder,
                'F' => PlayerFunction.Forward,
                _ => throw new ArgumentException($"Invalid PlayerFunction value: {functionChar}")
            };
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Compose_Click(object sender, RoutedEventArgs e)
        {

            DateTime day = new DateTime(DateTime.Now.Year, 7, 31);
            while (day.DayOfWeek != DayOfWeek.Saturday)
            {
                day = day.AddDays(-1);
            }


            List<Team> teamList1 = teams.GetRange(0, 8);
            List<Team> teamList2 = teams.GetRange(8, teams.Count - 8);
            for (int i = 1; i < 16; i++)
            {
                matchDays.Add(new MatchDay(i, teamList1, teamList2, day));
                day = day.AddDays(7);
                teamList2.Insert(0, teamList1[1]);
                teamList1.Remove(teamList1[1]);
                teamList1.Add(teamList2[teamList2.Count - 1]);
                teamList2.RemoveAt(teamList2.Count - 1);
            }

            Scores.IsEnabled = true;
            Ranking.IsEnabled = true;
            Compose.IsEnabled = false;
        }

        private void Ranking_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Scores_Click(object sender, RoutedEventArgs e)
        {
            matchDaysListBox.Items.Clear();

            foreach(MatchDay matchDay in matchDays) 
            {
                string formattedDate = matchDay.Date.ToString("dd/MM/yyyy");

                ListBoxItem listItem = new ListBoxItem { Content = "Match day: " + matchDay.DayNumber + " : " + formattedDate };
                listItem.IsEnabled = true;
                
                listItem.DataContext = matchDay;
                listItem.MouseDoubleClick += MatchDay_Click;
                matchDaysListBox.Items.Add(listItem);
            }
        }

        private void MatchDay_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItem? clickedItem = sender as ListBoxItem;

            gamesListBox.Items.Clear();
            
            MatchDay? matchDay = clickedItem?.DataContext as MatchDay;

            if (matchDay != null)
            {
                
                for (int i = 0; i < 8; i++)
                {
                    Label lbl = new Label { Content = matchDay.TeamList1[i].Name + " - " + matchDay.TeamList2[i].Name };
                    gamesListBox.Items.Add(lbl);
                }
            }
            

            
        }



    }
}
