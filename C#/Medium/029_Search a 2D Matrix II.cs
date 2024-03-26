/*Challenge link:https://leetcode.com/problems/search-a-2d-matrix-ii/description/
Question:
Write an efficient algorithm that searches for a value target in an m x n integer matrix matrix. This matrix has the following properties:

Integers in each row are sorted in ascending from left to right.
Integers in each column are sorted in ascending from top to bottom.
 

Example 1:
// see image in link

Input: matrix = [[1,4,7,11,15],[2,5,8,12,19],[3,6,9,16,22],[10,13,14,17,24],[18,21,23,26,30]], target = 5
Output: true
Example 2:
// see image in link

Input: matrix = [[1,4,7,11,15],[2,5,8,12,19],[3,6,9,16,22],[10,13,14,17,24],[18,21,23,26,30]], target = 20
Output: false
 

Constraints:

m == matrix.length
n == matrix[i].length
1 <= n, m <= 300
-109 <= matrix[i][j] <= 109
All the integers in each row are sorted in ascending order.
All the integers in each column are sorted in ascending order.
-109 <= target <= 109
*/

//***************Solution********************
//O(m+n) 
public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {

        //check valid
         if(matrix == null || matrix.Length < 1 || matrix[0].Length <1)
            return false;

        //upper and lower of grid boundaries
        int col = matrix[0].Length-1, row = 0;

        //loop through the grid
        while(col >= 0 && row <= matrix.Length-1) {
        //if we find the target in curretn cell, return true
            if(target == matrix[row][col]) 
                return true;

        //if the target is less than current cell, col - 1
        //else if target is greater, row +1
            else if(target < matrix[row][col]) 
                col--;
            else if(target > matrix[row][col])
                row++;
        }
        return false;
    }
    }
