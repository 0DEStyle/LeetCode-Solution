/*Challenge link:https://leetcode.com/problems/find-winner-on-a-tic-tac-toe-game/description/
Question:
Tic-tac-toe is played by two players A and B on a 3 x 3 grid. The rules of Tic-Tac-Toe are:

Players take turns placing characters into empty squares ' '.
The first player A always places 'X' characters, while the second player B always places 'O' characters.
'X' and 'O' characters are always placed into empty squares, never on filled ones.
The game ends when there are three of the same (non-empty) character filling any row, column, or diagonal.
The game also ends if all squares are non-empty.
No more moves can be played if the game is over.
Given a 2D integer array moves where moves[i] = [rowi, coli] indicates that the ith move will be played on grid[rowi][coli]. return the winner of the game if it exists (A or B). In case the game ends in a draw return "Draw". If there are still movements to play return "Pending".

You can assume that moves is valid (i.e., it follows the rules of Tic-Tac-Toe), the grid is initially empty, and A will play first.

 

Example 1:
//see image in link

Input: moves = [[0,0],[2,0],[1,1],[2,1],[2,2]]
Output: "A"
Explanation: A wins, they always play first.
Example 2:
//see image in link

Input: moves = [[0,0],[1,1],[0,1],[0,2],[1,0],[2,0]]
Output: "B"
Explanation: B wins.
Example 3:
//see image in link

Input: moves = [[0,0],[1,1],[2,0],[1,0],[1,2],[2,1],[0,1],[0,2],[2,2]]
Output: "Draw"
Explanation: The game ends in a draw since there are no moves to make.
 

Constraints:

1 <= moves.length <= 9
moves[i].length == 2
0 <= rowi, coli <= 2
There are no repeated elements on moves.
moves follow the rules of tic tac toe.

*/

//***************Solution********************
public class Solution {
    public string Tictactoe(int[][] moves) {
        // 0 3 6
        // 1 4 7
        // 2 5 8
        //less than 5 moves return pending
        if (moves.Length < 5) 
            return "Pending";

        int[] x = new int[9],
              o = new int[9];
        bool xMove = true;

        //win condition
        int[][] winCombinations = new int[][]{
            new[] {0,1,2}, new[] {3,4,5}, new[] {6,7,8}, // verticals
            new[] {0,4,8}, new[] {2,4,6},                // diagonals
            new[] {0,3,6}, new[] {1,4,7}, new[] {2,5,8}  // horizontals
        };
        //row col, Player A/X will play first.
        //loop through moves
        //set index to 1 based on move, iterate between player x and o
        foreach (var move in moves){
            var index = move[0] + move[1] * 3;
            if (xMove) 
                x[index] = 1;
            else 
                o[index] = 1;
            xMove = !xMove;
        }

        //check who wins
        foreach (var combination in winCombinations){
            if (combination.All(i => x[i] == 1)) 
                return "A";
            if (combination.All(i => o[i] == 1)) 
                return "B";
        }

        //reached 9 moves, return draw, else pending
        return moves.Length == 9 ? "Draw" : "Pending";
    }
}
