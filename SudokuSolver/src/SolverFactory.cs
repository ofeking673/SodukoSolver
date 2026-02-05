
public class SolverFactory {
  public static ISolver CreateSolver(IBoard board) {
    return board switch 
    {
        IBitmaskBoard b => new BitmaskSolver(),
        IListCandidatesBoard b=> new BacktrackSolver(),
        _ => throw new NotSupportedException($"No solver for board type {board.GetType().Name}")
    };
  }
}
