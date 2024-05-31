/*Challenge link:https://leetcode.com/problems/sum-of-square-numbers/description/
Question:
Given a non-negative integer c, decide whether there're two integers a and b such that a2 + b2 = c.

 

Example 1:

Input: c = 5
Output: true
Explanation: 1 * 1 + 2 * 2 = 5
Example 2:

Input: c = 3
Output: false
 

Constraints:

0 <= c <= 231 - 1

*/

//***************Solution********************
public class Solution {
    public bool JudgeSquareSum(int c) {
        //set boundaries
        long lo = 0, hi = (long)Math.Sqrt(c);

        while (lo <= hi){
            //sum formula
            long sum = lo * lo + hi * hi;
            //if matched, return true
            if (sum == c)
                return true;
            //if sum is less than c, shift high to left, else shift low to right
            if (sum > c)
                --hi;
            else
                ++lo;
        }
        //no match
        return false;
    }
}
