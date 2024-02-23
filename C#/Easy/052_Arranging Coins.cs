/*Challenge link:https://leetcode.com/problems/arranging-coins/description/
Question:
You have n coins and you want to build a staircase with these coins. The staircase consists of k rows where the ith row has exactly i coins. The last row of the staircase may be incomplete.

Given the integer n, return the number of complete rows of the staircase you will build.

 

Example 1:
(see image in link)

Input: n = 5
Output: 2
Explanation: Because the 3rd row is incomplete, we return 2.
Example 2:
(see image in link)

Input: n = 8
Output: 3
Explanation: Because the 4th row is incomplete, we return 3.
 

Constraints:

1 <= n <= 231 - 1
*/

//***************Solution********************
//Gauss Summation O(1):  n/2*(n+1)
//binary search method
public class Solution {
    public int ArrangeCoins(int n) {
        //set to long for whole numbers
        //start 1, n is upper bound(or less)
        long low = 0, high = n;

        //loop while true
        while(low <= high){
            //find mid point
            //coin increase each row
            var mid = low + (high - low) / 2;
            var steps = mid * (mid + 1) / 2;

            //if steps == n, meaning it fits perfectly, retun (int)mid
            //else shift either high or low by index of 1
            if(steps == n) return (int)mid;
            else if(n < steps) high = mid - 1;
            else low = mid + 1;
        }
        // return result
        return (int)high;
    }
}
