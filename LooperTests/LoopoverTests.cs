namespace LooperTests;

public class LoopoverTests
{
    [Fact]
    public void WhenBoardsContainsDiffChars_ReturnsNull()
    {
        char[][] mixedUpBoard = [['a','b'],['d','c']];
        char[][] solvedBoard = [['a','b'],['c','x']];

        Loopover.Result? result = Loopover.Solve(mixedUpBoard, solvedBoard);
        
        Assert.Null(result);
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

        Loopover.Result? result = Loopover.Solve(mixedUpBoard, solvedBoard);

        Assert.True(result?.Moves.Count > 0);
    }

    [Fact]
    public void WhenOneCharIsOffToTheRight_Moves1Left()
    {
        char[][] solvedBoard = [
            ['a','b'],
            ['c','d']];
        char[][] mixedUpBoard = [
            ['a','b'],
            ['d','c']];

        List<string> expectedMoves = ["L1"];

        Loopover.Result? result = Loopover.Solve(mixedUpBoard, solvedBoard);
        
        Assert.Equal(expectedMoves, result?.Moves);
        Assert.Equal(solvedBoard, result?.Board);
    }
 
    [Fact]
    public void WhenOneCharIsOffToTheRightBy2Cols_Moves2Right()
    {
        char[][] solvedBoard = [
            ['a','b','c','d','e'],
            ['f','g','h','i','j']];
        char[][] mixedUpBoard = [
            ['a','b','c','d','e'],
            ['i','j','f','g','h']];

        List<string> expectedMoves = ["L1", "L1"];

        Loopover.Result? result = Loopover.Solve(mixedUpBoard, solvedBoard);
        
        Assert.Equal(expectedMoves, result?.Moves);
        Assert.Equal(solvedBoard, result?.Board);
    }
 
    [Fact]
    public void WhenOneCharIsOffToTheRightBy3Cols_Moves3Right()
    {
        char[][] solvedBoard = [
            ['a','b','c','d','e','f'],
            ['g','h','i','j','k','l']];
        char[][] mixedUpBoard = [
            ['a','b','c','d','e','f'],
            ['j','k','l','g','h','i']];

        List<string> expectedMoves = ["L1", "L1", "L1"];

        Loopover.Result? result = Loopover.Solve(mixedUpBoard, solvedBoard);
        
        Assert.Equal(expectedMoves, result?.Moves);
        Assert.Equal(solvedBoard, result?.Board);
    }
 
    [Fact]
    public void WhenMovingOnceRightIsCloserThan3Left_MovesOnceRight()
    {
        char[][] solvedBoard = [
            ['a','b','c','d'],
            ['e','f','g','h']];
        char[][] mixedUpBoard = [
            ['a','b','c','d'],
            ['f','g','h','e']];

        List<string> expectedMoves = ["R1"];

        Loopover.Result? result = Loopover.Solve(mixedUpBoard, solvedBoard);
        
        Assert.Equal(expectedMoves, result?.Moves);
        Assert.Equal(solvedBoard, result?.Board);
    }

    [Fact]
    public void WhenOneCharIsOffToTheRightOnEachRow_MovesToTheLeftOnEachRow()
    {
        char[][] solvedBoard = [
            ['a','b'],
            ['c','d']];
        char[][] mixedUpBoard = [
            ['b','a'],
            ['d','c']];

        List<string> expectedMoves = ["L0", "L1"];

        Loopover.Result? result = Loopover.Solve(mixedUpBoard, solvedBoard);

        Assert.Equal(expectedMoves, result?.Moves);
        Assert.Equal(solvedBoard, result?.Board);
    }

    [Fact]
    public void WhenOneCharIsOffToTheBottomOnCol0_MovesCol0OneUp()
    {
        char[][] solvedBoard = [
            ['a','b'],
            ['c','d']];
        char[][] mixedUpBoard = [
            ['c','b'],
            ['a','d']];

        List<string> expectedMoves = ["U0"];

        Loopover.Result? result = Loopover.Solve(mixedUpBoard, solvedBoard);

        Assert.Equal(expectedMoves, result?.Moves);
        Assert.Equal(solvedBoard, result?.Board);
    }

    [Fact]
    public void WhenOneCharIsOffToTheBottomOnCol1_MovesCol1OneUp()
    {
        char[][] solvedBoard = [
            ['a','b'],
            ['c','d']];
        char[][] mixedUpBoard = [
            ['a','d'],
            ['c','b']];

        List<string> expectedMoves = ["U1"];

        Loopover.Result? result = Loopover.Solve(mixedUpBoard, solvedBoard);

        Assert.Equal(expectedMoves, result?.Moves);
        Assert.Equal(solvedBoard, result?.Board);
    }

    [Fact]
    public void WhenOneCharIsOffBy2ToTheBottomOnCol1_MovesRow1TwiceUp()
    {
        char[][] solvedBoard = [
            ['a','b'],
            ['c','d'],
            ['e','f'],
            ['g','h']];
        char[][] mixedUpBoard = [
            ['a','f'],
            ['c','h'],
            ['e','b'],
            ['g','d']];

        List<string> expectedMoves = ["U1", "U1"];

        Loopover.Result? result = Loopover.Solve(mixedUpBoard, solvedBoard);

        Assert.Equal(expectedMoves, result?.Moves);
        Assert.Equal(solvedBoard, result?.Board);
    }

    [Fact]
    public void WhenOneCharIsOffBy3ToTheBottomOnCol1_Moves1stRow3TimesUp()
    {
        char[][] solvedBoard = [
            ['a','b'],
            ['c','d'],
            ['e','f'],
            ['g','h'],
            ['i','j'],
            ['k','l']];
        char[][] mixedUpBoard = [
            ['a','h'],
            ['c','j'],
            ['e','l'],
            ['g','b'],
            ['i','d'],
            ['k','f']];

        List<string> expectedMoves = ["U1", "U1", "U1"];

        Loopover.Result? result = Loopover.Solve(mixedUpBoard, solvedBoard);

        Assert.Equal(expectedMoves, result?.Moves);
        Assert.Equal(solvedBoard, result?.Board);
    }

    [Fact]
    public void WhenMoveingOnceDownIsCloserThan3Up_MovesOnceDown()
    {
        char[][] solvedBoard = [
            ['a','b'],
            ['c','d'],
            ['e','f'],
            ['g','h']];
        char[][] mixedUpBoard = [
            ['a','d'],
            ['c','f'],
            ['e','h'],
            ['g','b']];

        List<string> expectedMoves = ["D1"];

        Loopover.Result? result = Loopover.Solve(mixedUpBoard, solvedBoard);

        Assert.Equal(expectedMoves, result?.Moves);
        Assert.Equal(solvedBoard, result?.Board);
    }
}