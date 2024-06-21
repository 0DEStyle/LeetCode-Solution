/*Challenge link:https://leetcode.com/problems/numbers-at-most-n-given-digit-set/description/
Question:
Given an array of digits which is sorted in non-decreasing order. You can write numbers using each digits[i] as many times as we want. For example, if digits = ['1','3','5'], we may write numbers such as '13', '551', and '1351315'.

Return the number of positive integers that can be generated that are less than or equal to a given integer n.

 

Example 1:

Input: digits = ["1","3","5","7"], n = 100
Output: 20
Explanation: 
The 20 numbers that can be written are:
1, 3, 5, 7, 11, 13, 15, 17, 31, 33, 35, 37, 51, 53, 55, 57, 71, 73, 75, 77.
Example 2:

Input: digits = ["1","4","9"], n = 1000000000
Output: 29523
Explanation: 
We can write 3 one digit numbers, 9 two digit numbers, 27 three digit numbers,
81 four digit numbers, 243 five digit numbers, 729 six digit numbers,
2187 seven digit numbers, 6561 eight digit numbers, and 19683 nine digit numbers.
In total, this is 29523 integers that can be written using the digits array.
Example 3:

Input: digits = ["7"], n = 8
Output: 1
 

Constraints:

1 <= digits.length <= 9
digits[i].length == 1
digits[i] is a digit from '1' to '9'.
All the values in digits are unique.
digits is sorted in non-decreasing order.
1 <= n <= 109
*/

//***************Solution********************
public class Solution {
    public int AtMostNGivenDigitSet(string[] digits, int n) {
        var N = n.ToString().ToCharArray();
        int len = N.Length, res = 1, pres = 1, smaller = -1;

        //loop from i up to N.length
        for (int i = 1, m = 1; i <= len; i++, m *= digits.Length){
            pres = res;
            res = 0;
            //get current element of n - '0', set to x
            int x = N[len - i] - '0';

            //loop through each digit in digits
            //if current digit is less than x, increase res by m
            //else if current digit is equal to x, increase res by pres
            foreach (string d in digits){
                if (int.Parse(d) < x) 
                    res += m;
                else if (int.Parse(d) == x) 
                    res += pres;
            }
            //update smaller by m for next iteration
            smaller += m;
        }
        return res + smaller;
    }
}
