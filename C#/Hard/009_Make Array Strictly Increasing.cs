/*Challenge link:https://leetcode.com/problems/make-array-strictly-increasing/description/
Question:
Given two integer arrays arr1 and arr2, return the minimum number of operations (possibly zero) needed to make arr1 strictly increasing.

In one operation, you can choose two indices 0 <= i < arr1.length and 0 <= j < arr2.length and do the assignment arr1[i] = arr2[j].

If there is no way to make arr1 strictly increasing, return -1.

 

Example 1:

Input: arr1 = [1,5,3,6,7], arr2 = [1,3,2,4]
Output: 1
Explanation: Replace 5 with 2, then arr1 = [1, 2, 3, 6, 7].
Example 2:

Input: arr1 = [1,5,3,6,7], arr2 = [4,3,1]
Output: 2
Explanation: Replace 5 with 3 and then replace 3 with 4. arr1 = [1, 3, 4, 6, 7].
Example 3:

Input: arr1 = [1,5,3,6,7], arr2 = [1,6,3,3]
Output: -1
Explanation: You can't make arr1 strictly increasing.
 

Constraints:

1 <= arr1.length, arr2.length <= 2000
0 <= arr1[i], arr2[i] <= 10^9
*/

//***************Solution********************
public class Solution {
    private readonly Dictionary<(int, int), int> _dp = new();
    private const int MaxCost = int.MaxValue - 1;

    public int MakeArrayIncreasing(int[] arr1, int[] arr2){
        Array.Sort(arr2);
        var answer = dfs(0, -1, arr1, arr2);
        return answer < MaxCost ? answer : -1;
    }

    //depth first search
    private int dfs(int i, int prev, int[] arr1, int[] arr2){
        if (i == arr1.Length)
            return 0;

        var key = (i, prev);
        if (_dp.TryGetValue(key, out var cached))
            return cached;

        var cost = MaxCost;
        // If arr1[i] is already greater than prev, we can leave it be.
        if (arr1[i] > prev)
            cost = dfs(i + 1, arr1[i], arr1, arr2);

        // Find a replacement with the smallest value in arr2.
        var idx = bisectRight(arr2, prev);

        // Replace arr1[i], with a cost of 1 operation.
        if (idx < arr2.Length)
            cost = Math.Min(cost, 1 + dfs(i + 1, arr2[idx], arr1, arr2));
        return _dp[key] =  cost;
    }

    // binary search
    private static int bisectRight(int[] arr, int value){
        int left = 0, right = arr.Length;

        while (left < right){
            //find mid index
            int mid = left + (right - left) / 2;

            //check condition
            if (arr[mid] <= value)
                left = mid + 1;
            else
                right = mid;
        }
        return left;
    }
}
