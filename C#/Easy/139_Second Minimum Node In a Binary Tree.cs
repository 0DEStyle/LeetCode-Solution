/*Challenge link:https://leetcode.com/problems/second-minimum-node-in-a-binary-tree/description/
Question:
Given a non-empty special binary tree consisting of nodes with the non-negative value, where each node in this tree has exactly two or zero sub-node. If the node has two sub-nodes, then this node's value is the smaller value among its two sub-nodes. More formally, the property root.val = min(root.left.val, root.right.val) always holds.

Given such a binary tree, you need to output the second minimum value in the set made of all the nodes' value in the whole tree.

If no such second minimum value exists, output -1 instead.

 

 

Example 1:
//see image in link

Input: root = [2,2,5,null,null,5,7]
Output: 5
Explanation: The smallest value is 2, the second smallest value is 5.
Example 2:
//see image in link

Input: root = [2,2,2]
Output: -1
Explanation: The smallest value is 2, but there isn't any second smallest value.
 

Constraints:

The number of nodes in the tree is in the range [1, 25].
1 <= Node.val <= 231 - 1
root.val == min(root.left.val, root.right.val) for each internal node of the tree.
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
    public int FindSecondMinimumValue(TreeNode root) {
        bool found = false;
        int secondMinimal = int.MaxValue, minimal = root.val;
        //node stack
        var stack = new Stack<TreeNode>();
        stack.Push(root);

        //loop while stack count is not 0
        while (stack.Count != 0){
            var node = stack.Pop();
            //if target found, set node val to 2nd min
            if (node.val > minimal && node.val <= secondMinimal){
                found = true;
                secondMinimal = node.val;
            }
           
           //if node val is less than 2nd min
           //if left is not null, push node left
           //if right is not null, push node right.
            if (node.val < secondMinimal){
                if (node.left != null)
                    stack.Push(node.left);
                if (node.right != null)
                    stack.Push(node.right);
            }
        }
        return found ? secondMinimal : -1;
    }
}
