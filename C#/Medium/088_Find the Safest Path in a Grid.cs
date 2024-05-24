/*Challenge link:https://leetcode.com/problems/find-the-safest-path-in-a-grid/description/
Question:
You are given a 0-indexed 2D matrix grid of size n x n, where (r, c) represents:

A cell containing a thief if grid[r][c] = 1
An empty cell if grid[r][c] = 0
You are initially positioned at cell (0, 0). In one move, you can move to any adjacent cell in the grid, including cells containing thieves.

The safeness factor of a path on the grid is defined as the minimum manhattan distance from any cell in the path to any thief in the grid.

Return the maximum safeness factor of all paths leading to cell (n - 1, n - 1).

An adjacent cell of cell (r, c), is one of the cells (r, c + 1), (r, c - 1), (r + 1, c) and (r - 1, c) if it exists.

The Manhattan distance between two cells (a, b) and (x, y) is equal to |a - x| + |b - y|, where |val| denotes the absolute value of val.

 

Example 1:
//see image in link

Input: grid = [[1,0,0],[0,0,0],[0,0,1]]
Output: 0
Explanation: All paths from (0, 0) to (n - 1, n - 1) go through the thieves in cells (0, 0) and (n - 1, n - 1).
Example 2:
//see image in link


Input: grid = [[0,0,1],[0,0,0],[0,0,0]]
Output: 2
Explanation: The path depicted in the picture above has a safeness factor of 2 since:
- The closest cell of the path to the thief at cell (0, 2) is cell (0, 0). The distance between them is | 0 - 0 | + | 0 - 2 | = 2.
It can be shown that there are no other paths with a higher safeness factor.
Example 3:
//see image in link


Input: grid = [[0,0,0,1],[0,0,0,0],[0,0,0,0],[1,0,0,0]]
Output: 2
Explanation: The path depicted in the picture above has a safeness factor of 2 since:
- The closest cell of the path to the thief at cell (0, 3) is cell (1, 2). The distance between them is | 0 - 1 | + | 3 - 2 | = 2.
- The closest cell of the path to the thief at cell (3, 0) is cell (3, 2). The distance between them is | 3 - 3 | + | 0 - 2 | = 2.
It can be shown that there are no other paths with a higher safeness factor.
 

Constraints:

1 <= grid.length == n <= 400
grid[i].length == n
grid[i][j] is either 0 or 1.
There is at least one thief in the grid.
*/

//***************Solution********************
public class Solution {
     // Directions for moving to neighboring cells: right, left, down, up
    int[][] dir = { new int[]{0, 1}, 
                    new int[]{0, -1}, 
                    new int[]{1, 0}, 
                    new int[]{-1, 0}};

    public int MaximumSafenessFactor(IList<IList<int>> grid) {
        int n = grid.Count;
        int[,] mat = new int[n, n];
        var multiSourceQueue = new Queue<int[]>();

        //***** To make modifications and navigation easier, the grid is converted into a 2-d array*******
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] == 1) {
                    // Push thief coordinates to the queue
                    multiSourceQueue.Enqueue(new int[]{i, j});
                    mat[i, j] = 0; // Mark thief cell with 0
                } 
                else
                    mat[i, j] = -1; // Mark empty cell with -1
            }
        }

        // ********Calculate safeness factor for each cell using BFS *******
        while (multiSourceQueue.Count > 0) {
            int size = multiSourceQueue.Count;

            while (size-- > 0) {
                int[] curr = multiSourceQueue.Dequeue();

                // Check neighboring cells
                foreach (var d in dir) {
                    int di = curr[0] + d[0];
                    int dj = curr[1] + d[1];
                    int val = mat[curr[0], curr[1]];

                    // Check if the neighboring cell is valid and unvisited
                    if (IsValidCell(mat, di, dj) && mat[di, dj] == -1) {
                        // Update safeness factor and push to the queue
                        mat[di, dj] = val + 1;
                        multiSourceQueue.Enqueue(new int[]{di, dj});
                    }
                }
            }
        }

        // *********Binary search for maximum safeness factor  **************
        int start = 0, end = 0, res = -1;

        // Set end as the maximum safeness factor possible
        for (int i = 0; i < n; i++) 
            for (int j = 0; j < n; j++) 
                end = Math.Max(end, mat[i, j]);
            

        while (start <= end) {
            //find mid index
            int mid = start + (end - start) / 2;

            //check condition valid, then store valid safeness and search for larger ones 
            //shift start to right by 1 index
            //else shift end to left by 1 index
            if (IsValidSafeness(mat, mid)) {
                res = mid; 
                start = mid + 1;
            }else 
                end = mid - 1;
        }
        return res;
    }

    // Check if a path exists with given minimum safeness value
    private bool IsValidSafeness(int[,] grid, int minSafeness) {
        int n = grid.GetLength(0);

        // Check if the source and destination cells satisfy minimum safeness
        if (grid[0, 0] < minSafeness || grid[n - 1, n - 1] < minSafeness) 
            return false;

        Queue<int[]> traversalQueue = new Queue<int[]>();
        traversalQueue.Enqueue(new int[]{0, 0});
        bool[,] visited = new bool[n, n];
        visited[0, 0] = true;

        // Breadth-first search to find a valid path
        while (traversalQueue.Count > 0) {
            int[] curr = traversalQueue.Dequeue();
            if (curr[0] == n - 1 && curr[1] == n - 1)
                return true; // Valid path found

            // Check neighboring cells
            foreach (var d in dir) {
                int di = curr[0] + d[0];
                int dj = curr[1] + d[1];

                // Check if the neighboring cell is valid, unvisited and satisfying minimum safeness
                if (IsValidCell(grid, di, dj) && !visited[di, dj] && grid[di, dj] >= minSafeness) {
                    visited[di, dj] = true;
                    traversalQueue.Enqueue(new int[]{di, dj});
                }
            }
        }
        return false; // No valid path found
    }

    // Check if a given cell lies within the grid
    private bool IsValidCell(int[,] mat, int i, int j) => 
    i >= 0 && j >= 0 && i < mat.GetLength(0) && j < mat.GetLength(0);
}
