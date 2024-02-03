/*Challenge link:https://leetcode.com/problems/binary-tree-postorder-traversal/description/
Question:
Given the root of a binary tree, return the postorder traversal of its nodes' values.

 

Example 1:

//see image in link

Input: root = [1,null,2,3]
Output: [3,2,1]
Example 2:

Input: root = []
Output: []
Example 3:

Input: root = [1]
Output: [1]
 

Constraints:

The number of the nodes in the tree is in the range [0, 100].
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
    public IList<int> PostorderTraversal(TreeNode root) {
        IList<int> posOrder = new List<int>();
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode node = root;
        
        //check if node is not empty
        if (node != null) stack.Push(node);

        while (stack.Count > 0) {
            node = stack.Pop();
            if(node == null) continue;

            //if left and right are null, add node.val into posOrder List
            if (node.left == null && node.right == null){
                posOrder.Add(node.val); 
                continue;
            }
            //push node, node right and left into stack, then set them to null
            stack.Push(node);
            stack.Push(node.right); node.right = null;
            stack.Push(node.left);  node.left = null;
        }
        return posOrder; 
}
}
