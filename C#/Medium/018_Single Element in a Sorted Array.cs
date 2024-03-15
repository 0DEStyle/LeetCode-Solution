/*Challenge link:https://leetcode.com/problems/single-element-in-a-sorted-array/description/
Question:
You are given a sorted array consisting of only integers where every element appears exactly twice, except for one element which appears exactly once.

Return the single element that appears only once.

Your solution must run in O(log n) time and O(1) space.

 

Example 1:

Input: nums = [1,1,2,3,3,4,4,8,8]
Output: 2
Example 2:

Input: nums = [3,3,7,7,10,11,11]
Output: 10
 

Constraints:

1 <= nums.length <= 105
0 <= nums[i] <= 105
*/

//***************Solution********************
//binary search method
public class Solution {
    public int SingleNonDuplicate(int[] nums) {
        //set boundaries
        int left = 0, right = nums.Length - 1;

        while (left < right) {
            //find mid index
            int mid =  left + (right - left) / 2;

            //if remainder is 1, shift mid to left by 1
            //is mid index is not equal to next index, set right as mid
            //else shift left to right by 2 index.
            if (mid % 2 == 1) 
                mid--;
            if (nums[mid] != nums[mid + 1]) 
                right = mid;
            else
                left = mid + 2;
        }
        return nums[left];
    }
}
