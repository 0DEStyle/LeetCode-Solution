/*Challenge link:https://leetcode.com/problems/longest-subsequence-with-limited-sum/description/
Question:
You are given an integer array nums of length n, and an integer array queries of length m.

Return an array answer of length m where answer[i] is the maximum size of a subsequence that you can take from nums such that the sum of its elements is less than or equal to queries[i].

A subsequence is an array that can be derived from another array by deleting some or no elements without changing the order of the remaining elements.

 

Example 1:

Input: nums = [4,5,2,1], queries = [3,10,21]
Output: [2,3,4]
Explanation: We answer the queries as follows:
- The subsequence [2,1] has a sum less than or equal to 3. It can be proven that 2 is the maximum size of such a subsequence, so answer[0] = 2.
- The subsequence [4,5,1] has a sum less than or equal to 10. It can be proven that 3 is the maximum size of such a subsequence, so answer[1] = 3.
- The subsequence [4,5,2,1] has a sum less than or equal to 21. It can be proven that 4 is the maximum size of such a subsequence, so answer[2] = 4.
Example 2:

Input: nums = [2,3,4,5], queries = [1]
Output: [0]
Explanation: The empty subsequence is the only subsequence that has a sum less than or equal to 1, so answer[0] = 0.
 

Constraints:

n == nums.length
m == queries.length
1 <= n, m <= 1000
1 <= nums[i], queries[i] <= 106
*/

//***************Solution********************
public class Solution {
    public int[] AnswerQueries(int[] nums, int[] queries) {
        //make new array res with queries length
        //sort the original array nums
        var res = new int[queries.Length];
        Array.Sort(nums);

        //loop through each item inside queries
        //set current element as queries[i]
        //total and count to 0
        for(int i = 0; i < queries.Length; i++){
            int element = queries[i];
            int total = 0, count = 0;

            //loop through the nums array,
            //if total + current element is less than or equal to element, then increase count by 1, add current nums to total
            for(int j = 0;j < nums.Length; j++){
                if(total + nums[j] <= element){
                    count++;
                    total += nums[j];
                }
                else break;
            }
            //set current res with new count
            res[i] = count; 
        }
        return res;
    }
}
