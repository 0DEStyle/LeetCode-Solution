/*Challenge link:https://leetcode.com/problems/power-of-four/description/
Question:
Given an integer n, return true if it is a power of four. Otherwise, return false.

An integer n is a power of four, if there exists an integer x such that n == 4x.

 

Example 1:

Input: n = 16
Output: true
Example 2:

Input: n = 5
Output: false
Example 3:

Input: n = 1
Output: true
 

Constraints:

-231 <= n <= 231 - 1
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//We can use "n&(n-1) == 0" to determine if n is power of 2. 
// For power of 4, the additional restriction is that in binary form, the only "1" should always located at the odd position.
// For example, 4^0 = 1, 4^1 = 100, 4^2 = 10000. 
//So we can use "num & 0x55555555==num" to check if "1" is located at the odd position.

public class Solution {
    public bool IsPowerOfFour(int n) => (n > 0) && ((n & (n - 1)) == 0) && ((n & 0x55555555) == n);
}
