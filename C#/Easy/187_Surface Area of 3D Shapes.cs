/*Challenge link:https://leetcode.com/problems/surface-area-of-3d-shapes/description/
Question:
You are given an n x n grid where you have placed some 1 x 1 x 1 cubes. Each value v = grid[i][j] represents a tower of v cubes placed on top of cell (i, j).

After placing these cubes, you have decided to glue any directly adjacent cubes to each other, forming several irregular 3D shapes.

Return the total surface area of the resulting shapes.

Note: The bottom face of each shape counts toward its surface area.

 

Example 1:
//see image in link

Input: grid = [[1,2],[3,4]]
Output: 34
Example 2:
//see image in link

Input: grid = [[1,1,1],[1,0,1],[1,1,1]]
Output: 32
Example 3:
//see image in link

Input: grid = [[2,2,2],[2,1,2],[2,2,2]]
Output: 46
 

Constraints:

n == grid.length == grid[i].length
1 <= n <= 50
0 <= grid[i][j] <= 50
*/

//***************Solution********************
public class Solution {
    public int SurfaceArea(int[][] grid) {
        int ar = 2 * grid.Length * grid.Length;

        
        for (int i = 0; i < grid.Length; i++)
            for (int j = 0; j < grid.Length; j++){
                if (grid[i][j] == 0){
                    ar -= 2;
                    continue;
                }
                ar += GetSideWall (grid, grid[i][j], i - 1, j);
                ar += GetSideWall (grid, grid[i][j], i + 1, j);
                ar += GetSideWall (grid, grid[i][j], i, j - 1);
                ar += GetSideWall (grid, grid[i][j], i, j + 1);
            }
        return ar;
    }

    int GetSideWall (int[][] grid, int h, int r, int c){
        if (r < 0 || r >= grid.Length || c < 0 || c >= grid[r].Length)
            return h;
        if (h > grid[r][c])
            return h - grid[r][c];
        return 0;
    }
}
