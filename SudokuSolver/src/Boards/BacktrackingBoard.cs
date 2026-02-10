public class BacktrackingBoard : IBoard
{
  private const int SIZE = 9;
  private readonly int[,] cells = new int[SIZE, SIZE];

  public BacktrackingBoard(int[,] initial)
  {
    for (int r = 0; r < SIZE; r++)
          for (int c = 0; c < SIZE; c++)
              cells[r, c] = initial[r, c];
  }
  
  /// <summary>Get the cell at the specified position</summary>
  /// <param name="row">The row of the requested cell</param>
  /// <param name="col">The column of the requested cell</param>
  /// <returns>The value of the cell</returns>
  public int GetCell(int row, int col) => cells[row, col];

  /// <summary>Set the cell at the specified position to a value</summary>
  /// <param name="row">The row of the requested cell</param>
  /// <param name="col">The column of the requested cell</param>
  /// <param name="val">The new value for the cell to be set to</param>
  public void SetCell(int row, int col, int val) => cells[row, col] = val;
 
  /// <summary>Clear the value of the cell at the specified position</summary>
  /// <param name="row">The row of the requested cell</param>
  /// <param name="col">The column of the requested cell</param>
  public void ClearCell(int row, int col) => cells[row, col] = 0;

  /// <summary>Get a list of all possible candidates</summary>
  /// <param name="row">The cell's row</param>
  /// <param name="col">The cell's column</param>
  /// <returns>A list containing the candidates in an integer representation</returns>
  public List<int> GetPossibleCandidates(int row, int col)
  {
    var candidates = new List<int>();
    if (GetCell(row, col) != 0) return candidates;

    for (int val = 1; val <= 9; val++)
    {
      if (IsValid(row, col, val))
        candidates.Add(val);
    }

    return candidates;
  }

 
  // Check if val can be placed at (row, col)
  /// <summary>Check whether a value can be placed at (row, col)</summary>
  /// <param name="row">A row for the cell</param>
  /// <param name="col">A column for the cell</param>
  /// <param name="val">The new value to check for</param>
  /// <returns>A boolean value representing whether the value is legal or not</returns>
  private bool IsValid(int row, int col, int val)
  {
    for (int i = 0; i < SIZE; i++)
    {
      if (cells[row, i] == val) return false;
      if (cells[i, col] == val) return false;
    }

    int startRow = (row / 3) * 3;
    int startCol = (col / 3) * 3;

    for (int r = startRow; r < startRow + 3; r++)
      for (int c = startCol; c < startCol + 3; c++)
        if (cells[r, c] == val)
          return false;

    return true;
  }

  /// <summary>Check whether the board is solved or not</summary>
  /// <returns>A boolean value representing the board state</returns>
  public bool IsSolved
  {
    get
    {
      for (int r = 0; r < SIZE; r++)
        for (int c = 0; c < SIZE; c++)
          if (cells[r, c] == 0)
            return false;
      return true;
    }
  }
}
