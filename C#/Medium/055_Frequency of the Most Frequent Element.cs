/*Challenge link:https://leetcode.com/problems/frequency-of-the-most-frequent-element/description/
Question:
The frequency of an element is the number of times it occurs in an array.

You are given an integer array nums and an integer k. In one operation, you can choose an index of nums and increment the element at that index by 1.

Return the maximum possible frequency of an element after performing at most k operations.

 

Example 1:

Input: nums = [1,2,4], k = 5
Output: 3
Explanation: Increment the first element three times and the second element two times to make nums = [4,4,4].
4 has a frequency of 3.
Example 2:

Input: nums = [1,4,8,13], k = 5
Output: 2
Explanation: There are multiple optimal solutions:
- Increment the first element three times to make nums = [4,4,8,13]. 4 has a frequency of 2.
- Increment the second element four times to make nums = [1,8,8,13]. 8 has a frequency of 2.
- Increment the third element five times to make nums = [1,4,13,13]. 13 has a frequency of 2.
Example 3:

Input: nums = [3,9,6], k = 2
Output: 1
 

Constraints:

1 <= nums.length <= 105
1 <= nums[i] <= 105
1 <= k <= 105
*/

//***************Solution********************
public class Solution {
    long[] preSum;
    public int MaxFrequency(int[] nums, int k) {
        int n = nums.Length, ans = 0;
        Array.Sort(nums);
        preSum = new long[n+1];

        for (int i = 0; i < n; i++)
            preSum[i + 1] = preSum[i] + nums[i];

        //checking each element for largest window
        for (int i = 0; i < n; i++)
            ans = Math.Max(ans, count(nums, k, i)); 
        return ans;
    }

    // left, right inclusive
    long getSum(int left, int right)  =>  preSum[right + 1] - preSum[left];

    //Binary search, count frequency of `nums[index]` if we make other elements equal to `nums[index]`
    int count(int[] nums, int k, int index) {
        //set boundaries
        int left = 0, right = index, res = index;

        while (left <= right) {
            //get mid index
            // get sum of(nums[mid], nums[mid + 1]...nums[index - 1])
            int mid = left + (right - left) / 2;
            long s = getSum(mid, index - 1); 

            // Found an answer -> Try to find a better answer in the left side
            //set res as mid, and shift right to left by 1 index
            //else shift left to right by 1 index, decreasing the window size  
            if (s + k >= (long)(index - mid) * nums[index]) { 
                res = mid; 
                right = mid - 1;
            } else 
                left = mid + 1; 
        }
        return index - res + 1;
    }
}
