/*Challenge link:https://leetcode.com/problems/best-time-to-buy-and-sell-stock/description/
Question:
You are given an array prices where prices[i] is the price of a given stock on the ith day.

You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.

Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.

 

Example 1:

Input: prices = [7,1,5,3,6,4]
Output: 5
Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.
Example 2:

Input: prices = [7,6,4,3,1]
Output: 0
Explanation: In this case, no transactions are done and the max profit = 0.
 

Constraints:

1 <= prices.length <= 105
0 <= prices[i] <= 104
*/

//***************Solution********************
//set max profit to 0, min price = int.MaxValue
//iterate through the prices array
//if current price is less than min price, set current price as the min price
//set profit to current price - min price
//check if profit is greater than max profit
//if true, set max profit to current profit
//return max profit
public class Solution {
    public int MaxProfit(int[] prices) {
        int maxP = 0, minP = int.MaxValue;

        for (int i = 0; i < prices.Length; i++) {
            if (prices[i] < minP) 
                minP = prices[i];
            int profit = prices[i] - minP;
            if (profit > maxP) 
                maxP = profit;
        }
        return maxP;
    }
}
