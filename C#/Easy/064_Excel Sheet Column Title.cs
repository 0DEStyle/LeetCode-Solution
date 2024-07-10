/*Challenge link:https://leetcode.com/problems/excel-sheet-column-title/description/
Question:
Given an integer columnNumber, return its corresponding column title as it appears in an Excel sheet.

For example:

A -> 1
B -> 2
C -> 3
...
Z -> 26
AA -> 27
AB -> 28 
...
 

Example 1:

Input: columnNumber = 1
Output: "A"
Example 2:

Input: columnNumber = 28
Output: "AB"
Example 3:

Input: columnNumber = 701
Output: "ZY"
 

Constraints:

1 <= columnNumber <= 231 - 1
*/

//***************Solution********************
public class Solution {
    public string ConvertToTitle(int n) {
        string res = "";
        //loop while n greater than 0
        //decrease n by 1
        //get ASCII value, set to c
        //accumulate string c + res, divide n by 26 then go for next iteration
        while (n > 0) {
            n--;
            char c = (char) ('A' + n % 26);
            res = c + res;
            n /= 26;
        }
        return res;
    }
}
