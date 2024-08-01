/*Challenge link:https://leetcode.com/problems/find-mode-in-binary-search-tree/description/
Question:
Given the root of a binary search tree (BST) with duplicates, return all the mode(s) (i.e., the most frequently occurred element) in it.

If the tree has more than one mode, return them in any order.

Assume a BST is defined as follows:

The left subtree of a node contains only nodes with keys less than or equal to the node's key.
The right subtree of a node contains only nodes with keys greater than or equal to the node's key.
Both the left and right subtrees must also be binary search trees.
 

Example 1:
//see image in link

Input: root = [1,null,2,2]
Output: [2]
Example 2:

Input: root = [0]
Output: [0]
 

Constraints:

The number of nodes in the tree is in the range [1, 104].
-105 <= Node.val <= 105
 

Follow up: Could you do that without using any extra space? (Assume that the implicit stack space incurred due to recursion does not count).
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
    private int? current_val = null;
    private int current_count = 0;
    private int max_count = 0;
    private List<int> modes = new List<int>();

    //main
    public int[] FindMode(TreeNode root) {
        in_order_traversal(root);
        return modes.ToArray();
    }

    //IOT method
    private void in_order_traversal(TreeNode node) {
        if (node == null) return;

        in_order_traversal(node.left);
        current_count = (node.val == current_val) ? current_count + 1 : 1;

        if (current_count == max_count)
            modes.Add(node.val);
        else if (current_count > max_count){
            max_count = current_count;
            modes.Clear();
            modes.Add(node.val);
        }
        current_val = node.val;
        in_order_traversal(node.right);
    }
}
