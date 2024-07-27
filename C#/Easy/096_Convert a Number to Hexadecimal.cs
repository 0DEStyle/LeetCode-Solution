/*Challenge link:https://leetcode.com/problems/convert-a-number-to-hexadecimal/description/
Question:
Given an integer num, return a string representing its hexadecimal representation. For negative integers, two’s complement method is used.

All the letters in the answer string should be lowercase characters, and there should not be any leading zeros in the answer except for the zero itself.

Note: You are not allowed to use any built-in library method to directly solve this problem.

 

Example 1:

Input: num = 26
Output: "1a"
Example 2:

Input: num = -1
Output: "ffffffff"
 

Constraints:

-231 <= num <= 231 - 1
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Solution {
    public string ToHex(int num) => num.ToString("X").ToLower();
}

//faster solution
public class Solution {
    //hex order
    private const string hex = "0123456789abcdef";
    public string ToHex(int num) {
        //if num is 0, return "0"
        if (num == 0) 
            return "0";
        

        var res = new StringBuilder();
        //if num is greater than 0, set n to num
        //else convert 2 to long, bit shift left 31, add num
        var n = num > 0 ? num : ((long)2 << 31) + num;

        //index 0 at index n % 16
        //divide n by 16
        while (n > 0) {
            res.Insert(0, hex[(int)(n % 16)]);
            n /= 16;
        }
        return res.ToString();
    }
}
