/*Challenge link:https://leetcode.com/problems/lucky-numbers-in-a-matrix/description/
Question:
Given an m x n matrix of distinct numbers, return all lucky numbers in the matrix in any order.

A lucky number is an element of the matrix such that it is the minimum element in its row and maximum in its column.

 

Example 1:

Input: matrix = [[3,7,8],[9,11,13],[15,16,17]]
Output: [15]
Explanation: 15 is the only lucky number since it is the minimum in its row and the maximum in its column.
Example 2:

Input: matrix = [[1,10,4,2],[9,3,8,7],[15,16,17,12]]
Output: [12]
Explanation: 12 is the only lucky number since it is the minimum in its row and the maximum in its column.
Example 3:

Input: matrix = [[7,8],[1,2]]
Output: [7]
Explanation: 7 is the only lucky number since it is the minimum in its row and the maximum in its column.
 

Constraints:

m == mat.length
n == mat[i].length
1 <= n, m <= 50
1 <= matrix[i][j] <= 105.
All elements in the matrix are distinct.
*/

//***************Solution********************
/*
 [
 [3 ,7 ,8],
 [9 ,11,13],
 [15,16,17]] => 15

 find min in row, then get max value in col

*/
public class Solution {
    public IList<int> LuckyNumbers(int[][] matrix) {
        int m = matrix.Length,  n = matrix[0].Length;
        int[] rmin = new int[m], cmax = new int[n];
        var res = new List<int>();
        Array.Fill(rmin, int.MaxValue);
        
        //loop through row and col
        //select min between current row element and element at i,j
        //select max between current col element and element at i,j
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                rmin[i] = Math.Min(rmin[i], matrix[i][j]);
                cmax[j] = Math.Max(cmax[j], matrix[i][j]);
            }
        }
        
        //if row min equal to col max, add to result.
        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
                if(rmin[i] == cmax[j])
                    res.Add(rmin[i]);
        
        return res;
    }
}
