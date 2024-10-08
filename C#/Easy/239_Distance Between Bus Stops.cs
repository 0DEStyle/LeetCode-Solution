/*Challenge link:https://leetcode.com/problems/distance-between-bus-stops/description/
Question:
A bus has n stops numbered from 0 to n - 1 that form a circle. We know the distance between all pairs of neighboring stops where distance[i] is the distance between the stops number i and (i + 1) % n.

The bus goes along both directions i.e. clockwise and counterclockwise.

Return the shortest distance between the given start and destination stops.

 

Example 1:

//see image in link

Input: distance = [1,2,3,4], start = 0, destination = 1
Output: 1
Explanation: Distance between 0 and 1 is 1 or 9, minimum is 1.
 

Example 2:

//see image in link


Input: distance = [1,2,3,4], start = 0, destination = 2
Output: 3
Explanation: Distance between 0 and 2 is 3 or 7, minimum is 3.
 

Example 3:

//see image in link


Input: distance = [1,2,3,4], start = 0, destination = 3
Output: 4
Explanation: Distance between 0 and 3 is 6 or 4, minimum is 4.
 

Constraints:

1 <= n <= 10^4
distance.length == n
0 <= start, destination < n
0 <= distance[i] <= 10^4
*/

//***************Solution********************
public class Solution {
    public int DistanceBetweenBusStops(int[] distance, int start, int destination) {
        //direction
        int cw = 0, ccw = 0;

        //switch if start greater than destination
        if(start > destination)
            (start, destination) = (destination, start);

        //while start is not the same as destination
        //accumulate clockwise  by distance at index start, increase start by 1 each iteration
        while (start != destination){
            cw += distance[start];
            start++;
        }
        //(cw, get the remaining distance ccw)
        //select min value betweent the two.
        return Math.Min(cw, distance.Sum() - cw);
    }
}
