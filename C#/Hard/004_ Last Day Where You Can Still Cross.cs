/*Challenge link:https://leetcode.com/problems/last-day-where-you-can-still-cross/description/
Question:
There is a 1-based binary matrix where 0 represents land and 1 represents water. You are given integers row and col representing the number of rows and columns in the matrix, respectively.

Initially on day 0, the entire matrix is land. However, each day a new cell becomes flooded with water. You are given a 1-based 2D array cells, where cells[i] = [ri, ci] represents that on the ith day, the cell on the rith row and cith column (1-based coordinates) will be covered with water (i.e., changed to 1).

You want to find the last day that it is possible to walk from the top to the bottom by only walking on land cells. You can start from any cell in the top row and end at any cell in the bottom row. You can only travel in the four cardinal directions (left, right, up, and down).

Return the last day where it is possible to walk from the top to the bottom by only walking on land cells.

 

Example 1:
//see image in link

Input: row = 2, col = 2, cells = [[1,1],[2,1],[1,2],[2,2]]
Output: 2
Explanation: The above image depicts how the matrix changes each day starting from day 0.
The last day where it is possible to cross from top to bottom is on day 2.
Example 2:
//see image in link

Input: row = 2, col = 2, cells = [[1,1],[1,2],[2,1],[2,2]]
Output: 1
Explanation: The above image depicts how the matrix changes each day starting from day 0.
The last day where it is possible to cross from top to bottom is on day 1.
Example 3:
//see image in link

Input: row = 3, col = 3, cells = [[1,2],[2,1],[3,3],[2,2],[1,1],[1,3],[2,3],[3,2],[3,1]]
Output: 3
Explanation: The above image depicts how the matrix changes each day starting from day 0.
The last day where it is possible to cross from top to bottom is on day 3.
 

Constraints:

2 <= row, col <= 2 * 104
4 <= row * col <= 2 * 104
cells.length == row * col
1 <= ri <= row
1 <= ci <= col
All the values of cells are unique.
*/

//***************Solution********************
public class Solution {
    //direction
    private int[][] directions = new int[][] { new int[] { 1, 0 }, new int[] { -1, 0 }, new int[] { 0, 1 }, new int[] { 0, -1 } };
    
    //validation check
    public bool CanCross(int row, int col, int[][] cells, int day) {
        int[][] grid = new int[row][];
        for (int i = 0; i < row; i++)
            grid[i] = new int[col];
        
        for (int i = 0; i < day; i++) {
            int r = cells[i][0] - 1;
            int c = cells[i][1] - 1;
            grid[r][c] = 1;
        }
        
        for (int i = 0; i < col; i++) 
            if (grid[0][i] == 0 && DFS(grid, 0, i, row, col)) 
                return true;
        return false;
    }

    //Depth first search method
    private bool DFS(int[][] grid, int r, int c, int row, int col) {
        if (r < 0 || r >= row || c < 0 || c >= col || grid[r][c] != 0)
            return false;
        if (r == row - 1) 
            return true;
        
        grid[r][c] = -1;
        
        foreach (int[] dir in directions) {
            int newR = r + dir[0], newC = c + dir[1];
            if (DFS(grid, newR, newC, row, col)) 
                return true;
        }
        return false;
    }

    //binary search method
    public int LatestDayToCross(int row, int col, int[][] cells) {
        //set boundaries
        int left = 1, right = row * col;
        
        while (left < right) {
            //find mid index
            int mid = right - (right - left) / 2;

            //check validation
            if (CanCross(row, col, cells, mid)) 
                left = mid;
            else
                right = mid - 1;
        }
        return left;
    }
}
