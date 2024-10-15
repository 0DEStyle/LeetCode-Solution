/*Challenge link:https://leetcode.com/problems/minimum-cost-to-move-chips-to-the-same-position/description/
Question:
We have n chips, where the position of the ith chip is position[i].

We need to move all the chips to the same position. In one step, we can change the position of the ith chip from position[i] to:

position[i] + 2 or position[i] - 2 with cost = 0.
position[i] + 1 or position[i] - 1 with cost = 1.
Return the minimum cost needed to move all the chips to the same position.

 

Example 1:
//see image in link

Input: position = [1,2,3]
Output: 1
Explanation: First step: Move the chip at position 3 to position 1 with cost = 0.
Second step: Move the chip at position 2 to position 1 with cost = 1.
Total cost is 1.
Example 2:
//see image in link

Input: position = [2,2,2,3,3]
Output: 2
Explanation: We can move the two chips at position  3 to position 2. Each move has cost = 1. The total cost = 2.
Example 3:

Input: position = [1,1000000000]
Output: 1
 

Constraints:

1 <= position.length <= 100
1 <= position[i] <= 10^9
*/

//***************Solution********************
/*
count the even numbers, count the odd numbers and return the least count.

check whether n is even with n % 2. However, the modulo division can be expensive. 
So we can just check the lowest bit of n using n & 1
*/

public class Solution {
    public int MinCostToMoveChips(int[] p) {
        //find sum where x is even
        int even = p.Sum(x => x & 1);

        //select min value between even and odd
        return Math.Min(even, p.Length - even);
    }
}
