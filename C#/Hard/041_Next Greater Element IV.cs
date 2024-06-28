/*Challenge link:https://leetcode.com/problems/next-greater-element-iv/description/
Question:
You are given a 0-indexed array of non-negative integers nums. For each integer in nums, you must find its respective second greater integer.

The second greater integer of nums[i] is nums[j] such that:

j > i
nums[j] > nums[i]
There exists exactly one index k such that nums[k] > nums[i] and i < k < j.
If there is no such nums[j], the second greater integer is considered to be -1.

For example, in the array [1, 2, 4, 3], the second greater integer of 1 is 4, 2 is 3, and that of 3 and 4 is -1.
Return an integer array answer, where answer[i] is the second greater integer of nums[i].

 

Example 1:

Input: nums = [2,4,0,9,6]
Output: [9,6,6,-1,-1]
Explanation:
0th index: 4 is the first integer greater than 2, and 9 is the second integer greater than 2, to the right of 2.
1st index: 9 is the first, and 6 is the second integer greater than 4, to the right of 4.
2nd index: 9 is the first, and 6 is the second integer greater than 0, to the right of 0.
3rd index: There is no integer greater than 9 to its right, so the second greater integer is considered to be -1.
4th index: There is no integer greater than 6 to its right, so the second greater integer is considered to be -1.
Thus, we return [9,6,6,-1,-1].
Example 2:

Input: nums = [3,3]
Output: [-1,-1]
Explanation:
We return [-1,-1] since neither integer has any integer greater than it.
 

Constraints:

1 <= nums.length <= 105
0 <= nums[i] <= 109
*/

//***************Solution********************
public class Solution {
    public int[] SecondGreaterElement(int[] A) {
        int n = A.Length;
        int[] res = new int[n];
        Array.Fill(res, -1);
        //mono stack
        Stack<int> s1 = new Stack<int>(), s2 = new Stack<int>(), tmp = new Stack<int>();

        //loop through array length amount of time
        //while stack2.count is not 0 AND a at s2.peek is less than current elemetn of a
        //set current element of a to res at s2.pop index
        //do the same for s1, but tmp.push at s1.pop index
        //is tmp.count is not 0,s2.push at tmp.pop index
        //s1.push at index i
        for (int i = 0; i < n; i++){
            while (s2.Count != 0 && A[s2.Peek()] < A[i])
                res[s2.Pop()] = A[i];
            while (s1.Count != 0 && A[s1.Peek()] < A[i])
                tmp.Push(s1.Pop());
            while (tmp.Count != 0)
                s2.Push(tmp.Pop());
            s1.Push(i);
        }
        return res;
    }
}
