/*Challenge link:https://leetcode.com/problems/two-best-non-overlapping-events/description/
Question:
You are given a 0-indexed 2D integer array of events where events[i] = [startTimei, endTimei, valuei]. The ith event starts at startTimei and ends at endTimei, and if you attend this event, you will receive a value of valuei. You can choose at most two non-overlapping events to attend such that the sum of their values is maximized.

Return this maximum sum.

Note that the start time and end time is inclusive: that is, you cannot attend two events where one of them starts and the other ends at the same time. More specifically, if you attend an event with end time t, the next event must start at or after t + 1.

 

Example 1:
//see image in link

Input: events = [[1,3,2],[4,5,2],[2,4,3]]
Output: 4
Explanation: Choose the green events, 0 and 1 for a sum of 2 + 2 = 4.
Example 2:
//see image in link
Example 1 Diagram
Input: events = [[1,3,2],[4,5,2],[1,5,5]]
Output: 5
Explanation: Choose event 2 for a sum of 5.
Example 3:
//see image in link

Input: events = [[1,5,3],[1,5,1],[6,6,5]]
Output: 8
Explanation: Choose events 0 and 2 for a sum of 3 + 5 = 8.
 

Constraints:

2 <= events.length <= 105
events[i].length == 3
1 <= startTimei <= endTimei <= 109
1 <= valuei <= 106
*/

//***************Solution********************
//binary search
public class Solution {
    int BinarySearch(int[][] events, int endTime){
        //set boundaries
        int l = 0, r = events.Length;
        
        while (r - l > 1){
            //find mid index
            int m = l + (r - l) / 2;
            
            //if event at m,0 is less than endtime
            //set right to mid
            //else set left to mid
            if (events[m][0] > endTime)
                r = m;
            else
                l = m;
        }
        return r;
    }
    

    public int MaxTwoEvents(int[][] events) {
        int n = events.Length, result = 0;
        //sort array in ascending order, compare a[0] to b[0]
        Array.Sort(events, (int[] a, int[] b) => a[0].CompareTo(b[0]));
        
        //create new int array
        var suffixMax = new int[n + 1];
        
        //loop from end down to 0, 
        //select max value between current element + 1 from suffix max, and event i,2, update result to suffixMax current element
        for (int i = n - 1; i >= 0; i--)
            suffixMax[i] = Math.Max(suffixMax[i + 1], events[i][2]);
        
        //loop through all elements
        for (int i = 0; i < n; i++){
            //get index from binarysearch
            //select max value between result and  events[i][2] + suffixMax[index], update the result.
            int index = BinarySearch(events, events[i][1]);
            result = Math.Max(result, events[i][2] + suffixMax[index]);    
        }
        return result;
    }
}
