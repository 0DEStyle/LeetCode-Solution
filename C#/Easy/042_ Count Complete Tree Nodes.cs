/*Challenge link:https://leetcode.com/problems/count-complete-tree-nodes/description/
Question:
Given the root of a complete binary tree, return the number of the nodes in the tree.

According to Wikipedia, every level, except possibly the last, is completely filled in a complete binary tree, and all nodes in the last level are as far left as possible. It can have between 1 and 2h nodes inclusive at the last level h.

Design an algorithm that runs in less than O(n) time complexity.

 

Example 1:


Input: root = [1,2,3,4,5,6]
Output: 6
Example 2:

Input: root = []
Output: 0
Example 3:

Input: root = [1]
Output: 1
 

Constraints:

The number of nodes in the tree is in the range [0, 5 * 104].
0 <= Node.val <= 5 * 104
The tree is guaranteed to be complete.
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
    public int CountNodes(TreeNode n){
        if (n == null) 
            return 0;
        int h = GetHeight(n, true);

        //check if height is a perfect binary tree
        //if true, left shift height and -1
        //else add leftside and right side.
        return h == GetHeight(n, false) ? 
            (1 << h) - 1 : 1 + CountNodes(n.left) + CountNodes(n.right);
        
        //count the treeNode to the left.
        int GetHeight(TreeNode n, bool toLeft){
            if (n == null) 
                return 0;
            int res = 1;
            while ((n = toLeft ? n.left : n.right) != null) 
                res++;
            return res;
        }
    }
}
