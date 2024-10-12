/*Challenge link:https://leetcode.com/problems/delete-characters-to-make-fancy-string/description/
Question:
A fancy string is a string where no three consecutive characters are equal.

Given a string s, delete the minimum possible number of characters from s to make it fancy.

Return the final string after the deletion. It can be shown that the answer will always be unique.

 

Example 1:

Input: s = "leeetcode"
Output: "leetcode"
Explanation:
Remove an 'e' from the first group of 'e's to create "leetcode".
No three consecutive characters are equal, so return "leetcode".
Example 2:

Input: s = "aaabaaaa"
Output: "aabaa"
Explanation:
Remove an 'a' from the first group of 'a's to create "aabaaaa".
Remove two 'a's from the second group of 'a's to create "aabaa".
No three consecutive characters are equal, so return "aabaa".
Example 3:

Input: s = "aab"
Output: "aab"
Explanation: No three consecutive characters are equal, so return "aab".
 

Constraints:

1 <= s.length <= 105
s consists only of lowercase English letters.
*/

//***************Solution********************
public class Solution {
    public string MakeFancyString(string s) {
        //string builder
        var sb = new StringBuilder();

        //loop through all char
        //if length is less than 2 OR
        //if last letter of string bulder is not c OR
        //if 2nd to last letter is not c
        //append c
        foreach (var c in s)
            if (sb.Length < 2 || sb[^1] != c || sb[^2] != c)
                sb.Append(c);
        //convert to string and return the result.
        return sb.ToString();
    }
}
