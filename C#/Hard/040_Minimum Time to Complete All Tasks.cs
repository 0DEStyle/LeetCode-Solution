/*Challenge link:https://leetcode.com/problems/minimum-time-to-complete-all-tasks/description/
Question:
There is a computer that can run an unlimited number of tasks at the same time. You are given a 2D integer array tasks where tasks[i] = [starti, endi, durationi] indicates that the ith task should run for a total of durationi seconds (not necessarily continuous) within the inclusive time range [starti, endi].

You may turn on the computer only when it needs to run a task. You can also turn it off if it is idle.

Return the minimum time during which the computer should be turned on to complete all tasks.

 

Example 1:

Input: tasks = [[2,3,1],[4,5,1],[1,5,2]]
Output: 2
Explanation: 
- The first task can be run in the inclusive time range [2, 2].
- The second task can be run in the inclusive time range [5, 5].
- The third task can be run in the two inclusive time ranges [2, 2] and [5, 5].
The computer will be on for a total of 2 seconds.
Example 2:

Input: tasks = [[1,3,2],[2,5,3],[5,6,2]]
Output: 4
Explanation: 
- The first task can be run in the inclusive time range [2, 3].
- The second task can be run in the inclusive time ranges [2, 3] and [5, 5].
- The third task can be run in the two inclusive time range [5, 6].
The computer will be on for a total of 4 seconds.
 

Constraints:

1 <= tasks.length <= 2000
tasks[i].length == 3
1 <= starti, endi <= 2000
1 <= durationi <= endi - starti + 1 
*/

//***************Solution********************
//visualise: https://www.youtube.com/watch?v=yw9l_BXKpno

public class Solution {

    //count and accumulate range
    public int Count(int[] range, int left, int right){
        int cnt = 0;
        for (int i = left; i <= right; i++)
            cnt += range[i];
        return cnt;
}

public int FindMinimumTime(int[][] tasks){
    int[] range = new int[2001];
    //sort taskes
    Array.Sort(tasks, (a, b) =>{
        if (a[1] != b[1]) return a[1] - b[1];
        return a[0] - b[0];
    });


    int tcnt = 0;
    //loop through all event in tasks.
    foreach (var ev in tasks){
        int cnt = Count(range, ev[0], ev[1]);
        if (cnt < ev[2]){
            cnt = ev[2] - cnt;
            for (int j = ev[1]; j >= ev[0] && cnt > 0 && cnt > 0; j--)
                if (range[j] == 0) { range[j] = 1; cnt--; tcnt++; }
        }
    }
    return tcnt;
}
}
