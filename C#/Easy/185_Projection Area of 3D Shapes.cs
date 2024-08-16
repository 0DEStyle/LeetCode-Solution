/*Challenge link:https://leetcode.com/problems/projection-area-of-3d-shapes/description/
Question:
You are given an n x n grid where we place some 1 x 1 x 1 cubes that are axis-aligned with the x, y, and z axes.

Each value v = grid[i][j] represents a tower of v cubes placed on top of the cell (i, j).

We view the projection of these cubes onto the xy, yz, and zx planes.

A projection is like a shadow, that maps our 3-dimensional figure to a 2-dimensional plane. We are viewing the "shadow" when looking at the cubes from the top, the front, and the side.

Return the total area of all three projections.

 

Example 1:
//see image in link

Input: grid = [[1,2],[3,4]]
Output: 17
Explanation: Here are the three projections ("shadows") of the shape made with each axis-aligned plane.
Example 2:

Input: grid = [[2]]
Output: 5
Example 3:

Input: grid = [[1,0],[0,2]]
Output: 8
 

Constraints:

n == grid.length == grid[i].length
1 <= n <= 50
0 <= grid[i][j] <= 50
*/

//***************Solution********************
public class Solution {
    public int ProjectionArea(int[][] grid) {
        int sideLength = grid.Length, totalProjectedArea = 0;

        for (int row = 0; row < sideLength; ++row){
            int maxcol = 0, maxrow = 0;

            for (int column = 0; column < sideLength; ++column){
                if (grid[row][column] > 0)
                    ++totalProjectedArea;
                if (maxrow < grid[row][column])
                    maxrow = grid[row][column];
                if (maxcol < grid[column][row])
                    maxcol = grid[column][row];
            }
            totalProjectedArea += maxrow + maxcol;
        }

        return totalProjectedArea;
    }
}
