/*Challenge link:https://leetcode.com/problems/perfect-number/description/
Question:
A perfect number is a positive integer that is equal to the sum of its positive divisors, excluding the number itself. A divisor of an integer x is an integer that can divide x evenly.

Given an integer n, return true if n is a perfect number, otherwise return false.

 

Example 1:

Input: num = 28
Output: true
Explanation: 28 = 1 + 2 + 4 + 7 + 14
1, 2, 4, 7, and 14 are all divisors of 28.
Example 2:

Input: num = 7
Output: false
 

Constraints:

1 <= num <= 108
*/

//***************Solution********************
public class Solution {
    //check bool value with method GetSumOfDivisors
    public bool CheckPerfectNumber(int num) => GetSumOfDivisors(num) == num;

    private static int GetSumOfDivisors(int num){
        int sum = 0;
        //from i up to sqare root of num
        //if num mod i is 0, accumulate sum by i
        //if i is not equal to num / i, accumulate sum with num / i
        for (int i = 1; i <= Math.Sqrt(num); i++){
            if (num % i == 0){
                sum += i;
                if (i != num / i)
                    sum += num / i;
            }
        }
        //get differrence between sum and num
        return sum - num;
    }
}
