/*Challenge link:https://leetcode.com/problems/reformat-the-string/description/
Question:
You are given an alphanumeric string s. (Alphanumeric string is a string consisting of lowercase English letters and digits).

You have to find a permutation of the string where no letter is followed by another letter and no digit is followed by another digit. That is, no two adjacent characters have the same type.

Return the reformatted string or return an empty string if it is impossible to reformat the string.

 

Example 1:

Input: s = "a0b1c2"
Output: "0a1b2c"
Explanation: No two adjacent characters have the same type in "0a1b2c". "a0b1c2", "0a1b2c", "0c2a1b" are also valid permutations.
Example 2:

Input: s = "leetcode"
Output: ""
Explanation: "leetcode" has only characters so we cannot separate them by digits.
Example 3:

Input: s = "1229857369"
Output: ""
Explanation: "1229857369" has only digits so we cannot separate them by characters.
 

Constraints:

1 <= s.length <= 500
s consists of only lowercase English letters and/or digits.
*/

//***************Solution********************
public class Solution {
    public string Reformat(string s) {
        //letter and digit
        List<char> l = new List<char>(), d = new List<char>();

        //loop through all characters, if ascii is greater than a, add to letter
        //else add to digit
        for(int i = 0; i < s.Length; i++){
            if(s[i] >= 'a')
               l.Add(s[i]);
            else
               d.Add(s[i]);
        }
        
        //if diff greater than 1, return nothing
        if(Math.Abs(l.Count - d.Count) > 1)
            return "";
        else{
            //if count equal, zip and concat result
            //else if letter count is greater than digit, append l 
            //else append d 
            if(l.Count == d.Count)
                return string.Concat(l.Zip(d, (x, y) => $"{x}{y}"));
            else if(l.Count > d.Count)
                return string.Concat(l.Zip(d, (x, y) => $"{x}{y}")) + l[l.Count - 1];
            else
                return string.Concat(d.Zip(l, (x, y) => $"{x}{y}")) + d[d.Count - 1];
            }
}}
