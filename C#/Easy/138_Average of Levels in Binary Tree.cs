/*Challenge link:https://leetcode.com/problems/average-of-levels-in-binary-tree/description/
Question:
Given the root of a binary tree, return the average value of the nodes on each level in the form of an array. Answers within 10-5 of the actual answer will be accepted.
 

Example 1:
//see image in link

Input: root = [3,9,20,null,null,15,7]
Output: [3.00000,14.50000,11.00000]
Explanation: The average value of nodes on level 0 is 3, on level 1 is 14.5, and on level 2 is 11.
Hence return [3, 14.5, 11].
Example 2:
//see image in link

Input: root = [3,9,20,15,7]
Output: [3.00000,14.50000,11.00000]
 

Constraints:

The number of nodes in the tree is in the range [1, 104].
-231 <= Node.val <= 231 - 1
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
    public IList<double> AverageOfLevels(TreeNode root) {

    //storages
    var res = new List<double>();
    Queue<TreeNode> q = new();
    q.Enqueue(root);
    
    while(q.Count > 0){
      int size = q.Count;
      double sum = 0.0;
    
    //loop through q.count
      for(int i = 0; i < size; i++){
        var levelNode = q.Dequeue();
        sum += levelNode.val;

        if(levelNode.left != null) 
            q.Enqueue(levelNode.left);
        if(levelNode.right != null)
            q.Enqueue(levelNode.right);
      }

    //get average and add to result list
      res.Add(sum/size);
    }
    
    return res;
    }
}
