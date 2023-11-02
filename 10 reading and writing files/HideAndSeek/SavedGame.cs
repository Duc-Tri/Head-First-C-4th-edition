using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Xml;

namespace HideAndSeek
{
    public class SavedGame
    {
        public string PlayerLocation { get; set; }

        public IDictionary<string, string> Opponents { get; set; } = new Dictionary<string, string>();

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
            PlayerLocation = gameController.CurrentLocation.Name;
            Opponents.Clear(); //  Location
            foreach (var op in gameController.Opponents)
            {
                //Console.WriteLine(op.Name + " █ " + op.currentLocation);

                //if (!gameController.foundOpponents.Contains(op)) 
                Opponents.Add(op.Name, op.currentLocation.Name);
            }

            FoundOpponents = new List<Opponent>(gameController.foundOpponents);
            MoveNumber = gameController.MoveNumber;

            string json = JsonSerializer.Serialize(instance, new JsonSerializerOptions { WriteIndented = true });
            Console.WriteLine(json);

            StreamWriter writer = new StreamWriter("save-hide-seek.json");
            writer.WriteLine(json);
            writer.Close();

            // for tests ------------------------------------------------------
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
            Console.WriteLine(json);

            instance = JsonSerializer.Deserialize<SavedGame>(json);

            (gameController.Opponents as List<Opponent>).Clear();
            (gameController.Opponents as List<Opponent>).AddRange(instance.Opponents.Select(x => new Opponent(x.Key, x.Value)).ToList());
            Console.WriteLine(string.Join(" │ ", gameController.Opponents));

            gameController.ClearHouseHideOpponents();
            gameController.foundOpponents.Clear();
            gameController.foundOpponents.AddRange(instance.FoundOpponents);

            foreach (var opp in gameController.Opponents)
                if (instance.FoundOpponents.Contains(opp))
                    (opp.currentLocation as LocationWithHidingPlace).CheckHidingPlace();

            gameController.MoveNumber = instance.MoveNumber;
            gameController.CurrentLocation = House.GetLocationByName(instance.PlayerLocation);
        }

    }

}