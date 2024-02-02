/*Challenge link:https://leetcode.com/problems/binary-tree-preorder-traversal/description/
Question:
Given the root of a binary tree, return the preorder traversal of its nodes' values.

 

Example 1:
//see image in link

Input: root = [1,null,2,3]
Output: [1,2,3]
Example 2:

Input: root = []
Output: []
Example 3:

Input: root = [1]
Output: [1]
 

Constraints:

The number of nodes in the tree is in the range [0, 100].
-100 <= Node.val <= 100
 

Follow up: Recursive solution is trivial, could you do it iteratively?
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
    public IList<int> PreorderTraversal(TreeNode root) {
      //create stack and list
        IList<int> preOrder = new List<int>();
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode node = root;

      //if null
        if (node != null) stack.Push(node);
      
        // go from visit > left > right
        while (stack.Count > 0) {
            node = stack.Pop();
            preOrder.Add(node.val); 
            if (node.right != null)stack.Push(node.right);
            if (node.left != null) stack.Push(node.left);
        }
        return preOrder;
    }
}
