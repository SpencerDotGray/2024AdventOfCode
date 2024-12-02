using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode;

public class Day01 : Day
{
    public void ExecuteOne(string data)
    {
        var left = new List<int>();
        var right = new List<int>();

        foreach (var point in data.Split('\n').Select(e => RemoveDoubleSpace(e).Split(" ")))
        {
            left.Add(int.Parse(point[0]));
            right.Add(int.Parse(point[1]));
        }

        left.Sort();
        right.Sort();

        int sum = 0;
        for (int i = 0; i < left.Count; i++)
        {
            sum += Math.Abs(left[i] - right[i]);
        }

        Console.WriteLine(sum);
    }

    public void ExecuteTwo(string data)
    {
        var l = data.Split('\n').Select(e => RemoveDoubleSpace(e).Split(" ")).Select(e => int.Parse(e[1]));

        var sum = data.Split('\n')
            .Select(e => RemoveDoubleSpace(e).Split(" "))
            .Select(e => int.Parse(e[0]))
            .Aggregate(0, (t, n) => t + n * l.Where(e => e == n).Count());

        Console.WriteLine(sum);
    }

    private string RemoveDoubleSpace(string data)
    {
        if (data.IndexOf("  ") > 0)
            return RemoveDoubleSpace(data.Replace("  ", " "));
        return data;
    }
}
