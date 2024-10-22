/*Challenge link:https://leetcode.com/problems/shift-2d-grid/description/
Question:
Given a 2D grid of size m x n and an integer k. You need to shift the grid k times.

In one shift operation:

Element at grid[i][j] moves to grid[i][j + 1].
Element at grid[i][n - 1] moves to grid[i + 1][0].
Element at grid[m - 1][n - 1] moves to grid[0][0].
Return the 2D grid after applying shift operation k times.

 

Example 1:
//see image in link

Input: grid = [[1,2,3],[4,5,6],[7,8,9]], k = 1
Output: [[9,1,2],[3,4,5],[6,7,8]]
Example 2:
//see image in link

Input: grid = [[3,8,1,9],[19,7,2,5],[4,6,11,10],[12,0,21,13]], k = 4
Output: [[12,0,21,13],[3,8,1,9],[19,7,2,5],[4,6,11,10]]
Example 3:

Input: grid = [[1,2,3],[4,5,6],[7,8,9]], k = 9
Output: [[1,2,3],[4,5,6],[7,8,9]]
 

Constraints:

m == grid.length
n == grid[i].length
1 <= m <= 50
1 <= n <= 50
-1000 <= grid[i][j] <= 1000
0 <= k <= 100
*/

//***************Solution********************
public class Solution {
    public IList<IList<int>> ShiftGrid(int[][] grid, int k) {
        //get num of grid cells mod k, remainder set to k
        k = k % (grid.Length * grid[0].Length);


        while (k != 0){
            //cell 1 and 2
            int tmp = grid[grid.Length - 1][grid[0].Length - 1],
                tmp2 = 0;
            
            for (int i = 0; i < grid.Length; i++)
                for (int j = 0; j < grid[0].Length; j++){
                    //1
                    tmp2 = grid[i][j];
                    //2
                    grid[i][j] = tmp;
                    //3
                    tmp = tmp2;
                }
            k--;
        }
        
        var ans = new List<IList<int>>();
        foreach (var row in grid) 
            ans.Add(new List<int>(row));

        return ans;
    }
}
