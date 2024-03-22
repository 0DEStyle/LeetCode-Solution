/*Challenge link:https://leetcode.com/problems/k-th-smallest-prime-fraction/description/
Question:

Code
Testcase
Testcase
Test Result
786. K-th Smallest Prime Fraction
Solved
Medium
Topics
Companies
You are given a sorted integer array arr containing 1 and prime numbers, where all the integers of arr are unique. You are also given an integer k.

For every i and j where 0 <= i < j < arr.length, we consider the fraction arr[i] / arr[j].

Return the kth smallest fraction considered. Return your answer as an array of integers of size 2, where answer[0] == arr[i] and answer[1] == arr[j].

 

Example 1:

Input: arr = [1,2,3,5], k = 3
Output: [2,5]
Explanation: The fractions to be considered in sorted order are:
1/5, 1/3, 2/5, 1/2, 3/5, and 2/3.
The third fraction is 2/5.
Example 2:

Input: arr = [1,7], k = 1
Output: [1,7]
 

Constraints:

2 <= arr.length <= 1000
1 <= arr[i] <= 3 * 104
arr[0] == 1
arr[i] is a prime number for i > 0.
All the numbers of arr are unique and sorted in strictly increasing order.
1 <= k <= arr.length * (arr.length - 1) / 2
 

Follow up: Can you solve the problem with better than O(n2) complexity?
*/

//***************Solution********************
//binary search method
public class Solution {
    public int[] getFractionsLessThanMid(int[] arr,int k,int n,double mid) {
        double maxLessThanMid = 0.0;
        //stores indices (x and y )of max fraction less than mid;
        //for storing fractions less than mid ()total)
        int x = 0, y = 0,  total = 0, j = 1;
        
        //loop throught the arr.Length n
        for(int i=0;i<n-1;i++){    
            //while fraction is greater than mid increment j
            while(j<n && arr[i]>arr[j]*mid){
                j++;
            }
            //if j is the same as arr.Length n, break
            if(j==n) break;

            //j fractions greater than mid, n-j fractions smaller than mid, add fractions smaller than mid to total
            total+=(n-j); 

            //get fraction
            double fraction = (double)arr[i]/arr[j];
            
            //update variables
            if(fraction>maxLessThanMid){
                maxLessThanMid = fraction;
                x = i;
                y = j;
            }
        }
        //format and return result
        return new int[]{total,x,y};
    }

    public int[] KthSmallestPrimeFraction(int[] arr, int k) {
        int n = arr.Length;
        double low = 0, high = 1;

        while(low<high){
            //get mid index
            double mid = low + (high - low)/2;
            //passs arr, k, arr.Length, mid index into the method getFractionsLessThanMid
            int[]  res = getFractionsLessThanMid(arr,k,n,mid);
            
            //if contion met, format and return result
            //else if res[0] is less than k, set high to mid 
            //else set low to mid
            if(res[0]==k) return new int[]{arr[res[1]],arr[res[2]]};
            else if(res[0]>k) high = mid;
            else low = mid;
        }
        return new int[]{};
    }
}
