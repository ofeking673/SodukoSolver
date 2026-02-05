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

  public int GetCell(int row, int col) {
    return cells[row, col];
  }

  public void SetCell(int row, int col, int val) {
    int bit = DigitToBit(val);
    int box = BoxIndex[row, col];

    cells[row, col] = val;
    rowMask[row] |= bit;
    colMask[col] |= bit;
    boxMask[box] |= bit;
  }

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

  public int GetCandidateMask(int row, int col) {
    if(cells[row, col] != 0)
      return 0;

    int used = rowMask[row] | colMask[col] | boxMask[BoxIndex[row, col]];

    return FULL_MASK & ~used;
  }
  
  
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

  private static int DigitToBit(int dig) {
    return 1 << (dig - 1);
  }
}
