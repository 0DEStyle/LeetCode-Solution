/*Challenge link:https://leetcode.com/problems/toeplitz-matrix/description/
Question:
Given an m x n matrix, return true if the matrix is Toeplitz. Otherwise, return false.

A matrix is Toeplitz if every diagonal from top-left to bottom-right has the same elements.

 

Example 1:
// see image in link

Input: matrix = [[1,2,3,4],[5,1,2,3],[9,5,1,2]]
Output: true
Explanation:
In the above grid, the diagonals are:
"[9]", "[5, 5]", "[1, 1, 1]", "[2, 2, 2]", "[3, 3]", "[4]".
In each diagonal all elements are the same, so the answer is True.
Example 2:
// see image in link

Input: matrix = [[1,2],[2,2]]
Output: false
Explanation:
The diagonal "[1, 2]" has different elements.
 

Constraints:

m == matrix.length
n == matrix[i].length
1 <= m, n <= 20
0 <= matrix[i][j] <= 99
 

Follow up:

What if the matrix is stored on disk, and the memory is limited such that you can only load at most one row of the matrix into the memory at once?
What if the matrix is so large that you can only load up a partial row into the memory at once?
*/

//***************Solution********************
public class Solution {
    public bool IsToeplitzMatrix(int[][] matrix) {
        //loop through matrix length
        //check seqence equal
        //i, end 1 to start
        //from i + 1, start 1 up to end.
        for (int i = 0; i < matrix.Length - 1; i++)
            if (!matrix[i][..^1].SequenceEqual(matrix[i + 1][1..])) 
                return false;
	return true;
    }
}
