/*Challenge link:https://leetcode.com/problems/valid-triangle-number/description/
Question:
Given an integer array nums, return the number of triplets chosen from the array that can make triangles if we take them as side lengths of a triangle.

 

Example 1:

Input: nums = [2,2,3,4]
Output: 3
Explanation: Valid combinations are: 
2,3,4 (using the first 2)
2,3,4 (using the second 2)
2,2,3
Example 2:

Input: nums = [4,2,3,4]
Output: 4
 

Constraints:

1 <= nums.length <= 1000
0 <= nums[i] <= 1000
*/

//***************Solution********************
//two pointers O(n^2)
public class Solution {
    public int TriangleNumber(int[] A) {
        //sort the array in ascending order
        //define boundaries
         Array.Sort(A);
        int count = 0, n = A.Length;

        //start from n - 1, down to 2
        for (int i = n - 1 ; i >= 2; i--) {
            //left = 0, right = i - 1
            int l = 0, r = i-1;

            while (l < r) {
                //if left + right is greater than current element
                //increase count by right - left
                //reduce right by 1
                if (A[l] + A[r] > A[i]) {
                    count += r-l;
                    r--;
            }
            //increase left by 1
            else l++;
        }
    }
    return count;
    }
}
