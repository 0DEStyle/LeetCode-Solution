/*Challenge link:https://leetcode.com/problems/maximum-population-year/description/
Question:
You are given a 2D integer array logs where each logs[i] = [birthi, deathi] indicates the birth and death years of the ith person.

The population of some year x is the number of people alive during that year. The ith person is counted in year x's population if x is in the inclusive range [birthi, deathi - 1]. Note that the person is not counted in the year that they die.

Return the earliest year with the maximum population.

 

Example 1:

Input: logs = [[1993,1999],[2000,2010]]
Output: 1993
Explanation: The maximum population is 1, and 1993 is the earliest year with this population.
Example 2:

Input: logs = [[1950,1961],[1960,1971],[1970,1981]]
Output: 1960
Explanation: 
The maximum population is 2, and it had happened in years 1960 and 1970.
The earlier year between them is 1960.
 

Constraints:

1 <= logs.length <= 100
1950 <= birthi < deathi <= 2050
*/

//***************Solution********************
/*
1 <= logs.length <= 100
1950 <= birth < death <= 2050

the earliest year with most people alive.
 (B-D -> born on same year or previous year - died this year)

*/
public class Solution {
    public int MaximumPopulation(int[][] logs) {
        //cap 100
        var alive = new int[101];
        int maxyear = 0;

        //cap 1950
        foreach(var log in logs){
            alive[log[0] - 1950]++;
            alive[log[1] - 1950]--;
        }
        
        //loop through alive length
        //accumulate sum for current element.
        //if current element of alive is greater than alive, set max year to i, else leave it as it is.
        for(int i = 1; i < alive.Length; i++){
            alive[i] += alive[i - 1];
            maxyear = alive[i] > alive[maxyear] ? i : maxyear;
        }

        return 1950 + maxyear;
    }
}
