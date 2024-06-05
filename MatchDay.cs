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

        public MatchDay(int dayNumber, DateTime date)
        {
            DayNumber = dayNumber;
            Date = date;

            TeamList1 = new List<Team>();
            TeamList2 = new List<Team>();

            ScoreList1 = new List<int>();
            ScoreList2 = new List<int>();
        }
    }
}
