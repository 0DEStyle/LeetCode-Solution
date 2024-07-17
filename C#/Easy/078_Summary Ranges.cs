/*Challenge link:https://leetcode.com/problems/summary-ranges/description/
Question:
You are given a sorted unique integer array nums.

A range [a,b] is the set of all integers from a to b (inclusive).

Return the smallest sorted list of ranges that cover all the numbers in the array exactly. That is, each element of nums is covered by exactly one of the ranges, and there is no integer x such that x is in one of the ranges but not in nums.

Each range [a,b] in the list should be output as:

"a->b" if a != b
"a" if a == b
 

Example 1:

Input: nums = [0,1,2,4,5,7]
Output: ["0->2","4->5","7"]
Explanation: The ranges are:
[0,2] --> "0->2"
[4,5] --> "4->5"
[7,7] --> "7"
Example 2:

Input: nums = [0,2,3,4,6,8,9]
Output: ["0","2->4","6","8->9"]
Explanation: The ranges are:
[0,0] --> "0"
[2,4] --> "2->4"
[6,6] --> "6"
[8,9] --> "8->9"
 

Constraints:

0 <= nums.length <= 20
-231 <= nums[i] <= 231 - 1
All the values of nums are unique.
nums is sorted in ascending order.
*/

//***************Solution********************
//better descrption:  find 'continuous' range inside the array and break it into elements
public class Solution {
    public IList<string> SummaryRanges(int[] nums) {
         var result = new List<string>();

         //loop through nums length
            for (int i = 0; i < nums.Length; i++){
                int start = nums[i];
                //while i is less than num.length AND
                //next element at nums - current element is 1, 
                //increase i by 1
                //if start is not equal to current element, add new element to list, else add only the start element
                while (i < nums.Length - 1 && nums[i + 1] - nums[i] == 1)
                    i++;
                if (start != nums[i])
                    result.Add($"{start}->{nums[i]}");
                else
                    result.Add($"{start}");
            }
            return result;
    }
}

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
