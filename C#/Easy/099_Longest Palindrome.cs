/*Challenge link:https://leetcode.com/problems/longest-palindrome/description/
Question:
Given a string s which consists of lowercase or uppercase letters, return the length of the longest 
palindrome
 that can be built with those letters.

Letters are case sensitive, for example, "Aa" is not considered a palindrome.

 

Example 1:

Input: s = "abccccdd"
Output: 7
Explanation: One longest palindrome that can be built is "dccaccd", whose length is 7.
Example 2:

Input: s = "a"
Output: 1
Explanation: The longest palindrome that can be built is "a", whose length is 1.
 

Constraints:

1 <= s.length <= 2000
s consists of lowercase and/or uppercase English letters only.
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Solution {
    public int LongestPalindrome(string s) {
        var set = new HashSet<char>();
        var maxLength = 0;

        //loop through each character in string s
        //if set contains ch, remove ch, add maxlength by 2
        //else add ch.
        foreach (var ch in s){
            if (set.Contains(ch)){
                set.Remove(ch);
                maxLength += 2;
            }
            else
                set.Add(ch);
        }
        //if count is greater than 0, return maxlength + 1(mid)
        //else maxlength
        return set.Count > 0 ? maxLength + 1 : maxLength;
    }
}
