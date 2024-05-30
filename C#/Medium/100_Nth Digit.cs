/*Challenge link:https://leetcode.com/problems/nth-digit/description/
Question:
Given an integer n, return the nth digit of the infinite integer sequence [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, ...].

 

Example 1:

Input: n = 3
Output: 3
Example 2:

Input: n = 11
Output: 0
Explanation: The 11th digit of the sequence 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, ... is a 0, which is part of the number 10.
 

Constraints:

1 <= n <= 231 - 1
*/

//***************Solution********************
public class Solution {
    public int FindNthDigit(int n) {
        //set boundaries
        int len = 1, start = 1;
      //using long or out of bound
        long count = 9;

        //find the length of number where nth digit is
        while (n > len * count){
            n -= (int)(len * count);
            len += 1;
            count *= 10;
            start *= 10;
        }
        //find actual number where nth digit is from
        start += (int)((n - 1) / len);
        string s = start.ToString();

        //find the nth digitand return result
        return int.Parse(s[(int)((n - 1) % len)].ToString());
    }
}
