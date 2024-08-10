/*Challenge link:https://leetcode.com/problems/maximum-depth-of-n-ary-tree/description/
Question:
Given a n-ary tree, find its maximum depth.

The maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.

Nary-Tree input serialization is represented in their level order traversal, each group of children is separated by the null value (See examples).

 

Example 1:

//see image in link

Input: root = [1,null,3,2,4,null,5,6]
Output: 3
Example 2:
//see image in link


Input: root = [1,null,2,3,4,5,null,null,6,7,null,8,null,9,10,null,null,11,null,12,null,13,null,null,14]
Output: 5
 

Constraints:

The total number of nodes is in the range [0, 104].
The depth of the n-ary tree is less than or equal to 1000.
*/

//***************Solution********************
/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/

public class Solution {
   public int MaxDepth(Node root) {
        int depth = GetDepth(root, 0);
        return depth;    
    }

    private int GetDepth(Node node, int level){
        if (node == null)
             return level; 
        int curDepth = level + 1;

        if (node.children == null || node.children.Count == 0) 
            return curDepth;

        int maxDepth = curDepth;
        
        for (int i = 0; i < node.children.Count; i++){
            int depth = GetDepth(node.children[i], curDepth);
            if (maxDepth < depth) { maxDepth = depth; }
        }

        return maxDepth;
    }
}
