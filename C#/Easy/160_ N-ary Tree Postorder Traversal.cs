/*Challenge link:https://leetcode.com/problems/n-ary-tree-postorder-traversal/description/
Question:
Given the root of an n-ary tree, return the postorder traversal of its nodes' values.

Nary-Tree input serialization is represented in their level order traversal. Each group of children is separated by the null value (See examples)

 

Example 1:
//see image in link

Input: root = [1,null,3,2,4,null,5,6]
Output: [5,6,3,2,4,1]
Example 2:
//see image in link

Input: root = [1,null,2,3,4,5,null,null,6,7,null,8,null,9,10,null,null,11,null,12,null,13,null,null,14]
Output: [2,6,14,11,7,3,12,8,4,13,9,10,5,1]
 

Constraints:

The number of nodes in the tree is in the range [0, 104].
0 <= Node.val <= 104
The height of the n-ary tree is less than or equal to 1000.
 

Follow up: Recursive solution is trivial, could you do it iteratively?
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
    IList<int> res=new List<int>();

    //helper method
    void post(Node root){
        if(root==null)
            return;

        foreach(Node i in root.children)
            post(i);
        res.Add(root.val);
    }

    public IList<int> Postorder(Node root) {
        post(root);
        return res;
    }
}
