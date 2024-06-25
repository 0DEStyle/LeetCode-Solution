/*Challenge link:https://leetcode.com/problems/count-pairs-of-nodes/description/
Question:
You are given an undirected graph defined by an integer n, the number of nodes, and a 2D integer array edges, the edges in the graph, where edges[i] = [ui, vi] indicates that there is an undirected edge between ui and vi. You are also given an integer array queries.

Let incident(a, b) be defined as the number of edges that are connected to either node a or b.

The answer to the jth query is the number of pairs of nodes (a, b) that satisfy both of the following conditions:

a < b
incident(a, b) > queries[j]
Return an array answers such that answers.length == queries.length and answers[j] is the answer of the jth query.

Note that there can be multiple edges between the same two nodes.

 

Example 1:
//see image in link

Input: n = 4, edges = [[1,2],[2,4],[1,3],[2,3],[2,1]], queries = [2,3]
Output: [6,5]
Explanation: The calculations for incident(a, b) are shown in the table above.
The answers for each of the queries are as follows:
- answers[0] = 6. All the pairs have an incident(a, b) value greater than 2.
- answers[1] = 5. All the pairs except (3, 4) have an incident(a, b) value greater than 3.
Example 2:

Input: n = 5, edges = [[1,5],[1,5],[3,4],[2,5],[1,3],[5,1],[2,3],[2,5]], queries = [1,2,3,4,5]
Output: [10,10,9,8,6]
 

Constraints:

2 <= n <= 2 * 104
1 <= edges.length <= 105
1 <= ui, vi <= n
ui != vi
1 <= queries.length <= 20
0 <= queries[j] < edges.length
*/

//***************Solution********************
//visualisation: https://www.youtube.com/watch?v=9pAVTzVYnPc
//visualisation: https://www.youtube.com/watch?v=9pAVTzVYnPc
public class Solution {
    public int[] CountPairs(int n, int[][] edges, int[] queries) {
        Dictionary<int, Dictionary<int, int>> dupMap = new Dictionary<int, Dictionary<int, int>>();
Dictionary<int, HashSet<int>> map = new Dictionary<int, HashSet<int>>();
int[] ans = new int[queries.Length];
int[] count = new int[n];
foreach (int[] e in edges)
{
    int min = Math.Min(e[0] - 1, e[1] - 1);
    int max = Math.Max(e[0] - 1, e[1] - 1);
    if (!dupMap.ContainsKey(min))
    {
        dupMap[min] = new Dictionary<int, int>();
    }
    dupMap[min][max] = (dupMap[min].GetValueOrDefault(max, 0) + 1);
    if (!map.ContainsKey(min))
    {
        map[min] = new HashSet<int>();
    }
    map[min].Add(max);
    count[min]++;
    count[max]++;
}
List<int> indexes = Enumerable.Range(0, n).ToList();
indexes.Sort((a, b) => count[a].CompareTo(count[b]));
for (int j = 0, hi = n; j < queries.Length; j++, hi = n)
{
    for (int i = 0; i < n; i++)
    {
        while (hi > i + 1 && count[indexes[i]] + count[indexes[hi - 1]] > queries[j])
        {
            hi--;
        }
        if (hi == i)
        {
            hi++;
        }
        ans[j] += n - hi;
        if (map.ContainsKey(indexes[i]))
        {
            foreach (int adj in map[indexes[i]])
            {
                int ttl = count[indexes[i]] + count[adj];
                if (ttl > queries[j] && ttl - (dupMap[indexes[i]].GetValueOrDefault(adj, 0)) <= queries[j])
                {
                    ans[j]--;
                }
            }
        }
    }
}
return ans;


    }
}
