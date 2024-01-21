/*Challenge link:https://leetcode.com/problems/same-tree/
Question:
Given the roots of two binary trees p and q, write a function to check if they are the same or not.
//see image in link
Two binary trees are considered the same if they are structurally identical, and the nodes have the same value.

 //see image in link

Example 1:

Input: p = [1,2,3], q = [1,2,3]
Output: true

Example 2:

Input: p = [1,2], q = [1,null,2]
Output: false

Example 3:

Input: p = [1,2,1], q = [1,1,2]
Output: false

 

Constraints:

    The number of nodes in both trees is in the range [0, 100].
    -104 <= Node.val <= 104


*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//solution 1, recursion

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
    public bool IsSameTree(TreeNode p, TreeNode q) {
        if(p == null || q == null) return p == q;

        return (p.val == q.val) && IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
    }
}


//solution 2 Level-Order-Traversal using Queue
public class Solution {
    public bool IsSameTree(TreeNode p, TreeNode q) {
        // Create queues for both trees.
        Queue<TreeNode> q1 = new Queue<TreeNode>();
        Queue<TreeNode> q2 = new Queue<TreeNode>();

        // Start by adding the root nodes of both trees to their respective queues.
        q1.Enqueue(p);
        q2.Enqueue(q);

         while (q1.Count > 0 && q2.Count > 0) {
            TreeNode node1 = q1.Dequeue();
            TreeNode node2 = q2.Dequeue();

            // If the values of the current nodes are not equal, the trees are not identical.
            if (node1 == null && node2 == null) 
                continue;
            if (node1 == null || node2 == null || node1.val != node2.val) 
                return false;

            // Add the left and right children of both nodes to their respective queues.
            q1.Enqueue(node1.left);
            q1.Enqueue(node1.right);
            q2.Enqueue(node2.left);
            q2.Enqueue(node2.right);
        }
        // If both queues are empty, the trees are identical.
        return q1.Count == 0 && q2.Count == 0;
    }
}

//solution 2 Level-Order-Traversal using Stack
public class Solution {
    public bool IsSameTree(TreeNode p, TreeNode q) {
        Stack<TreeNode> s1 = new Stack<TreeNode>();
        Stack<TreeNode> s2 = new Stack<TreeNode>();

        s1.Push(p);
        s2.Push(q);

        while (s1.Count > 0 && s2.Count > 0) {
            TreeNode node1 = s1.Pop();
            TreeNode node2 = s2.Pop();

            if (node1 == null && node2 == null) {
                continue;
            } else if (node1 == null || node2 == null || node1.val != node2.val) {
                return false;
            }

            s1.Push(node1.left);
            s1.Push(node1.right);
            s2.Push(node2.left);
            s2.Push(node2.right);
        }

        return s1.Count == 0 && s2.Count == 0;
    }
}

//solution 3 recursion usin Hash tree
public class Solution {
     private String computeTreeHash(TreeNode node) {
        if (node == null) return "null";
        
        String leftHash = computeTreeHash(node.left);
        String rightHash = computeTreeHash(node.right);
        return $"({node.val}{leftHash}{rightHash})";
    }

    public bool IsSameTree(TreeNode p, TreeNode q) {
        String hash1 = computeTreeHash(p);
        String hash2 = computeTreeHash(q);
        return hash1 == hash2;}
}
