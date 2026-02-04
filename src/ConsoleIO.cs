
public class ConsoleIO
{
    public ConsoleIO() {}
    
    public string ReadInput() {
        return System.Console.ReadLine();
    }

    public Board parseBoard() {
        string boardInput = ReadInput();

    
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

        return new Board(grid); 
        // If the input has logic issues, the board enforces all rules and will throw an exception
    } 

    public void PrintBoard(IBoard board) {
        for(int i = 0; i < 9; i++) {
            for(int j = 0; j < 9; j++) 
                Console.Write(board.GetCell(i, j));
            Console.WriteLine();
        }
    }
}
