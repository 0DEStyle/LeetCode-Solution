/*Challenge link:https://leetcode.com/problems/convert-integer-to-the-sum-of-two-no-zero-integers/description/
Question:
No-Zero integer is a positive integer that does not contain any 0 in its decimal representation.

Given an integer n, return a list of two integers [a, b] where:

a and b are No-Zero integers.
a + b = n
The test cases are generated so that there is at least one valid solution. If there are many valid solutions, you can return any of them.

 

Example 1:

Input: n = 2
Output: [1,1]
Explanation: Let a = 1 and b = 1.
Both a and b are no-zero integers, and a + b = 2 = n.
Example 2:

Input: n = 11
Output: [2,9]
Explanation: Let a = 2 and b = 9.
Both a and b are no-zero integers, and a + b = 9 = n.
Note that there are other valid answers as [8, 3] that can be accepted.
 

Constraints:

2 <= n <= 104
*/

//***************Solution********************
public class Solution {
    public int[] GetNoZeroIntegers(int n) {
        //loop from 1 up to n
        //if string "i" and "n-i" index of '0' equal to -1, meaning not found
        //return i and n-i
        for(int i = 1; i < n; i++)
            if ($"{i}{n - i}".IndexOf('0') == -1)
                return new int[] { i, n - i };
        //else return empty int array
        return new int[0];
    }
}
