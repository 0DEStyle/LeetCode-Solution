/*Challenge link:https://leetcode.com/problems/minimum-common-value/description/
Question:
Given two integer arrays nums1 and nums2, sorted in non-decreasing order, return the minimum integer common to both arrays. If there is no common integer amongst nums1 and nums2, return -1.

Note that an integer is said to be common to nums1 and nums2 if both arrays have at least one occurrence of that integer.

 

Example 1:

Input: nums1 = [1,2,3], nums2 = [2,4]
Output: 2
Explanation: The smallest element common to both arrays is 2, so we return 2.
Example 2:

Input: nums1 = [1,2,3,6], nums2 = [2,3,4,5]
Output: 2
Explanation: There are two common elements in the array 2 and 3 out of which 2 is the smallest, so 2 is returned.
 

Constraints:

1 <= nums1.length, nums2.length <= 105
1 <= nums1[i], nums2[j] <= 109
Both nums1 and nums2 are sorted in non-decreasing order.
*/

//***************Solution********************
//loop through each element in nums1,
//check if binary search nums2 of i is less than or equal to 0
//if true return i, else return -1
public class Solution {
    public int GetCommon(int[] nums1, int[] nums2) {
        foreach(var i in nums1)
            if(Array.BinarySearch(nums2, i) >= 0)
                return i;
        return -1;
    }
}


//binary search normal
public class Solution {
    public int GetCommon(int[] nums1, int[] nums2) {
        int len2 = nums2.Length - 1;

        //loop through each item in nums1 and compare
        foreach (var num in nums1) {
        int low = 0, high = len2;
        
            while (low <= high) {
                //find mid point
                int mid = low + (high - low) / 2;

                //if result matches, return num
                //else shift to either left(low) side or right(high) side
                if (nums2[mid] == num) 
                    return num;
                else if (nums2[mid] < num) 
                    low = mid + 1;
                else 
                    high = mid - 1;
            }
        }
        //return -1 if nothing matches
        return -1;       
    }
}
