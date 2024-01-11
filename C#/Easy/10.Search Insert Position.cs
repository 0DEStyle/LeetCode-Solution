/*Challenge link:https://leetcode.com/problems/search-insert-position/description/
Question:
Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.

You must write an algorithm with O(log n) runtime complexity.

 

Example 1:

Input: nums = [1,3,5,6], target = 5
Output: 2
Example 2:

Input: nums = [1,3,5,6], target = 2
Output: 1
Example 3:

Input: nums = [1,3,5,6], target = 7
Output: 4
 

Constraints:

1 <= nums.length <= 104
-104 <= nums[i] <= 104
nums contains distinct values sorted in ascending order.
-104 <= target <= 104
*/

//***************Solution********************

//loop through each element inside nums
//check if nums[i] is greater or equal to the target, if true, return the current index

//if nothing is matched, meaning the target is the biggest number, return the last position of nums(nums.Length)
public class Solution {
    public int SearchInsert(int[] nums, int target) {
        for(int i = 0; i < nums.Length; i++)
            if(nums[i] >= target) 
                return i;
        
        return nums.Length;
    }
}

//solution 2
//binary search target.
public class Solution
{
    public int SearchInsert(int[] nums, int target)
    {
        var index = Array.BinarySearch(nums, target);
        return index >= 0 ? index : ~index;
    }
}
