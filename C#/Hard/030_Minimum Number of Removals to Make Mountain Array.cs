/*Challenge link:https://leetcode.com/problems/minimum-number-of-removals-to-make-mountain-array/description/
Question:
You may recall that an array arr is a mountain array if and only if:

arr.length >= 3
There exists some index i (0-indexed) with 0 < i < arr.length - 1 such that:
arr[0] < arr[1] < ... < arr[i - 1] < arr[i]
arr[i] > arr[i + 1] > ... > arr[arr.length - 1]
Given an integer array nums​​​, return the minimum number of elements to remove to make nums​​​ a mountain array.

 

Example 1:

Input: nums = [1,3,1]
Output: 0
Explanation: The array itself is a mountain array so we do not need to remove any elements.
Example 2:

Input: nums = [2,1,1,5,6,2,3,1]
Output: 3
Explanation: One solution is to remove the elements at indices 0, 1, and 5, making the array nums = [1,5,6,3,1].
 

Constraints:

3 <= nums.length <= 1000
1 <= nums[i] <= 109
It is guaranteed that you can make a mountain array out of nums.
*/

//***************Solution********************
public class Solution {
    public int MinimumMountainRemovals(int[] nums) {
        //lbs longest bitomic subsequence
        int n = nums.Length, lbs = 0;
        //set dp storage
        int[] dp = new int[n], dp2 = new int[n];
        var lis = new List<int>();
        
        //loop up to n-1
        //if list.count is 0 OR list at last index is less than current element of num
        //add current element to lis
        //else do binary search for current element, (binarsearch return negative if index not found)
        //if idx is less than 0,set list at bit wise complement of idx to current element
        for (int i = 0; i < n - 1; i++){
            if (lis.Count == 0 || lis[lis.Count - 1] < nums[i])
                lis.Add(nums[i]);
            else{
                int idx = lis.BinarySearch(nums[i]);
                if (idx < 0)
                    lis[~idx] = nums[i];
            }
            //set current dp to lis.count
            dp[i] = lis.Count;
        }
        lis.Clear();

        //from from n down to 1
        //if lis count equal 0 OR list at last index is less than current element
        //add current num to lis
        //else do binary search for current element, (binarsearch return negative if index not found)
        //if idx is less than 0,set list at bit wise complement of idx to current element
        for (int i = n - 1; i >= 1; i--){
            if (lis.Count == 0 || lis[lis.Count - 1] < nums[i])
                lis.Add(nums[i]);
            else{
                int idx = lis.BinarySearch(nums[i]);
                if (idx < 0)
                    lis[~idx] = nums[i];
            }
            //set current dp2 to lis.count
            dp2[i] = lis.Count;
            //compare dp1 and dp2
            //select max value and set to lbs
            if (dp[i] > 1 && dp2[i] > 1)
                lbs = Math.Max(lbs, dp[i] + dp2[i] - 1);
        }
        return n - lbs;
}}
