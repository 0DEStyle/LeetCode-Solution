/*Challenge link:https://leetcode.com/problems/find-building-where-alice-and-bob-can-meet/description/
Question:
You are given a 0-indexed array heights of positive integers, where heights[i] represents the height of the ith building.

If a person is in building i, they can move to any other building j if and only if i < j and heights[i] < heights[j].

You are also given another array queries where queries[i] = [ai, bi]. On the ith query, Alice is in building ai while Bob is in building bi.

Return an array ans where ans[i] is the index of the leftmost building where Alice and Bob can meet on the ith query. If Alice and Bob cannot move to a common building on query i, set ans[i] to -1.

 

Example 1:

Input: heights = [6,4,8,5,2,7], queries = [[0,1],[0,3],[2,4],[3,4],[2,2]]
Output: [2,5,-1,5,2]
Explanation: In the first query, Alice and Bob can move to building 2 since heights[0] < heights[2] and heights[1] < heights[2]. 
In the second query, Alice and Bob can move to building 5 since heights[0] < heights[5] and heights[3] < heights[5]. 
In the third query, Alice cannot meet Bob since Alice cannot move to any other building.
In the fourth query, Alice and Bob can move to building 5 since heights[3] < heights[5] and heights[4] < heights[5].
In the fifth query, Alice and Bob are already in the same building.  
For ans[i] != -1, It can be shown that ans[i] is the leftmost building where Alice and Bob can meet.
For ans[i] == -1, It can be shown that there is no building where Alice and Bob can meet.
Example 2:

Input: heights = [5,3,8,2,6,1,4,6], queries = [[0,7],[3,5],[5,2],[3,0],[1,6]]
Output: [7,6,-1,4,6]
Explanation: In the first query, Alice can directly move to Bob's building since heights[0] < heights[7].
In the second query, Alice and Bob can move to building 6 since heights[3] < heights[6] and heights[5] < heights[6].
In the third query, Alice cannot meet Bob since Bob cannot move to any other building.
In the fourth query, Alice and Bob can move to building 4 since heights[3] < heights[4] and heights[0] < heights[4].
In the fifth query, Alice can directly move to Bob's building since heights[1] < heights[6].
For ans[i] != -1, It can be shown that ans[i] is the leftmost building where Alice and Bob can meet.
For ans[i] == -1, It can be shown that there is no building where Alice and Bob can meet.

 

Constraints:

1 <= heights.length <= 5 * 104
1 <= heights[i] <= 109
1 <= queries.length <= 5 * 104
queries[i] = [ai, bi]
0 <= ai, bi <= heights.length - 1
*/

//***************Solution********************
//better explanation: https://www.youtube.com/watch?v=zl4Y9GYjBc0

//test case passed but took too long. 993ms, depend on server.
public class Solution {
    public int[] LeftmostBuildingQueries(int[] A, int[][] queries) {
        int n = A.Length, qn = queries.Length;
        List<List<int[]>> que = new List<List<int[]>>();
        for (int i = 0; i < n; i++)
            que.Add(new List<int[]>());
        PriorityQueue<int[], int[]> h = new PriorityQueue<int[], int[]>(Comparer<int[]>.Create((a, b) => a[0].CompareTo(b[0])));
        int[] res = new int[qn];
        Array.Fill(res, -1);
        // Step 1
        for (int qi = 0; qi < qn; qi++)
        {
            int i = queries[qi][0], j = queries[qi][1];
            if (i < j && A[i] < A[j])
            {
                res[qi] = j;
            }
            else if (i > j && A[i] > A[j])
            {
                res[qi] = i;
            }
            else if (i == j)
            {
                res[qi] = i;
            }
            else // Step 2
            {
                que[Math.Max(i, j)].Add(new int[] { Math.Max(A[i], A[j]), qi });
            }
        }
        // Step 3
        for (int i = 0; i < n; i++)
        {
            while (h.Count > 0 && h.Peek()[0] < A[i])
            {
                res[h.Dequeue()[1]] = i;
            }
            foreach (int[] q in que[i])
            {
                h.Enqueue(q, q);
            }
        }

        return res;
    }
}

//method 2
public class Solution {
    public int[] LeftmostBuildingQueries(int[] heights, int[][] queries) {
        int qLen = queries.Length, hLen = heights.Length;
        SortedList<int, int> validIndexes = new();
        int[] output = new int[qLen];
        List<(int[] query, int ind)> qLis = new();
        List<int> hLis = new();

        //assign values into queries
        for (int i = 0; i < qLen; i++){
            if (queries[i][0] > queries[i][1]){
                var holder = queries[i][0];
                queries[i][0] = queries[i][1];
                queries[i][1] = holder;
            }
            qLis.Add((queries[i], i));
        }
        //assign numbers into height list.
        for (int i = 0; i < hLen; i++)
            hLis.Add(i);

        //sort both height and queries lists.
        hLis.Sort((a, b) => heights[a].CompareTo(heights[b]));
        qLis.Sort((a, b) => {
            int maxA = Math.Max(heights[a.query[0]], heights[a.query[1]]);
            int maxB = Math.Max(heights[b.query[0]], heights[b.query[1]]);
            return maxA.CompareTo(maxB);
        });

        int hInd = hLen - 1;

        for (int i = qLen - 1; i > -1; i--){
            //Alice 
            int heightA = heights[qLis[i].query[0]];
            //Bob
            int heightB = heights[qLis[i].query[1]];

            //check height and query conditons
            if ((qLis[i].query[0] == qLis[i].query[1]) || heightA < heightB){
                output[qLis[i].ind] = qLis[i].query[1];
                continue;
            }

            //select max value between heigh A and B
            int max = Math.Max(heightA, heightB), floor = qLis[i].query[1];

            //if id is greater than -1 AND  heights is greater than max
            //add valid indexes
            while (hInd > -1 && heights[hLis[hInd]] > max)
                validIndexes.Add(hLis[hInd], hLis[hInd--]);

            //perform binary search and store in output array
            output[qLis[i].ind] = bSearch(validIndexes, floor);
        }
        return output;
    }

    //binary search
    private int bSearch(SortedList<int, int> vIndexes, int floor){
        var vals = vIndexes.Keys;
        //set boundaries
        int lo = 0, hi = vals.Count - 1, mid = 0, nm = -1;

        while (lo <= hi){
            //find mid index
            mid = lo + (hi - lo) / 2;

            //shift index accordingly
            if (vals[mid] > floor){
                nm = vals[mid];
                hi = mid - 1;
            }
            else lo = mid + 1;
        }
        return nm;
    }
}
