using System.IO;

string[] lines = File.ReadAllLines("./input.in");

int score = 0;

foreach (var line in lines)
{
    var (opponent, me) = convert(line);
    score += addScore(me) + winLose(opponent, me);
}

System.Console.WriteLine(score);

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

