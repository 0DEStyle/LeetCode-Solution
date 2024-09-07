/*Challenge link:https://leetcode.com/problems/available-captures-for-rook/description/
Question:
You are given an 8 x 8 matrix representing a chessboard. There is exactly one white rook represented by 'R', some number of white bishops 'B', and some number of black pawns 'p'. Empty squares are represented by '.'.

A rook can move any number of squares horizontally or vertically (up, down, left, right) until it reaches another piece or the edge of the board. A rook is attacking a pawn if it can move to the pawn's square in one move.

Note: A rook cannot move through other pieces, such as bishops or pawns. This means a rook cannot attack a pawn if there is another piece blocking the path.

Return the number of pawns the white rook is attacking.

 

Example 1:


Input: board = [[".",".",".",".",".",".",".","."],[".",".",".","p",".",".",".","."],[".",".",".","R",".",".",".","p"],[".",".",".",".",".",".",".","."],[".",".",".",".",".",".",".","."],[".",".",".","p",".",".",".","."],[".",".",".",".",".",".",".","."],[".",".",".",".",".",".",".","."]]

Output: 3

Explanation:

In this example, the rook is attacking all the pawns.

Example 2:


Input: board = [[".",".",".",".",".",".","."],[".","p","p","p","p","p",".","."],[".","p","p","B","p","p",".","."],[".","p","B","R","B","p",".","."],[".","p","p","B","p","p",".","."],[".","p","p","p","p","p",".","."],[".",".",".",".",".",".",".","."],[".",".",".",".",".",".",".","."]]

Output: 0

Explanation:

The bishops are blocking the rook from attacking any of the pawns.

Example 3:


Input: board = [[".",".",".",".",".",".",".","."],[".",".",".","p",".",".",".","."],[".",".",".","p",".",".",".","."],["p","p",".","R",".","p","B","."],[".",".",".",".",".",".",".","."],[".",".",".","B",".",".",".","."],[".",".",".","p",".",".",".","."],[".",".",".",".",".",".",".","."]]

Output: 3

Explanation:

The rook is attacking the pawns at positions b5, d6, and f5.

 

Constraints:

board.length == 8
board[i].length == 8
board[i][j] is either 'R', '.', 'B', or 'p'
There is exactly one cell with board[i][j] == 'R'
*/

//***************Solution********************/*
8x8
upper case R white
lower case black
R rook 1
B bishops
P pawns
. empty

Input: board = [
[".",".",".",".",".",".",".","."],
[".",".",".","p",".",".",".","."],
[".",".",".","R",".",".",".","p"],
[".",".",".",".",".",".",".","."],
[".",".",".",".",".",".",".","."],
[".",".",".","p",".",".",".","."],
[".",".",".",".",".",".",".","."],
[".",".",".",".",".",".",".","."]]

*/
public class Solution {
    public int NumRookCaptures(char[][] board) {
        int CheckCell(int x, int y){
            if (x < 0 || y < 0 || x >= board[0].Length || y >= board.Length  || board[y][x] == 'B') return -1; 
            if (board[y][x] == 'p') return 1; 
            return 0; 
        }

        int rx = -1, ry = -1;

        for (int y = 0; y < board.Length; y++){
            for (int x = 0; x < board[0].Length; x++){
                if (board[y][x] == 'R') {
                    rx = x; ry = y; 
                    break; 
                }
            }
        }

        int[] dir = new int[]{ 0,0,0,0 };
        for (int i = 0; i < board.Length; i++){
            if (dir[0] == 0) 
                dir[0] = CheckCell(rx + 1 + i, ry);
            if (dir[1] == 0) 
                dir[1] = CheckCell(rx - 1 - i, ry);
            if (dir[2] == 0) 
                dir[2] = CheckCell(rx, ry + 1 + i);
            if (dir[3] == 0) 
                dir[3] = CheckCell(rx, ry - 1 - i);
        }

        int result = 0;
        for (int i = 0; i < dir.Length; i++)
            if (dir[i] == 1) result += 1; 
        return result;
    }
    }
