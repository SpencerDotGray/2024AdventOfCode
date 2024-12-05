using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode;
public class Day04 : Day
{
    void Day.ExecuteOne(string data)
    {
        var grid = data.Split('\n').Aggregate(new List<List<char>>(), (t, n) => t.Append(n.ToCharArray().ToList()).ToList());

        int count = 0;
        for (int i = 0; i < grid.Count; i++)
        {
            for (int j = 0; j < grid[i].Count; j++)
            {
                char c = grid[i][j];

                if (c != 'X')
                    continue;

                if (j >= 3 && grid[i][j - 1] == 'M' && grid[i][j - 2] == 'A' && grid[i][j - 3] == 'S') // Check Left
                    count++;
                if (j <= grid[i].Count - 4 && grid[i][j + 1] == 'M' && grid[i][j + 2] == 'A' && grid[i][j + 3] == 'S') // Check Right
                    count++;
                if (i >= 3 && grid[i - 1][j] == 'M' && grid[i - 2][j] == 'A' && grid[i - 3][j] == 'S') // Check Up
                    count++;
                if (i <= grid.Count - 4 && grid[i + 1][j] == 'M' && grid[i + 2][j] == 'A' && grid[i + 3][j] == 'S') // Check Down
                    count++;
                if (j >= 3 && i >= 3 && grid[i - 1][j - 1] == 'M' && grid[i - 2][j - 2] == 'A' && grid[i - 3][j - 3] == 'S') // Check Left Up
                    count++;
                if (j <= grid[i].Count && i >= 3 && grid[i - 1][j + 1] == 'M' && grid[i - 2][j + 2] == 'A' && grid[i - 3][j + 3] == 'S') // Check Right Up
                    count++;
                if (j >= 3 && i <= grid.Count - 4 && grid[i + 1][j - 1] == 'M' && grid[i + 2][j - 2] == 'A' && grid[i + 3][j - 3] == 'S') // Check Left Down
                    count++;
                if (j <= grid[i].Count - 4 && i <= grid.Count - 4 && grid[i + 1][j + 1] == 'M' && grid[i + 2][j + 2] == 'A' && grid[i + 3][j + 3] == 'S') // Check Right Down
                    count++;           
            }
        }

        Console.WriteLine(count);
    }

    void Day.ExecuteTwo(string data)
    {
        var grid = data.Split('\n').Aggregate(new List<List<char>>(), (t, n) => t.Append(n.ToCharArray().ToList()).ToList());

        List<string> patterns = new List<string>()
        {
            "S.M\n.A.\nS.M",
            "S.S\n.A.\nM.M",
            "M.M\n.A.\nS.S",
            "M.S\n.A.\nM.S"
        };

        int count = 0;
        for (int i = 0; i < grid.Count; i++)
        {
            for (int j = 0; j < grid[i].Count; j++)
            {
                char c = grid[i][j];
                try
                {
                    if (c == 'A')
                        count += patterns.Contains($"{grid[i - 1][j - 1]}.{grid[i - 1][j + 1]}\n.A.\n{grid[i + 1][j - 1]}.{grid[i + 1][j + 1]}") ? 1 : 0;
                }
                catch (Exception ex)
                {
                    continue;
                }
            }
        }

        Console.WriteLine($"Count: {count}");
    }
}

