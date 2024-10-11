/*Challenge link:https://leetcode.com/problems/maximum-number-of-balloons/description/
Question:
Given a string text, you want to use the characters of text to form as many instances of the word "balloon" as possible.

You can use each character in text at most once. Return the maximum number of instances that can be formed.

 

Example 1:



Input: text = "nlaebolko"
Output: 1
Example 2:



Input: text = "loonbalxballpoon"
Output: 2
Example 3:

Input: text = "leetcode"
Output: 0
 

Constraints:

1 <= text.length <= 104
text consists of lower case English letters only.
 

Note: This question is the same as 2287: Rearrange Characters to Make Target String.
*/

//***************Solution********************
public class Solution {
    public int MaxNumberOfBalloons(string text) {
        //26 letters, set min to max int value
        var letters = new int[26];
        int min = Int32.MaxValue;

        //loop through each char in text
        //accumulate letter at index c - 'a' by 1
        foreach(char c in text)
            letters[c - 'a']++;
        
        //balloon uses l and o twice
        letters['l' - 'a'] /= 2;
        letters['o' - 'a'] /= 2;

        //loop through each c in the string "balloon"
        //select min valu between current min and character at c - 'a'
        foreach(char c in "balloon")
            min = Math.Min(letters[c - 'a'], min);
        
        //return min number of instances.
        return min;
    }
}
