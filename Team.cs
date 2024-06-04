using System.Collections.Generic;
using System.Windows.Documents;

namespace Soccer
{
    public class Team
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public int Points { get; set; }
        public List<Player> Players { get; set; } = new List<Player>();

        public Team(int id, string name, string location)
        {
            Id = id;
            Name = name;
            Location = location;
        }

        
    }
}
