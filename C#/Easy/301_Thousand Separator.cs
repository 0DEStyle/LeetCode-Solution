/*Challenge link:https://leetcode.com/problems/thousand-separator/description/
Question:
Given an integer n, add a dot (".") as the thousands separator and return it in string format.

 

Example 1:

Input: n = 987
Output: "987"
Example 2:

Input: n = 1234
Output: "1.234"
 

Constraints:

0 <= n <= 231 - 1
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

public class Solution {
    public string ThousandSeparator(int n) => String.Format("{0:#,##0}", n).Replace(',','.');
}
