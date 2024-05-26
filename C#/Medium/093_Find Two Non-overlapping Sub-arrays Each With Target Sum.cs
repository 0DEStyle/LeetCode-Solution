/*Challenge link:https://leetcode.com/problems/find-two-non-overlapping-sub-arrays-each-with-target-sum/description/
Question:
You are given an array of integers arr and an integer target.

You have to find two non-overlapping sub-arrays of arr each with a sum equal target. There can be multiple answers so you have to find an answer where the sum of the lengths of the two sub-arrays is minimum.

Return the minimum sum of the lengths of the two required sub-arrays, or return -1 if you cannot find such two sub-arrays.

 

Example 1:

Input: arr = [3,2,2,4,3], target = 3
Output: 2
Explanation: Only two sub-arrays have sum = 3 ([3] and [3]). The sum of their lengths is 2.
Example 2:

Input: arr = [7,3,4,7], target = 7
Output: 2
Explanation: Although we have three non-overlapping sub-arrays of sum = 7 ([7], [3,4] and [7]), but we will choose the first and third sub-arrays as the sum of their lengths is 2.
Example 3:

Input: arr = [4,3,2,6,2,3,4], target = 6
Output: -1
Explanation: We have only one sub-array of sum = 6.
 

Constraints:

1 <= arr.length <= 105
1 <= arr[i] <= 1000
1 <= target <= 108
*/

//***************Solution********************
//Sliding window 
public class Solution {
    public int MinSumOfLengths(int[] arr, int target) {
        int n = arr.Length;
        int[] best = new int[n];
        //fill array best with max in value, set boundaries
        Array.Fill(best, int.MaxValue);
        int sum = 0, start = 0, ans = int.MaxValue, bestSoFar = int.MaxValue;

        //loop through arr.length
        for (int i = 0; i < n; i++){
            //accumulate sum for current element.
            sum += arr[i];
            //if sum is greater than target, subtract arr[start] from sum, increase start by 1
            while (sum > target){
                sum -= arr[start];
                start++;
            }
            //if sum matches target,  if start is greater than 0 AND best[start -1] is not max value
            //select min value between ans and best[start - 1] + i - start + 1, store in ans
            //select min value between bestSoFar and i - start + 1, store in bestSoFar
            if (sum == target){
                if (start > 0 && best[start - 1] != int.MaxValue)
                    ans = Math.Min(ans, best[start - 1] + i - start + 1);
                bestSoFar = Math.Min(bestSoFar, i - start + 1);
            }
            //update current best
            best[i] = bestSoFar;
        }
        //return -1 or ans based of validation.
        return ans == int.MaxValue ? -1 : ans;
    }
}
