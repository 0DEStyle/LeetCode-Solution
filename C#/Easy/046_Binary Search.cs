/*Challenge link:https://leetcode.com/problems/binary-search/description/
Question:
Given an array of integers nums which is sorted in ascending order, and an integer target, write a function to search target in nums. If target exists, then return its index. Otherwise, return -1.

You must write an algorithm with O(log n) runtime complexity.

 

Example 1:

Input: nums = [-1,0,3,5,9,12], target = 9
Output: 4
Explanation: 9 exists in nums and its index is 4
Example 2:

Input: nums = [-1,0,3,5,9,12], target = 2
Output: -1
Explanation: 2 does not exist in nums so return -1
 

Constraints:

1 <= nums.length <= 104
-104 < nums[i], target < 104
All the integers in nums are unique.
nums is sorted in ascending order.
*/

//***************Solution********************
//binary search 
public class Solution {
    public int Search(int[] nums, int target) {
        //set left to start index and right to end index of nums
        int left = 0, right = nums.Length - 1;

        //while left is less than or equal to right
        //find mid index, if target equal to nums[mid], return result.
        //else shift index accordingly
        while(left <= right){
            int mid = (left + right) / 2;
        if(target == nums[mid])
            return mid;
        else if(target < nums[mid])
            right = mid - 1;
        else
            left = mid + 1;
        }
        //no result.
        return -1;
    }
}


//brute force
public class Solution {
    public int Search(int[] nums, int target) {
    for(int i = 0; i< nums.Length ; i++){
        if(nums[i] == target)return i;
    }
    return - 1;
    }
}
