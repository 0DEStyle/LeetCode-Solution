/*Challenge link:https://leetcode.com/problems/find-a-peak-element-ii/description/
Question:
A peak element in a 2D grid is an element that is strictly greater than all of its adjacent neighbors to the left, right, top, and bottom.

Given a 0-indexed m x n matrix mat where no two adjacent cells are equal, find any peak element mat[i][j] and return the length 2 array [i,j].

You may assume that the entire matrix is surrounded by an outer perimeter with the value -1 in each cell.

You must write an algorithm that runs in O(m log(n)) or O(n log(m)) time.

 

Example 1:
//see image in link


Input: mat = [[1,4],[3,2]]
Output: [0,1]
Explanation: Both 3 and 4 are peak elements so [1,0] and [0,1] are both acceptable answers.
Example 2:
//see image in link


Input: mat = [[10,20,15],[21,30,14],[7,16,32]]
Output: [1,1]
Explanation: Both 30 and 32 are peak elements so [1,1] and [2,2] are both acceptable answers.
 

Constraints:

m == mat.length
n == mat[i].length
1 <= m, n <= 500
1 <= mat[i][j] <= 105
No two adjacent cells are equal.
*/

//***************Solution********************
public class Solution {
    public int[] FindPeakGrid(int[][] mat) {
        int n = mat.Length, m = mat[0].Length, lo = 0, hi = m - 1, mid; 


        while (lo <= hi) {
            //find mid index
            mid = lo + (hi - lo) / 2;
            int max_row = 0;

            //loop through matrix's col length
            //if the mid element of current row is less than current i's mid
            //set current max row to i
            for (int i = 0; i < n; ++i) {
                if (mat[max_row][mid] < mat[i][mid])
                    max_row = i;
            }

            //if mid is 0 OR current max row's mid element is less than current max row's left side
            //AND if mid is matrix's length -1 OR current max row's mid is less than current max row's right side.
            //return index of  max_row and mid
            if ((mid == 0 || mat[max_row][mid] > mat[max_row][mid - 1]) &&
                (mid == m - 1 || mat[max_row][mid] > mat[max_row][mid + 1]))
                return new int[] {max_row, mid};

            //else if mid is less than 0, AND max row's left side is greater than max row's mid
            //shift high to left by 1 index
            //else shift low to right by 1 index.
            else if (mid > 0 && mat[max_row][mid - 1] > mat[max_row][mid])
                hi = mid - 1;
            else
                lo = mid + 1;
        }
        //no matches return -1, -1
        return new int[] {-1, -1};
    }
}
