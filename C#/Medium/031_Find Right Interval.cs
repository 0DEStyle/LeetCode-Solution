/*Challenge link:https://leetcode.com/problems/find-right-interval/
Question:
You are given an array of intervals, where intervals[i] = [starti, endi] and each starti is unique.

The right interval for an interval i is an interval j such that startj >= endi and startj is minimized. Note that i may equal j.

Return an array of right interval indices for each interval i. If no right interval exists for interval i, then put -1 at index i.

 

Example 1:

Input: intervals = [[1,2]]
Output: [-1]
Explanation: There is only one interval in the collection, so it outputs -1.
Example 2:

Input: intervals = [[3,4],[2,3],[1,2]]
Output: [-1,0,1]
Explanation: There is no right interval for [3,4].
The right interval for [2,3] is [3,4] since start0 = 3 is the smallest start that is >= end1 = 3.
The right interval for [1,2] is [2,3] since start1 = 2 is the smallest start that is >= end2 = 2.
Example 3:

Input: intervals = [[1,4],[2,3],[3,4]]
Output: [-1,2,-1]
Explanation: There is no right interval for [1,4] and [3,4].
The right interval for [2,3] is [3,4] since start2 = 3 is the smallest start that is >= end1 = 3.
 

Constraints:

1 <= intervals.length <= 2 * 104
intervals[i].length == 2
-106 <= starti <= endi <= 106
The start point of each interval is unique.
*/

//***************Solution********************
//binary search method
public class Solution {
    public int[] FindRightInterval(int[][] i) {
        //populate number start from 0, count up to i.Length, store in s array
        //create result array with size of i.Length 
        var s = Enumerable.Range(0, i.Length).ToArray();
        var res = new int[i.Length];

        //sort array s, a and b are current and next.
        Array.Sort(s, (a, b) => i[a][0] - i[b][0]);

        //loop through i(interval)'s length
        for(var j=0; j < i.Length; j++){
            //set e(target) as first element of j
            //set upper and lower boundaries
            var e = i[j][1];
            var (low, high) = (0, i.Length);

            while(low < high){
                //find mid index
                var mid = low + (high - low) / 2;

                //if target is less than interval's s array ' s mid element
                //then shift low to right by 1 index, else set high to mid
                if(i[s[mid]][0] < e)
                    low = mid + 1;
                else
                    high = mid;
            }
            //update result, if low is equal to i.Length then return -1, else return low element of s
            res[j] = (low == i.Length) ? -1 : s[low];
        }
        return res;
    }
}
