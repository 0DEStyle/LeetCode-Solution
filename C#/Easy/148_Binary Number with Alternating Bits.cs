/*Challenge link:https://leetcode.com/problems/binary-number-with-alternating-bits/description/
Question:
Given a positive integer, check whether it has alternating bits: namely, if two adjacent bits will always have different values.

 

Example 1:

Input: n = 5
Output: true
Explanation: The binary representation of 5 is: 101
Example 2:

Input: n = 7
Output: false
Explanation: The binary representation of 7 is: 111.
Example 3:

Input: n = 11
Output: false
Explanation: The binary representation of 11 is: 1011.
 

Constraints:

1 <= n <= 231 - 1
*/

//***************Solution********************
public class Solution {
    public bool HasAlternatingBits(int n) {
        var b = Convert.ToString(n, 2);

        for(int i = 0; i < b.Length; i++)
            if (i % 2 == b[i] - '0')
                return false;
        return true;
    }
}
