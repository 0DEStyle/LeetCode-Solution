/*Challenge link:https://leetcode.com/problems/cousins-in-binary-tree/description/
Question:
Given the root of a binary tree with unique values and the values of two different nodes of the tree x and y, return true if the nodes corresponding to the values x and y in the tree are cousins, or false otherwise.

Two nodes of a binary tree are cousins if they have the same depth with different parents.

Note that in a binary tree, the root node is at the depth 0, and children of each depth k node are at the depth k + 1.

 

Example 1:
//see image in link

Input: root = [1,2,3,4], x = 4, y = 3
Output: false
Example 2:
//see image in link

Input: root = [1,2,3,null,4,null,5], x = 5, y = 4
Output: true
Example 3:
//see image in link

Input: root = [1,2,3,null,4], x = 2, y = 3
Output: false
 

Constraints:

The number of nodes in the tree is in the range [2, 100].
1 <= Node.val <= 100
Each node has a unique value.
x != y
x and y are exist in the tree.
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
    public bool IsCousins(TreeNode root, int x, int y) {
        TreeNode xParent = null, yParent = null;
        int xDepth = -1, yDepth = -1;

        void Traverse(TreeNode node, int depth, TreeNode parent){
            //if null, return.
            if (node == null)
                return;
            
            //if val is equal to x, set parent and depth
            if (node.val == x) { 
                xParent = parent; 
                xDepth = depth; 
                }

            //if val is equal to y, set parent and depth
            if (node.val == y) { 
                yParent = parent; 
                yDepth = depth; 
                }

            //recursion, pass left and right into Traverse
            Traverse(node.left, depth + 1, node);
            Traverse(node.right, depth + 1, node);
        }

        //check update root, check if parents are different and depth are the same.
        Traverse(root, 0, null);
        return xParent != yParent && xDepth == yDepth;
    }
}
