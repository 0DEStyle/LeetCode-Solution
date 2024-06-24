/*Challenge link:https://leetcode.com/problems/median-of-two-sorted-arrays/description/
Question:
Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.

The overall run time complexity should be O(log (m+n)).

 

Example 1:

Input: nums1 = [1,3], nums2 = [2]
Output: 2.00000
Explanation: merged array = [1,2,3] and median is 2.
Example 2:

Input: nums1 = [1,2], nums2 = [3,4]
Output: 2.50000
Explanation: merged array = [1,2,3,4] and median is (2 + 3) / 2 = 2.5.
 

Constraints:

nums1.length == m
nums2.length == n
0 <= m <= 1000
0 <= n <= 1000
1 <= m + n <= 2000
-106 <= nums1[i], nums2[i] <= 106
*/

//***************Solution********************
public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        var merged = new List<int>();
        //2 pointers
        int i = 0, j = 0;
        
        //add current index to merged list
        while (i < nums1.Length && j < nums2.Length) {
            if (nums1[i] < nums2[j]) 
                merged.Add(nums1[i++]);
            else
                merged.Add(nums2[j++]);
        }
        
        //append remaining elements into merged
        while (i < nums1.Length) merged.Add(nums1[i++]);
        while (j < nums2.Length) merged.Add(nums2[j++]);
        

        //calculate median
        int mid = merged.Count / 2;
        if (merged.Count % 2 == 0) 
            return (merged[mid-1] + merged[mid]) / 2.0;
        else
            return merged[mid];
    }
}
