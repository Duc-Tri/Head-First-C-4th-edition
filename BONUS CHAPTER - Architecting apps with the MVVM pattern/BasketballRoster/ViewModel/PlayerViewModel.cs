namespace BasketballRoster.ViewModel
{
    // Here’s the PlayerViewModel. It’s just a simple data object with properties for the data template to bind to.
    public class PlayerViewModel
    {
        public string Name { get; set; } = "";
        public int Number { get; set; }

        public PlayerViewModel(string name, int number)
        {
            Name = name;
            Number = number;
        }

        public override string ToString() => $"{Name} (#{Number})";

    }

}