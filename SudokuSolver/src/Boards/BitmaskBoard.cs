public class BitmaskBoard : IBitmaskBoard
{  
  private const int SIZE = 9;
  private const int FULL_MASK = 0x1FF; // 9 bits set

  private readonly int[,] cells = new int[SIZE, SIZE];
  
  private readonly int[] rowMask = new int[SIZE];
  private readonly int[] colMask = new int[SIZE];
  private readonly int[] boxMask = new int[SIZE];
  
  private static readonly int[,] BoxIndex = new int[SIZE, SIZE];
  
  static BitmaskBoard() {
    for (int r = 0; r < SIZE; r++)
      for (int c = 0; c < SIZE; c++)
        BoxIndex[r,c] = (r / 3) * 3 + (c / 3);
  }

  public BitmaskBoard(int[,] input) {
    for (int r = 0; r < SIZE; r++) {
      for (int c = 0; c < SIZE; c++) {
        int val = input[r,c];
        
        if(val != 0)
          PlaceInitialValue(r, c, val);
      }
    }
  }
  
  /// <summary>
  /// Places the initial values of the sudoku solved board, if a conflict is met, the board is invalid.
  /// </summary>
  /// <param name-"row">The row of the current cell</param>
  /// <param name="col">The column of the current cell</param>
  /// <param name="val">The new value to bet set to the cell</param>
  /// <exception cref="ArgumentException">Thrown if a duplicate value is found</exception>
  private void PlaceInitialValue(int row, int col, int val) {
    int bit = DigitToBit(val);
    int box = BoxIndex[row, col];

    if((rowMask[row] & bit) != 0 ||
       (colMask[col] & bit) != 0 ||
       (boxMask[box] & bit) != 0)
    {
      throw new ArgumentException("Invalid board: Duplicate value.");
    }

    cells[row,col] = val;
     
    rowMask[row] |= bit;
    colMask[col] |= bit;
    boxMask[box] |= bit;
  }
  
  /// <summary>Get the cell at the specified position</summary>
  /// <param name="row">The row of the requested cell</param>
  /// <param name="col">The column of the requested cell</param>
  /// <returns>The value of the cell</returns>
  public int GetCell(int row, int col) {
    return cells[row, col];
  }
  

  /// <summary>Set the cell at the specified position to a value</summary>
  /// <param name="row">The row of the requested cell</param>
  /// <param name="col">The column of the requested cell</param>
  /// <param name="val">The new value for the cell to be set to</param>
  public void SetCell(int row, int col, int val) {
    int bit = DigitToBit(val);
    int box = BoxIndex[row, col];

    cells[row, col] = val;
    rowMask[row] |= bit;
    colMask[col] |= bit;
    boxMask[box] |= bit;
  }

  /// <summary>Clear the value of the cell at the specified position</summary>
  /// <param name="row">The row of the requested cell</param>
  /// <param name="col">The column of the requested cell</param>
  public void ClearCell(int row, int col) {
    int val = cells[row, col];
    if(val == 0) {
      return;
    } 

    int bit = DigitToBit(val);
    int box = BoxIndex[row, col];

    cells[row, col] = 0;
    rowMask[row] &= ~bit;
    colMask[col] &= ~bit;
    boxMask[box] &= ~bit;
  }

  /// <summary>
  /// Get the candidate mask for easy possible candidate choosing
  /// </summary>
  /// <param name="row">The row of the cell to get the mask for</param>
  /// <param name="col">The column of the cell to get the mask for</param>
  /// <returns>The integer representation of the mask</returns>
  public int GetCandidateMask(int row, int col) {
    if(cells[row, col] != 0)
      return 0;

    int used = rowMask[row] | colMask[col] | boxMask[BoxIndex[row, col]];

    return FULL_MASK & ~used;
  }
  
  /// <summary>Check whether the board is solved or not</summary>
  /// <returns>A boolean value representing the board state</returns>
  public bool IsSolved 
  {
    get 
    {
      for (int r = 0; r < SIZE; r++) 
        for(int c = 0; c < SIZE; c++)
          if (cells[r,c] == 0)
            return false;

      return true;
    }
  }
  
  /// <summary>Transforms an integer to a binary representation for the bitmask handling</summary>
  /// <param name="dig">The digit to transform</param>
  /// <returns>The binary representation</returns>
  private static int DigitToBit(int dig) {
    return 1 << (dig - 1);
  }
}
