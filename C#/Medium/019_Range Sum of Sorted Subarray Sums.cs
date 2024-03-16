/*Challenge link:https://leetcode.com/problems/range-sum-of-sorted-subarray-sums/description/
Question:You are given the array nums consisting of n positive integers. You computed the sum of all non-empty continuous subarrays from the array and then sorted them in non-decreasing order, creating a new array of n * (n + 1) / 2 numbers.

Return the sum of the numbers from index left to index right (indexed from 1), inclusive, in the new array. Since the answer can be a huge number return it modulo 109 + 7.

 

Example 1:

Input: nums = [1,2,3,4], n = 4, left = 1, right = 5
Output: 13 
Explanation: All subarray sums are 1, 3, 6, 10, 2, 5, 9, 3, 7, 4. After sorting them in non-decreasing order we have the new array [1, 2, 3, 3, 4, 5, 6, 7, 9, 10]. The sum of the numbers from index le = 1 to ri = 5 is 1 + 2 + 3 + 3 + 4 = 13. 
Example 2:

Input: nums = [1,2,3,4], n = 4, left = 3, right = 4
Output: 6
Explanation: The given array is the same as example 1. We have the new array [1, 2, 3, 3, 4, 5, 6, 7, 9, 10]. The sum of the numbers from index le = 3 to ri = 4 is 3 + 3 = 6.
Example 3:

Input: nums = [1,2,3,4], n = 4, left = 1, right = 10
Output: 50
 

Constraints:

n == nums.length
1 <= nums.length <= 1000
1 <= nums[i] <= 100
1 <= left <= right <= n * (n + 1) / 2
*/

//***************Solution********************

//brute force
public class Solution {
    public int RangeSum(int[] nums, int n, int left, int right) {
      //mod to 1e9 + 7
        int m = (int)1e9+7, k=1, size = (n*(n+1))/2, ans = 0;
        int[] prefixSumArr = new int[size+1];

      //accumulate sum and populate the all elements.
        for(int i=0; i<n; i++){
            int prefixSum = 0;
            for(int j=i; j<n; j++){
               prefixSum += nums[j];
               prefixSumArr[k++] = prefixSum;
            }
        }
      //sort the sum array
      //accumulate ans then mod 1e9 + 7
        Array.Sort(prefixSumArr);
        for(int i=left; i<=right; i++)
            ans = (ans+prefixSumArr[i])%m;
      
        return ans;
    }
}

//binary solution timed out at submit...
public class Solution {
    public static int largestSubArraySumPossible = 0;

    public int positionOfSubArraySum(int[] nums, int sum) {
        //set boundaries for 2 pointers
        int left = 0, right = 0, currSum = 0, ans = 0, len = nums.Length;

       //accumulate sum while right is less than len
        while(right < len){
            currSum += nums[right];

            //if current sum is greater than sum, subtract nums[left] then shift left to right by 1 index
            while(currSum > sum)
                currSum -= nums[left++];

            //accumulate right - left  + 1 to ans
            //increase right by 1
            ans += (right - left + 1);
            right++;
        }
        return ans;
    }

    public int kthSubArraySum(int[] nums, int k){
        //Use Binary search to find subArraySum such that there are 
        //(left-1) subArraySums with value less than current sum.
        int low = 0, high = largestSubArraySumPossible;

        while(low < high){
            //find mid index
            int mid = low + (high - low)/2;

            //if condition is met, shift low to right by 1 index, else set high as mid
            if(positionOfSubArraySum(nums, mid) < k)
                low = mid + 1;
            else
                high = mid;
        }
      return low;
    }

    public int RangeSum(int[] nums, int n, int left, int right){
        int mod = (int) 1e9 + 7, ans = 0;

        //loop through n, accumulate n sum and add to global variable largestSubArraySumPossible
        for(int i = 0; i < n; i++)
            largestSubArraySumPossible+=nums[i];

        //start from left, up to right
        //accumulate ans, ans + kthSubSum(nums, i) % mod.
        for(int i = left; i <= right; i++)
            ans = (ans + kthSubArraySum(nums, i)) % mod;

        return ans;
    }
}
