using System;
using System.Collections.Generic;
using System.Drawing;

public class Loopover 
{
  public static List<string> Solve(char[][] mixedUpBoard, char[][] solvedBoard) 
  {
    bool canBeSolved = CheckAllCharsAreInBothBoards(mixedUpBoard, solvedBoard);
    if (!canBeSolved) return null;

    var board = (char[][])mixedUpBoard.Clone();
    List<string> moves = GetMovesToSolve(board, solvedBoard);

    return moves;
  }

    private static List<string> GetMovesToSolve(char[][] board, char[][] solvedBoard)
    {
        List<string> moves = [];
        var numOfRows = solvedBoard.Length;
        var numOfCols = solvedBoard[0].Length;

        for (int row = 0; row < numOfRows; row++)
            for (int col = 0; col < numOfCols; col++)
            {
                char target = solvedBoard[row][col];
                Point origin = FindTargetInBoard(target, board);

                int rowDistance = row - origin.X;
                int colDistance = col - origin.Y;

                if (TargetReached(rowDistance, colDistance)) continue;
                if (ShouldMoveLeft(rowDistance)) moves.Add(SwitchLeft(board, origin, rowDistance));
                if (ShouldMoveRight(rowDistance)) moves.Add(SwitchRight(board, origin, rowDistance));
            }

        return moves;
    }

    private static string SwitchRight(char[][] board, Point origin, int rowDistance)
    {
        string row = new string(board[origin.X]);
        int totalMoves = Math.Abs(rowDistance);
        string switchedRow = row[(row.Length - totalMoves)..] + row[..(row.Length - totalMoves)];
        board[origin.X] = switchedRow.ToCharArray();
        return $"R{totalMoves}";
    }

    private static string SwitchLeft(char[][] board, Point origin, int rowDistance)
    {
        string row = new string(board[origin.X]);
        int totalMoves = Math.Abs(rowDistance);
        string switchedRow = row.Substring(totalMoves) + row[..totalMoves];
        board[origin.X] = switchedRow.ToCharArray();
        return $"L{totalMoves}";
    }

    private static bool ShouldMoveRight(int rowDistance) => rowDistance > 0;

    private static bool ShouldMoveLeft(int rowDistance) => rowDistance < 0;

    private static bool TargetReached(int rowDistance, int colDistance) => rowDistance == 0 && colDistance == 0;

    private static Point FindTargetInBoard(char target, char[][] board)
    {
        var numOfRows = board.Length;
        var numOfCols = board[0].Length;
        for (int row = 0; row < numOfRows; row++)
            for (int col = 0; col < numOfCols; col++)
                if (board[row][col] == target) return new Point(row, col);

        throw new InvalidOperationException($"Target '{target}' not found in the board.");
    }

    private static bool CheckAllCharsAreInBothBoards(char[][] mixedUpBoard, char[][] solvedBoard)
    {
        var mixedChars = mixedUpBoard.Select(c => c).SelectMany(x => x).Order();
        var solvedChars = solvedBoard.Select(c => c).SelectMany(x => x).Order();

        return mixedChars.SequenceEqual(solvedChars);
    }
}