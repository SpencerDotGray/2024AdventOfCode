﻿

using AdventOfCode;
using System.Reflection;

string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"testinput.txt");

var fileIn = File.ReadAllText(path);

Day day = new Day04();

day.ExecuteTwo(fileIn);