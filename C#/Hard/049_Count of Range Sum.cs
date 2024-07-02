/*Challenge link:https://leetcode.com/problems/count-of-range-sum/description/
Question:
Given an integer array nums and two integers lower and upper, return the number of range sums that lie in [lower, upper] inclusive.

Range sum S(i, j) is defined as the sum of the elements in nums between indices i and j inclusive, where i <= j.

 

Example 1:

Input: nums = [-2,5,-1], lower = -2, upper = 2
Output: 3
Explanation: The three ranges are: [0,0], [2,2], and [0,2] and their respective sums are: -2, -1, 2.
Example 2:

Input: nums = [0], lower = 0, upper = 0
Output: 1
 

Constraints:

1 <= nums.length <= 105
-231 <= nums[i] <= 231 - 1
-105 <= lower <= upper <= 105
The answer is guaranteed to fit in a 32-bit integer.
*/

//***************Solution********************
//https://www.youtube.com/watch?v=m9P1drvDjzY

public class Solution {
    //Global variables and arrays
    int lower, upper, count = 0;
    long[] preSum, temp;

    public int CountRangeSum(int[] nums, int lower, int upper) {
        this.lower = lower;
        this.upper = upper;

        preSum = new long[nums.Length + 1];
        temp = new long[nums.Length + 1];

        for(int i = 0; i < nums.Length; i++)
            preSum[i + 1] = preSum[i] + nums[i];

        Sort(preSum, 0, preSum.Length - 1);
        return count;
    }

    public void Sort(long[] nums, int left, int right){
        if(left >= right)
            return;
        //get mid index
        int mid = left + (right - left) / 2;

        Sort(nums, left, mid);
        Sort(nums, mid + 1, right);
        Merge(nums, left, mid, right);
    }

    public void Merge(long[] nums, int left, int mid, int right){
        //set boundaries
        int start = mid + 1, end = mid + 1;

        for(int i = left; i <= right; i++)
            temp[i] = nums[i];
        
        for(int i = left; i <= mid; i++){
            while(start <= right && nums[start] - nums[i] < lower)
                start++;
            while(end <= right && nums[end] - nums[i] <= upper)
                end++;
            count += end - start;
        }

        int m = left, n = mid + 1;
        for(int i = left; i <= right; i++){
            if(m == mid + 1)
                nums[i] = temp[n++];
            else if(n == right + 1)
                nums[i] = temp[m++];
            else if(temp[m] > temp[n])
                nums[i] = temp[n++];
            else
                nums[i] = temp[m++];
        }
    }
}
