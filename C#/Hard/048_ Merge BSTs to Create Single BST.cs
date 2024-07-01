/*Challenge link:https://leetcode.com/problems/merge-bsts-to-create-single-bst/description/
Question:
You are given n BST (binary search tree) root nodes for n separate BSTs stored in an array trees (0-indexed). Each BST in trees has at most 3 nodes, and no two roots have the same value. In one operation, you can:

Select two distinct indices i and j such that the value stored at one of the leaves of trees[i] is equal to the root value of trees[j].
Replace the leaf node in trees[i] with trees[j].
Remove trees[j] from trees.
Return the root of the resulting BST if it is possible to form a valid BST after performing n - 1 operations, or null if it is impossible to create a valid BST.

A BST (binary search tree) is a binary tree where each node satisfies the following property:

Every node in the node's left subtree has a value strictly less than the node's value.
Every node in the node's right subtree has a value strictly greater than the node's value.
A leaf is a node that has no children.

 

Example 1:
//see image in link

Input: trees = [[2,1],[3,2,5],[5,4]]
Output: [3,2,5,1,null,4]
Explanation:
In the first operation, pick i=1 and j=0, and merge trees[0] into trees[1].
Delete trees[0], so trees = [[3,2,5,1],[5,4]].

In the second operation, pick i=0 and j=1, and merge trees[1] into trees[0].
Delete trees[1], so trees = [[3,2,5,1,null,4]].

The resulting tree, shown above, is a valid BST, so return its root.
Example 2:
//see image in link

Input: trees = [[5,3,8],[3,2,6]]
Output: []
Explanation:
Pick i=0 and j=1 and merge trees[1] into trees[0].
Delete trees[1], so trees = [[5,3,8,2,6]].

The resulting tree is shown above. This is the only valid operation that can be performed, but the resulting tree is not a valid BST, so return null.
Example 3:
//see image in link

Input: trees = [[5,4],[3]]
Output: []
Explanation: It is impossible to perform any operations.
 

Constraints:

n == trees.length
1 <= n <= 5 * 104
The number of nodes in each tree is in the range [1, 3].
Each node in the input may have children but no grandchildren.
No two roots of trees have the same value.
All the trees in the input are valid BSTs.
1 <= TreeNode.val <= 5 * 104.
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
 //Every node in the node's left subtree has a value strictly less than the node's value.
//Every node in the node's right subtree has a value strictly greater than the node's value.
public class Solution {
    public TreeNode CanMerge(IList<TreeNode> trees) {
    // Collect the leaves
    var leaves = new HashSet<int>();
    var map = new Dictionary<int, TreeNode>();

    foreach (TreeNode tree in trees){
        map[tree.val] = tree;
        if (tree.left != null)
            leaves.Add(tree.left.val);
        if (tree.right != null)
            leaves.Add(tree.right.val);
    }

    // Decide the root of the resulting tree
    TreeNode result = null;
    foreach (TreeNode tree in trees){
        if (!leaves.Contains(tree.val)){
            result = tree;
            break;
        }
    }
    if (result == null)
        return null;
    return Traverse(result, map, int.MinValue, int.MaxValue) && map.Count == 1 ? result : null;
}
    public bool Traverse(TreeNode root, Dictionary<int, TreeNode> map, int min, int max){
    if (root == null)
        return true;
    if (root.val <= min || root.val >= max)
        return false;

    if (root.left == null && root.right == null){
        if (map.ContainsKey(root.val) && root != map[root.val]){
            TreeNode next = map[root.val];
            root.left = next.left;
            root.right = next.right;
            map.Remove(root.val);
        }
    }
    return Traverse(root.left, map, min, root.val) && Traverse(root.right, map, root.val, max);
}
}
