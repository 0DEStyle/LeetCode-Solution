/*Challenge link:https://leetcode.com/problems/maximize-the-profit-as-the-salesman/description/
Question:
You are given an integer n representing the number of houses on a number line, numbered from 0 to n - 1.

Additionally, you are given a 2D integer array offers where offers[i] = [starti, endi, goldi], indicating that ith buyer wants to buy all the houses from starti to endi for goldi amount of gold.

As a salesman, your goal is to maximize your earnings by strategically selecting and selling houses to buyers.

Return the maximum amount of gold you can earn.

Note that different buyers can't buy the same house, and some houses may remain unsold.

 

Example 1:

Input: n = 5, offers = [[0,0,1],[0,2,2],[1,3,2]]
Output: 3
Explanation: There are 5 houses numbered from 0 to 4 and there are 3 purchase offers.
We sell houses in the range [0,0] to 1st buyer for 1 gold and houses in the range [1,3] to 3rd buyer for 2 golds.
It can be proven that 3 is the maximum amount of gold we can achieve.
Example 2:

Input: n = 5, offers = [[0,0,1],[0,2,10],[1,3,2]]
Output: 10
Explanation: There are 5 houses numbered from 0 to 4 and there are 3 purchase offers.
We sell houses in the range [0,2] to 2nd buyer for 10 golds.
It can be proven that 10 is the maximum amount of gold we can achieve.
 

Constraints:

1 <= n <= 105
1 <= offers.length <= 105
offers[i].length == 3
0 <= starti <= endi <= n - 1
1 <= goldi <= 103
*/

//***************Solution********************
public class Solution {
    public int MaximizeTheProfit(int n, IList<IList<int>> offers) {
        //convert offer list to array
        int[] dp = new int[offers.Count];
        //fill array with -1
        Array.Fill(dp, -1);

        //x is the current element, sort x at index 1 by ascending order, sort x at index 0 by ascending order
        //convert to list and store in affer.
        offers = offers.OrderBy(x=>x[1]).OrderBy(x=>x[0]).ToList();
        //return the result of Dfs after passing offers, 0 and dp.
        return Dfs(offers, 0, dp);
    }

    private int Dfs(IList<IList<int>> offers, int idx, int[] dp){
        //if index is greater or equal to offer length, return 0
        if(idx >= offers.Count)
            return 0;
        //if dp at index is not equal to -1, return dp at index
        if(dp[idx] != -1)
            return dp[idx];

        // Consider current offer, perfrom binary search to find next index
        int nextIdx = BinarySearch(offers, idx+1, offers[idx][1] + 1);
        //set dp at current index to: offer at idnex 2 + dfs (offer, next index, dp) 
        dp[idx] = offers[idx][2] + Dfs(offers, nextIdx, dp);
        //set dp at curretn index to: select max value between current index of dp, and Dfs(offers, idx+1, dp)
        dp[idx] = Math.Max(dp[idx], Dfs(offers, idx+1, dp));
        //return dp at index
        return dp[idx];
    }

    private int BinarySearch(IList<IList<int>> offers, int start, int target){
        int end = offers.Count - 1;

        while(end > start){
            //find mid index
            int mid = start + (end - start)/2;

            //if offere at mid 0 is greater or equal to target, set end to mid
            //else shift start to right by 1
            if(offers[mid][0] >= target)
                end = mid;
            else
                start = mid + 1;
        }
        //if offer at end 0 is greater or equal to target, return end, else return offers length
        return offers[end][0] >= target ? end : offers.Count;
    }
}
