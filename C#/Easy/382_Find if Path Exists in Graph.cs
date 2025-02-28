/*Challenge link:https://leetcode.com/problems/find-if-path-exists-in-graph/description/
Question:
There is a bi-directional graph with n vertices, where each vertex is labeled from 0 to n - 1 (inclusive). The edges in the graph are represented as a 2D integer array edges, where each edges[i] = [ui, vi] denotes a bi-directional edge between vertex ui and vertex vi. Every vertex pair is connected by at most one edge, and no vertex has an edge to itself.

You want to determine if there is a valid path that exists from vertex source to vertex destination.

Given edges and the integers n, source, and destination, return true if there is a valid path from source to destination, or false otherwise.

 

Example 1:


Input: n = 3, edges = [[0,1],[1,2],[2,0]], source = 0, destination = 2
Output: true
Explanation: There are two paths from vertex 0 to vertex 2:
- 0 → 1 → 2
- 0 → 2
Example 2:


Input: n = 6, edges = [[0,1],[0,2],[3,5],[5,4],[4,3]], source = 0, destination = 5
Output: false
Explanation: There is no path from vertex 0 to vertex 5.
 

Constraints:

1 <= n <= 2 * 105
0 <= edges.length <= 2 * 105
edges[i].length == 2
0 <= ui, vi <= n - 1
ui != vi
0 <= source, destination <= n - 1
There are no duplicate edges.
There are no self edges.
*/

//***************Solution********************
public class Solution {
    public bool ValidPath(int n, int[][] edges, int source, int destination) { 
        // Initialize parent array for Union-Find
        var parent = new int[n];

        //loop through n, all vertices, set current element of parent to i
        for (int i = 0; i < n; i++)
            parent[i] = i;
        
        // Perform Union operation for each edge
        foreach (var edge in edges) {
            int parent1 = Find(parent, edge[0]), 
                parent2 = Find(parent, edge[1]);

        //if both parent are not equal, update aprent 2 to parent 1.
            if (parent1 != parent2) 
                parent[parent2] = parent1;
        }
        
        // Check if source and destination belong to the same component
        return Find(parent, source) == Find(parent, destination);
    }

    //if parent node is not equal to node, pass parent and parent node into find, then update result to parent node
    //else return parent node
    private int Find(int[] parent, int node) =>
        parent[node] != node ? parent[node] = Find(parent, parent[node]) : parent[node];
}
