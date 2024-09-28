/*Challenge link:https://leetcode.com/problems/element-appearing-more-than-25-in-sorted-array/description/
Question:
Given an integer array sorted in non-decreasing order, there is exactly one integer in the array that occurs more than 25% of the time, return that integer.

 

Example 1:

Input: arr = [1,2,2,6,6,6,6,7,10]
Output: 6
Example 2:

Input: arr = [1,1]
Output: 1
 

Constraints:

1 <= arr.length <= 104
0 <= arr[i] <= 105
*/

//***************Solution********************
public class Solution {
    public int FindSpecialInteger(int[] a) {
        //25%
        int len = a.Length / 4;

        for (int i = 0; i < a.Length - len; i++) {
            //check current element,
            //if match, return current element
            if (a[i] == a[i + len])
                return a[i];
        }

        //return last element if no result.
        return a[a.Length - 1];
    }
}
