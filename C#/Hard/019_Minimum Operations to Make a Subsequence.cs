/*Challenge link:https://leetcode.com/problems/minimum-operations-to-make-a-subsequence/description/
Question:
You are given an array target that consists of distinct integers and another integer array arr that can have duplicates.

In one operation, you can insert any integer at any position in arr. For example, if arr = [1,4,1,2], you can add 3 in the middle and make it [1,4,3,1,2]. Note that you can insert the integer at the very beginning or end of the array.

Return the minimum number of operations needed to make target a subsequence of arr.

A subsequence of an array is a new array generated from the original array by deleting some elements (possibly none) without changing the remaining elements' relative order. For example, [2,7,4] is a subsequence of [4,2,3,7,2,1,4] (the underlined elements), while [2,4,2] is not.

 

Example 1:

Input: target = [5,1,3], arr = [9,4,2,3,4]
Output: 2
Explanation: You can add 5 and 1 in such a way that makes arr = [5,9,4,1,2,3,4], then target will be a subsequence of arr.
Example 2:

Input: target = [6,4,8,1,3,2], arr = [4,7,6,2,3,8,6,1]
Output: 3
 

Constraints:

1 <= target.length, arr.length <= 105
1 <= target[i], arr[i] <= 109
target contains no duplicates.
*/

//***************Solution********************
public class Solution {
    public int MinOperations(int[] target, int[] arr) {
        var indexMap = new Dictionary<int, int>();
        var indices = new List<int>();

        for (int i = 0; i < target.Length; i++) 
            indexMap[target[i]] = i;
        foreach (var num in arr)
            if (indexMap.ContainsKey(num)) 
                indices.Add(indexMap[num]);
        
        int maxLength = LongestIncreasingSubsequence(indices.ToArray());
        return target.Length - maxLength;
    }
    
    private int LongestIncreasingSubsequence(int[] nums) {
        var lis = new List<int>();
        
        foreach (var num in nums) {
            //find mid index, the method returns negative if index is not found
            // so we use abs value in that case
            int index = lis.BinarySearch(num);
            
            //check condition
            if (index < 0)
                index = Math.Abs(index) - 1;
            if (index == lis.Count)
                lis.Add(num);
            else
                lis[index] = num;
        }
        return lis.Count;
}
}
