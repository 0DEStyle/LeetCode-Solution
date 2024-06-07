/*Challenge link:https://leetcode.com/problems/minimum-array-length-after-pair-removals/description/
Question:
Given an integer array num sorted in non-decreasing order.

You can perform the following operation any number of times:

Choose two indices, i and j, where nums[i] < nums[j].
Then, remove the elements at indices i and j from nums. The remaining elements retain their original order, and the array is re-indexed.
Return the minimum length of nums after applying the operation zero or more times.

 

Example 1:

Input: nums = [1,2,3,4]

Output: 0

Explanation:

//see image in link

Example 2:

Input: nums = [1,1,2,2,3,3]

Output: 0

Explanation:
//see image in link

Example 3:

Input: nums = [1000000000,1000000000]

Output: 2

Explanation:
//see image in link

Since both numbers are equal, they cannot be removed.

Example 4:

Input: nums = [2,3,4,4,4]

Output: 1

Explanation:
//see image in link


 

Constraints:

1 <= nums.length <= 105
1 <= nums[i] <= 109
nums is sorted in non-decreasing order.
*/

//***************Solution********************
public class Solution {
    public int MinLengthAfterRemovals(IList<int> nums) {
        //set boundaries
        int left = 0,right = nums.Count / 2;

        while (left <= right){
            //get mid index
            int mid = left + (right - left) / 2;

            //check validation, if true, shift left to right by 1 index
            //else shift right to left by 1 index
            if (CanRemoveKPairs(nums, mid))
                left = mid + 1;
            else
                right = mid - 1;
        }
        //return num count - right * 2
        return nums.Count - right * 2;
    }

    //validation
    public bool CanRemoveKPairs(IList<int> nums, int k){
        //loop through mid index amount of time
        //if current num is greater or equal to num count - mid index + 1
        //return false, else return true.
        for (var i = 0; i < k; i++)
            if (nums[i] >= nums[nums.Count - k + i])
                return false;
        return true;
    }
}
