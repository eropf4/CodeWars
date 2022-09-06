using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


public static class Program
{
    public static void Main ()
    {
        var p1 = Console.ReadLine();
        var p2 = Console.ReadLine();

        var rps = new Kata();
        Console.WriteLine(rps.Rps(p1,p2));
    }
}

public class Kata
{
    private Dictionary<string,Thing> KeyValuePairs { get; set; }

    public Kata ()
    {
        KeyValuePairs = new Dictionary<string, Thing>
        {
            { "scissors", new Scissors() },
            { "rock", new Rock() },
            { "paper", new Paper() }
        };
    }

    public string Rps(string p1, string p2)
    {
        var player = KeyValuePairs[p1];
        player.Opponent = KeyValuePairs[p2];

        player.CalculateVictory();

        return player.PlayerResult switch
        {
            Result.Won => "Player 1 won!",
            Result.Defeat => "Player 2 won!",
            _ => "Draw!"
        };
    }

     public abstract class Thing
    {
        public Result PlayerResult { get; set; } = Result.Draw;
        public Thing Opponent { get; set; }
        public virtual void CalculateVictory() { }
    }

    public class Scissors: Thing
    {
        public override void CalculateVictory()
        {
            if (Opponent is Rock) PlayerResult = Result.Defeat;
            else if (Opponent is Paper) PlayerResult = Result.Won;
        }
    }

    public class Rock : Thing
    {
        public override void CalculateVictory()
        {
            if (Opponent is Paper) PlayerResult = Result.Defeat;
            else if (Opponent is Scissors) PlayerResult = Result.Won;
        }
    }

    public class Paper : Thing
    {
        public override void CalculateVictory()
        {
            if (Opponent is Scissors) PlayerResult = Result.Defeat;
            else if (Opponent is Rock) PlayerResult = Result.Won;
        }
    }

    public enum Result
    {
        Won,
        Defeat,
        Draw
    }
}
