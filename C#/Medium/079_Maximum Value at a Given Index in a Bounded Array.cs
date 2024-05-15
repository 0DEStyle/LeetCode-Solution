/*Challenge link:https://leetcode.com/problems/maximum-value-at-a-given-index-in-a-bounded-array/description/
Question:
You are given three positive integers: n, index, and maxSum. You want to construct an array nums (0-indexed) that satisfies the following conditions:

nums.length == n
nums[i] is a positive integer where 0 <= i < n.
abs(nums[i] - nums[i+1]) <= 1 where 0 <= i < n-1.
The sum of all the elements of nums does not exceed maxSum.
nums[index] is maximized.
Return nums[index] of the constructed array.

Note that abs(x) equals x if x >= 0, and -x otherwise.

 

Example 1:

Input: n = 4, index = 2,  maxSum = 6
Output: 2
Explanation: nums = [1,2,2,1] is one array that satisfies all the conditions.
There are no arrays that satisfy all the conditions and have nums[2] == 3, so 2 is the maximum nums[2].
Example 2:

Input: n = 6, index = 1,  maxSum = 10
Output: 3
 

Constraints:

1 <= n <= maxSum <= 109
0 <= index < n
*/

//***************Solution********************
public class Solution {
    public int MaxValue(int n, int index, int maxSum) {
        maxSum -= n;
        int left = 0, right = maxSum, mid;

        while (left < right){
            //find mid index
            mid = (left + right + 1) / 2;
            //check condition, if true set left to mid, else shift right to left by 1 index
            if (Test(n, index, mid) <= maxSum)
                left = mid;
            else
                right = mid - 1;
        }
        //return left + 1
        return left + 1;
        }

        //(n,index,mid) => (n, index, a)
        private long Test(int n, int index, int a){
            //for left, select max value between mid -index and 0, store in b
            //The sum of arithmetic sequence {b, b+1, ....a}, equals to (a + b) * (a - b + 1) / 2.
            int b = Math.Max(a - index, 0);
            long res = (long)(a + b) * (a - b + 1) / 2;

            //select max value for right 
            b = Math.Max(a - ((n - 1) - index), 0);
            res += (long)(a + b) * (a - b + 1) / 2;
            return res - a;
        }
}
