/*Challenge link:https://leetcode.com/problems/univalued-binary-tree/description/
Question:
A binary tree is uni-valued if every node in the tree has the same value.

Given the root of a binary tree, return true if the given tree is uni-valued, or false otherwise.

 

Example 1:
//see image in link

Input: root = [1,1,1,1,1,null,1]
Output: true
Example 2:
//see image in link

Input: root = [2,2,2,5,2]
Output: false
 

Constraints:

The number of nodes in the tree is in the range [1, 100].
0 <= Node.val < 100
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
    public bool IsUnivalTree(TreeNode root) => check(root, root.val);

    private bool check(TreeNode node, int preVal){
        if (node == null)
            return true;
        if (node.val != preVal)
            return false;
        return check(node.left, node.val) && check(node.right, node.val);
    }
}
