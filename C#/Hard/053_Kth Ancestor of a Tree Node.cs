/*Challenge link:https://leetcode.com/problems/kth-ancestor-of-a-tree-node/description/
Question:
You are given a tree with n nodes numbered from 0 to n - 1 in the form of a parent array parent where parent[i] is the parent of ith node. The root of the tree is node 0. Find the kth ancestor of a given node.

The kth ancestor of a tree node is the kth node in the path from that node to the root node.

Implement the TreeAncestor class:

TreeAncestor(int n, int[] parent) Initializes the object with the number of nodes in the tree and the parent array.
int getKthAncestor(int node, int k) return the kth ancestor of the given node node. If there is no such ancestor, return -1.
 

Example 1:
//see image in link

Input
["TreeAncestor", "getKthAncestor", "getKthAncestor", "getKthAncestor"]
[[7, [-1, 0, 0, 1, 1, 2, 2]], [3, 1], [5, 2], [6, 3]]
Output
[null, 1, 0, -1]

Explanation
TreeAncestor treeAncestor = new TreeAncestor(7, [-1, 0, 0, 1, 1, 2, 2]);
treeAncestor.getKthAncestor(3, 1); // returns 1 which is the parent of 3
treeAncestor.getKthAncestor(5, 2); // returns 0 which is the grandparent of 5
treeAncestor.getKthAncestor(6, 3); // returns -1 because there is no such ancestor
 

Constraints:

1 <= k <= n <= 5 * 104
parent.length == n
parent[0] == -1
0 <= parent[i] < n for all 0 < i < n
0 <= node < n
There will be at most 5 * 104 queries.
*/

//***************Solution********************
//    -1
//  0     0
//1  1   2  2
//int getKthAncestor(int node, int k)
//visualisation: https://www.youtube.com/watch?v=QKSfS5VMv_Q
//binary lifting(power of 2): https://www.youtube.com/watch?v=oib-XsjFa-M
//binary search divide by 2

/**
 * Your TreeAncestor object will be instantiated and called as such:
 * TreeAncestor obj = new TreeAncestor(n, parent);
 * int param_1 = obj.GetKthAncestor(node,k);
 */

//Binary Lifting
public class TreeAncestor {
    //global array variable
    int[][] dp;
    int m, n;

public TreeAncestor(int n, int[] parent){
    this.n = n;
    //index jump
    this.m = (int)(Math.Log(n) / Math.Log(2)) + 1;
    dp = new int[m][];

    //fill dp array
    for (int i = 0; i < m; i++){
        dp[i] = new int[n];
        Array.Fill(dp[i], -1);
    }

    for (int i = 0; i < m; i++){
        for (int j = 0; j < n; j++){
            if (i == 0)
                dp[i][j] = parent[j];
            else{
                if (dp[i - 1][j] == -1)
                    dp[i][j] = -1;
                else
                    dp[i][j] = dp[i - 1][dp[i - 1][j]];
            }
        }
    }
}

public int GetKthAncestor(int node, int k){
    int row = 0;
    while (k > 0){
        if ((k & 1) == 1){
            if (node == -1)
                return -1;
            node = dp[row][node];
        }
        k >>= 1;
        row++;
    }
    return node;
}
}
