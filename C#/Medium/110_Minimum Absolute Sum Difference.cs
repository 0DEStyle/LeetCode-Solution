/*Challenge link:https://leetcode.com/problems/minimum-absolute-sum-difference/description/
Question:
You are given two positive integer arrays nums1 and nums2, both of length n.

The absolute sum difference of arrays nums1 and nums2 is defined as the sum of |nums1[i] - nums2[i]| for each 0 <= i < n (0-indexed).

You can replace at most one element of nums1 with any other element in nums1 to minimize the absolute sum difference.

Return the minimum absolute sum difference after replacing at most one element in the array nums1. Since the answer may be large, return it modulo 109 + 7.

|x| is defined as:

x if x >= 0, or
-x if x < 0.
 

Example 1:

Input: nums1 = [1,7,5], nums2 = [2,3,5]
Output: 3
Explanation: There are two possible optimal solutions:
- Replace the second element with the first: [1,7,5] => [1,1,5], or
- Replace the second element with the third: [1,7,5] => [1,5,5].
Both will yield an absolute sum difference of |1-2| + (|1-3| or |5-3|) + |5-5| = 3.
Example 2:

Input: nums1 = [2,4,6,8,10], nums2 = [2,4,6,8,10]
Output: 0
Explanation: nums1 is equal to nums2 so no replacement is needed. This will result in an 
absolute sum difference of 0.
Example 3:

Input: nums1 = [1,10,4,4,2,7], nums2 = [9,3,5,1,7,4]
Output: 20
Explanation: Replace the first element with the second: [1,10,4,4,2,7] => [10,10,4,4,2,7].
This yields an absolute sum difference of |10-9| + |10-3| + |4-5| + |4-1| + |2-7| + |7-4| = 20
 

Constraints:

n == nums1.length
n == nums2.length
1 <= n <= 105
1 <= nums1[i], nums2[i] <= 105
*/

//***************Solution********************
public class Solution {
    public int MinAbsoluteSumDiff(int[] nums1, int[] nums2) {
        int n = nums1.Length, modulo = 1000000007, diff = 0, sum = 0;
        if (n==1) 
            return Math.Abs(nums1[0] - nums2[0]);
        
        int[] nums = new int[n];
        Array.Copy(nums1, nums, n);
        Array.Sort(nums);

        // Count the sum with update for max difference
        for (int i=0; i<n; i++){
            sum = AddSumInModulo(sum, Math.Abs(nums1[i]-nums2[i]), modulo);
            // Calculate the new difference and correct the sum if needed
            int new_diff = CalcDiff(nums1[i], nums2[i], nums, Math.Abs(nums1[i]-nums2[i]) );

            if ( new_diff > diff ) {
                sum = AddSumInModulo(sum, - new_diff + diff, modulo);
                diff = new_diff;
            }
        }
        return sum;        
    }

    public int AddSumInModulo(int sum, int add, int modulo) => (sum + add) % modulo;

    //binary search
    public int CalcDiff(int key, int target, int[] nums, int basediff){
        //set boundaries
        int l = 0, r = nums.Length-1;

        while (r-l>1) {
            //find mid index
            int mid = l + (r-l)/2;
            if ( nums[mid]>target ) 
                r = mid;
            else 
                l = mid;
        }
        // Final check for l&r, if we do not need to move element for minimum difference - we return zero as a result
        if ( Math.Abs(nums[l]-target) > Math.Abs(nums[r]-target) ) 
            l = r;
        if (nums[l]==key) 
            return 0;
        return basediff - Math.Abs(nums[l]-target);
    }
}
