/*Challenge link:https://leetcode.com/problems/base-7/description/
Question:
Given an integer num, return a string of its base 7 representation.

 

Example 1:

Input: num = 100
Output: "202"
Example 2:

Input: num = -7
Output: "-10"
 

Constraints:

-107 <= num <= 107
*/

//***************Solution********************
public class Solution {
    public string ConvertToBase7(int num){
        //0
        if (num == 0) return "0";

        //negative sign
        var isNegative = num < 0;
        num *= isNegative ? -1 : 1;

        var result = "";
        while (num > 0){
            var digit = num % 7;
            num /= 7;
            result = digit.ToString() + result;
        }

        result = isNegative ? "-" + result : result;
        
        return result.ToString();

    }
}
