using System;
using System.Collections.Generic;

public class Loopover 
{
  public static List<string> Solve(char[][] mixedUpBoard, char[][] solvedBoard) 
  {
    bool canBeSolved = CheckAllCharsAreInBothBoards(mixedUpBoard, solvedBoard);
    if (!canBeSolved) return null;

    var board = mixedUpBoard.Clone();
    List<string> moves = GetMovesToSolve(board, solvedBoard);

    return moves;
  }

    private static List<string> GetMovesToSolve(object board, char[][] solvedBoard)
    {
        return ["L1"];
    }

    private static bool CheckAllCharsAreInBothBoards(char[][] mixedUpBoard, char[][] solvedBoard)
    {
        var mixedChars = mixedUpBoard.Select(c => c).SelectMany(x => x).Order();
        var solvedChars = solvedBoard.Select(c => c).SelectMany(x => x).Order();

        return mixedChars.SequenceEqual(solvedChars);
    }
}