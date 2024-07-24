/*Challenge link:https://leetcode.com/problems/reverse-string/description/
Question:
Write a function that reverses a string. The input string is given as an array of characters s.

You must do this by modifying the input array in-place with O(1) extra memory.

 

Example 1:

Input: s = ["h","e","l","l","o"]
Output: ["o","l","l","e","h"]
Example 2:

Input: s = ["H","a","n","n","a","h"]
Output: ["h","a","n","n","a","H"]
 

Constraints:

1 <= s.length <= 105
s[i] is a printable ascii character.
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Solution {
    public void ReverseString(char[] s) => Array.Reverse(s);
}

//method 2, slower
public class Solution {
    public void ReverseString(char[] s){
        //reverse order
        for (int i = 1; i <= s.Length / 2; i++)
            (s[i - 1], s[^i]) = (s[^i], s[i - 1]);
    }
}
