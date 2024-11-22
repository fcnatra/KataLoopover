namespace LooperTests;

public class LoopoverTests
{
    [Fact]
    public void WhenBoardsContainsDiffChars_ReturnsNull()
    {
        char[][] mixedUpBoard = [['a','b'],['d','c']];
        char[][] solvedBoard = [['a','b'],['c','x']];

        List<string>? moves = Loopover.Solve(mixedUpBoard, solvedBoard);
        
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

        List<string>? moves = Loopover.Solve(mixedUpBoard, solvedBoard);

        Assert.True(moves?.Count > 0);
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

        List<string>? moves = Loopover.Solve(mixedUpBoard, solvedBoard);
        
        Assert.Equal(expectedMoves, moves);
        Assert.Equal(solvedBoard, Loopover.LastBoardSolved);
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

        List<string>? moves = Loopover.Solve(mixedUpBoard, solvedBoard);
        
        Assert.Equal(expectedMoves, moves);
        Assert.Equal(solvedBoard, Loopover.LastBoardSolved);
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

        List<string>? moves = Loopover.Solve(mixedUpBoard, solvedBoard);
        
        Assert.Equal(expectedMoves, moves);
        Assert.Equal(solvedBoard, Loopover.LastBoardSolved);
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

        List<string>? moves = Loopover.Solve(mixedUpBoard, solvedBoard);
        
        Assert.Equal(expectedMoves, moves);
        Assert.Equal(solvedBoard, Loopover.LastBoardSolved);
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

        List<string>? moves = Loopover.Solve(mixedUpBoard, solvedBoard);

        Assert.Equal(expectedMoves, moves);
        Assert.Equal(solvedBoard, Loopover.LastBoardSolved);
    }

    [Fact]
    public void WhenOneCharIsOffToTheBottomOnCol0_ReturnsD0()
    {
        char[][] solvedBoard = [
            ['a','b'],
            ['c','d']];
        char[][] mixedUpBoard = [
            ['c','b'],
            ['a','d']];

        List<string> expectedMoves = ["D0"];

        List<string>? moves = Loopover.Solve(mixedUpBoard, solvedBoard);

        Assert.Equal(expectedMoves, moves);
        Assert.Equal(solvedBoard, Loopover.LastBoardSolved);
    }

    [Fact]
    public void WhenOneCharIsOffToTheBottomOnCol1_ReturnsD1()
    {
        char[][] solvedBoard = [
            ['a','b'],
            ['c','d']];
        char[][] mixedUpBoard = [
            ['a','d'],
            ['c','b']];

        List<string> expectedMoves = ["D1"];

        List<string>? moves = Loopover.Solve(mixedUpBoard, solvedBoard);

        Assert.Equal(expectedMoves, moves);
        Assert.Equal(solvedBoard, Loopover.LastBoardSolved);
    }
}