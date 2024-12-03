using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode;

public class Day03 : Day
{
    public void ExecuteOne(string data)
    {
        string pattern = "mul\\([0-9]+,[0-9]+\\)";
        Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

        int sum = 0;
        foreach (Match match in regex.Matches(data))
        {
            string[] numbers = match
                .Value
                .Replace("mul(", "")
                .Replace(")", "")
                .Split(',');

            sum += int.Parse(numbers[0]) * int.Parse(numbers[1]);
        }

        Console.WriteLine($"{sum}");
    }

    public void ExecuteTwo(string data)
    {
        var donts = Regex.Matches(data, "don't\\(\\)").Select(e => e.Index).ToList();
        var dos = Regex.Matches(data, "do\\(\\)").Select(e => e.Index).ToList();

        string output = "";
        bool take = true;

        for (int i = 0; i < data.Length; i++)
        {
            if (donts.Contains(i))
                take = false;
            if (dos.Contains(i))
                take = true;

            output += take ? data[i] : "";
        }

        ExecuteOne(output);
    }
}
