/*Challenge link:https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/description/
Question:
Given an integer array nums where the elements are sorted in ascending order, convert it to a 
height-balanced
 binary search tree.

 //see image in link

Example 1:

 //see image in link
 
Input: nums = [-10,-3,0,5,9]
Output: [0,-3,9,-10,null,5]
Explanation: [0,-10,5,null,-3,null,9] is also accepted:

Example 2:
 //see image in link

Input: nums = [1,3]
Output: [3,1]
Explanation: [1,null,3] and [3,1] are both height-balanced BSTs.
 

Constraints:

1 <= nums.length <= 104
-104 <= nums[i] <= 104
nums is sorted in a strictly increasing order.
*/

//***************Solution********************
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

//0 is the mid point inside nums,
//set mid as num.length / 2
//if nums length is 0, return null
//if nums length is 1, return new TreeNode with num[0] with null at left and right
//else create new TreeNode, set nums[mid] as mid point, 
//recursively call SortedArrayToBST to process left  by taking numbers up to mid
//recursively call SortedArrayToBST to process right  by skipping numbers up to mid + 1

public class Solution {
    public TreeNode SortedArrayToBST(int[] nums) {
        var mid = nums.Length / 2;
        return nums.Length == 0 ?  null : 
               nums.Length == 1 ?  new TreeNode(nums[0], null, null) :
               new TreeNode(nums[mid], SortedArrayToBST(nums.Take(mid).ToArray()), SortedArrayToBST(nums.Skip(mid+1).ToArray()));
    }
}
