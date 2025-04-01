/*Challenge link:https://leetcode.com/problems/count-equal-and-divisible-pairs-in-an-array/description/
Question:
Given a 0-indexed integer array nums of length n and an integer k, return the number of pairs (i, j) where 0 <= i < j < n, such that nums[i] == nums[j] and (i * j) is divisible by k.
 

Example 1:

Input: nums = [3,1,2,2,2,1,3], k = 2
Output: 4
Explanation:
There are 4 pairs that meet all the requirements:
- nums[0] == nums[6], and 0 * 6 == 0, which is divisible by 2.
- nums[2] == nums[3], and 2 * 3 == 6, which is divisible by 2.
- nums[2] == nums[4], and 2 * 4 == 8, which is divisible by 2.
- nums[3] == nums[4], and 3 * 4 == 12, which is divisible by 2.
Example 2:

Input: nums = [1,2,3,4], k = 1
Output: 0
Explanation: Since no value in nums is repeated, there are no pairs (i,j) that meet all the requirements.
 

Constraints:

1 <= nums.length <= 100
1 <= nums[i], k <= 100
*/

//***************Solution********************
/*
[3,1,2,2,2,1,3]
 0 1 2 3 4 5 6

*/
public class Solution {
    public int CountPairs(int[] nums, int k) {
        var hMap = new Dictionary<int, List<int>>();
        int count = 0;
        
        for (int i = 0; i < nums.Length; i++) {
            var l = new List<int>();
            //if hash map doesn't contain current element, add i to list, set current list to l
            if(!hMap.ContainsKey(nums[i])) {
                l.Add(i);
                hMap[nums[i]] = l;
            }
            //else set list 2 to current element of hashmap
            //loop through each element in list 2, if the product of current indexs are event, increase count by 1
            else{
                var l2 = hMap[nums[i]];
                foreach (int j in l2) 
                    if ((i * j) % k == 0) 
                        count++;
                
                l2.Add(i);
                hMap[nums[i]] = l2;                
            }
        }
        return count;
        }
}
