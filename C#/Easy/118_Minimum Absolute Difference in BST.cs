/*Challenge link:https://leetcode.com/problems/minimum-absolute-difference-in-bst/description/
Question:
Given the root of a Binary Search Tree (BST), return the minimum absolute difference between the values of any two different nodes in the tree.

 

Example 1:
//see image in link

Input: root = [4,2,6,1,3]
Output: 1
Example 2:
//see image in link

Input: root = [1,0,48,null,null,12,49]
Output: 1
 

Constraints:

The number of nodes in the tree is in the range [2, 104].
0 <= Node.val <= 105
 

Note: This question is the same as 783: https://leetcode.com/problems/minimum-distance-between-bst-nodes/
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
    int lastValue, minimumDelta;

    public int GetMinimumDifference(TreeNode root) {
        lastValue = Int32.MaxValue;
        minimumDelta = Int32.MaxValue;
        
        //check condition and find min
        CheckNode(root);
        return minimumDelta;
    }

    // check nodes and update value of minumumDelta
    private void CheckNode(TreeNode node){
        if (node == null) 
            return;

        CheckNode(node.left);
        minimumDelta = Math.Min(minimumDelta, Math.Abs(lastValue - node.val));
        lastValue = node.val;
        CheckNode(node.right);
    }
}
