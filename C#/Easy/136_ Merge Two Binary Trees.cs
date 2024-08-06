/*Challenge link:https://leetcode.com/problems/merge-two-binary-trees/description/
Question:
You are given two binary trees root1 and root2.

Imagine that when you put one of them to cover the other, some nodes of the two trees are overlapped while the others are not. You need to merge the two trees into a new binary tree. The merge rule is that if two nodes overlap, then sum node values up as the new value of the merged node. Otherwise, the NOT null node will be used as the node of the new tree.

Return the merged tree.

Note: The merging process must start from the root nodes of both trees.

 

Example 1:
//see image in link

Input: root1 = [1,3,2,5], root2 = [2,1,3,null,4,null,7]
Output: [3,4,5,5,4,null,7]
Example 2:

Input: root1 = [1], root2 = [1,2]
Output: [2,2]
 

Constraints:

The number of nodes in both trees is in the range [0, 2000].
-104 <= Node.val <= 104
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
    public TreeNode MergeTrees(TreeNode root1, TreeNode root2) {
        
        //check null
        //if either root 1 or 2 is null, return the other root
        if (root1 == null & root2 == null) 
            return null;
        if (root1 == null) 
            return root2;
        if (root2 == null) 
            return root1;

        //pass root1 and 2 left node into mergetree
        //pass root1 and 2 right node into mergetree
        var left = MergeTrees(root1.left, root2.left);
        var right = MergeTrees(root1.right, root2.right);

        //if not equal set to equal.
        if (root1.left != left) 
            root1.left = left;
        if (root1.right != right) 
            root1.right = right;

        //accumulate sum of both value
        root1.val += root2.val;

        return root1;
    }
}
