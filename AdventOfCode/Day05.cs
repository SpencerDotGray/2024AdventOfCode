using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode;
public class Day05 : Day
{
    private List<List<int>> invalidUpdates;
    private List<List<int>> updates;
    private Dictionary<int, List<int>> rules;

    public Day05()
    {
        invalidUpdates = new List<List<int>>();
        updates = new List<List<int>>();
        rules = new Dictionary<int, List<int>>();
    }

    public void ExecuteOne(string data)
    {
        // This assumes the formatting of the rules is correct, which is an assumption I am willing to make
        var r = data.Split('\n').Where(rule => rule.Contains('|')).Select(rule => (int.Parse(rule.Split('|')[0]), int.Parse(rule.Split('|')[1]))).ToList();
        updates = data.Split('\n').Where(update => update.Contains(',')).Select(row => row.Split(',').Select(digit => int.Parse(digit)).ToList()).ToList();

        foreach (var rule in r)
        {
            if (!rules.ContainsKey(rule.Item1))
                rules.Add(rule.Item1, new List<int>());

            rules[rule.Item1].Add(rule.Item2);
        }

        int sum = 0;
        foreach (var update in updates) // Go Through Each Row
        {
            bool violationFound = false;
            for (int i = update.Count-1; i >= 1; i--) // Go Through Update Backwards
            {
                int digit = update[i];

                if (rules.ContainsKey(digit))
                {
                    bool isViolation = GetViolationIndicies(rules[digit], update.Slice(0, i)) != null;// Go Through Each Rule for Digit: update[i];

                    if (isViolation)
                        violationFound = true;
                }
            }

            if (violationFound)
                invalidUpdates.Add(update);

            sum += violationFound ? 0 : GetMiddleDigitInList(update);
        }

        Console.WriteLine($"Part 1 Sum: {sum}");
    }

    private int GetMiddleDigitInList(List<int> list)
    {
        double middle = list.Count / 2.0;
        return list[(int)Math.Floor(middle)];
    }

    private int? GetViolationIndicies(List<int> checkDigits, List<int> remainingList)
    {
        for (int i = 0; i < checkDigits.Count; i++)
        {
            var digit = checkDigits[i];
            if (remainingList.Contains(digit))
                return remainingList.IndexOf(digit);
        }

        return null;
    }

    public void ExecuteTwo(string data)
    {
        ExecuteOne(data);

        int sum = 0;
        foreach (var update in invalidUpdates) // Go Through Each Row
        {
            bool violationFound = true;

            int dontBrickMachinesCheck = 0;
            while (violationFound && dontBrickMachinesCheck <= 1000)
            {
                violationFound = false;
                for (int i = update.Count - 1; i >= 1; i--) // Go Through Update Backwards
                {
                    int digit = update[i];

                    if (rules.ContainsKey(digit))
                    {
                        int? violation = GetViolationIndicies(rules[digit], update.Slice(0, i));

                        if (violation != null)
                        {
                            var temp = update[i];
                            update[i] = update[violation.Value!];
                            update[violation.Value!] = temp;
                            violationFound = true;
                            break;
                        }
                    }
                }
                dontBrickMachinesCheck++;
            }

            sum += GetMiddleDigitInList(update);
        }

        Console.WriteLine($"\nPart 2 Sum: {sum}");
    }
}

