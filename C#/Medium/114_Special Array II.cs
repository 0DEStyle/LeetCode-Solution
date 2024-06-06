/*Challenge link:https://leetcode.com/problems/special-array-ii/description/
Question:
An array is considered special if every pair of its adjacent elements contains two numbers with different parity.

You are given an array of integer nums and a 2D integer matrix queries, where for queries[i] = [fromi, toi] your task is to check that 
subarray
 nums[fromi..toi] is special or not.

Return an array of booleans answer such that answer[i] is true if nums[fromi..toi] is special.

 

Example 1:

Input: nums = [3,4,1,2,6], queries = [[0,4]]

Output: [false]

Explanation:

The subarray is [3,4,1,2,6]. 2 and 6 are both even.

Example 2:

Input: nums = [4,3,1,6], queries = [[0,2],[2,3]]

Output: [false,true]

Explanation:

The subarray is [4,3,1]. 3 and 1 are both odd. So the answer to this query is false.
The subarray is [1,6]. There is only one pair: (1,6) and it contains numbers with different parity. So the answer to this query is true.
 

Constraints:

1 <= nums.length <= 105
1 <= nums[i] <= 105
1 <= queries.length <= 105
queries[i].length == 2
0 <= queries[i][0] <= queries[i][1] <= nums.length - 1
*/

//***************Solution********************
public class Solution {
    public bool[] IsArraySpecial(int[] nums, int[][] queries) {
        //create a new list
        var indexes = new List<int>();

        //loop through nums length
        //if current element mod 2 equal to last element mod 2, add to index
        for (var i = 1; i < nums.Length; i++)
            if (nums[i] % 2 == nums[i - 1] % 2)
                indexes.Add(i);

        //convert array queries to query
        // pass query[0] and query[1] into binary search, get the absolute value
        //because it return negative if no match, check if i0 is equal to i1
        return Array.ConvertAll(queries, query =>{
            var i0 = Math.Abs(indexes.BinarySearch(query[0]) + 1);
            var i1 = Math.Abs(indexes.BinarySearch(query[1]) + 1);
            return i0 == i1;
        });
}
}
