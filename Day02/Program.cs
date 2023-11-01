using System.IO;
using System;

string[] lines = File.ReadAllLines("./input.in");
// string[] lines = File.ReadAllLines("./test_input.in");

int score = 0;

foreach (var line in lines)
{
    var (opponent, me) = convert(line);
    score += addScore(me) + winLose(opponent, me);
}

System.Console.WriteLine("Part 1 answer: " + score);

score = 0;

foreach (var line in lines)
{
    var (opponent, me) = convert2(line);
    score += addScore(me) + winLose(opponent, me);
}

System.Console.WriteLine("Part 2 answer: " + score);

static int winLose(string opponent, string me)
{
    if (opponent == me)
    {
        return 3;
    }
    else
    {
        if (me == "Rock")
        {
            if (opponent == "Paper")
            {
                return 0;
            }
            else if (opponent == "Scissors")
            {
                return 6;
            }
        }
        else if (me == "Paper")
        {
            if (opponent == "Scissors")
            {
                return 0;
            }
            else if (opponent == "Rock")
            {
                return 6;
            }
        }
        else if (me == "Scissors")
        {
            if (opponent == "Rock")
            {
                return 0;
            }
            else if (opponent == "Paper")
            {
                return 6;
            }
        }
    }
    return 0;
}

static int addScore(string me)
{
    return me switch
    {
        "Rock" => 1,
        "Paper" => 2,
        "Scissors" => 3,
        _ => 0,
    };
}

static (string Opponent, string Me) convert(string line)
{
    var parts = line.Split(' ');
    var (opponent, me) = (parts[0], parts[1]);

    switch (opponent)
    {
        case "A":
            opponent = "Rock";
            break;
        case "B":
            opponent = "Paper";
            break;
        case "C":
            opponent = "Scissors";
            break;
    }

    switch (me)
    {
        case "X":
            me = "Rock";
            break;
        case "Y":
            me = "Paper";
            break;
        case "Z":
            me = "Scissors";
            break;
    }

    return (Opponent: opponent, Me: me);
}

static (string opponent, string me) convert2(string line)
{
    var parts = line.Split(' ');
    var (opponent, me) = (parts[0], parts[1]);
    Option result;

    switch (opponent)
    {
        case "A":
            opponent = "Rock";
            result = new Rock();
            break;
        case "B":
            opponent = "Paper";
            result = new Paper();
            break;
        case "C":
            opponent = "Scissors";
            result = new Scissors();
            break;
        default:
            throw new InvalidOperationException($"Invalid opponent value: {opponent}");
    }

    switch (me)
    {
        case "X":
            me = result.Lose;
            break;
        case "Y":
            me = result.Draw;
            break;
        case "Z":
            me = result.Win;
            break;
    }

    return (opponent: opponent, me: me);
}

interface Option
{
    string Name { get; }
    string Win { get; }
    string Draw { get; }
    string Lose { get; }
}

class Rock : Option
{
    public string Name => "Rock";
    public string Win => "Paper";
    public string Draw => "Rock";
    public string Lose => "Scissors";
}

class Paper : Option
{
    public string Name => "Paper";
    public string Win => "Scissors";
    public string Draw => "Paper";
    public string Lose => "Rock";
}

class Scissors : Option
{
    public string Name => "Scissors";
    public string Win => "Rock";
    public string Draw => "Scissors";
    public string Lose => "Paper";
}
