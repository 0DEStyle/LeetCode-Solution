/*Challenge link:https://leetcode.com/problems/minimum-operations-to-reduce-x-to-zero/description/
Question:
You are given an integer array nums and an integer x. In one operation, you can either remove the leftmost or the rightmost element from the array nums and subtract its value from x. Note that this modifies the array for future operations.

Return the minimum number of operations to reduce x to exactly 0 if it is possible, otherwise, return -1.

 

Example 1:

Input: nums = [1,1,4,2,3], x = 5
Output: 2
Explanation: The optimal solution is to remove the last two elements to reduce x to zero.
Example 2:

Input: nums = [5,6,7,8,9], x = 4
Output: -1
Example 3:

Input: nums = [3,2,20,1,1,3], x = 10
Output: 5
Explanation: The optimal solution is to remove the last three elements and the first two elements (5 operations in total) to reduce x to zero.
 

Constraints:

1 <= nums.length <= 105
1 <= nums[i] <= 104
1 <= x <= 109
*/

//***************Solution********************
//2 pointers
public class Solution {
    public int MinOperations(int[] nums, int x) {
        int sum = 0, maxLength = -1, currSum = 0, l = 0, r = 0;

        //accumulate sum
        foreach (int num in nums)
            sum += num;

        //loop while r is less than nums.length
        while (r < nums.Length){
            //accumulate num[r] to current sum
            currSum += nums[r];

            //while l is less than r AND current sum is greater than sum - target
            while (l <= r && currSum > sum - x)
            //remove num[l++] from current sum
                currSum -= nums[l++];

            //if target matches, sum - x, then select max value between maxlength and r-l+1
            if (currSum == sum - x)
                maxLength = Math.Max(maxLength, r - l + 1);
            //increase r by 1 for next iteration
            r++;
        }
        //if max length is -1, return -1, else nums.length - maxlength
        return maxLength == -1 ? -1 : nums.Length - maxLength;


    }
}
