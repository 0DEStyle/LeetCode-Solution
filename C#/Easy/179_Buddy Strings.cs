/*Challenge link:https://leetcode.com/problems/buddy-strings/description/
Question:
Given two strings s and goal, return true if you can swap two letters in s so the result is equal to goal, otherwise, return false.

Swapping letters is defined as taking two indices i and j (0-indexed) such that i != j and swapping the characters at s[i] and s[j].

For example, swapping at indices 0 and 2 in "abcd" results in "cbad".
 

Example 1:

Input: s = "ab", goal = "ba"
Output: true
Explanation: You can swap s[0] = 'a' and s[1] = 'b' to get "ba", which is equal to goal.
Example 2:

Input: s = "ab", goal = "ab"
Output: false
Explanation: The only letters you can swap are s[0] = 'a' and s[1] = 'b', which results in "ba" != goal.
Example 3:

Input: s = "aa", goal = "aa"
Output: true
Explanation: You can swap s[0] = 'a' and s[1] = 'a' to get "aa", which is equal to goal.
 

Constraints:

1 <= s.length, goal.length <= 2 * 104
s and goal consist of lowercase letters.
*/

//***************Solution********************
public class Solution {
    public bool BuddyStrings(string s, string goal) {

        //check match length
        if (s.Length != goal.Length) 
            return false;
        var list = new List<int>();


        //add i to list if s index is not equal to goal index
        //list count greater than 2, return false
        for (int i = 0; i < s.Length; i++){
            if (s[i] != goal[i]){
                list.Add(i);
                if (list.Count > 2) 
                    return false;
            }
        }

        //list count is 0
        //length greater than 26, return true
        if (list.Count == 0){
            if (s.Length > 26) 
                return true;
            var set = new HashSet<char>();
            
            //if set contains current element, return true, add element to set
            for (int i = 0; i < s.Length; i++){
                if (set.Contains(s[i]))
                    return true;
                set.Add(s[i]);
            }
            //return false
            return false;
        }
        if (list.Count == 1) 
            return false;
        //check match
        return s[list[0]] == goal[list[1]] && s[list[1]] == goal[list[0]];
    }
}
