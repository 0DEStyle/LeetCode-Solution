/*Challenge link:https://leetcode.com/problems/sell-diminishing-valued-colored-balls/description/
Question:
You have an inventory of different colored balls, and there is a customer that wants orders balls of any color.

The customer weirdly values the colored balls. Each colored ball's value is the number of balls of that color you currently have in your inventory. For example, if you own 6 yellow balls, the customer would pay 6 for the first yellow ball. After the transaction, there are only 5 yellow balls left, so the next yellow ball is then valued at 5 (i.e., the value of the balls decreases as you sell more to the customer).

You are given an integer array, inventory, where inventory[i] represents the number of balls of the ith color that you initially own. You are also given an integer orders, which represents the total number of balls that the customer wants. You can sell the balls in any order.

Return the maximum total value that you can attain after selling orders colored balls. As the answer may be too large, return it modulo 109 + 7.

 

Example 1:
//see image in link

Input: inventory = [2,5], orders = 4
Output: 14
Explanation: Sell the 1st color 1 time (2) and the 2nd color 3 times (5 + 4 + 3).
The maximum total value is 2 + 5 + 4 + 3 = 14.
Example 2:

Input: inventory = [3,5], orders = 6
Output: 19
Explanation: Sell the 1st color 2 times (3 + 2) and the 2nd color 4 times (5 + 4 + 3 + 2).
The maximum total value is 3 + 2 + 5 + 4 + 3 + 2 = 19.
 

Constraints:

1 <= inventory.length <= 105
1 <= inventory[i] <= 109
1 <= orders <= min(sum(inventory[i]), 109)
*/

//***************Solution********************
public class Solution {
    public int MaxProfit(int[] inventory, long orders) {
        int mod = 1000000007, curIndex = inventory.Length - 1, curValue = inventory[curIndex];
        long profit = 0;
        Array.Sort(inventory);


        while (orders > 0){
            while (curIndex >= 0 && inventory[curIndex] == curValue)
                curIndex--;

            // if all colors of balls are the same value, nextValue is 0
            int nextValue = curIndex < 0 ? 0 : inventory[curIndex];
            // number of colors of balls with same value 
            int numSameColor = inventory.Length - 1 - curIndex;
            // number of items to buy
            long nums = (long)(curValue - nextValue) * numSameColor;


                // buy all items
            if (orders >= nums)
                profit += (long)(curValue + nextValue + 1) * (curValue - nextValue) / 2 * numSameColor;
            else{
                // orders left is less than the number of items to buy
                long numFullRow = orders / numSameColor;
                long remainder = orders % numSameColor;
                profit += (long)(curValue + curValue - numFullRow + 1) * numFullRow / 2 * numSameColor;
                profit += (long)(curValue - numFullRow) * remainder;
            }
            orders -= nums;
            profit = profit % mod;
            curValue = nextValue;
        }
        return (int)profit;
}
}
