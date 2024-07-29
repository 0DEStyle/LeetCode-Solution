/*Challenge link:https://leetcode.com/problems/number-of-segments-in-a-string/description/
Question:
Given a string s, return the number of segments in the string.

A segment is defined to be a contiguous sequence of non-space characters.

 

Example 1:

Input: s = "Hello, my name is John"
Output: 5
Explanation: The five segments are ["Hello,", "my", "name", "is", "John"]
Example 2:

Input: s = "Hello"
Output: 1
 

Constraints:

0 <= s.length <= 300
s consists of lowercase and uppercase English letters, digits, or one of the following characters "!@#$%^&*()_+-=',.:".
The only space character in s is ' '.
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Solution {
    public int CountSegments(string s) => s.Split(" ", StringSplitOptions.RemoveEmptyEntries).Length;
}

//method 2
public class Solution {
    public int CountSegments(string s) {
        var res = 0;
        var counterOn = true;

        //loop through s.length
        //set item to current element
        //if item is space, counteron = true,
        //else if counteron is true, increase res by 1, set counteron to false
        for (var i = 0; i < s.Length; i++) {
            var item = s[i];
            if (item == ' ')
                counterOn = true;
            else if (counterOn) {
                res++;
                counterOn = false;
            }
        }
        return res;
    }
}
