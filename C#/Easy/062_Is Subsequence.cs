/*Challenge link:https://leetcode.com/problems/is-subsequence/description/
Question:
Given two strings s and t, return true if s is a subsequence of t, or false otherwise.

A subsequence of a string is a new string that is formed from the original string by deleting some (can be none) of the characters without disturbing the relative positions of the remaining characters. (i.e., "ace" is a subsequence of "abcde" while "aec" is not).

 

Example 1:

Input: s = "abc", t = "ahbgdc"
Output: true
Example 2:

Input: s = "axc", t = "ahbgdc"
Output: false
 

Constraints:

0 <= s.length <= 100
0 <= t.length <= 104
s and t consist only of lowercase English letters.
 

Follow up: Suppose there are lots of incoming s, say s1, s2, ..., sk where k >= 109, and you want to check one by one to see if t has its subsequence. In this scenario, how would you change your code?
*/

//***************Solution********************

public class Solution {
    public bool IsSubsequence(string s, string t) {
        int i = 0, j = 0;
        //loop while i and j are less than length
        while (i < s.Length && j < t.Length) {
            //if s at index i equal to t at index j, increase i
            if (s[i] == t[j])
                i++;
            j++;
        }
        //return a bool value
        return i == s.Length;
    }
}
