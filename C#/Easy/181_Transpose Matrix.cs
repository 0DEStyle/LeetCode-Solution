/*Challenge link:https://leetcode.com/problems/transpose-matrix/description/
Question:
Given a 2D integer array matrix, return the transpose of matrix.

The transpose of a matrix is the matrix flipped over its main diagonal, switching the matrix's row and column indices.
//see image in link


 

Example 1:

Input: matrix = [[1,2,3],[4,5,6],[7,8,9]]
Output: [[1,4,7],[2,5,8],[3,6,9]]
Example 2:

Input: matrix = [[1,2,3],[4,5,6]]
Output: [[1,4],[2,5],[3,6]]
 

Constraints:

m == matrix.length
n == matrix[i].length
1 <= m, n <= 1000
1 <= m * n <= 105
-109 <= matrix[i][j] <= 109
*/

//***************Solution********************
public class Solution {
    public int[][] Transpose(int[][] m) {
        int r = m[0].Length, c = m.Length;
        var res = new int[r][];

        for (int i = 0; i < r; i++) {
            res[i] = new int[c];
            for (int j = 0; j < c; j++) 
                res[i][j] = m[j][i];
        }
        return res;
    }
}
