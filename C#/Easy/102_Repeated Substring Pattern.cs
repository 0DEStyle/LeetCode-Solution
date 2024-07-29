/*Challenge link:https://leetcode.com/problems/repeated-substring-pattern/description/
Question:
Given a string s, check if it can be constructed by taking a substring of it and appending multiple copies of the substring together.

 

Example 1:

Input: s = "abab"
Output: true
Explanation: It is the substring "ab" twice.
Example 2:

Input: s = "aba"
Output: false
Example 3:

Input: s = "abcabcabcabc"
Output: true
Explanation: It is the substring "abc" four times or the substring "abcabc" twice.
 

Constraints:

1 <= s.length <= 104
s consists of lowercase English letters.
*/

//***************Solution********************

/*
Concatenate to get "abababab".
Remove first and last characters to get "bababa".
Check if "abab" is present in "bababa" - It is. Hence, return True.
*/
public class Solution {
    public bool RepeatedSubstringPattern(string s) {
        string doubled = s + s;
        string sub = doubled.Substring(1, doubled.Length - 2);
        return sub.Contains(s);
    }
}
