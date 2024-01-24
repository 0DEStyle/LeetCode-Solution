/*Challenge link:https://leetcode.com/problems/balanced-binary-tree/description/
Question:
Given a binary tree, determine if it is 
height-balanced
.
//see image in link
 

Example 1:


Input: root = [3,9,20,null,null,15,7]
Output: true
Example 2:
//see image in link

Input: root = [1,2,2,3,3,null,null,4,4]
Output: false
Example 3:

Input: root = []
Output: true
 

Constraints:

The number of nodes in the tree is in the range [0, 5000].
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
    private static int getHeight(TreeNode node) => node == null ? 0 : 1 + Math.Max(getHeight(node.left), getHeight(node.right));
    
    public bool IsBalanced(TreeNode root){
        if(root == null) return true;
        int leftH = getHeight(root.left);
        int rightH = getHeight(root.right);

        return Math.Abs(leftH - rightH) <=1 && IsBalanced(root.left) && IsBalanced(root.right);
    }


}
