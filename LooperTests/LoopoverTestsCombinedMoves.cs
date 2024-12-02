namespace LooperTests;

public class LoopoverTestsCombinedMoves
{
    [Fact]
    public void WhenCharIsDownRightAway_MovesLeftUp()
    {
        char[][] solvedBoard = [
            ['a','b'],
            ['c','d']];
        char[][] mixedUpBoard = [
            ['c','b'],
            ['d','a']];

        List<string> expectedMoves = ["L1", "U0"];

        Loopover.Result? result = Loopover.Solve(mixedUpBoard, solvedBoard);
        
        Assert.Equal(expectedMoves, result?.Moves);
        Assert.Equal(solvedBoard, result?.Board);
    }

    [Fact]
    public void WhenCharIsDownRightAway_MovesRightUp()
    {
        char[][] solvedBoard = [
            ['a','b'],
            ['c','d']];
        char[][] mixedUpBoard = [
            ['a','d'],
            ['b','c']];

        List<string> expectedMoves = ["R1", "U1"];

        Loopover.Result? result = Loopover.Solve(mixedUpBoard, solvedBoard);
        
        Assert.Equal(expectedMoves, result?.Moves);
        Assert.Equal(solvedBoard, result?.Board);
    }

    [Fact]
    public void WhenFixingPostitionAffectsAOtherChar_MovesToFixAreIncluded()
    {
        char[][] solvedBoard = [
            ['a','b'],
            ['c','d']];
        char[][] mixedUpBoard = [
            ['d','b'],
            ['c','a']];

        List<string> expectedMoves = ["L1", "U0", "L1"];

        Loopover.Result? result = Loopover.Solve(mixedUpBoard, solvedBoard);
        
        Assert.Equal(expectedMoves, result?.Moves);
        Assert.Equal(solvedBoard, result?.Board);
    }

    [Fact]
    public void WhenFixingPostitionAffectsMoreThanOneChar_MovesToFixAreIncluded()
    {
        char[][] solvedBoard = [
            ['a','b','c'],
            ['d','e','f'],
            ['g','h','i']];
        char[][] mixedUpBoard = [
            ['h','b','c'],
            ['d','e','f'],
            ['g','a','i']];

        List<string> expectedMoves = ["L1", "D0", "U0"];

        Loopover.Result? result = Loopover.Solve(mixedUpBoard, solvedBoard);
        
        Assert.Equal(expectedMoves, result?.Moves);
        Assert.Equal(solvedBoard, result?.Board);
    }
}