/*Challenge link:https://leetcode.com/problems/find-k-th-smallest-pair-distance/description/
Question:
The distance of a pair of integers a and b is defined as the absolute difference between a and b.

Given an integer array nums and an integer k, return the kth smallest distance among all the pairs nums[i] and nums[j] where 0 <= i < j < nums.length.

 

Example 1:

Input: nums = [1,3,1], k = 1
Output: 0
Explanation: Here are all the pairs:
(1,3) -> 2
(1,1) -> 0
(3,1) -> 2
Then the 1st smallest distance pair is (1,1), and its distance is 0.
Example 2:

Input: nums = [1,1,1], k = 2
Output: 0
Example 3:

Input: nums = [1,6,1], k = 3
Output: 5
 

Constraints:

n == nums.length
2 <= n <= 104
0 <= nums[i] <= 106
1 <= k <= n * (n - 1) / 2
*/

//***************Solution********************
public class Solution {
    public int SmallestDistancePair(int[] nums, int k) {
        //sort in ascending order
        Array.Sort(nums);
        int n = nums.Length;
        //set boudnaries
        int l = 0, r = nums[n-1] - nums[0];
        
        while (l < r) {
            //get mid index
            int m = l + (r - l) / 2, count = 0, j = 0;

            for (int i = 0; i < n; i++) {
                while (j < n && nums[j] - nums[i] <= m)
                    j++;
                count += j - i - 1;
            }

            //shift index accordingly
            if (count < k)
                l = m + 1;
            else
                r = m;
        }
        return l;
    }
}
