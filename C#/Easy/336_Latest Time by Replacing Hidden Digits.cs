/*Challenge link:https://leetcode.com/problems/latest-time-by-replacing-hidden-digits/description/
Question:
You are given a string time in the form of  hh:mm, where some of the digits in the string are hidden (represented by ?).

The valid times are those inclusively between 00:00 and 23:59.

Return the latest valid time you can get from time by replacing the hidden digits.

 

Example 1:

Input: time = "2?:?0"
Output: "23:50"
Explanation: The latest hour beginning with the digit '2' is 23 and the latest minute ending with the digit '0' is 50.
Example 2:

Input: time = "0?:3?"
Output: "09:39"
Example 3:

Input: time = "1?:22"
Output: "19:22"
 

Constraints:

time is in the format hh:mm.
It is guaranteed that you can produce a valid time from the given string.
*/

//***************Solution********************
public class Solution {
    public string MaximumTime(string time) {
        char[] c = time.ToCharArray();

        //if character at current index is ?

        //set 4th to 9(0 cap)
        //set 3rd to 5(60 cap)
        //if 0 is ? or digit is 2, set 1st to 3(24 cap), else 9(0 cap)
        //if 1 greater than 3, set 0 to 1 else 2
        if (c[4] is '?') c[4] = '9';
        if (c[3] is '?') c[3] = '5';
        if (c[1] is '?') c[1] = c[0] is '?' or '2' ? '3' : '9';
        if (c[0] is '?') c[0] = c[1] > '3' ? '1' : '2';

        return new string(c);
    }
}
