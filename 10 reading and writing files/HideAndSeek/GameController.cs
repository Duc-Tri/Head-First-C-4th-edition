using HideAndSeek;
using System;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;

public class GameController
{
    /// <summary>
    /// The player's current location in the house
    /// </summary>
    public Location CurrentLocation { get; private set; }

    /// <summary>
    /// Returns the the current status to show to the player
    /// </summary>
    public string Status => CurrentLocation.DescriptionAllDirections();

    /// <summary>
    /// A prompt to display to the player
    /// </summary>
    public string Prompt => "Which direction do you want to go: ";

    public GameController()
    {
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

        var lower = input.ToLower();
        foreach (var d in Enum.GetNames(typeof(Direction)).ToList())
        {
            if (d.ToLower().Equals(lower))
            {
                if (Move((Direction)Enum.Parse(typeof(Direction), d)))
                    return "Moving " + d;
                else
                    return "There's no exit in that direction";
            }
        }

        return "That's not a valid direction";
    }

}