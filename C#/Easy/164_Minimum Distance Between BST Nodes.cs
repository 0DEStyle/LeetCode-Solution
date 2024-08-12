/*Challenge link:https://leetcode.com/problems/minimum-distance-between-bst-nodes/description/
Question:
Given the root of a Binary Search Tree (BST), return the minimum difference between the values of any two different nodes in the tree.

 

Example 1:

//see image in link
Input: root = [4,2,6,1,3]
Output: 1
Example 2:
//see image in link

Input: root = [1,0,48,null,null,12,49]
Output: 1
 

Constraints:

The number of nodes in the tree is in the range [2, 100].
0 <= Node.val <= 105
 

Note: This question is the same as 530: https://leetcode.com/problems/minimum-absolute-difference-in-bst/
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
    TreeNode prev = null;
    int ans = Int32.MaxValue;
    
    private void inorder(TreeNode root){
        if(root == null)
            return ;
        inorder(root.left);
        if(prev != null)
            ans = Math.Min(ans, root.val - prev.val);
        prev = root;
        inorder(root.right);
        return ;
            
    }
    public int MinDiffInBST(TreeNode root) {
        inorder(root);
        return ans;
    }
}
