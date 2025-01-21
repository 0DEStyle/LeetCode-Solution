/*Challenge link:https://leetcode.com/problems/check-if-binary-string-has-at-most-one-segment-of-ones/description/
Question:
Given a binary string s ​​​​​without leading zeros, return true​​​ if s contains at most one contiguous segment of ones. Otherwise, return false.

 

Example 1:

Input: s = "1001"
Output: false
Explanation: The ones do not form a contiguous segment.
Example 2:

Input: s = "110"
Output: true
 

Constraints:

1 <= s.length <= 100
s[i]​​​​ is either '0' or '1'.
s[0] is '1'.
*/

//***************Solution********************
//answer is true if last 1 is before 0, or no zeros at all.

public class Solution {
    public bool CheckOnesSegment(string s) =>
     s.IndexOf('0') > s.LastIndexOf('1') || s.IndexOf('0') == -1;
}
