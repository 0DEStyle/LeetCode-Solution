/*Challenge link:https://leetcode.com/problems/search-a-2d-matrix/description/
Question:You are given an m x n integer matrix matrix with the following two properties:

Each row is sorted in non-decreasing order.
The first integer of each row is greater than the last integer of the previous row.
Given an integer target, return true if target is in matrix or false otherwise.

You must write a solution in O(log(m * n)) time complexity.

 

Example 1:
//see image in link


Input: matrix = [[1,3,5,7],[10,11,16,20],[23,30,34,60]], target = 3
Output: true
Example 2:
//see image in link


Input: matrix = [[1,3,5,7],[10,11,16,20],[23,30,34,60]], target = 13
Output: false
 

Constraints:

m == matrix.length
n == matrix[i].length
1 <= m, n <= 100
-104 <= matrix[i][j], target <= 104
*/

//***************Solution********************
//binary search
public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
            //check null or zero, and if true return false
            if (matrix == null || matrix.Length == 0) 
                return false;
            
            //set boundaries
            int low = 0, rows = matrix.Length, cols = matrix[0].Length;
            int high = rows * cols - 1;

            while (low <= high) {
                //find mid index
                int mid = low + (high - low) / 2;

                //if the element at mid index divede by cols, and mid index mod cols is equal to target
                //return true
                //if the result is less than target, then shift low to right by 1 index
                //else shift high to left by 1 index
                if (matrix[mid / cols][mid % cols] == target)
                    return true;
                if (matrix[mid / cols][mid % cols] < target) 
                    low = mid + 1;
                else
                    high = mid - 1;
            }
            //no matches
            return false;
    }
}
