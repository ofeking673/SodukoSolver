using System.Numerics;

public class BitmaskSolver : ISolver {
  
  private const int SIZE = 9;
  
  /// <summary>Check if the board is able to be solved by this solver type</summary>
  /// <param name="board">The board instance</param>
  /// <returns>Boolean value representing whether the board was solved</returns>
  /// <exception cref="ArgumentException">Thrown if the board is not of type IBitmaskBoard</exception>
  public bool Solve(IBoard board)
  {
    if (board is not IBitmaskBoard bm)
      throw new ArgumentException("BimaskSolver requires BitmaskBoard.");

    return SolveBitmaskRecursive(bm);
  }

  /// <summary></summary>
  /// <param name="board">The board to solve</param>
  /// <returns>Boolean value representing whether the board was solved or not</returns>
  private bool SolveBitmaskRecursive(IBitmaskBoard board) 
  {
    int bestRow = -1, bestCol = -1;
    int bestMask = 0;
    int bestCount = 10;

    // find empty cell with fewest candidates, using bitmask directly
    for (int r = 0; r < SIZE; r++)
    {
      for (int c = 0; c < SIZE; c++)
      {
        if (board.GetCell(r, c) != 0)
          continue;

        int mask = board.GetCandidateMask(r, c);
        if (mask == 0)
          return false;

        int count = BitOperations.PopCount((uint)mask);
        
        if (count < bestCount)
        {
          bestCount = count;
          bestMask = mask;
          bestRow = r;
          bestCol = c;
          if (count == 1)
              goto Found; // cannot get better than 1
        }
      }
    }

    // No empty cells → solved
    if (bestRow == -1)
      return board.IsSolved;

  Found:
    int m = bestMask;
    // This checks all of the bits inside of bestMask, so that the cheapest masks will be at the beginning of the recursion
    while (m != 0)
    {
      int bit = m & -m;
      int val = BitToDigit(bit);

      board.SetCell(bestRow, bestCol, val);
      if (SolveBitmaskRecursive(board))
        return true;

      board.ClearCell(bestRow, bestCol); // backtrack

      m &= m - 1; // clear lowest set bit
    }

    return false;
  }
  
  /// <summary>Transforms the bitmask bit into the digit</summary>
  /// <param name="bit">The bit to transform</param>
  /// <returns>The bit index, AKA the number</returns>
  private int BitToDigit(int bit) {
    int digit = 1;
    while ((bit >>= 1) != 0) {
      digit++;
    }
    return digit;
  }
}
