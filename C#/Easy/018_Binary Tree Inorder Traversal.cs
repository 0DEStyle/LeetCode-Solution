/*Challenge link:https://leetcode.com/problems/binary-tree-inorder-traversal/
Question:
Given the root of a binary tree, return the inorder traversal of its nodes' values.

 

Example 1:


Input: root = [1,null,2,3]
Output: [1,3,2]
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
/*notes: 
//ref: https://en.wikipedia.org/wiki/Binary_search_tree#Traversal
Inorder: left node right (node is 'in' correct order)
Preorder: node left right (node is 'pre' postion)
Postorder: left right node (node is in 'post' position)
*/
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

//recursive method 
//create a list call res

//if root is null, return res
//then recursively traverse to left until it reaches null, and add root.val
//then recursively traverse to right, until it reaches null, then return res
public class Solution {
    List<int> res = new List<int>{};
    
    public IList<int> InorderTraversal(TreeNode root) {
        if(root == null) return res;
        InorderTraversal(root.left);
        res.Add(root.val);
        InorderTraversal(root.right);
        return res;
    }
}

//solution 2 Iterative Approach with Stack
//using stack keep track of nodes and to pop result into res
public class Solution {
    
    public IList<int> InorderTraversal(TreeNode root) {
        List<int> res = new List<int>{};
        Stack<TreeNode> stack = new Stack<TreeNode>();

        while(root != null || stack.Count > 0){
            while(root != null){
                stack.Push(root);
                root = root.left;
            }
            root = stack.Pop();
            res.Add(root.val);
            root = root.right;
        }
        return res;
    }
}

//Morris Inorder Tree traversal
//ref: https://www.youtube.com/watch?v=wGXB9OWhPTg
public class Solution {
    public IList<int> InorderTraversal(TreeNode root) {
        List<int> result = new List<int>();
        TreeNode current = root;

        while (current != null) {
            if (current.left == null) {
                result.Add(current.val);
                current = current.right;
            } else {
                TreeNode predecessor = current.left;

                while (predecessor.right != null && predecessor.right != current) {
                    predecessor = predecessor.right;
                }

                if (predecessor.right == null) {
                    predecessor.right = current;
                    current = current

.left;
                } else {
                    predecessor.right = null;
                    result.Add(current.val);
                    current = current.right;
                }
            }
        }

        return result;
    }
}
