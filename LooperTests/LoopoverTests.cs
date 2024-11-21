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
    public void WhenOneCharIsOffToTheLeftOnRow1_ReturnsR1()
    {
        char[][] solvedBoard = [
            ['a','b'],
            ['c','d']];
        char[][] mixedUpBoard = [
            ['a','b'],
            ['d','c']];

        List<string> expectedMoves = ["R1"];

        List<string>? moves = Loopover.Solve(mixedUpBoard, solvedBoard);
        
        Assert.Equal(expectedMoves, moves);
        Assert.Equal(solvedBoard, Loopover.LastBoardSolved);
    }

    [Fact]
    public void WhenOneCharIsOffToTheLeftBy2ColsOnRow1_ReturnsR1R1()
    {
        char[][] solvedBoard = [
            ['a','b','c'],
            ['d','e','f']];
        char[][] mixedUpBoard = [
            ['a','b','c'],
            ['f','d','e']];

        List<string> expectedMoves = ["R1", "R1"];

        List<string>? moves = Loopover.Solve(mixedUpBoard, solvedBoard);
        
        Assert.Equal(expectedMoves, moves);
        Assert.Equal(solvedBoard, Loopover.LastBoardSolved);
    }

    [Fact]
    public void WhenOneCharIsOffToTheLeftOnEachRow_ReturnsMovesToTheRight()
    {
        char[][] solvedBoard = [
            ['a','b'],
            ['c','d']];
        char[][] mixedUpBoard = [
            ['b','a'],
            ['d','c']];

        List<string> expectedMoves = ["R0", "R1"];

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