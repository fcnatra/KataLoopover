# Kata Loopover
https://www.codewars.com/kata/5c1d796370fee68b1e000611/train/csharp

## Sources to read
https://www.giantbomb.com/forums/sliding-block-puzzles-232130/a-fool-proof-guide-to-solving-every-solvable-slidi-1802039/

https://openprocessing.org/sketch/576328

## Steps

- Order first row
    - Go to any row below the destination row
    - Move to column
    - Move up
- Order first column
    - Go to any row below the destination row (save path)
    - Go to adyacent column
    - Revert saved path
    - Move destination column down until one row above the moving block (save path)
    - Move the block to the destination colummn
    - Revert saved path
- Order next row (if it's edge, treat it like a column movement)
- Order next column

