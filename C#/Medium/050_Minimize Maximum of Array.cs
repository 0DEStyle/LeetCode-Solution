/*Challenge link:https://leetcode.com/problems/minimize-maximum-of-array/description/
Question:
You are given a 0-indexed array nums comprising of n non-negative integers.

In one operation, you must:

Choose an integer i such that 1 <= i < n and nums[i] > 0.
Decrease nums[i] by 1.
Increase nums[i - 1] by 1.
Return the minimum possible value of the maximum integer of nums after performing any number of operations.

 

Example 1:

Input: nums = [3,7,1,6]
Output: 5
Explanation:
One set of optimal operations is as follows:
1. Choose i = 1, and nums becomes [4,6,1,6].
2. Choose i = 3, and nums becomes [4,6,2,5].
3. Choose i = 1, and nums becomes [5,5,2,5].
The maximum integer of nums is 5. It can be shown that the maximum number cannot be less than 5.
Therefore, we return 5.
Example 2:

Input: nums = [10,1]
Output: 10
Explanation:
It is optimal to leave nums as is, and since 10 is the maximum value, we return 10.
 

Constraints:

n == nums.length
2 <= n <= 105
0 <= nums[i] <= 109
*/

//***************Solution********************
//binary search
public class Solution {
    public int MinimizeArrayValue(int[] nums) {
        //set boundaries
        int start = 0, end = 0; 

        //loop through each elements in nums, select max value between end and i, store in end
        foreach(int i in nums)
            end = Math.Max( end, i );

        while( start < end ){
            //find mid index
            int mid = start + (end-start)/2;

            //check if possible by calling isPossible method
            //if true, set end to mid, else shift start to right by 1 index
            if( isPossible( nums, mid ) )
                end = mid;
            else
                start = mid+1;
        }
        return start;
    }

    public bool  isPossible(int[] nums, int limit ) {
        long moves = 0;

        //loop through each element in nums
        foreach(int ele in nums){
            //if current elements is less than or equal to limt
            //accumulate sum for moves, by getting the difference between limit and ele
            if( ele <= limit )
                moves += (limit-ele);
            else{
                // check if moves are available.
                  // i.e. we cann't increase the previous element
                  // required times, so return false.
                if( moves < (ele-limit) ){
                    return false;
            }else
                moves -= (ele-limit);
                
            }
        }
        return true;
    }
}
