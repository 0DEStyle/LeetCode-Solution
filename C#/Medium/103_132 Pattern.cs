/*Challenge link:https://leetcode.com/problems/132-pattern/description/
Question:
Given an array of n integers nums, a 132 pattern is a subsequence of three integers nums[i], nums[j] and nums[k] such that i < j < k and nums[i] < nums[k] < nums[j].

Return true if there is a 132 pattern in nums, otherwise, return false.

 

Example 1:

Input: nums = [1,2,3,4]
Output: false
Explanation: There is no 132 pattern in the sequence.
Example 2:

Input: nums = [3,1,4,2]
Output: true
Explanation: There is a 132 pattern in the sequence: [1, 4, 2].
Example 3:

Input: nums = [-1,3,2,0]
Output: true
Explanation: There are three 132 patterns in the sequence: [-1, 3, 2], [-1, 3, 0] and [-1, 2, 0].
 

Constraints:

n == nums.length
1 <= n <= 2 * 105
-109 <= nums[i] <= 109
*/

//***************Solution********************
public class Solution {
    public bool Find132pattern(int[] nums) {
        int len = nums.Length;
        //false is length is less than 3
        if (len < 3) return false;
        //create an int stack
        var stk = new Stack<int>();
        int k = -1;

        //1 < 3, 3 > 2, 1 < 2
        //i < j, j > k, i < k
        
        //start from len -i, go down to 0
        for (int i = len - 1; i >= 0; i--){
            //scan if k is greater than i
            if (k > -1 && nums[k] > nums[i])
                return true;

            //check if i is greater that whatever is in the stk, pop stk and set it to k
            while (stk.Count > 0 && nums[i] > nums[stk.Peek()])
                k = stk.Pop();
            //push i into stack
            stk.Push(i);
        }
        //no match
        return false;
    }
}
