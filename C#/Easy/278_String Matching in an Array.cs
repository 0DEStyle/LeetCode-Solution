/*Challenge link:https://leetcode.com/problems/string-matching-in-an-array/description/
Question:
Given an array of string words, return all strings in words that is a substring of another word. You can return the answer in any order.

A substring is a contiguous sequence of characters within a string

 

Example 1:

Input: words = ["mass","as","hero","superhero"]
Output: ["as","hero"]
Explanation: "as" is substring of "mass" and "hero" is substring of "superhero".
["hero","as"] is also a valid answer.
Example 2:

Input: words = ["leetcode","et","code"]
Output: ["et","code"]
Explanation: "et", "code" are substring of "leetcode".
Example 3:

Input: words = ["blue","green","bu"]
Output: []
Explanation: No string of words is substring of another string.
 

Constraints:

1 <= words.length <= 100
1 <= words[i].length <= 30
words[i] contains only lowercase English letters.
All the strings of words are unique.
*/

//***************Solution********************
public class Solution {
    public IList<string> StringMatching(string[] words) {
        List<string> res = new();
        string s;

        //loop through words length
        //set s(temnp) to current word
        //update current to nothing
        for(int i = 0; i < words.Length; i++){
            s = words[i];
            words[i] = "";

            //if index s of words combined is greater or equal to 0, add s to result.
            if(String.Join(" ",words).IndexOf(s) >= 0)
                res.Add(s);
            
            //put s back into current words for next iternation
            words[i] = s;
        }
        return res;
    }
}