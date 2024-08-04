/*Challenge link:https://leetcode.com/problems/reshape-the-matrix/description/
Question:
In MATLAB, there is a handy function called reshape which can reshape an m x n matrix into a new one with a different size r x c keeping its original data.

You are given an m x n matrix mat and two integers r and c representing the number of rows and the number of columns of the wanted reshaped matrix.

The reshaped matrix should be filled with all the elements of the original matrix in the same row-traversing order as they were.

If the reshape operation with given parameters is possible and legal, output the new reshaped matrix; Otherwise, output the original matrix.

 

Example 1:
//see image in link


Input: mat = [[1,2],[3,4]], r = 1, c = 4
Output: [[1,2,3,4]]
Example 2:
//see image in link

Input: mat = [[1,2],[3,4]], r = 2, c = 4
Output: [[1,2],[3,4]]
 

Constraints:

m == mat.length
n == mat[i].length
1 <= m, n <= 100
-1000 <= mat[i][j] <= 1000
1 <= r, c <= 300
*/

//***************Solution********************
public class Solution {
    public int[][] MatrixReshape(int[][] mat, int r, int c) {
        int n = mat.Length;
		int m = mat[0].Length;
		
        //validation check
		if (m * n != r * c)
			return mat;
		
        //create structure
		int[][] arr = new int[r][];
        //assign colume of array into arr
		for (int i = 0; i < r; i++) 
			arr[i] = new int[c];
		
        //asign value into arr
		for (int i = 0; i < n; i++) {
			for (int j = 0; j < m; j++) {
				int l = i * m + j;
				arr[l / c][l % c] = mat[i][j];
			}
		}
		return arr;
    }
}
