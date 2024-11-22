using System;
using System.Collections.Generic;
using System.Drawing;

public class Loopover 
{
    public static char[][]? LastBoardSolved {get; set;}

  public static List<string>? Solve(char[][] mixedUpBoard, char[][] solvedBoard) 
  {
    bool canBeSolved = CheckAllCharsAreInBothBoards(mixedUpBoard, solvedBoard);
    if (!canBeSolved) return null;

    var board = (char[][])mixedUpBoard.Clone();
    List<string> moves = GetMovesToSolve(board, solvedBoard);

    LastBoardSolved = (char[][])board.Clone();
    return moves;
  }

    private static List<string> GetMovesToSolve(char[][] board, char[][] solvedBoard)
    {
        List<string> moves = [];
        var numOfRows = solvedBoard.Length;
        var numOfCols = solvedBoard[0].Length;

        for (int rowInSolved = 0; rowInSolved < numOfRows; rowInSolved++)
            for (int colInSolved = 0; colInSolved < numOfCols; colInSolved++)
            {
                char targetChar = solvedBoard[rowInSolved][colInSolved];
                Point currentLocation = FindTargetInBoard(targetChar, board);

                int rowDistance = rowInSolved - currentLocation.X;
                int colDistance = colInSolved - currentLocation.Y;

                if (TargetReached(rowDistance, colDistance)) continue;
                
                if (ShouldMoveLeft(colDistance)) moves.AddRange(SwitchLeft(board, currentLocation, colDistance));
                if (ShouldMoveRight(colDistance)) moves.AddRange(SwitchRight(board, currentLocation, colDistance));
                if (ShouldMoveUp(rowDistance)) moves.AddRange(SwitchUp(board, currentLocation, rowDistance));
                if (ShouldMoveDown(rowDistance)) moves.AddRange(SwitchDown(board, currentLocation, rowDistance));
            }

        return moves;
    }

    private static IEnumerable<string> SwitchDown(char[][] board, Point origin, int rowDistance)
    {
        List<string> moves = [];
        int totalMoves = Math.Abs(rowDistance);
        for (int i = 0; i < totalMoves; i++)
        {
            char temp = board[board.Length - 1][origin.Y];
            for (int row = board.Length - 1; row > 0; row--)
            {
                board[row][origin.Y] = board[row - 1][origin.Y];
            }
            board[0][origin.Y] = temp;
            moves.Add($"D{origin.Y}");
        }
        return moves;
    }

    private static IEnumerable<string> SwitchUp(char[][] board, Point origin, int rowDistance)
    {
        List<string> moves = [];
        int totalMoves = Math.Abs(rowDistance);
        for (int i = 0; i < totalMoves; i++)
        {
            char temp = board[0][origin.Y];
            for (int row = 0; row < board.Length - 1; row++)
            {
                board[row][origin.Y] = board[row + 1][origin.Y];
            }
            board[board.Length - 1][origin.Y] = temp;
            moves.Add($"U{origin.Y}");
        }
        return moves;
    }

    private static bool ShouldMoveUp(int rowDistance) => rowDistance > 0;

    private static bool ShouldMoveDown(int rowDistance) => rowDistance < 0;

    private static IEnumerable<string> SwitchRight(char[][] board, Point origin, int colDistance)
    {
        string row = new string(board[origin.X]);
        int totalMoves = Math.Abs(colDistance);
        string switchedRow = row[(row.Length - totalMoves)..] + row[..(row.Length - totalMoves)];
        board[origin.X] = switchedRow.ToCharArray();
        return Enumerable.Repeat($"R{origin.X}", totalMoves);
    }

    private static IEnumerable<string> SwitchLeft(char[][] board, Point origin, int colDistance)
    {
        string row = new string(board[origin.X]);
        int totalMoves = Math.Abs(colDistance);
        string switchedRow = row.Substring(totalMoves) + row[..totalMoves];
        board[origin.X] = switchedRow.ToCharArray();
        return Enumerable.Repeat($"L{origin.X}", totalMoves);
    }

    private static bool ShouldMoveRight(int colDistance) => colDistance > 0;

    private static bool ShouldMoveLeft(int colDistance) => colDistance < 0;

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