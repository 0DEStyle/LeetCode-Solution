/*Challenge link:https://leetcode.com/problems/minimum-time-to-complete-trips/description/
Question:
You are given an array time where time[i] denotes the time taken by the ith bus to complete one trip.

Each bus can make multiple trips successively; that is, the next trip can start immediately after completing the current trip. Also, each bus operates independently; that is, the trips of one bus do not influence the trips of any other bus.

You are also given an integer totalTrips, which denotes the number of trips all buses should make in total. Return the minimum time required for all buses to complete at least totalTrips trips.

 

Example 1:

Input: time = [1,2,3], totalTrips = 5
Output: 3
Explanation:
- At time t = 1, the number of trips completed by each bus are [1,0,0]. 
  The total number of trips completed is 1 + 0 + 0 = 1.
- At time t = 2, the number of trips completed by each bus are [2,1,0]. 
  The total number of trips completed is 2 + 1 + 0 = 3.
- At time t = 3, the number of trips completed by each bus are [3,1,1]. 
  The total number of trips completed is 3 + 1 + 1 = 5.
So the minimum time needed for all buses to complete at least 5 trips is 3.
Example 2:

Input: time = [2], totalTrips = 1
Output: 2
Explanation:
There is only one bus, and it will complete its first trip at t = 2.
So the minimum time needed to complete 1 trip is 2.
 

Constraints:

1 <= time.length <= 105
1 <= time[i], totalTrips <= 107
*/

//***************Solution********************
//binary search
public class Solution {

    //help function
    private bool IsLess(int[] time, long current, int totalTrips){
        long total = 0;
        //loop through time length
        //accumulate sum total, current divide by current time.
        //if total is greater or equal to totalTrips, end the binary search.
        for(int i = 0; i < time.Length; i++){
            total += current / time[i];
            if (total >= totalTrips)
                return false;
        }
        return true;
    }

    public long MinimumTime(int[] time, int totalTrips) {
        int min = time[0];
        //loop through time length
        // if min is greater than current time, set min to current time
        for(int i = 1; i < time.Length; i++)
            if (min > time[i]) min = time[i];

        //set boundaries
        long left = 1, right = (long)totalTrips * min;
        while (left < right){
            //find mid index
            long mid = left + (right - left) / 2;

            //check condition with IsLess function, if true shift left to right by 1, else set right to mid
            if (IsLess(time, mid, totalTrips))
                left = mid + 1;
            else
                right = mid;
        }
        return left;
    }

}
