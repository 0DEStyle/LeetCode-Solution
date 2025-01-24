/*Challenge link:https://leetcode.com/problems/determine-color-of-a-chessboard-square/description/
Question:
You are given coordinates, a string that represents the coordinates of a square of the chessboard. Below is a chessboard for your reference.



Return true if the square is white, and false if the square is black.

The coordinate will always represent a valid chessboard square. The coordinate will always have the letter first, and the number second.

 

Example 1:

Input: coordinates = "a1"
Output: false
Explanation: From the chessboard above, the square with coordinates "a1" is black, so return false.
Example 2:

Input: coordinates = "h3"
Output: true
Explanation: From the chessboard above, the square with coordinates "h3" is white, so return true.
Example 3:

Input: coordinates = "c7"
Output: false
 

Constraints:

coordinates.length == 2
'a' <= coordinates[0] <= 'h'
'1' <= coordinates[1] <= '8'
*/

//***************Solution********************
//offset ascii value, mod 2 and check if it is odd.
public class Solution {
    public bool SquareIsWhite(string c) => (char.ToUpper(c[0]) - 64 + c[1] - '0') % 2 != 0;
}
