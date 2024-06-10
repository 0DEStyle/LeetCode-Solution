/*Challenge link:https://leetcode.com/problems/find-the-kth-smallest-sum-of-a-matrix-with-sorted-rows/description/
Question:
You are given an m x n matrix mat that has its rows sorted in non-decreasing order and an integer k.

You are allowed to choose exactly one element from each row to form an array.

Return the kth smallest array sum among all possible arrays.

 

Example 1:

Input: mat = [[1,3,11],[2,4,6]], k = 5
Output: 7
Explanation: Choosing one element from each row, the first k smallest sum are:
[1,2], [1,4], [3,2], [3,4], [1,6]. Where the 5th sum is 7.
Example 2:

Input: mat = [[1,3,11],[2,4,6]], k = 9
Output: 17
Example 3:

Input: mat = [[1,10,10],[1,4,5],[2,3,6]], k = 7
Output: 9
Explanation: Choosing one element from each row, the first k smallest sum are:
[1,1,2], [1,1,3], [1,4,2], [1,4,3], [1,1,6], [1,5,2], [1,5,3]. Where the 7th sum is 9.  
 

Constraints:

m == mat.length
n == mat.length[i]
1 <= m, n <= 40
1 <= mat[i][j] <= 5000
1 <= k <= min(200, nm)
mat[i] is a non-decreasing array.
*/

//***************Solution********************
public class Solution {
    //check less than method
    public int LessThan(int[][] mat, int sum, int idx, int k){
        //return 0 if sum i sless than 0
    if (sum < 0)
        return 0;
        //return 1 if index is same as mat length
    if (idx == mat.Length)
        return 1;

    int ans = 0;
    //loop through mat[0] length
    for (int j = 0; j < mat[0].Length; j++){
        //recursively set cnt
        int cnt = LessThan(mat, sum - mat[idx][j], idx + 1, k - ans);
        //if cnt is 0 break
        if (cnt == 0) 
            break;

        //accumulate ans by adding cnt
        //if ans is greater than k, break
        ans += cnt;
        if (ans > k)
            break;
    }
    return ans;
}

    public int KthSmallest(int[][] mat, int k){
        //set boundaries
    int m = mat.Length, n = mat[0].Length, left = m, right = 5000 * m, sum = 0;

    while (left <= right){
        //find mid index
        int mid = left +(right- left) / 2;
        //get cnt by passing variable to LessThan method
        int cnt = LessThan(mat, mid, 0, k);

        //shift index accordingly
        if (cnt >= k){
            right = mid - 1;
            sum = mid;
        }
        else
            left = mid + 1;
    }
    return sum;
}
}
