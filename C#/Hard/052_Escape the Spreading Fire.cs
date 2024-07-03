/*Challenge link:https://leetcode.com/problems/escape-the-spreading-fire/description/
Question:
You are given a 0-indexed 2D integer array grid of size m x n which represents a field. Each cell has one of three values:

0 represents grass,
1 represents fire,
2 represents a wall that you and fire cannot pass through.
You are situated in the top-left cell, (0, 0), and you want to travel to the safehouse at the bottom-right cell, (m - 1, n - 1). Every minute, you may move to an adjacent grass cell. After your move, every fire cell will spread to all adjacent cells that are not walls.

Return the maximum number of minutes that you can stay in your initial position before moving while still safely reaching the safehouse. If this is impossible, return -1. If you can always reach the safehouse regardless of the minutes stayed, return 109.

Note that even if the fire spreads to the safehouse immediately after you have reached it, it will be counted as safely reaching the safehouse.

A cell is adjacent to another cell if the former is directly north, east, south, or west of the latter (i.e., their sides are touching).

 

Example 1:
//see image in link

Input: grid = [[0,2,0,0,0,0,0],[0,0,0,2,2,1,0],[0,2,0,0,1,2,0],[0,0,2,2,2,0,2],[0,0,0,0,0,0,0]]
Output: 3
Explanation: The figure above shows the scenario where you stay in the initial position for 3 minutes.
You will still be able to safely reach the safehouse.
Staying for more than 3 minutes will not allow you to safely reach the safehouse.
Example 2:
//see image in link

Input: grid = [[0,0,0,0],[0,1,2,0],[0,2,0,0]]
Output: -1
Explanation: The figure above shows the scenario where you immediately move towards the safehouse.
Fire will spread to any cell you move towards and it is impossible to safely reach the safehouse.
Thus, -1 is returned.
Example 3:
//see image in link

Input: grid = [[0,0,0],[2,2,0],[1,2,0]]
Output: 1000000000
Explanation: The figure above shows the initial grid.
Notice that the fire is contained by walls and you will always be able to safely reach the safehouse.
Thus, 109 is returned.
 

Constraints:

m == grid.length
n == grid[i].length
2 <= m, n <= 300
4 <= m * n <= 2 * 104
grid[i][j] is either 0, 1, or 2.
grid[0][0] == grid[m - 1][n - 1] == 0
*/

//***************Solution********************
public class Solution {
    //moving dirction
    int[] dir_x = {1, -1, 0, 0}, dir_y = {0, 0, 1, -1};
    
    public int MaximumMinutes(int[][] grid) {
        //set boundaries
        int l = 0, r = (int)1e9 + 1;
        while(l < r){
            //find mid index
            int mid = l + r >> 1;
            if(!Escape(grid, mid))
                r = mid;
            else l = mid + 1;
        }
        //not possible
        if(!Escape(grid, 0)) return -1;
        //return  10^9
        if(Escape(grid, (int)1e9)) return (int)1e9;
        return l - 1;
    }

    //check validation
    public bool Escape(int[][] grid, int mins){
        int n = grid.Length, m = grid[0].Length;
        int[][] map = new int[n][];

        //set map to grid
        for(int i = 0; i < n; i++){
            map[i] = new int[m];
            for(int j = 0; j < m; j++)
                map[i][j] = grid[i][j];
        }

        Queue<int[]> q1 = new(), q2 = new();
        //enqueue to q1
        for(int i = 0; i < n; i++){
            for(int j = 0; j < m; j++)
                if(map[i][j] == 1)
                    q1.Enqueue(new int[]{i, j});
        }

        //minute is not 0
        if(mins != 0){
            while(q1.Count > 0 && mins-- > 0){
                int size = q1.Count;
                while(size-- != 0){
                    var p = q1.Dequeue();
                    int x = p[0], y = p[1];
                    if(x == 0 && y == 0)
                        return false;
                    for(int i = 0; i < 4; i++){
                        int dx = x + dir_x[i], dy = y + dir_y[i];
                        if(dx < 0 || dy < 0 || dx >= n || dy >= m)
                            continue;
                        if(map[dx][dy] == 0){
                            map[dx][dy] = 1;
                            q1.Enqueue(new int[]{dx, dy});
                        }
                    }
                }
            }
        }

        q2.Enqueue(new int[]{0, 0});
        map[0][0] = -1;
        while(q1.Count > 0 && q2.Count > 0){
            int size1 = q1.Count, size2 = q2.Count;
            while(size2-- != 0){
                var p = q2.Dequeue();
                int x = p[0], y = p[1];
            
                if(map[n - 1][m - 1] == -1) 
                    return true;
                if(map[x][y] == 1) continue;
                for(int i = 0; i < 4; i++){
                    int dx = x + dir_x[i], dy = y + dir_y[i];
                    if(dx < 0 || dy < 0 || dx >= n || dy >= m)
                        continue;
                    if(map[dx][dy] != 0) continue;
                    if(dx == n - 1 && dy == m - 1)
                        return true;
                    map[dx][dy] = -1;
                    q2.Enqueue(new int[]{dx, dy});
                }
            }

            while(size1-- != 0){
                var p = q1.Dequeue();
                int x = p[0], y = p[1];
                for(int i = 0; i < 4; i++){
                    int dx = x + dir_x[i], dy = y + dir_y[i];
                    if(dx < 0 || dy < 0 || dx >= n || dy >= m)
                        continue;
                    if(map[dx][dy] == 1 || map[dx][dy] == 2) continue; 
                    map[dx][dy] = 1;
                    q1.Enqueue(new int[]{dx, dy});
                }
            }
        }

        while(q2.Count > 0 && map[n - 1][m - 1] != -1){
            var p = q2.Dequeue();
            int x = p[0], y = p[1];
            for(int i = 0; i < 4; i++){
                int dx = x + dir_x[i], dy = y + dir_y[i];
                if(dx < 0 || dy < 0 || dx >= n || dy >= m)
                    continue;
                if(map[dx][dy] != 0) continue;
                map[dx][dy] = -1;
                if(map[n - 1][m - 1] == -1) return true;
                q2.Enqueue(new int[]{dx, dy});
            }
        }
  
        if(q1.Count == 0 && map[n - 1][m - 1] == -1)
            return true; 
        return false;
    }
}
