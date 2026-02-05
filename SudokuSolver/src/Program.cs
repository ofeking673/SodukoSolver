using System.Diagnostics;

while (true)
{
    Solver solver = new Solver();
    try {
        int [,] grid = ConsoleIO.parseBoard(ConsoleIO.ReadInput());
        var board = new BacktrackingBoard(grid);

        Console.WriteLine("Original board:");
        ConsoleIO.PrintBoard(board);

        Console.WriteLine("-=========================-");

        Stopwatch sw = new Stopwatch();
        sw.Start();
        solver.Solve(board);
        sw.Stop();
        ConsoleIO.PrintBoard(board);

        Console.WriteLine($"It took exactly {sw.ElapsedMilliseconds} ms.");
    }
    catch (Exception ex) {
        Console.WriteLine(ex.Message);
    }
}
