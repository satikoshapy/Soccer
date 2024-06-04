namespace Soccer
{
    public enum PlayerFunction
    {
        Goalkeeper = 'G',
        Defender = 'D',
        Midfielder = 'M',
        Forward = 'F'
    }

    public class Player
    {
        public int TeamId { get; set; }
        public int ShirtNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public PlayerFunction Function { get; set; }

        public Player(int teamId, int shirtNumber, string firstname, string lastname, PlayerFunction function)
        {
            TeamId = teamId;
            ShirtNumber = shirtNumber;
            FirstName = firstname;
            LastName = lastname;
            Function = function;
        }
    }
}
