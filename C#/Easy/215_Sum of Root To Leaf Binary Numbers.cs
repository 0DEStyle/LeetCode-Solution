/*Challenge link:https://leetcode.com/problems/sum-of-root-to-leaf-binary-numbers/description/
Question:
You are given the root of a binary tree where each node has a value 0 or 1. Each root-to-leaf path represents a binary number starting with the most significant bit.

For example, if the path is 0 -> 1 -> 1 -> 0 -> 1, then this could represent 01101 in binary, which is 13.
For all leaves in the tree, consider the numbers represented by the path from the root to that leaf. Return the sum of these numbers.

The test cases are generated so that the answer fits in a 32-bits integer.

 

Example 1:


Input: root = [1,0,1,0,1,0,1]
Output: 22
Explanation: (100) + (101) + (110) + (111) = 4 + 5 + 6 + 7 = 22
Example 2:

Input: root = [0]
Output: 0
 

Constraints:

The number of nodes in the tree is in the range [1, 1000].
Node.val is 0 or 1.
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
public class Solution {
    private int sum = 0;

    public int SumRootToLeaf(TreeNode root) {
        Recursion(root, 0);
        return sum;
    }
    
    //helper method
    private void Recursion(TreeNode node, int s){
        //update val to node val + s * 2 (s start with 0, get binary value)
        var val = s * 2 + node.val;

        //if left/right node is not null, pass value recursively back to method
        if(node.left != null)
            Recursion(node.left, val);
        if(node.right != null)
            Recursion(node.right, val);  

        //if both null is null, accumulate sum for binary bits
        if(node.left == null && node.right == null)
            sum += val;
    }
}
