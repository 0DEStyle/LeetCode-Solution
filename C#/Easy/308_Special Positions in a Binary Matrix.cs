/*Challenge link:https://leetcode.com/problems/special-positions-in-a-binary-matrix/description/
Question:
Given an m x n binary matrix mat, return the number of special positions in mat.

A position (i, j) is called special if mat[i][j] == 1 and all other elements in row i and column j are 0 (rows and columns are 0-indexed).

 

Example 1:
//see image in link

Input: mat = [[1,0,0],[0,0,1],[1,0,0]]
Output: 1
Explanation: (1, 2) is a special position because mat[1][2] == 1 and all other elements in row 1 and column 2 are 0.
Example 2:
//see image in link

Input: mat = [[1,0,0],[0,1,0],[0,0,1]]
Output: 3
Explanation: (0, 0), (1, 1) and (2, 2) are special positions.
 

Constraints:

m == mat.length
n == mat[i].length
1 <= m, n <= 100
mat[i][j] is either 0 or 1.
*/

//***************Solution********************
//special: the only "1" in its row and column
//then count the number of special

public class Solution {
    public int NumSpecial(int[][] m) {
        int count = 0;

        //loop through each cell
        for(int i = 0; i < m.Length; i++){
            for(int j = 0; j < m[i].Length; j++){
                if(m[i][j] == 1){
                    int sumx = 0, sumy = 0;

                    //get sum of x
                    for(int x = 0; x < m[i].Length; x++)
                        sumx += m[i][x];

                    //get sum of y
                    for(int y = 0; y < m.Length; y++)
                        sumy += m[y][j];
                    
                    if(sumx == 1 && sumy == 1)
                        count++;
                }
            }
        }
        return count;
    }
}

