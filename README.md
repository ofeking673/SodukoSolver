# Sudoku Solver

A high-performance Sudoku solver written in C# (.NET 8.0) that implements multiple solving algorithms with optimized data structures.

## Features

- **Multiple Solving Algorithms:**
  - **BitmaskSolver**: Uses bitwise operations to efficiently track candidates for each cell
  - **BacktrackSolver**: Classic backtracking algorithm with constraint propagation
  
- **Flexible Board Implementations:**
  - **BitmaskBoard**: Optimized board using bitmasks for fast candidate tracking
  - **BacktrackingBoard**: Traditional board implementation with list-based candidates  
  
- **Factory Pattern**: Automatically selects the appropriate solver based on board type

- **Performance Optimized**: 
  - Solves 100 puzzles in under 1 second
  - Uses bitwise operations for efficient candidate management
  - Implements "minimum remaining values" heuristic for faster solving

## Project Structure

```
SudokuSolver/
├── SudokuSolver/                 # Main application
│   └── src/
│       ├── Program.cs            # Entry point with console interface
│       ├── ConsoleIO.cs          # Input/output handling and board parsing
│       ├── SolverFactory.cs      # Factory for creating appropriate solvers
│       ├── Boards/
│       │   ├── IBoard.cs         # Board interfaces
│       │   ├── BitmaskBoard.cs   # Bitmask-optimized board implementation
│       │   └── BacktrackingBoard.cs  # Traditional board implementation
│       └── Solvers/
│           ├── ISolver.cs        # Solver interface
│           ├── BitmaskSolver.cs  # Optimized solver using bitwise operations
│           └── BacktrackSolver.cs    # Classic backtracking solver
└── SudokuSolver.Tests/           # Unit and performance tests
    ├── Tests/
    │   ├── ParsingTests.cs       # Input validation tests
    │   └── SudokuSpeedTest.cs    # Performance benchmarks
    └── Source_Files/
        └── 17_clue.txt      # Sample puzzles for testing
```

## Usage

### Running the Application

1. Clone the repository:
```bash
git clone https://github.com/ofeking673/SudokuSolver.git
cd SudokuSolver
```

2. Build and run:
```bash
dotnet run --project SudokuSolver -c Release
```

3. Enter a Sudoku puzzle as an 81-character string (row by row, use `0` for empty cells):
```
003020600900305001001806400008102900700000008006708200002609500800203009005010300
```

### Input Format

- Puzzles must be exactly 81 characters long
- Each character represents a cell (rows 1-9, columns 1-9)
- Use digits `1-9` for filled cells
- Use `0` for empty cells
- Example: `003020600900305001...` (81 digits total)

### Example Output

```
Original board:
+-------+-------+-------+
| . . 3 | . 2 . | 6 . . |
| 9 . . | 3 . 5 | . . 1 |
| . . 1 | 8 . 6 | 4 . . |
+-------+-------+-------+
| . . 8 | 1 . 2 | 9 . . |
| 7 . . | . . . | . . 8 |
| . . 6 | 7 . 8 | 2 . . |
+-------+-------+-------+
| . . 2 | 6 . 9 | 5 . . |
| 8 . . | 2 . 3 | . . 9 |
| . . 5 | . 1 . | 3 . . |
+-------+-------+-------+
-=========================-
+-------+-------+-------+
| 4 8 3 | 9 2 1 | 6 5 7 |
| 9 6 7 | 3 4 5 | 8 2 1 |
| 2 5 1 | 8 7 6 | 4 9 3 |
+-------+-------+-------+
| 5 4 8 | 1 3 2 | 9 7 6 |
| 7 2 9 | 5 6 4 | 1 3 8 |
| 1 3 6 | 7 9 8 | 2 4 5 |
+-------+-------+-------+
| 3 7 2 | 6 8 9 | 5 1 4 |
| 8 1 4 | 2 5 3 | 7 6 9 |
| 6 9 5 | 4 1 7 | 3 8 2 |
+-------+-------+-------+
Solve time:
00:00.0008
```

## Algorithm Details

### BitmaskSolver

The optimized solver uses bitwise operations for efficient candidate tracking:

- **Candidate Representation**: Each possible value (1-9) is represented as a bit in a 9-bit integer
- **Constraint Tracking**: Maintains bitmasks for rows, columns, and 3x3 boxes
- **MRV Heuristic**: Selects cells with the fewest remaining candidates first
- **Bit Manipulation**: Uses `BitOperations.PopCount` for fast candidate counting

### BacktrackSolver

Classic recursive backtracking with:

- Cell-by-cell traversal (left-to-right, top-to-bottom)
- Constraint checking for rows, columns, and boxes
- Recursive depth-first search
- Backtracking on invalid placements

## Testing

Run the test suite:

```bash
dotnet test -c Release
```

The project includes:

- **Validation Tests**: Ensure invalid boards are rejected
- **Performance Tests**: Verify all puzzles solve in under 1 second
- **Edge Case Tests**: Handle malformed input gracefully

## Requirements

- .NET 10.0 SDK or later
- Compatible with Windows, macOS, and Linux

## Performance

- Solves typical puzzles in milliseconds
- Passes benchmark: 49150 tests pass in average of 0.0082 seconds per puzzle
- Optimized for hard/evil difficulty puzzles

## License

This project is open source and available for educational purposes.

## Contributing

Contributions are welcome! Feel free to open issues or submit pull requests.

## Author

Created by [ofeking673](https://github.com/ofeking673)
