
public interface IBoard 
{
  int GetCell(int row, int col);
  void SetCell(int row, int col, int val);
  void ClearCell(int row, int col);

  List<int> GetPossibleCandidates(int row, int col);
  bool IsSolved { get; }
}
