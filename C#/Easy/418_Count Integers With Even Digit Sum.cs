/*Challenge link:https://leetcode.com/problems/count-integers-with-even-digit-sum/description/
Question:
Given a positive integer num, return the number of positive integers less than or equal to num whose digit sums are even.

The digit sum of a positive integer is the sum of all its digits.

 

Example 1:

Input: num = 4
Output: 2
Explanation:
The only integers less than or equal to 4 whose digit sums are even are 2 and 4.    
Example 2:

Input: num = 30
Output: 14
Explanation:
The 14 integers less than or equal to 30 whose digit sums are even are
2, 4, 6, 8, 11, 13, 15, 17, 19, 20, 22, 24, 26, and 28.
 

Constraints:

1 <= num <= 1000
*/

//***************Solution********************
public class Solution {
    public int CountEven(int n) {
        int sum = n + (n / 10) + (n / 100) + (n / 1000);
        return (n - (sum & 1)) / 2;
    }
}
