/*Challenge link:https://leetcode.com/problems/minimum-interval-to-include-each-query/description/
Question:
You are given a 2D integer array intervals, where intervals[i] = [lefti, righti] describes the ith interval starting at lefti and ending at righti (inclusive). The size of an interval is defined as the number of integers it contains, or more formally righti - lefti + 1.

You are also given an integer array queries. The answer to the jth query is the size of the smallest interval i such that lefti <= queries[j] <= righti. If no such interval exists, the answer is -1.

Return an array containing the answers to the queries.

 

Example 1:

Input: intervals = [[1,4],[2,4],[3,6],[4,4]], queries = [2,3,4,5]
Output: [3,3,1,4]
Explanation: The queries are processed as follows:
- Query = 2: The interval [2,4] is the smallest interval containing 2. The answer is 4 - 2 + 1 = 3.
- Query = 3: The interval [2,4] is the smallest interval containing 3. The answer is 4 - 2 + 1 = 3.
- Query = 4: The interval [4,4] is the smallest interval containing 4. The answer is 4 - 4 + 1 = 1.
- Query = 5: The interval [3,6] is the smallest interval containing 5. The answer is 6 - 3 + 1 = 4.
Example 2:

Input: intervals = [[2,3],[2,5],[1,8],[20,25]], queries = [2,19,5,22]
Output: [2,-1,4,6]
Explanation: The queries are processed as follows:
- Query = 2: The interval [2,3] is the smallest interval containing 2. The answer is 3 - 2 + 1 = 2.
- Query = 19: None of the intervals contain 19. The answer is -1.
- Query = 5: The interval [2,5] is the smallest interval containing 5. The answer is 5 - 2 + 1 = 4.
- Query = 22: The interval [20,25] is the smallest interval containing 22. The answer is 25 - 20 + 1 = 6.
 

Constraints:

1 <= intervals.length <= 105
1 <= queries.length <= 105
intervals[i].length == 2
1 <= lefti <= righti <= 107
1 <= queries[j] <= 107
*/

//***************Solution********************
public class Solution {
    public int[] MinInterval(int[][] intervals, int[] queries) {
        //set priority queue int int, int
        var minHeap = new PriorityQueue<(int,int),int>();
        int n = queries.Length, i = 0;

        //set queryindex map size to n, res to n size
        var queryIndexMap = new int[n][];
        var res = new int[n];

        //allcate querie and i into queryIndexMap
        foreach(var querie in queries){
            queryIndexMap[i] = new int[]{querie,i};
            i++;
        }

        //sort queryindexMap and intervals, then set i to 0
        Array.Sort(queryIndexMap, (a,b)=> a[0]-b[0]);
        Array.Sort(intervals, (a,b)=>a[0]-b[0]);
       i = 0;

       //loop through each item in queryIndexMap
       foreach(var item in queryIndexMap){
            //store item 0 and 1 into querie and index
           var querie = item[0];
           var index = item[1];

            //if condition is valid, enqueue current intervals difference into minHeap<(int,int),int> (left, right), left
           while(i< intervals.Length && querie>=intervals[i][0]){
               minHeap.Enqueue(((intervals[i][1] - intervals[i][0] +1), intervals[i][1]),(intervals[i][1] - intervals[i][0] +1));
                i++;
           }
            //dequeue if count is greater than 0 AND item2 is less than querie
           while(minHeap.Count>0 && minHeap.Peek().Item2<querie)
               minHeap.Dequeue();

            //if count i greater than 0, set current index at res to Item1
            //else set to -1 if not found.
           if(minHeap.Count>0)
               res[index] = minHeap.Peek().Item1;
           else
               res[index] = -1;
       }
       return res;
    }
}
