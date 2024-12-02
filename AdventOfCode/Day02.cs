using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode;

public class Day02 : Day
{
    public void ExecuteOne(string data) 
    {
        var reports = data
            .Split('\n')
            .Select(e => e
                .Split(' ')
                .Select(e => int.Parse(e)).ToList()
            );

        int safeReports = 0;

        foreach (var report in reports)
        {
            if (!CheckAscendingDescending(report))
                continue;

            if (!CheckReportValues(report))
                continue;

            safeReports++;
        }

        Console.WriteLine($"Safe Reports Found: {safeReports}");
    }

    public void ExecuteTwo(string data)
    {
        var reports = data
            .Split('\n')
            .Select(e => e
                .Split(' ')
                .Select(e => int.Parse(e)).ToList()
            );

        int safeReports = 0;

        foreach (var report in reports)
        {
            if (CheckAscendingDescending(report) && CheckReportValues(report))
            {
                safeReports++;
                continue;
            }

            for (int i = 0; i < report.Count; i++)
            {
                var reportSlice = report.Select((e, index) => index == i ? -1 : e).Where(e => e >= 0).ToList();

                if (CheckAscendingDescending(reportSlice) && CheckReportValues(reportSlice))
                {
                    safeReports++;
                    break;
                }
            }
        }

        Console.WriteLine($"Safe Reports Found: {safeReports}");
    }

    private bool CheckReportValues(List<int> report)
    {
        int checkSum = 0;
        for (int i = 0; i < report.Count() - 1; i++)
        {
            checkSum += Math.Abs(report[i] - report[i + 1]) switch
            {
                (>= 1) and (<= 3) => 0,
                _ => 1
            };
        }

        return checkSum == 0;
    }

    private bool CheckAscendingDescending(List<int> report)
    {
        bool isAscending = report.SequenceEqual(report.Order());
        bool isDescending = report.SequenceEqual(report.OrderDescending());

        return isAscending || isDescending;
    }
}
