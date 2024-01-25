/*Challenge link:https://leetcode.com/problems/minimum-depth-of-binary-tree/description/
Question:
Given a binary tree, find its minimum depth.

The minimum depth is the number of nodes along the shortest path from the root node down to the nearest leaf node.

Note: A leaf is a node with no children.

 

Example 1:

//see image at link

Input: root = [3,9,20,null,null,15,7]
Output: 2
Example 2:

Input: root = [2,null,3,null,4,null,5,null,6]
Output: 5
 

Constraints:

The number of nodes in the tree is in the range [0, 105].
-1000 <= Node.val <= 1000
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

//depth first search, recursive method 
//T: O(N)
//S: O(N)
public class Solution {
    public int MinDepth(TreeNode root) {
        if(root == null) return 0;
        var leftMinDepth = MinDepth(root.left);
        var rightMinDepth = MinDepth(root.right);
        
        return leftMinDepth == 0 || rightMinDepth == 0 ? Math.Max(leftMinDepth, rightMinDepth) + 1 : 
                                                         Math.Min(leftMinDepth, rightMinDepth) + 1;
    }
}

//solution 2 Breadth-First Search
public class Solution {
    public int MinDepth(TreeNode root) {
        if(root == null) return 0;
        
        var depth = 0;
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count != 0){
            var size = queue.Count;

            for (var i = 0; i < size; i++){
                var curr = queue.Dequeue();

                if (curr.left != null) queue.Enqueue(curr.left);
                if (curr.right!= null) queue.Enqueue(curr.right); 
                if (curr.left == null && curr.right == null) return depth + 1;
            }
            depth++;
        }
        return 0;
    }
}
