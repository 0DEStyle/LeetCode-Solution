/*Challenge link:https://leetcode.com/problems/maximum-side-length-of-a-square-with-sum-less-than-or-equal-to-threshold/description/
Question:
Given a m x n matrix mat and an integer threshold, return the maximum side-length of a square with a sum less than or equal to threshold or return 0 if there is no such square.

 

Example 1:


Input: mat = [[1,1,3,2,4,3,2],[1,1,3,2,4,3,2],[1,1,3,2,4,3,2]], threshold = 4
Output: 2
Explanation: The maximum side length of square with sum less than 4 is 2 as shown.
Example 2:

Input: mat = [[2,2,2,2,2],[2,2,2,2,2],[2,2,2,2,2],[2,2,2,2,2],[2,2,2,2,2]], threshold = 1
Output: 0
 

Constraints:

m == mat.length
n == mat[i].length
1 <= m, n <= 300
0 <= mat[i][j] <= 104
0 <= threshold <= 105
*/

//***************Solution********************
//prefix sum  one pass O(mn)
public class Solution {
    public int MaxSideLength(int[][] mat, int threshold) {
        //with (i, j) as the bottom right, only looking for square with length of current max + 1 (next eligible max length)
        //n to mat column length, m to row length
        int n = mat.Length, m = mat[0].Length, max = 0;
        //new sum array
        int[,] sums = new int[n + 1, m + 1];
        
        //loop through each elements.
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                //accumulate sum
                sums[i + 1, j + 1] = sums[i + 1, j] + sums[i, j + 1] - sums[i, j] + mat[i][j];

                //i/j - max are greater or equal to 0, and check if sum is less than or equal to threshold
                //if true, max plus 1.
                if (i - max >= 0 && j - max >= 0 && 
                    sums[i + 1, j + 1] - sums[i - max, j + 1] - sums[i + 1, j - max] + sums[i - max, j - max] <= threshold) 
                    max += 1;
            }
        }
        return max;    
    }
}
