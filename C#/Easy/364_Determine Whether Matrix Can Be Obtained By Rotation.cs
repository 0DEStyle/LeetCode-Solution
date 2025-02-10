/*Challenge link:https://leetcode.com/problems/determine-whether-matrix-can-be-obtained-by-rotation/description/
Question:
Given two n x n binary matrices mat and target, return true if it is possible to make mat equal to target by rotating mat in 90-degree increments, or false otherwise.

 

Example 1:
//see image in link

Input: mat = [[0,1],[1,0]], target = [[1,0],[0,1]]
Output: true
Explanation: We can rotate mat 90 degrees clockwise to make mat equal target.
Example 2:
//see image in link

Input: mat = [[0,1],[1,1]], target = [[1,0],[0,1]]
Output: false
Explanation: It is impossible to make mat equal to target by rotating mat.
Example 3:
//see image in link

Input: mat = [[0,0,0],[0,1,0],[1,1,1]], target = [[1,1,1],[0,1,0],[0,0,0]]
Output: true
Explanation: We can rotate mat 90 degrees clockwise two times to make mat equal target.
 

Constraints:

n == mat.length == target.length
n == mat[i].length == target[i].length
1 <= n <= 10
mat[i][j] and target[i][j] are either 0 or 1.
*/

//***************Solution********************
public class Solution {
    public bool FindRotation(int[][] mat, int[][] target) {
        //4 rotation
        var c = new bool[4];
        Array.Fill(c, true);
        int n = mat[0].Count();

        //loop through each cell and check if current cell is not equal to target, set c to false respeactively
        for (int i = 0; i < n; i++){
            for (int j = 0; j < n; j++){
                if (mat[i][j] != target[i][j]) c[0] = false;
                if (mat[i][j] != target[n - j - 1][i]) c[1] = false;
                if (mat[i][j] != target[n - i - 1][n - j - 1]) c[2] = false;
                if (mat[i][j] != target[j][n - i - 1]) c[3] = false;
            }
        }
        //if any one of these is true.
        return c[0] || c[1] || c[2] || c[3];
    }
}
