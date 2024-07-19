/*Challenge link:https://leetcode.com/problems/valid-anagram/description/
Question:
Given two strings s and t, return true if t is an anagram of s, and false otherwise.

An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.

 

Example 1:

Input: s = "anagram", t = "nagaram"
Output: true
Example 2:

Input: s = "rat", t = "car"
Output: false
 

Constraints:

1 <= s.length, t.length <= 5 * 104
s and t consist of lowercase English letters.
 

Follow up: What if the inputs contain Unicode characters? How would you adapt your solution to such a case?
*/

//***************Solution********************
//fast method
public class Solution {
    public bool IsAnagram(string s, string t){
        if (s.Length != t.Length) 
            return false;

        var freq = new Dictionary<char, int>();

        for (int i = 0; i < s.Length; i++) {
            freq.TryAdd(s[i], 0);
            freq.TryAdd(t[i], 0);

            freq[s[i]]++;
            freq[t[i]]--;
        }

        return freq.Values.All(x => x == 0);        
    }
}
//linq
public class Solution {
    public bool IsAnagram(string s, string t) {
        // sort both string in ascending order then compare them.
        s = String.Concat(s.OrderBy(x => x));
        t = String.Concat(t.OrderBy(x => x));
        return s == t;
    }
}
//2
public class Solution {
    public bool IsAnagram(string s, string t) => 
    String.Concat(s.OrderBy(x => x)) == String.Concat(t.OrderBy(x => x));
}
