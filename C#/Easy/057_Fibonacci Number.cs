/*Challenge link:https://leetcode.com/problems/fibonacci-number/description/
Question:
The Fibonacci numbers, commonly denoted F(n) form a sequence, called the Fibonacci sequence, such that each number is the sum of the two preceding ones, starting from 0 and 1. That is,

F(0) = 0, F(1) = 1
F(n) = F(n - 1) + F(n - 2), for n > 1.
Given n, calculate F(n).

 

Example 1:

Input: n = 2
Output: 1
Explanation: F(2) = F(1) + F(0) = 1 + 0 = 1.
Example 2:

Input: n = 3
Output: 2
Explanation: F(3) = F(2) + F(1) = 1 + 1 = 2.
Example 3:

Input: n = 4
Output: 3
Explanation: F(4) = F(3) + F(2) = 2 + 1 = 3.
 

Constraints:

0 <= n <= 30
*/

//***************Solution********************
public class Solution {
public int Fib(int n) {
    if (n <= 1) 
        return n;

    //create dp 31, Constraints: 0 <= n <= 30, fill array with -1
    var dp = new int[31];
    Array.Fill(dp, -1); 
    // Temporary variables to store values of Fib(n-1) & Fib(n-2)
    int first, second;

    //if value at n - 1 is not -1, set it to first
    //else set first to fib(n-1)
    if (dp[n - 1] != -1)
        first = dp[n - 1];
    else
        first = Fib(n - 1);

    //if value at n - 2 is not -1, set it to second
    //else set second to fib(n-2)
    if (dp[n - 2] != -1) 
        second = dp[n - 2];
    else 
        second = Fib(n - 2);

    // Memoization
    return dp[n] = first + second;
}
}
