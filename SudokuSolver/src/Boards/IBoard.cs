
public interface IBoard 
{
  int GetCell(int row, int col);
  void SetCell(int row, int col, int val);
  void ClearCell(int row, int col);

  bool IsSolved { get; }
}

public interface IListCandidatesBoard : IBoard
{
  IEnumerable<int> GetPossibleCandidates(int row, int col);
}

public interface IBitmaskBoard : IBoard
{
  int GetCandidateMask(int row, int col);
}
