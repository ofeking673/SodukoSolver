using System;

while (true)
{
    try {
        int [,] grid = ConsoleIO.parseBoard(ConsoleIO.ReadInput());
        var board = new Board(grid);
        ConsoleIO.PrintBoard(board);
    }
    catch (Exception ex) {
        Console.WriteLine(ex.Message);
    }
}
