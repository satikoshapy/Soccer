using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace Soccer
{
    public class MatchDay
    {

        public int DayNumber { get; set; }
        public List<Team> TeamList1 { get; set; }
        public List<Team> TeamList2 { get; set;}

        public List<int> ScoreList1 { get; set; }
        public List<int> ScoreList2 { get; set; }

        public DateTime Date {  get; set; }

        public MatchDay(int dayNumber, List<Team> teamList1, List<Team> teamList2, DateTime date)
        {
            DayNumber = dayNumber;
            TeamList1 = teamList1;
            TeamList2 = teamList2;
            Date = date;
        }
    }
}
