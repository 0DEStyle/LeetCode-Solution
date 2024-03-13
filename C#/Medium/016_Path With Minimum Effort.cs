/*Challenge link:https://leetcode.com/problems/path-with-minimum-effort/description/
Question:
You are a hiker preparing for an upcoming hike. You are given heights, a 2D array of size rows x columns, where heights[row][col] represents the height of cell (row, col). You are situated in the top-left cell, (0, 0), and you hope to travel to the bottom-right cell, (rows-1, columns-1) (i.e., 0-indexed). You can move up, down, left, or right, and you wish to find a route that requires the minimum effort.

A route's effort is the maximum absolute difference in heights between two consecutive cells of the route.

Return the minimum effort required to travel from the top-left cell to the bottom-right cell.

 

Example 1:
//see image in link


Input: heights = [[1,2,2],[3,8,2],[5,3,5]]
Output: 2
Explanation: The route of [1,3,5,3,5] has a maximum absolute difference of 2 in consecutive cells.
This is better than the route of [1,2,2,2,5], where the maximum absolute difference is 3.
Example 2:
//see image in link



Input: heights = [[1,2,3],[3,8,4],[5,3,5]]
Output: 1
Explanation: The route of [1,2,3,4,5] has a maximum absolute difference of 1 in consecutive cells, which is better than route [1,3,5,3,5].
Example 3:
//see image in link


Input: heights = [[1,2,1,1,1],[1,2,1,2,1],[1,2,1,2,1],[1,2,1,2,1],[1,1,1,2,1]]
Output: 0
Explanation: This route does not require any effort.
 

Constraints:

rows == heights.length
columns == heights[i].length
1 <= rows, columns <= 100
1 <= heights[i][j] <= 106
*/

//***************Solution********************
//Dijkstra's Algorithm, shortest path
//ref: https://www.youtube.com/watch?v=_lHSawdgXpI

public class Solution {
    public int MinimumEffortPath(int[][] heights) {

        //get boundaries, create new distance array
        //create sortedset, with effort and the x y coordinate as parameter to keeps track of the minimum effort
        int rows = heights.Length, cols = heights[0].Length;
        int[,] dist = new int[rows, cols];
        var minHeap = new SortedSet<(int effort, int x, int y)>();
        minHeap.Add((0, 0, 0));

        //set row and col to ∞ for starter
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) 
                dist[i, j] = int.MaxValue;
        }

        //starting point, and direction array
        dist[0, 0] = 0;
        int[][] directions = new int[][] { new int[]{ 0, 1 }, new int[]{ 0, -1 }, new int[]{ 1, 0 }, new int[]{ -1, 0 }};
        
        //while minHeap count is greater than 0
        //set effort x and y to min value
        //remove min value from minheap
        while (minHeap.Count > 0) {
            var (effort, x, y) = minHeap.Min;
            minHeap.Remove(minHeap.Min);
            
            //if current effort is greater than distance at x and y, keep going
            //if we reeach the end point, return effort
            if (effort > dist[x, y]) continue;
            if (x == rows - 1 && y == cols - 1) return effort;
            
            // loop through each direction
            foreach (var dir in directions) {
                //x and y direction
                int nx = x + dir[0], ny = y + dir[1];

                //if the coordiante is within boundaries
                if (nx >= 0 && nx < rows && ny >= 0 && ny < cols) {
                    //find max value between effort and height's difference
                    int new_effort = Math.Max(effort, Math.Abs(heights[x][y] - heights[nx][ny]));

                    //if new effort is less than last effort, update the distance and heap
                    if (new_effort < dist[nx, ny]) {
                        dist[nx, ny] = new_effort;
                        minHeap.Add((new_effort, nx, ny));
                    }
                }
            }
        }
        return -1;
        }
}
