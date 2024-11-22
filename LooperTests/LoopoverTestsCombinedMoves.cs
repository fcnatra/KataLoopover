namespace LooperTests;

public class LoopoverTestsCombinedMoves
{
    [Fact]
    public void WhenBoardsContainsDiffChars_ReturnsNull()
    {
        char[][] solvedBoard = [
            ['a','b'],
            ['c','d']];
        char[][] mixedUpBoard = [
            ['c','b'],
            ['d','a']];

        List<string> expectedMoves = ["L1", "U0"];

        List<string>? moves = Loopover.Solve(mixedUpBoard, solvedBoard);
        
        Assert.Equal(expectedMoves, moves);
        Assert.Equal(solvedBoard, Loopover.LastBoardSolved);
    }
}