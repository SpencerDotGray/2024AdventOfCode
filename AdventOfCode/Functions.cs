using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode;

public static class Functions
{
    public static string ListToString<T>(List<T> l)
    {
        return l.Aggregate("", (t, n) => $"{t} {n.ToString()}");
    }

    public static void PrintList<T>(List<T> l)
    {
        Console.WriteLine(ListToString(l));
    }
}
