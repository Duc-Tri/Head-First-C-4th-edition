using HideAndSeek;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.ConstrainedExecution;

public class GameController
{
    /// <summary>
    /// The player's current location in the house
    /// </summary>
    public Location CurrentLocation { get; private set; }

    /// <summary>
    /// Returns the the current status to show to the player
    /// </summary>
    public string Status => CurrentLocation.ExitsAndDirections() + (foundOpponents.Count > 0 ?
                                                            Environment.NewLine + $"You have found {foundOpponents.Count} of {Opponents.ToList().Count} opponents: {string.Join(", ", foundOpponents)}" :
                                                            Environment.NewLine + "You have not found any opponent");

    /// The number of moves the player has made
    /// </summary>
    public int MoveNumber { get; private set; } = 1;

    /// <summary>
    /// Private list of opponents the player needs to find
    /// </summary>
    public readonly IEnumerable<Opponent> Opponents = new List<Opponent>()
     {
     new Opponent("Joe"), new Opponent("Bob"), new Opponent("Ana"), new Opponent("Owen"), new Opponent("Jimmy"),
     };

    /// <summary>
    /// Private list of opponents the player has found so far
    /// </summary>
    private readonly List<Opponent> foundOpponents = new List<Opponent>();

    /// <summary>
    /// Returns true if the game is over
    /// </summary>
    public bool GameOver => Opponents.Count() == foundOpponents.Count();

    /// <summary>
    /// A prompt to display to the player
    /// </summary>
    public string Prompt => $"{MoveNumber}: Which direction do you want to go (or type 'check'): ";

    public GameController()
    {
        House.ClearHidingPlaces();
        foreach (var opponent in Opponents)
            opponent.Hide();

        CurrentLocation = House.Entry;
    }

    /// <summary>
    /// Move to the location in a direction
    /// </summary>
    /// <param name="direction">The direction to move</param>
    /// <returns>True if the player can move in that direction, false oterwise</returns>
    public bool Move(Direction direction)
    {
        bool canMove = CurrentLocation.Exits.ContainsKey(direction);

        if (canMove) CurrentLocation = CurrentLocation.Exits[direction];

        return canMove;
    }

    /// <summary>
    /// Parses input from the player and updates the status
    /// </summary>
    /// <param name="input">Input to parse</param>
    /// <returns>The results of parsing the input</returns>
    public string ParseInput(string input)
    {
        // The ParseInput method parses a string that the user typed in. Parsing means analyzing text. You’ll use the Enum.TryParse method, just like you did with card values in Chapter 9.

        var lowerInput = input.ToLower();
        if (lowerInput.Equals("check"))
        {
            MoveNumber++;

            if (CurrentLocation is not LocationWithHidingPlace) return "There is no hiding place in the Entry";

            var hidingLocation = CurrentLocation as LocationWithHidingPlace;
            var foundInPlace = hidingLocation.CheckHidingPlace().ToList();

            if (foundInPlace.Count == 0) return $"Nobody was hiding {hidingLocation.HidingPlace}";

            foundOpponents.AddRange(foundInPlace);
            return $"You found {foundInPlace.Count} opponent{(foundInPlace.Count > 1 ? "s" : "")} hiding {hidingLocation.HidingPlace}";
        }

        foreach (var d in Enum.GetNames(typeof(Direction)).ToList())
        {
            if (d.ToLower().Equals(lowerInput))
            {
                if (Move((Direction)Enum.Parse(typeof(Direction), d)))
                {
                    MoveNumber++;
                    return "Moving " + d;
                }
                else
                    return "There's no exit in that direction";
            }
        }

        return "That's not a valid direction";
    }

}