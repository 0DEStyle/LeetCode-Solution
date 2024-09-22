/*Challenge link:https://leetcode.com/problems/occurrences-after-bigram/description/
Question:
Given two strings first and second, consider occurrences in some text of the form "first second third", where second comes immediately after first, and third comes immediately after second.

Return an array of all the words third for each occurrence of "first second third".

 

Example 1:

Input: text = "alice is a good girl she is a good student", first = "a", second = "good"
Output: ["girl","student"]
Example 2:

Input: text = "we will we will rock you", first = "we", second = "will"
Output: ["we","rock"]
 

Constraints:

1 <= text.length <= 1000
text consists of lowercase English letters and spaces.
All the words in text are separated by a single space.
1 <= first.length, second.length <= 10
first and second consist of lowercase English letters.
text will not have any leading or trailing spaces.
*/

//***************Solution********************
public class Solution {
    public string[] FindOcurrences(string text, string first, string second) {
        //split by space
        var words = text.Split(" ");
        var res = new List<string>();

        //loop through  word's length
        //if current word equal to second AND last word equal to first
        //add next word into res
        for(int i = 1;i < words.Length - 1;i++)
            if(words[i] == second && words[i-1] == first)
                res.Add(words[i+1]);

        return res.ToArray();
    }
}
