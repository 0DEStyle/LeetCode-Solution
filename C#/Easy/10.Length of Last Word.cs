/*Challenge link:https://leetcode.com/problems/length-of-last-word/description/
Question:
Given a string s consisting of words and spaces, return the length of the last word in the string.

A word is a maximal 
substring
 consisting of non-space characters only.

 

Example 1:

Input: s = "Hello World"
Output: 5
Explanation: The last word is "World" with length 5.
Example 2:

Input: s = "   fly me   to   the moon  "
Output: 4
Explanation: The last word is "moon" with length 4.
Example 3:

Input: s = "luffy is still joyboy"
Output: 6
Explanation: The last word is "joyboy" with length 6.
 

Constraints:

1 <= s.length <= 104
s consists of only English letters and spaces ' '.
There will be at least one word in s.
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//ref:https://learn.microsoft.com/en-us/dotnet/api/system.stringsplitoptions?view=net-8.0#fields
//Split string by space, Omit array elements that contain an empty string from the result.
//get last element, then get length
public class Solution {
    public int LengthOfLastWord(string s)  => 
    s.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).Last().Length;
}


//solution 2
//loop through each letter, starting from the end
//if current character is not empty space, add 1 to res, else if res is less than 0, return res.
public class Solution {
    public int LengthOfLastWord(string s) {
        int res = 0;
        for (int i = s.Length - 1; i >= 0; ) {
            if (s[i--] != ' ') 
                res++;
            else if(res > 0) 
                return res;
        }
        return res;
    }
}
