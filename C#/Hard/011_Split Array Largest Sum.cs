/*Challenge link:https://leetcode.com/problems/split-array-largest-sum/description/
Question:
Given an integer array nums and an integer k, split nums into k non-empty subarrays such that the largest sum of any subarray is minimized.

Return the minimized largest sum of the split.

A subarray is a contiguous part of the array.

 

Example 1:

Input: nums = [7,2,5,10,8], k = 2
Output: 18
Explanation: There are four ways to split nums into two subarrays.
The best way is to split it into [7,2,5] and [10,8], where the largest sum among the two subarrays is only 18.
Example 2:

Input: nums = [1,2,3,4,5], k = 2
Output: 9
Explanation: There are four ways to split nums into two subarrays.
The best way is to split it into [1,2,3] and [4,5], where the largest sum among the two subarrays is only 9.
 

Constraints:

1 <= nums.length <= 1000
0 <= nums[i] <= 106
1 <= k <= min(50, nums.length)
*/

//***************Solution********************
public class Solution {
    public int SplitArray(int[] nums, int k) {
        //validation local function
        bool IsHighEnough(int target){
            int sum = 0, count = 1;

            //loop through num in nums
            //accumulate sum
            //if sum is greater than target, set sum to n,
            //if count is greater than k, return false.
            foreach (int n in nums){
                sum += n;
                if (sum > target){
                    sum = n;
                    if (++count > k) 
                        return false;
                }
            }
            return true;
        }

        //set boundaries
        int lo = nums.Max(), hi = nums.Sum();
            
        while (lo < hi){
            //find mid index
            int mid = lo + (hi - lo) / 2;
            //check validation
            if (IsHighEnough(mid)) 
                hi = mid;
            else 
                lo = mid + 1;
        }
        return lo;
}}
