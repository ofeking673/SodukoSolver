
public class SolverFactory {
  
  /// <summary>
  /// Creates a respective solver depending on board type
  /// </summary>
  /// <param name="board">A board instance</param>
  /// <exception cref="NotSupportedException">Thrown if the board is of an unsupported type</exception>
  public static ISolver CreateSolver(IBoard board) {
    return board switch 
    {
        IBitmaskBoard b => new BitmaskSolver(),
        IListCandidatesBoard b=> new BacktrackSolver(),
        _ => throw new NotSupportedException($"No solver for board type {board.GetType().Name}")
    };
  }
}
