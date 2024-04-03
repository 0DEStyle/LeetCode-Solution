/*Challenge link:https://leetcode.com/problems/maximum-length-of-repeated-subarray/description/
Question:
Given two integer arrays nums1 and nums2, return the maximum length of a subarray that appears in both arrays.

 

Example 1:

Input: nums1 = [1,2,3,2,1], nums2 = [3,2,1,4,7]
Output: 3
Explanation: The repeated subarray with maximum length is [3,2,1].
Example 2:

Input: nums1 = [0,0,0,0,0], nums2 = [0,0,0,0,0]
Output: 5
Explanation: The repeated subarray with maximum length is [0,0,0,0,0].
 

Constraints:

1 <= nums1.length, nums2.length <= 1000
0 <= nums1[i], nums2[i] <= 100
*/

//***************Solution********************
public class Solution {
    public int FindLength(int[] nums1, int[] nums2) {
        //get length of num1 and num2 array.
        int n= nums1.Length, m= nums2.Length, ans=0;

        //dynamic programming storage
        var dp= new int[n+1, m+1];
        
        //loop through each element 
        for(int i=1;i<=n;i++)
            for(int j=1;j<=m;j++){

                //check if curretn element of num1 is the same as num2
                //if so, set dp[i,j] to 1+ last element
                //select max value between ans and curretn element
                if(nums1[i-1]==nums2[j-1] ){
                    dp[i,j ]= 1+ dp[i-1, j-1];
                    ans=Math.Max(ans,dp[i, j] );
                } 
                //set curretn element to 0
                else dp[i,j]=0;
            }
        return ans;
    }
}
