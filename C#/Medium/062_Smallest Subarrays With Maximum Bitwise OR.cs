/*Challenge link:https://leetcode.com/problems/smallest-subarrays-with-maximum-bitwise-or/description/
Question:
You are given a 0-indexed array nums of length n, consisting of non-negative integers. For each index i from 0 to n - 1, you must determine the size of the minimum sized non-empty subarray of nums starting at i (inclusive) that has the maximum possible bitwise OR.

In other words, let Bij be the bitwise OR of the subarray nums[i...j]. You need to find the smallest subarray starting at i, such that bitwise OR of this subarray is equal to max(Bik) where i <= k <= n - 1.
The bitwise OR of an array is the bitwise OR of all the numbers in it.

Return an integer array answer of size n where answer[i] is the length of the minimum sized subarray starting at i with maximum bitwise OR.

A subarray is a contiguous non-empty sequence of elements within an array.

 

Example 1:

Input: nums = [1,0,2,1,3]
Output: [3,3,2,2,1]
Explanation:
The maximum possible bitwise OR starting at any index is 3. 
- Starting at index 0, the shortest subarray that yields it is [1,0,2].
- Starting at index 1, the shortest subarray that yields the maximum bitwise OR is [0,2,1].
- Starting at index 2, the shortest subarray that yields the maximum bitwise OR is [2,1].
- Starting at index 3, the shortest subarray that yields the maximum bitwise OR is [1,3].
- Starting at index 4, the shortest subarray that yields the maximum bitwise OR is [3].
Therefore, we return [3,3,2,2,1]. 
Example 2:

Input: nums = [1,2]
Output: [2,1]
Explanation:
Starting at index 0, the shortest subarray that yields the maximum bitwise OR is of length 2.
Starting at index 1, the shortest subarray that yields the maximum bitwise OR is of length 1.
Therefore, we return [2,1].
 

Constraints:

n == nums.length
1 <= n <= 105
0 <= nums[i] <= 109
*/

//***************Solution********************
//O(30n)
public class Solution {
    public int[] SmallestSubarrays(int[] nums) {
        int n = nums.Length;
        var last = new int[30];
        var res = new int[n];

        //start from end down to 0, set current element of res to 1
        for (int i = n - 1; i >= 0; --i) {
            res[i] = 1;
            //loop for 30 times(process each bit)
            //if current element of i AND (j bit shift to left by 1) is greater than 0
            //set j element at last as i
            //select max between current res and last[j] - i + 1. update current res 
            for (int j = 0; j < 30; ++j) {
                if ((nums[i] & (1 << j)) > 0)
                    last[j] = i;
                res[i] = Math.Max(res[i], last[j] - i + 1);
            }
        }
        return res;
    }
}
