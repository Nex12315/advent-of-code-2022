using System.IO;
using System.Collections.Generic;
using System.Linq;

string[] lines = File.ReadAllLines("./input.in");

List<int> calories = new List<int> { };

System.Console.WriteLine(lines);

int sum = 0;
int amount = 0;

foreach (var line in lines)
{
    if (line != "")
    {
        sum += int.Parse(line);
    }
    else
    {
        calories.Add(sum);
        sum = 0;
        amount++;
    }
}

int max1 = 0;
int max2 = 0;
int max3 = 0;

int chosen = 0;

foreach (int number in calories)
{
    if (max1 < number)
    {
        max1 = number;
        chosen = number;
    }
}

calories.Remove(chosen);

foreach (int number in calories)
{
    if (max2 < number)
    {
        max2 = number;
        chosen = number;
    }
}

calories.Remove(chosen);

foreach (int number in calories)
{
    if (max3 < number)
    {
        max3 = number;
        chosen = number;
    }
}

calories.Remove(chosen);

System.Console.WriteLine(max1 + max2 + max3);
