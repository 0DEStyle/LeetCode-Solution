/*Challenge link:https://leetcode.com/problems/split-a-string-in-balanced-strings/description/
Question:
Balanced strings are those that have an equal quantity of 'L' and 'R' characters.

Given a balanced string s, split it into some number of substrings such that:

Each substring is balanced.
Return the maximum number of balanced strings you can obtain.

 

Example 1:

Input: s = "RLRRLLRLRL"
Output: 4
Explanation: s can be split into "RL", "RRLL", "RL", "RL", each substring contains same number of 'L' and 'R'.
Example 2:

Input: s = "RLRRRLLRLL"
Output: 2
Explanation: s can be split into "RL", "RRRLLRLL", each substring contains same number of 'L' and 'R'.
Note that s cannot be split into "RL", "RR", "RL", "LR", "LL", because the 2nd and 5th substrings are not balanced.
Example 3:

Input: s = "LLLLRRRR"
Output: 1
Explanation: s can be split into "LLLLRRRR".
 

Constraints:

2 <= s.length <= 1000
s[i] is either 'L' or 'R'.
s is a balanced string.
*/

//***************Solution********************
public class Solution {
    public int BalancedStringSplit(string s) {
        //count, l and r count
        int cnt = 0,lCount = 0,rCount = 0;

        //loop through s.length
        //if current element is r, add 1 to r
        //else add 1 to l
        //if l and r are equal, count plus 1
        for(int i = 0; i < s.Length;i++){
            if(s[i] == 'R')
                 rCount++;
            else 
                lCount++;
            if(lCount == rCount) 
                cnt++;
        }
        return cnt;
    }
}
