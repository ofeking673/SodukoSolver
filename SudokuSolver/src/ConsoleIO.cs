
public class ConsoleIO
{
    public ConsoleIO() {}
    
    public static string ReadInput() {
        return Console.ReadLine() 
            ?? throw new InvalidOperationException("No input provided.");
    }

    public static int[,] parseBoard(string boardInput) {
        
        if (boardInput.Length != 81) {
            throw new ArgumentException("Input length must be exactly 81 bytes.");
        }
    
        int [,] grid = new int[9,9];

        for (int i = 0; i < 81; i++) {
            char ch = boardInput[i];

            if (ch < '0' || ch > '9') {
                throw new ArgumentException("Input must contain only digits.");
            }

            int row = i / 9;
            int col = i % 9;

            grid[row, col] = ch - '0';
        }

        return grid;
    }
        
    public static void PrintBoard(IBoard board)
    {
        const int SIZE = 9;

        for (int r = 0; r < SIZE; r++)
        {
            if (r % 3 == 0)
                Console.WriteLine("+-------+-------+-------+");

            for (int c = 0; c < SIZE; c++)
            {
                if (c % 3 == 0)
                    Console.Write("| ");

                int value = board.GetCell(r, c);
                Console.Write(value == 0 ? ". " : value + " ");
            }

            Console.WriteLine("|");
        }

        Console.WriteLine("+-------+-------+-------+");
    }
}
