using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace HideAndSeek
{
    public class SavedGame
    {
        public Location PlayerLocation { get; set; }

        public IDictionary<string, string> Opponents { get; set; }

        public List<Opponent> FoundOpponents { get; set; }

        public int MoveNumber { get; set; }

        public static SavedGame instance;

        public static SavedGame Instance
        {
            get
            {
                if (instance == null) instance = new SavedGame();

                return instance;
            }
        }

        public SavedGame() { }

        public void Save(GameController gameController)
        {
            PlayerLocation = gameController.CurrentLocation;
            Opponents = new Dictionary<string, string>(); //  Location
            foreach (var op in gameController.Opponents)
            {
                Console.WriteLine(op.Name + " █ " + op.currentLocation);

                if (!gameController.foundOpponents.Contains(op)) Opponents.Add(op.Name, op.currentLocation.Name);
            }

            FoundOpponents = new List<Opponent>(gameController.foundOpponents);
            MoveNumber = gameController.MoveNumber;

            string json = JsonSerializer.Serialize(instance);
            Console.WriteLine(json);

            StreamWriter writer = new StreamWriter("save-hide-seek.json");
            writer.WriteLine(json);
            writer.Close();

            // for tests
            FoundOpponents.Clear();
            MoveNumber = 0;
            PlayerLocation = null;
            Opponents.Clear();

        }

        public void Load(GameController gameController)
        {
            StreamReader reader = new StreamReader("save-hide-seek.json");
            string json = reader.ReadToEnd();
            reader.Close();

            instance = JsonSerializer.Deserialize<SavedGame>(json);

            Console.WriteLine(json);
            foreach (var op in instance.Opponents)
            {
                Console.WriteLine(op.Key + " ■█■ " + op.Value);

            }

        }
    }

}