/*Challenge link:https://leetcode.com/problems/count-the-number-of-consistent-strings/description/
Question:
You are given a string allowed consisting of distinct characters and an array of strings words. A string is consistent if all characters in the string appear in the string allowed.

Return the number of consistent strings in the array words.

 

Example 1:

Input: allowed = "ab", words = ["ad","bd","aaab","baa","badab"]
Output: 2
Explanation: Strings "aaab" and "baa" are consistent since they only contain characters 'a' and 'b'.
Example 2:

Input: allowed = "abc", words = ["a","b","c","ab","ac","bc","abc"]
Output: 7
Explanation: All strings are consistent.
Example 3:

Input: allowed = "cad", words = ["cc","acd","b","ba","bac","bad","ac","d"]
Output: 4
Explanation: Strings "cc", "acd", "ac", and "d" are consistent.
 

Constraints:

1 <= words.length <= 104
1 <= allowed.length <= 26
1 <= words[i].length <= 10
The characters in allowed are distinct.
words[i] and allowed contain only lowercase English letters.
*/

//***************Solution********************

public class Solution {
    public int CountConsistentStrings(string allowed, string[] words) {
        int allowedMask = 0, count = 0;

        //off set ch to 0 by subtracting 'a', left shift by 1, Or with Mask
        foreach (var ch in allowed) 
            allowedMask |= (1 << (ch - 'a'));

        //loop through each word
        foreach (var word in words) {
            int wordMask = 0;
            //loop through each character, or with wordMask
            foreach (var ch in word) 
                wordMask |= (1 << (ch - 'a'));

            // If the word's mask is a subset of allowedMask, it's consistent
            if ((wordMask & allowedMask) == wordMask) 
                count++;
        }
        return count;
    }
}
