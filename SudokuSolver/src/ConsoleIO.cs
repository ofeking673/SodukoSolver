
public class ConsoleIO
{
    public ConsoleIO() {}
    
    /// <summary> 
    /// Reads a single line of input from the console.
    /// </summary>
    /// <returns>A string containing the user's input.</returns>
    /// <exception cref="InvalidOperationException">Thrown if no input is provided.</exception>
    public static string ReadInput() {
        return Console.ReadLine() 
            ?? throw new InvalidOperationException("No input provided.");
    }


    /// <summary>
    /// Parses a string representation of a Sudoku board into a 2D integer array.
    /// The input string must be exactly 81 characters long, where each character is a digit
    /// between '0' and '9'. The character '0' represents an empty cell.
    /// </summary>
    /// <param name="boardInput">A string containing the Sudoku board representation.</param>
    /// <returns>A 2D integer array representing the Sudoku board.</returns>
    /// <exception cref="ArgumentException">Thrown if the input string is not valid.</exception>
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
    /// <summary>
    /// Takes a board interface representing all types of sudoku boards
    /// Prints all cells respectively to their position
    /// </summary>
    /// <param name="board"> A Board interface.</param>
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
