/*Challenge link:https://leetcode.com/problems/sum-of-mutated-array-closest-to-target/description/
Question:
Given an integer array arr and a target value target, return the integer value such that when we change all the integers larger than value in the given array to be equal to value, the sum of the array gets as close as possible (in absolute difference) to target.

In case of a tie, return the minimum such integer.

Notice that the answer is not neccesarilly a number from arr.

 

Example 1:

Input: arr = [4,9,3], target = 10
Output: 3
Explanation: When using 3 arr converts to [3, 3, 3] which sums 9 and that's the optimal answer.
Example 2:

Input: arr = [2,3,5], target = 10
Output: 5
Example 3:

Input: arr = [60864,25176,27249,21296,20204], target = 56803
Output: 11361
 

Constraints:

1 <= arr.length <= 104
1 <= arr[i], target <= 105
*/

//***************Solution********************
public class Solution {
    //simple method to find sum.
    private int sumAfterChanges(int[] array, int value) {
        int sum = 0;
        foreach(int number in array)
            sum += Math.Min(number, value);
        return sum;
    }

    //binary search
    public int FindBestValue(int[] arr, int target) {
        Array.Sort(arr);
        int left = 0, right = arr[arr.Length - 1];
        int minDifference =  Int32.MaxValue, result = 0;

        while (left <= right) {
            int middle = left + (right - left) / 2;
            int sum = sumAfterChanges(arr, middle);

            if (sum > target)
                right = middle - 1;
            else
                left = middle + 1;

            if ((Math.Abs(sum - target) < minDifference) || (Math.Abs(sum - target) == minDifference && middle < result)) {
                minDifference = Math.Abs(sum - target);
                result = middle;
            }
        }
        return result;
    }
}
