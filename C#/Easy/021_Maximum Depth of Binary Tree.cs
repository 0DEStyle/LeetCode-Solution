/*Challenge link:https://leetcode.com/problems/maximum-depth-of-binary-tree/
Question:
Given the root of a binary tree, return its maximum depth.

A binary tree's maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.

 

Example 1:


Input: root = [3,9,20,null,null,15,7]
Output: 3
Example 2:

Input: root = [1,null,2]
Output: 2
 

Constraints:

The number of nodes in the tree is in the range [0, 104].
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
//if root is null return 0
//else starting from root(1) + whichever is higher between root.left and root.right while passing them into MaxDepth recursively
public class Solution {
    public int MaxDepth(TreeNode root) {
        if(root == null) return 0;
        return 1 + Math.Max(MaxDepth(root.left), MaxDepth(root.right));
    }
}

//solution 2
//breadth first search, search by level, using queue, iterative method
public class Solution {
public class Solution {
    public int MaxDepth(TreeNode root) {
        if(root == null) return 0;

        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);
        int depth = 0;

        while(q.Count !=  0){
            var size = q.Count;
            for(int i = 0; i < size; i++){
                var current = q.Dequeue();
                if(current.left != null)
                    q.Enqueue(current.left);
                if(current.right != null)
                    q.Enqueue(current.right);
            }
            depth++;
        }
        return depth;
    }
}

//solution 3
   //Depth first search, using stack, iterative method
public class Solution {
    public int MaxDepth(TreeNode root) {
        if(root == null) return 0;

        var s = new Stack<(TreeNode, int)>();
        var res = 0;
        s.Push((root,1));

        while(s.Count !=  0){
            var (curr, currDepth) = s.Pop();
            res = Math.Max(res, currDepth);
            if(curr.left != null) s.Push((curr.left, currDepth + 1));
            if(curr.right != null) s.Push((curr.right, currDepth + 1));
        }
        return res;
    }
}
