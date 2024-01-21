/*Challenge link:https://leetcode.com/problems/symmetric-tree/description/
Question:
Given the root of a binary tree, check whether it is a mirror of itself (i.e., symmetric around its center).


 //check image in link

Example 1:

 //check image in link
 
Input: root = [1,2,2,3,4,4,3]
Output: true
Example 2:


Input: root = [1,2,2,null,3,null,3]
Output: false
 

Constraints:

The number of nodes in the tree is in the range [1, 1000].
-100 <= Node.val <= 100
 

Follow up: Could you solve it both recursively and iteratively?
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
    private bool checkSymetry(TreeNode l, TreeNode r){
        if(l == null || r == null)
            return l?.val == r?.val;
        if(l.val != r.val)
            return false;

        return checkSymetry(l.left, r.right) && checkSymetry(l.right, r.left);
    }

    public bool IsSymmetric(TreeNode root)  => checkSymetry(root?.left, root?.right);

}

//solution 2 iterative Depth first search
public class Solution {
     public bool IsSymmetric(TreeNode root){
        var s = new Stack<(TreeNode, TreeNode)>();
        s.Push((root.left, root.right));

        while (s.Any()){
            switch (s.Pop()){
                case (null, null): continue;

                case (null, _) or (_, null): return false;

                case (TreeNode l, TreeNode r) when l.val != r.val: return false;

                case (TreeNode l, TreeNode r) when l.val == r.val:
                    s.Push((l.left, r.right));
                    s.Push((l.right, r.left));
                    break;
            }
        }
        return true;
    }
}
