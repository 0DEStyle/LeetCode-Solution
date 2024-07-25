/*Challenge link:https://leetcode.com/problems/ransom-note/description/
Question:
Given two strings ransomNote and magazine, return true if ransomNote can be constructed by using the letters from magazine and false otherwise.

Each letter in magazine can only be used once in ransomNote.

 

Example 1:

Input: ransomNote = "a", magazine = "b"
Output: false
Example 2:

Input: ransomNote = "aa", magazine = "ab"
Output: false
Example 3:

Input: ransomNote = "aa", magazine = "aab"
Output: true
 

Constraints:

1 <= ransomNote.length, magazine.length <= 105
ransomNote and magazine consist of lowercase English letters.
*/

//***************Solution********************
public class Solution {
    public bool CanConstruct(string ransomNote, string magazine) {
        var list = new List<char>(magazine);

        //loop randsomeNote length
        //if randomsnote at index i was not removed from the list, return false.
            for (int i = 0; i < ransomNote.Length; i++)
                if (!list.Remove(ransomNote[i]))
                    return false;
            return true;
    }
}
