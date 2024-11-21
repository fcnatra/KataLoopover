namespace LooperTests;

public class LoopoverTests
{
    [Fact]
    public void WhenBoardsContainsDiffChars_ReturnsNull()
    {
        char[][] mixedUpBoard = [['a','b'],['d','c']];
        char[][] solvedBoard = [['a','b'],['c','x']];

        List<string> moves = Loopover.Solve(mixedUpBoard, solvedBoard);
        Assert.Null(moves);
    }

    [Fact]
    public void WhenAllCharAreInBoth_ReturnsAListWithMoves()
    {
        char[][] mixedUpBoard = [['a','b'],['d','c']];
        char[][] solvedBoard = [['a','b'],['c','d']];
        List<string> expectedMoves = ["L1"];

        List<string> moves = Loopover.Solve(mixedUpBoard, solvedBoard);
        Assert.True(moves.SequenceEqual(expectedMoves));
    }
}