/*Challenge link:https://leetcode.com/problems/decompress-run-length-encoded-list/description/
Question:
We are given a list nums of integers representing a list compressed with run-length encoding.

Consider each adjacent pair of elements [freq, val] = [nums[2*i], nums[2*i+1]] (with i >= 0).  For each such pair, there are freq elements with value val concatenated in a sublist. Concatenate all the sublists from left to right to generate the decompressed list.

Return the decompressed list.

 

Example 1:

Input: nums = [1,2,3,4]
Output: [2,4,4,4]
Explanation: The first pair [1,2] means we have freq = 1 and val = 2 so we generate the array [2].
The second pair [3,4] means we have freq = 3 and val = 4 so we generate [4,4,4].
At the end the concatenation [2] + [4,4,4] is [2,4,4,4].
Example 2:

Input: nums = [1,1,2,3]
Output: [1,3,3]
 

Constraints:

2 <= nums.length <= 100
nums.length % 2 == 0
1 <= nums[i] <= 100
*/

//***************Solution********************
public class Solution {
    public int[] DecompressRLElist(int[] nums) {
        int index, num, currIndex = 0, arrSize = 0;

        //count number size that fit into the array
        for (int i = 0; i < nums.Length; i += 2) 
            arrSize += nums[i];
        
        //create res with array size
        int[] res = new int[arrSize];


        for (int i = 0; i < nums.Length - 1; i += 2) {
            //update index to current index
            //set num to next num
            index = nums[i];
            num = nums[i + 1];

            //store inside res.
            for (int j = 0; j < index; j++)
                res[currIndex++] = num;
        }
        return res;
    }
}
