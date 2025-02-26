/*Challenge link:https://leetcode.com/problems/second-largest-digit-in-a-string/description/
Question:
Given an alphanumeric string s, return the second largest numerical digit that appears in s, or -1 if it does not exist.

An alphanumeric string is a string consisting of lowercase English letters and digits.

 

Example 1:

Input: s = "dfa12321afd"
Output: 2
Explanation: The digits that appear in s are [1, 2, 3]. The second largest digit is 2.
Example 2:

Input: s = "abc1111"
Output: -1
Explanation: The digits that appear in s are [1]. There is no second largest digit. 
 

Constraints:

1 <= s.length <= 500
s consists of only lowercase English letters and digits.
*/

//***************Solution********************
public class Solution {
    public int SecondHighest(string s) {
        int l = -1, l2 = -1;

        foreach (var c in s){
            if (Char.IsDigit(c)){
                //offset character ascii value with 0
                var x = c - '0';
                if (x > l){
                    l2 = l;
                    l = x;
                }
                else if ((x != l) && (x > l2))
                    l2 = x;
            }
        }
        return l2;
    }
}
