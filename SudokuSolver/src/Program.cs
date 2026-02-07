using System.Diagnostics;

while (true)
{
    try {
        int [,] grid = ConsoleIO.parseBoard(ConsoleIO.ReadInput());
        var board = new BitmaskBoard(grid);
        ISolver solver = SolverFactory.CreateSolver(board); 
        Console.WriteLine("Original board:");
        ConsoleIO.PrintBoard(board);

        Console.WriteLine("-=========================-");

        Stopwatch sw = new Stopwatch();
        sw.Start();
        solver.Solve(board);
        sw.Stop();
        ConsoleIO.PrintBoard(board);

        Console.WriteLine($"Solve time:\n{FormatStopwatch(sw)}");
    }
    catch (Exception ex) {
        Console.WriteLine(ex.Message);
    }
}


string FormatStopwatch(Stopwatch sw)
{
    TimeSpan ts = sw.Elapsed;
    return ts.ToString(@"mm\:ss\.ffff");
}
