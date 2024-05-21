/*Challenge link:https://leetcode.com/problems/heaters/description/
Question:
Winter is coming! During the contest, your first job is to design a standard heater with a fixed warm radius to warm all the houses.

Every house can be warmed, as long as the house is within the heater's warm radius range. 

Given the positions of houses and heaters on a horizontal line, return the minimum radius standard of heaters so that those heaters could cover all houses.

Notice that all the heaters follow your radius standard, and the warm radius will the same.

 

Example 1:

Input: houses = [1,2,3], heaters = [2]
Output: 1
Explanation: The only heater was placed in the position 2, and if we use the radius 1 standard, then all the houses can be warmed.
Example 2:

Input: houses = [1,2,3,4], heaters = [1,4]
Output: 1
Explanation: The two heaters were placed at positions 1 and 4. We need to use a radius 1 standard, then all the houses can be warmed.
Example 3:

Input: houses = [1,5], heaters = [2]
Output: 3
 

Constraints:

1 <= houses.length, heaters.length <= 3 * 104
1 <= houses[i], heaters[i] <= 109
*/

//***************Solution********************
//binary search
public class Solution {
    public int FindRadius(int[] houses, int[] heaters) {
        Array.Sort(heaters);
        int ans = 0;

        //loop through all elements in houses
        foreach (int ele in houses){
            //boundaries
            int lo = 0, hi = heaters.Length - 1;
            int justSmaller = -1, justLarger = -1;

            while (lo <= hi){
                //find mid index
                int mid = lo + (hi - lo) / 2;
                //if mid index matches element, set justSmalleer and justLarger to mid
                if (heaters[mid] == ele){
                    justSmaller = heaters[mid];
                    justLarger = heaters[mid];
                    break;
                }
                //if mid index less than element, set justSmalleer to mid, then shift low to right by 1 index
                else if (heaters[mid] < ele){
                    justSmaller = heaters[mid];
                    lo = mid + 1;
                }
                //else, set justLarger to mid, then shift high to left by 1 index
                else{
                    justLarger = heaters[mid];
                    hi = mid - 1;
                }
            }
            //update both variables for next iteration.
            justSmaller = justSmaller == -1 ? int.MaxValue : ele - justSmaller;
            justLarger = justLarger == -1 ? int.MaxValue : justLarger - ele;

            //select max value between ans, and the min value between smaller and larger.
            ans = Math.Max(ans, Math.Min(justSmaller, justLarger));
        }
        return ans;
    }
}
