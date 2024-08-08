/*Challenge link:https://leetcode.com/problems/valid-palindrome-ii/description/
Question:
Given a string s, return true if the s can be palindrome after deleting at most one character from it.

 

Example 1:

Input: s = "aba"
Output: true
Example 2:

Input: s = "abca"
Output: true
Explanation: You could delete the character 'c'.
Example 3:

Input: s = "abc"
Output: false
 

Constraints:

1 <= s.length <= 105
s consists of lowercase English letters.
*/

//***************Solution********************
public class Solution {
    public bool ValidPalindrome(string s) => IsPalindrome(s, 0, s.Length - 1, false);
    
    private bool IsPalindrome(string s, int start, int end, bool hasError){
        while(start < end){
            if(s[start].Equals(s[end])){
                start++;
                end--;
                continue;
            }
            
            if(hasError) 
                return false;
            return IsPalindrome(s, start + 1, end, true) || IsPalindrome(s, start, end - 1, true);
        }
        return true;
    }
}
