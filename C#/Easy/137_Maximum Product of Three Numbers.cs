/*Challenge link:https://leetcode.com/problems/maximum-product-of-three-numbers/description/
Question:Given an integer array nums, find three numbers whose product is maximum and return the maximum product.

 

Example 1:

Input: nums = [1,2,3]
Output: 6
Example 2:

Input: nums = [1,2,3,4]
Output: 24
Example 3:

Input: nums = [-1,-2,-3]
Output: -6
 

Constraints:

3 <= nums.length <= 104
-1000 <= nums[i] <= 1000
*/

//***************Solution********************
public class Solution {
    public int MaximumProduct(int[] n) {
        Array.Sort(n);
        int n1 = n.Length - 1, n2 = n.Length - 2, n3 = n.Length - 3;


        return n[n1] * n[n2] * n[n3] > n[n1] * n[0] * n[1] ?
               n[n1] * n[n2] * n[n3] :
               n[n1] * n[0] * n[1];
    }
}
