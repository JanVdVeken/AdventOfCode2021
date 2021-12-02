// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using D02.Records;


var input =File.ReadLines(@"C:\Users\vande\OneDrive\Bureaublad\GitRoot\AdventOfCode\AdventOfCode2021\AdventOfCode2021\Inputs\D02.txt");
List<Command> commands = new List<Command>();
foreach (var inputline in input)
{
    commands.Add(new Command(inputline.Split(" ")[0],int.Parse(inputline.Split(" ")[1])));
}

Submarine submarine = new Submarine(0,0);
commands.ForEach(x => submarine.Move(x));
Console.WriteLine(submarine.CalcPosition());