/*Challenge link:https://leetcode.com/problems/minimum-subsequence-in-non-increasing-order/description/
Question:
Given the array nums, obtain a subsequence of the array whose sum of elements is strictly greater than the sum of the non included elements in such subsequence. 

If there are multiple solutions, return the subsequence with minimum size and if there still exist multiple solutions, return the subsequence with the maximum total sum of all its elements. A subsequence of an array can be obtained by erasing some (possibly zero) elements from the array. 

Note that the solution with the given constraints is guaranteed to be unique. Also return the answer sorted in non-increasing order.

 

Example 1:

Input: nums = [4,3,10,9,8]
Output: [10,9] 
Explanation: The subsequences [10,9] and [10,8] are minimal such that the sum of their elements is strictly greater than the sum of elements not included. However, the subsequence [10,9] has the maximum total sum of its elements. 
Example 2:

Input: nums = [4,4,7,6,7]
Output: [7,7,6] 
Explanation: The subsequence [7,7] has the sum of its elements equal to 14 which is not strictly greater than the sum of elements not included (14 = 4 + 4 + 6). Therefore, the subsequence [7,6,7] is the minimal satisfying the conditions. Note the subsequence has to be returned in non-increasing order.  
 

Constraints:

1 <= nums.length <= 500
1 <= nums[i] <= 100
*/

//***************Solution********************
/*
10 9 = 19
10 8 = 18
4 3 8 = 15

7 7 = 14
7 6 = 13

4 4 6 7 7 = 28
4 6 7 7 = 24
6 7 7 = 20

*/
public class Solution {
    public IList<int> MinSubsequence(int[] nums) {
        //sort in ascending order then reverse.
        Array.Sort(nums);
        Array.Reverse(nums);

        int i = 0,sum = 0,sum1 = 0;

        var a = new List<int>();
        sum1 = nums.Sum();

        while(i <= nums.Length - 1){
            sum += nums[i];
            a.Add(nums[i]);
            int f = sum1 - sum;
            //check if sum is greater than subarray sum, if true return list a
            if(sum > f)
                return a;
            i++;
        }
        return a;
    }
}
