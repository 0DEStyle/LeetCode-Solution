/*Challenge link:https://leetcode.com/problems/binary-tree-paths/description/
Question:
Given the root of a binary tree, return all root-to-leaf paths in any order.

A leaf is a node with no children.

 

Example 1:
//see image in link

Input: root = [1,2,3,null,5]
Output: ["1->2->5","1->3"]
Example 2:

Input: root = [1]
Output: ["1"]
 

Constraints:

The number of nodes in the tree is in the range [1, 100].
-100 <= Node.val <= 100
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
      public IList<string> BinaryTreePaths(TreeNode root) {
        var result = new List<string>();
        //pass treenode, string and list result into DFS method
        DFS(root, "", result);
        return result;
    }

    private void DFS(TreeNode node, string path, List<string> result) {
        //return if node is null
        //append node.val into path
        if (node == null) return;
        path += node.val.ToString();

        //if left AND right nodes are null
        //add path to result
        //else pass node left and right into DFS until the node in them are null
        if (node.left == null && node.right == null)
            result.Add(path);
        else {
            DFS(node.left, path + "->", result);
            DFS(node.right, path + "->", result);
        }
}
}
