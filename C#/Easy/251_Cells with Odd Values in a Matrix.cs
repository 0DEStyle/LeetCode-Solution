/*Challenge link:https://leetcode.com/problems/cells-with-odd-values-in-a-matrix/description/
Question:
There is an m x n matrix that is initialized to all 0's. There is also a 2D array indices where each indices[i] = [ri, ci] represents a 0-indexed location to perform some increment operations on the matrix.

For each location indices[i], do both of the following:

Increment all the cells on row ri.
Increment all the cells on column ci.
Given m, n, and indices, return the number of odd-valued cells in the matrix after applying the increment to all locations in indices.

 

Example 1:
//see image in link

Input: m = 2, n = 3, indices = [[0,1],[1,1]]
Output: 6
Explanation: Initial matrix = [[0,0,0],[0,0,0]].
After applying first increment it becomes [[1,2,1],[0,1,0]].
The final matrix is [[1,3,1],[1,3,1]], which contains 6 odd numbers.
Example 2:
//see image in link


Input: m = 2, n = 2, indices = [[1,1],[0,0]]
Output: 0
Explanation: Final matrix = [[2,2],[2,2]]. There are no odd numbers in the final matrix.
 

Constraints:

1 <= m, n <= 50
1 <= indices.length <= 100
0 <= ri < m
0 <= ci < n
 

Follow up: Could you solve this in O(n + m + indices.length) time with only O(n + m) extra space?
*/

//***************Solution********************
public class Solution {
    public int OddCells(int m, int n, int[][] indices) {
        // Initialise and fill matrix
        int[] matrix1 = new int[m], matrix2 = new int[n];
        int total = 0;

        //loop through indices
        //increase current cell by 1 for both matrix 1 and 2
        for(int i = 0; i < indices.Length; i++){
            matrix1[indices[i][0]] +=1;
            matrix2[indices[i][1]] +=1;
        }

        //loop through m and n
        //check if current cell is odd or even, then add to total count
        for(int i = 0; i < m; i++)
            for(int j = 0; j < n; j++)
                total += (matrix1[i] + matrix2[j]) %2 == 0 ? 0 : 1;

        return total;
    }
}
