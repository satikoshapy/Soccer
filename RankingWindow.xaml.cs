using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Documents;

namespace Soccer
{
    /// <summary>
    /// Interaction logic for RangschikkingWindow.xaml
    /// </summary>
    public partial class RankingWindow : Window
    {
        public List<Team> Teams;
        public RankingWindow(List<Team> teams)
        {
            InitializeComponent();
            Teams = teams;
            teams.Sort((team1, team2) => team2.Points.CompareTo(team1.Points));


            StringBuilder sb = new StringBuilder();

            
            foreach (Team team in Teams)
            {
                sb.AppendLine($"{team.Points}    {team.Name}");
            }

            
            rankingTextBox.Text = sb.ToString();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
