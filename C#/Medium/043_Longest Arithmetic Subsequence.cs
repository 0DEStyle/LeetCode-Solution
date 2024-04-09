/*Challenge link:https://leetcode.com/problems/longest-arithmetic-subsequence/description/
Question:
Given an array nums of integers, return the length of the longest arithmetic subsequence in nums.

Note that:

A subsequence is an array that can be derived from another array by deleting some or no elements without changing the order of the remaining elements.
A sequence seq is arithmetic if seq[i + 1] - seq[i] are all the same value (for 0 <= i < seq.length - 1).
 

Example 1:

Input: nums = [3,6,9,12]
Output: 4
Explanation:  The whole array is an arithmetic sequence with steps of length = 3.
Example 2:

Input: nums = [9,4,7,2,10]
Output: 3
Explanation:  The longest arithmetic subsequence is [4,7,10].
Example 3:

Input: nums = [20,1,15,3,10,5,8]
Output: 4
Explanation:  The longest arithmetic subsequence is [20,15,10,5].
 

Constraints:

2 <= nums.length <= 1000
0 <= nums[i] <= 500
*/

//***************Solution********************
//brute force, dp
public class Solution {
    public int LongestArithSeqLength(int[] nums) {
        //create dictionary to keep track
        //set max squence length to 1
        Dictionary<(int, int), int> d = new Dictionary<(int, int), int>();
        int maxSeqLength = 1, n = nums.Length;

        //loop through all elements
        for (int i = 0; i < n; i++){
            for (int j = i + 1; j < n; j++){
                //find difference of current and next, set previous count to 1
                int diff = nums[j] - nums[i], previousCount = 1;
                
                //check if dictionary contains current element and difference. 
                //if true set previouscount to current index & diff value of dictionary
                if (d.ContainsKey((i, diff)))
                    previousCount = d[(i, diff)];

                //increase current element by previousCount + 1
                //select max values between max sequence and current elemetn of d, update max sequence length
                d[(j, diff)] = previousCount + 1;
                maxSeqLength = Math.Max(maxSeqLength, d[(j, diff)]);
            }
        }
        return maxSeqLength;
    }
}
