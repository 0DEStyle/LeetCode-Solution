/*Challenge link:https://leetcode.com/problems/replace-all-digits-with-characters/description/
Question:
You are given a 0-indexed string s that has lowercase English letters in its even indices and digits in its odd indices.

You must perform an operation shift(c, x), where c is a character and x is a digit, that returns the xth character after c.

For example, shift('a', 5) = 'f' and shift('x', 0) = 'x'.
For every odd index i, you want to replace the digit s[i] with the result of the shift(s[i-1], s[i]) operation.

Return s after replacing all digits. It is guaranteed that shift(s[i-1], s[i]) will never exceed 'z'.

Note that shift(c, x) is not a preloaded function, but an operation to be implemented as part of the solution.

 

Example 1:

Input: s = "a1c1e1"
Output: "abcdef"
Explanation: The digits are replaced as follows:
- s[1] -> shift('a',1) = 'b'
- s[3] -> shift('c',1) = 'd'
- s[5] -> shift('e',1) = 'f'
Example 2:

Input: s = "a1b2c3d4e"
Output: "abbdcfdhe"
Explanation: The digits are replaced as follows:
- s[1] -> shift('a',1) = 'b'
- s[3] -> shift('b',2) = 'd'
- s[5] -> shift('c',3) = 'f'
- s[7] -> shift('d',4) = 'h'
 

Constraints:

1 <= s.length <= 100
s consists only of lowercase English letters and digits.
shift(s[i-1], s[i]) <= 'z' for all odd indices i.
*/

//***************Solution********************
/*
abcdef
012345
a1b2c3 d4e
abbdcf dhe

*/
public class Solution {
    public string ReplaceDigits(string s) {
    var sb = new StringBuilder(s);

    //start from 1 , loop through s length, increase by 2 each iteration
    //last index + current index, offset with '0', convert to char and store at current string builder
       for(int i = 1; i < s.Length; i += 2)
           sb[i] = (char)(s[i - 1] + s[i] - '0');
       
       //convert to string and return result.
       return sb.ToString();
    }
}
