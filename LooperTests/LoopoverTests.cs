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
        char[][] solvedBoard = [
            ['a','b'],
            ['c','d']];
        char[][] mixedUpBoard = [
            ['a','b'],
            ['d','c']];

        List<string> expectedMoves = ["R1"];

        List<string> moves = Loopover.Solve(mixedUpBoard, solvedBoard);
        Assert.Equal(expectedMoves, moves);
    }
}