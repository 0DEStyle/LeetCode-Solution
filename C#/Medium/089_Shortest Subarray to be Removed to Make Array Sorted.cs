/*Challenge link:https://leetcode.com/problems/shortest-subarray-to-be-removed-to-make-array-sorted/description/
Question:
Given an integer array arr, remove a subarray (can be empty) from arr such that the remaining elements in arr are non-decreasing.

Return the length of the shortest subarray to remove.

A subarray is a contiguous subsequence of the array.

 

Example 1:

Input: arr = [1,2,3,10,4,2,3,5]
Output: 3
Explanation: The shortest subarray we can remove is [10,4,2] of length 3. The remaining elements after that will be [1,2,3,3,5] which are sorted.
Another correct solution is to remove the subarray [3,10,4].
Example 2:

Input: arr = [5,4,3,2,1]
Output: 4
Explanation: Since the array is strictly decreasing, we can only keep a single element. Therefore we need to remove a subarray of length 4, either [5,4,3,2] or [4,3,2,1].
Example 3:

Input: arr = [1,2,3]
Output: 0
Explanation: The array is already non-decreasing. We do not need to remove any elements.
 

Constraints:

1 <= arr.length <= 105
0 <= arr[i] <= 109
*/

//***************Solution********************
/*
Tip: For problems, like this, always think of drawing mountains from the array (peak and valley) and analyzing the mountains. I got the solution by using that only.
*/
//2nd attempt code, faster ver
/*
Tip: For problems, like this, always think of drawing mountains from the array (peak and valley) and analyzing the mountains. I got the solution by using that only.
*/
public class Solution {
    public int FindLengthOfShortestSubarray(int[] arr) {
        int n = arr.Length; if (n<2) return 0;
        int result = 0;
        // Case 'equality', optional, main case covers this also
        if (arr[0]==arr[n-1]) {
            for (int i=0; i<n-1; i++) {
                if (arr[i]!=arr[0]) result++;
            }
            return result;
        }
        // Main case, two pointers
        // First set minimized right position:
        int l = 0, r = n - 1;
        for (;r > 0 && arr[r - 1] <= arr[r]; r--);
        result = r;
        // Now going to find optimal left position
        for (; l < r && (l == 0 || arr[l - 1] <= arr[l]); l++) {
            // adjust the right pointer and update the result
            while (r<n && arr[r]<arr[l]) r++;
            result = Math.Min(result, r-l-1);
        }
        return result;
    }
}


//1st attempt code, slower ver
public class Solution {
    public int FindLengthOfShortestSubarray(int[] A) {
        //boundaries
        int N = A.Length, left = 0, right = N - 1;

        //if left + 1 is less than arr length AND current left is less than or equal to current left + 1
        //increase left by 1,
        while (left + 1 < N && A[left] <= A[left + 1]) 
            left++;
        
        //if left is equal to a.length -1, return 0
        if (left == N - 1) return 0;

        //if right + 1 is greater than left AND current right - 1 is less than or equal to current right
        //decrease right by 1,
        while (right > left && A[right - 1] <= A[right])
            right--;

        //select min value between left and right
        int ans = Math.Min(N - left - 1, right), i = 0, j = right;

        //i is less than or equal to left AND j is less than n
        while (i <= left && j < N) {
            //if right of a is greater or equal to left, select min value between ans and (right - left - 1)
            if (A[j] >= A[i]) {
                ans = Math.Min(ans, j - i - 1);
                i++;
            } 
            else 
                j++;
        }
        return ans;
    }
}
