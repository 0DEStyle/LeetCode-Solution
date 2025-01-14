/*Challenge link:https://leetcode.com/problems/longest-nice-substring/description/
Question:
A string s is nice if, for every letter of the alphabet that s contains, it appears both in uppercase and lowercase. For example, "abABB" is nice because 'A' and 'a' appear, and 'B' and 'b' appear. However, "abA" is not because 'b' appears, but 'B' does not.

Given a string s, return the longest substring of s that is nice. If there are multiple, return the substring of the earliest occurrence. If there are none, return an empty string.

 

Example 1:

Input: s = "YazaAay"
Output: "aAa"
Explanation: "aAa" is a nice string because 'A/a' is the only letter of the alphabet in s, and both 'A' and 'a' appear.
"aAa" is the longest nice substring.
Example 2:

Input: s = "Bb"
Output: "Bb"
Explanation: "Bb" is a nice string because both 'B' and 'b' appear. The whole string is a substring.
Example 3:

Input: s = "c"
Output: ""
Explanation: There are no nice substrings.
 

Constraints:

1 <= s.length <= 100
s consists of uppercase and lowercase English letters.
*/

//***************Solution********************
public class Solution {
    public string LongestNiceSubstring(string s) => DFS(s);

    //helper function
    private string DFS(string s){
        var ans = new HashSet<char>(s);

        //return empty if length is less than 2 letters
        if(s.Length < 2)
            return "";
        
        //loop through each character
        for(int i = 0; i < s.Length; i++){
            //if ans doesn't contain lower or upper case of current letter
            //pass 0, i substring into DFS (before)
            //pass i + 1, s.length - i - 1 into DFS (after)
            //if s2 length greater than s1, return s2, else s1
            if(!ans.Contains(char.ToLower(s[i])) || !ans.Contains(char.ToUpper(s[i]))){
                string str1 = DFS(s.Substring(0,i));
                string str2 = DFS(s.Substring(i+1, s.Length-i-1));
                return str2.Length > str1.Length ? str2 : str1;
            }
        }
        return s;
}}
