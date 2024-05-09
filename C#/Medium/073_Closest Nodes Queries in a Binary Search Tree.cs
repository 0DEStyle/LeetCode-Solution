/*Challenge link:https://leetcode.com/problems/closest-nodes-queries-in-a-binary-search-tree/description/
Question:
You are given the root of a binary search tree and an array queries of size n consisting of positive integers.

Find a 2D array answer of size n where answer[i] = [mini, maxi]:

mini is the largest value in the tree that is smaller than or equal to queries[i]. If a such value does not exist, add -1 instead.
maxi is the smallest value in the tree that is greater than or equal to queries[i]. If a such value does not exist, add -1 instead.
Return the array answer.

 

Example 1:
(see image in link)

Input: root = [6,2,13,1,4,9,15,null,null,null,null,null,null,14], queries = [2,5,16]
Output: [[2,2],[4,6],[15,-1]]
Explanation: We answer the queries in the following way:
- The largest number that is smaller or equal than 2 in the tree is 2, and the smallest number that is greater or equal than 2 is still 2. So the answer for the first query is [2,2].
- The largest number that is smaller or equal than 5 in the tree is 4, and the smallest number that is greater or equal than 5 is 6. So the answer for the second query is [4,6].
- The largest number that is smaller or equal than 16 in the tree is 15, and the smallest number that is greater or equal than 16 does not exist. So the answer for the third query is [15,-1].
Example 2:
(see image in link)

Input: root = [4,null,9], queries = [3]
Output: [[-1,4]]
Explanation: The largest number that is smaller or equal to 3 in the tree does not exist, and the smallest number that is greater or equal to 3 is 4. So the answer for the query is [-1,4].
 

Constraints:

The number of nodes in the tree is in the range [2, 105].
1 <= Node.val <= 106
n == queries.length
1 <= n <= 105
1 <= queries[i] <= 106
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
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

    //inorder traversal method
    private void applyInOrder(TreeNode root, IList<int> list){
            if (root == null)
                return; 
            applyInOrder(root.left, list);
            list.Add(root.val);
            applyInOrder(root.right, list);
        }

    public IList<IList<int>> ClosestNodes(TreeNode root, IList<int> queries) {
          var sorted = new List<int>();
          //apply inorder traversal
            applyInOrder(root, sorted);

            var result = new List<IList<int>>();
            //check root empty
            if (root == null)
                return result; 

            //loop through each number in queries
            //apply binary search on number in sorted list.
            foreach (var number in queries){
                var found = sorted.BinarySearch(number);

                //if result greater than -1, add new items into result.
                if (found > -1)
                    result.Add(new int[] { sorted[found], sorted[found] });
                else{
                    //bitwise completment found, store in index
                    int index = ~found, smallestLarger = -1, largestSmaller = -1;

                    //if index is less than sorted.count, set smallest to current sorted index.
                    if (index < sorted.Count){
                        smallestLarger = sorted[index];
                        //if index is greater than 0, set largest to sorted index -1
                        if (index > 0)
                            largestSmaller = sorted[index - 1];
                    }
                    //set largest to sorted at sorted.count -1
                    else
                        largestSmaller = sorted[sorted.Count - 1]; 
                    //add new items into result.
                    result.Add(new int[]{largestSmaller, smallestLarger}.ToList()); 
                }
            }
            return result;
            }
}
