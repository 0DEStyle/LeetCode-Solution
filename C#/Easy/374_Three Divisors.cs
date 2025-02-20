/*Challenge link:https://leetcode.com/problems/three-divisors/description/
Question:
Given an integer n, return true if n has exactly three positive divisors. Otherwise, return false.

An integer m is a divisor of n if there exists an integer k such that n = k * m.

 

Example 1:

Input: n = 2
Output: false
Explantion: 2 has only two divisors: 1 and 2.
Example 2:

Input: n = 4
Output: true
Explantion: 4 has three divisors: 1, 2, and 4.
 

Constraints:

1 <= n <= 104
*/

//***************Solution********************
// check even, then check count is 3.
public class Solution {
    public bool IsThree(int n) =>
    Enumerable.Range(1, n + 1)
              .Where(x => n % x == 0)
              .Count() == 3;
}
