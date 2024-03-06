/*Challenge link:https://leetcode.com/problems/kth-smallest-element-in-a-sorted-matrix/description/
Question:
Given an n x n matrix where each of the rows and columns is sorted in ascending order, return the kth smallest element in the matrix.

Note that it is the kth smallest element in the sorted order, not the kth distinct element.

You must find a solution with a memory complexity better than O(n2).

 

Example 1:

Input: matrix = [[1,5,9],[10,11,13],[12,13,15]], k = 8
Output: 13
Explanation: The elements in the matrix are [1,5,9,10,11,12,13,13,15], and the 8th smallest number is 13
Example 2:

Input: matrix = [[-5]], k = 1
Output: -5
 

Constraints:

n == matrix.length == matrix[i].length
1 <= n <= 300
-109 <= matrix[i][j] <= 109
All the rows and columns of matrix are guaranteed to be sorted in non-decreasing order.
1 <= k <= n2
 

Follow up:

Could you solve the problem with a constant memory (i.e., O(1) memory complexity)?
Could you solve the problem in O(n) time complexity? The solution may be too advanced for an interview but you may find reading this paper fun.

*/

//***************Solution********************
/*
Binary search method
    grid
    <c
r
V

matrix is sorted in ascending order by rows and columns already
*/
public class Solution {
    //global variable for gird size
    int m, n;

    public int countLessOrEqual(int[][] matrix, int target) {
        //start with the right most column
        //c column, r row
        int cnt = 0, c = n - 1; 

        //decrease column until matrix[r][c] <= target
        for (int r = 0; r < m; ++r) {
            //scan all cells in current row
            while (c >= 0 && matrix[r][c] > target) --c;  
            cnt += (c + 1);
        }
        return cnt;
    }

    public int KthSmallest(int[][] matrix, int k) {
        //the matrix need not be a square
        //left and right pointers for 2d matrix
        m = matrix.Length; n = matrix[0].Length;
        int left = matrix[0][0], right = matrix[m-1][n-1], ans = -1;

        while (left <= right) {
            //find mid value, note mid is not necessarily a value in the matrix, but a point for reference
            int mid = left + (right - left) /2;
            
            //check condition
            //if valid, add mid to ans, shift right to left by 1, else shift left to right by 1
            if (countLessOrEqual(matrix, mid) >= k) {
                ans = mid;
                right = mid - 1; 
            } 
            else 
             left = mid + 1; 
        }
        return ans;
    }
}
