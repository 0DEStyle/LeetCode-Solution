/*Challenge link:https://leetcode.com/problems/maximum-number-of-events-that-can-be-attended-ii/description/
Question:
You are given an array of events where events[i] = [startDayi, endDayi, valuei]. The ith event starts at startDayi and ends at endDayi, and if you attend this event, you will receive a value of valuei. You are also given an integer k which represents the maximum number of events you can attend.

You can only attend one event at a time. If you choose to attend an event, you must attend the entire event. Note that the end day is inclusive: that is, you cannot attend two events where one of them starts and the other ends on the same day.

Return the maximum sum of values that you can receive by attending events.

 

Example 1:
//see image in link


Input: events = [[1,2,4],[3,4,3],[2,3,1]], k = 2
Output: 7
Explanation: Choose the green events, 0 and 1 (0-indexed) for a total value of 4 + 3 = 7.
Example 2:
//see image in link


Input: events = [[1,2,4],[3,4,3],[2,3,10]], k = 2
Output: 10
Explanation: Choose event 2 for a total value of 10.
Notice that you cannot attend any other event as they overlap, and that you do not have to attend k events.
Example 3:
//see image in link


Input: events = [[1,1,1],[2,2,2],[3,3,3],[4,4,4]], k = 3
Output: 9
Explanation: Although the events do not overlap, you can only attend 3 events. Pick the highest valued three.
 

Constraints:

1 <= k <= events.length
1 <= k * events.length <= 106
1 <= startDayi <= endDayi <= 109
1 <= valuei <= 106
*/

//***************Solution********************
public class Solution {
     public int MaxValue(int[][] events, int k) {
        //sort array, dp storage
        Array.Sort(events, (a, b) => a[0] - b[0]);
        int n = events.Length;
        int[][] dp = new int[k + 1][];

        //set dp
        for (int i = 0; i <= k; i++){
            dp[i] = new int[n];
            Array.Fill(dp[i], -1);
        }

        //pass variable into Depth-first search method
        return DFS(0, k, events, dp);
    }
    //Depth-first search method
    private int DFS(int curIndex, int count, int[][] events, int[][] dp){
        if (count == 0 || curIndex == events.Length)
            return 0;
        if (dp[count][curIndex] != -1)
            return dp[count][curIndex];

        //binary search for next index
        int nextIndex = BisectRight(events, events[curIndex][1]);

        //select max value between current index and next index
        dp[count][curIndex] = Math.Max(DFS(curIndex + 1, count, events, dp), events[curIndex][2] + DFS(nextIndex, count - 1, events, dp));
        return dp[count][curIndex];
    }

    public static int BisectRight(int[][] events, int target){
        //set boundaries
        int left = 0, right = events.Length;
        while (left < right){
            //find mid index
            int mid = (left + right) / 2;
            if (events[mid][0] <= target)
                left = mid + 1;
            else
                right = mid;
        }
        return left;
    }
}
