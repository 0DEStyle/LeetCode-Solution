/*Challenge link:https://leetcode.com/problems/same-tree/
Question:
Given the roots of two binary trees p and q, write a function to check if they are the same or not.
//see image in link
Two binary trees are considered the same if they are structurally identical, and the nodes have the same value.

 //see image in link

Example 1:

Input: p = [1,2,3], q = [1,2,3]
Output: true

Example 2:

Input: p = [1,2], q = [1,null,2]
Output: false

Example 3:

Input: p = [1,2,1], q = [1,1,2]
Output: false

 

Constraints:

    The number of nodes in both trees is in the range [0, 100].
    -104 <= Node.val <= 104


*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//solution 1, recursion

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
public class Solution {
    public bool IsSameTree(TreeNode p, TreeNode q) {
        if(p == null || q == null) return p == q;

        return (p.val == q.val) && IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
    }
}
