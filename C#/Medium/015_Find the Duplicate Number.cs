/*Challenge link:https://leetcode.com/problems/find-the-duplicate-number/
Question:
Given an array of integers nums containing n + 1 integers where each integer is in the range [1, n] inclusive.

There is only one repeated number in nums, return this repeated number.

You must solve the problem without modifying the array nums and uses only constant extra space.

 

Example 1:

Input: nums = [1,3,4,2,2]
Output: 2
Example 2:

Input: nums = [3,1,3,4,2]
Output: 3
Example 3:

Input: nums = [3,3,3,3,3]
Output: 3
 

Constraints:

1 <= n <= 105
nums.length == n + 1
1 <= nums[i] <= n
All the integers in nums appear only once except for precisely one integer which appears two or more times.
 

Follow up:

How can we prove that at least one duplicate number must exist in nums?
Can you solve the problem in linear runtime complexity?
*/

//***************Solution********************
public class Solution {
    public int FindDuplicate(int[] nums) {
        //boundary 
        int low = 0, high = nums.Length - 1, cnt = 0;

        while(low <= high){
            //find mid index
            int mid = low + (high - low)/2;
            cnt = 0;

            foreach(int num in nums)
                if(num <= mid)cnt++;

            //if condition is valid, shift low to right by 1 index
            //else shift high to right by 1 index
            if(cnt <= mid)
                low = mid + 1;
            else
                high = mid - 1;
        }
    return low; 
    }
}
