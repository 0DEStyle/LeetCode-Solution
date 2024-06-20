/*Challenge link:https://leetcode.com/problems/max-sum-of-rectangle-no-larger-than-k/description/
Question:
Given an m x n matrix matrix and an integer k, return the max sum of a rectangle in the matrix such that its sum is no larger than k.

It is guaranteed that there will be a rectangle with a sum no larger than k.

 

Example 1:
//see image in link

Input: matrix = [[1,0,1],[0,-2,3]], k = 2
Output: 2
Explanation: Because the sum of the blue rectangle [[0, 1], [-2, 3]] is 2, and 2 is the max number no larger than k (k = 2).
Example 2:

Input: matrix = [[2,2,-1]], k = 3
Output: 3
 

Constraints:

m == matrix.length
n == matrix[i].length
1 <= m, n <= 100
-100 <= matrix[i][j] <= 100
-105 <= k <= 105
 

Follow up: What if the number of rows is much larger than the number of columns?
*/

//***************Solution********************
public class Solution {
    //main
    public int MaxSumSubmatrix(int[][] matrix, int k) {
        int n=matrix.Length;
        int m=matrix[0].Length;
        int max=int.MinValue;
        
        for(int i=0;i<n;i++)
        {
            var a = new int[m];
            for(int j=i;j<n;j++)
            {
                for(int x=0;x<m;x++)
                a[x]+=matrix[j][x];
                
                int sum=helper(a,k);
                max=Math.Max(max,sum);
            }
        }
        return max;
    }
    
    public int helper(int[] a, int k)
    {
        int ans=int.MinValue;
        
        for(int i=0;i<a.Length;i++)
        {
            int s=0;
            for(int j=i;j<a.Length;j++)
            {
                s+=a[j];
                if(s<=k)
                ans=Math.Max(ans,s);
            }
        }
        return ans;
    }
 }
