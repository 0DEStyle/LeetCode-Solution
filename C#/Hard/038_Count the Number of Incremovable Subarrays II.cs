/*Challenge link:https://leetcode.com/problems/count-the-number-of-incremovable-subarrays-ii/description/
Question:
You are given a 0-indexed array of positive integers nums.

A subarray of nums is called incremovable if nums becomes strictly increasing on removing the subarray. For example, the subarray [3, 4] is an incremovable subarray of [5, 3, 4, 6, 7] because removing this subarray changes the array [5, 3, 4, 6, 7] to [5, 6, 7] which is strictly increasing.

Return the total number of incremovable subarrays of nums.

Note that an empty array is considered strictly increasing.

A subarray is a contiguous non-empty sequence of elements within an array.

 

Example 1:

Input: nums = [1,2,3,4]
Output: 10
Explanation: The 10 incremovable subarrays are: [1], [2], [3], [4], [1,2], [2,3], [3,4], [1,2,3], [2,3,4], and [1,2,3,4], because on removing any one of these subarrays nums becomes strictly increasing. Note that you cannot select an empty subarray.
Example 2:

Input: nums = [6,5,7,8]
Output: 7
Explanation: The 7 incremovable subarrays are: [5], [6], [5,7], [6,5], [5,7,8], [6,5,7] and [6,5,7,8].
It can be shown that there are only 7 incremovable subarrays in nums.
Example 3:

Input: nums = [8,7,6,6]
Output: 3
Explanation: The 3 incremovable subarrays are: [8,7,6], [7,6,6], and [8,7,6,6]. Note that [8,7] is not an incremovable subarray because after removing [8,7] nums becomes [6,6], which is sorted in ascending order but not strictly increasing.
 

Constraints:

1 <= nums.length <= 105
1 <= nums[i] <= 109
*/

//***************Solution********************
public class Solution {
    public long IncremovableSubarrayCount(int[] nums){
            int l = 0, r = nums.Length - 1;
            int idx = 1;
            while (idx < nums.Length && nums[l] < nums[idx]){
                idx++;
                l++;
            }
            if (idx == nums.Length)
                return (long)nums.Length * (nums.Length + 1) / 2;
                
            idx = nums.Length - 2;
            while (idx > 0 && nums[r] > nums[idx]){
                idx--;
                r--;
            }
            long ans = 0;
            for (int i = 0; i <= l; i++){
                //pass boundaries into binary search to find index.
                int val = BinarySearch(nums, r, nums.Length - 1, nums[i]);
                val = nums.Length - val + 1;
                ans = ans + val;
            }
            ans = ans + nums.Length - r + 1;
            return ans;
        }

        //binary search
        private int BinarySearch(int[] nums, int l, int r, long x){
            int ans = -1;
            while (l <= r){
                //find mid index
                int mid = l + (r - l) / 2;
                //check condition and shift l and right accordingly
                if (nums[mid] <= x)
                    l = mid + 1;
                else{
                    ans = mid;
                    r = mid - 1;
                }
            }
            if (ans == -1) return nums.Length;
            return ans;
        }
}
