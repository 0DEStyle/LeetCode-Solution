/*Challenge link:https://leetcode.com/problems/first-unique-character-in-a-string/description/
Question:
Given a string s, find the first non-repeating character in it and return its index. If it does not exist, return -1.

 

Example 1:

Input: s = "leetcode"
Output: 0
Example 2:

Input: s = "loveleetcode"
Output: 2
Example 3:

Input: s = "aabb"
Output: -1
 

Constraints:

1 <= s.length <= 105
s consists of only lowercase English letters.
*/

//***************Solution********************
public class Solution {
    public int FirstUniqChar(string s) {
        //if strign is null or empty, return -1
         if (string.IsNullOrEmpty(s))
            return -1;

        // Stores the frequency of string s
        int[] freq = new int[26]; 

        //loop through each character in s, increase ch -'a' index in freq by 1
        foreach (char ch in s)
            freq[ch - 'a']++;

        //loop s.length, set ch to current index of s
        //if freq == 1, return i
        for (int i = 0; i < s.Length; i++) {
            char ch = s[i];
            if (freq[ch - 'a'] == 1)
                return i;
        }
        //no match
        return -1;
    }
}
