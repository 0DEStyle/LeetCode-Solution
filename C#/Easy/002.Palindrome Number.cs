/*Challenge link:https://leetcode.com/problems/palindrome-number/
Question:
Example 1:

Input: x = 121
Output: true
Explanation: 121 reads as 121 from left to right and from right to left.
Example 2:

Input: x = -121
Output: false
Explanation: From left to right, it reads -121. From right to left, it becomes 121-. Therefore it is not a palindrome.
Example 3:

Input: x = 10
Output: false
Explanation: Reads 01 from right to left. Therefore it is not a palindrome.
 

Constraints:

-231 <= x <= 231 - 1
 

Follow up: Could you solve it without converting the integer to a string?
*/

//***************Solution********************
public class Solution {
    public bool IsPalindrome(int x) {
        //if x is less than zero, meaning it contains negative sign
        if(x < 0) return false;
        
        int quotient = x, res = 0, rem = 0;

        //reverse number digit by digit.
        while(quotient != 0){
            rem = quotient % 10;
            res = res * 10 + rem;
            quotient /= 10;
        }
        //return bool value to check if result is equal to x
        return res == x;
    }
}
