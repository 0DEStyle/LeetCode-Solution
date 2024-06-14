/*Challenge link:https://leetcode.com/problems/maximum-profit-in-job-scheduling/description/
Question:
We have n jobs, where every job is scheduled to be done from startTime[i] to endTime[i], obtaining a profit of profit[i].

You're given the startTime, endTime and profit arrays, return the maximum profit you can take such that there are no two jobs in the subset with overlapping time range.

If you choose a job that ends at time X you will be able to start another job that starts at time X.

 

Example 1:
//see image in link


Input: startTime = [1,2,3,3], endTime = [3,4,5,6], profit = [50,10,40,70]
Output: 120
Explanation: The subset chosen is the first and fourth job. 
Time range [1-3]+[3-6] , we get profit of 120 = 50 + 70.
Example 2:
//see image in link



Input: startTime = [1,2,3,4,6], endTime = [3,5,10,6,9], profit = [20,20,100,70,60]
Output: 150
Explanation: The subset chosen is the first, fourth and fifth job. 
Profit obtained 150 = 20 + 70 + 60.
Example 3:
//see image in link



Input: startTime = [1,1,1], endTime = [2,3,4], profit = [5,6,4]
Output: 6
 

Constraints:

1 <= startTime.length == endTime.length == profit.length <= 5 * 104
1 <= startTime[i] < endTime[i] <= 109
*/

//***************Solution********************
public class Solution {
    public int JobScheduling(int[] startTime, int[] endTime, int[] profit) {
    //x is current, y is next, if current = next reutnr 1, else compare x to y
    var comp = Comparer<int>.Create((x, y) => x == y ? 1 : x.CompareTo(y));
    int n = startTime.Length;

    //create element start from n, count up to n
    //i and x are current element, select current start time, current end time, curretn profit
    //order by start ascendinly, convert to list
    var list = Enumerable.Range(0, n)
        .Select(i => (start: startTime[i], end: endTime[i], profit: profit[i]))
        .OrderBy(x => x.start).ToList();

    //loop through n, set curretn start time to current index of list.start
    for (var i = 0; i < n; i++)
        startTime[i] = list[i].start;

    //dynamic programing storage
    var dp = new int[n + 1];

    //binary search
    for (int k = n - 1; k >= 0; k--) {
        //find mid index
        int i = Array.BinarySearch(startTime,k+1,list.Count-k-1, list[k].end, comp);

        //the built in binary search will return -1 if index not found, 
        //so using bit wise completement to the negative result to produce an index ~
        //select max value if dp[k + 1], list[k].profit + dp[i < 0 
        //return ~i or i, set to current dp
        dp[k] = Math.Max(dp[k + 1], list[k].profit + dp[i < 0 ? ~i : i]);
    }
    return dp[0];
}
}
