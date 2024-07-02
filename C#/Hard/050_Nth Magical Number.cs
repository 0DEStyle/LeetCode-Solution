/*Challenge link:https://leetcode.com/problems/nth-magical-number/description/
Question:
A positive integer is magical if it is divisible by either a or b.

Given the three integers n, a, and b, return the nth magical number. Since the answer may be very large, return it modulo 109 + 7.

 

Example 1:

Input: n = 1, a = 2, b = 3
Output: 2
Example 2:

Input: n = 4, a = 2, b = 3
Output: 6
 

Constraints:

1 <= n <= 109
2 <= a, b <= 4 * 104
*/

//***************Solution********************//1 2 4 6 8
public class Solution {
    private static int Gcd(int a, int b) {
        while (true) {
            int r = a % b;
            if (r == 0)
               return b;
            (a, b) = (b, r);
        }
    }

    private static long Guess(long val, int a, int b, int lcm) => val / a + val / b - val / lcm;

    public int NthMagicalNumber(int n, int a, int b) {
        //set boundaries
        long left = 1, right = ((long) n + 1) * a;
        int lcm = a * b / Gcd(a, b);

        while (right - left > 1) {
            //find mid index
            long middle = left + (right - left) / 2;

            //shift index accordingly
            if (Guess(middle, a, b, lcm) >= n) 
                right = middle;
            else
                left = middle;
        }   
        return (int)(right % 1_000_000_007);
    }
}
