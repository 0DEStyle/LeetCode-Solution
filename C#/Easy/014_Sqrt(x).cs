/*Challenge link:https://leetcode.com/problems/sqrtx/description/
Question:
Given a non-negative integer x, return the square root of x rounded down to the nearest integer. The returned integer should be non-negative as well.

You must not use any built-in exponent function or operator.

For example, do not use pow(x, 0.5) in c++ or x ** 0.5 in python.
 

Example 1:

Input: x = 4
Output: 2
Explanation: The square root of 4 is 2, so we return 2.
Example 2:

Input: x = 8
Output: 2
Explanation: The square root of 8 is 2.82842..., and since we round it down to the nearest integer, 2 is returned.
*/

//***************Solution********************
/*if x is 0 return 0

using binary tree search method, go either right or left side depend on the half way result of sqrt

set left to 1 to avoid zero division

while left is less than or equal to right

mid is left + ((right - left) /2) <-this avoids overflow
an aaproximate sqrt root will be x / mid

if sqrt == mid, meaning perfect sqrt, return mid
else if sqrt less than mid, go to right side
else go to left side.

*/
public class Solution {
    public int MySqrt(int x) {
        if(x == 0) return 0;
        int left = 1, right = x,mid,sqrt;
        
        while(left <= right){
            mid = left + (right - left) / 2;
            sqrt = x / mid;
            if(sqrt == mid) return mid;
            else if(sqrt < mid) right = mid - 1;
            else left = mid + 1;
        }
        return right; 
    }
}
