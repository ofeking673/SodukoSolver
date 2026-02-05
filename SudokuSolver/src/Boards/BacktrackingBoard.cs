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

  public int GetCell(int row, int col) => cells[row, col];

  public void SetCell(int row, int col, int val) => cells[row, col] = val;

  public void ClearCell(int row, int col) => cells[row, col] = 0;


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
  private bool IsValid(int row, int col, int val)
  {
    // Check row and column
    for (int i = 0; i < SIZE; i++)
    {
      if (cells[row, i] == val) return false;
      if (cells[i, col] == val) return false;
    }

    // Check 3x3 box
    int startRow = (row / 3) * 3;
    int startCol = (col / 3) * 3;

    for (int r = startRow; r < startRow + 3; r++)
      for (int c = startCol; c < startCol + 3; c++)
        if (cells[r, c] == val)
          return false;

    return true;
  }

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
