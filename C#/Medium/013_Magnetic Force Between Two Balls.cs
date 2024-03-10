/*Challenge link:https://leetcode.com/problems/magnetic-force-between-two-balls/description/
Question:
In the universe Earth C-137, Rick discovered a special form of magnetic force between two balls if they are put in his new invented basket. Rick has n empty baskets, the ith basket is at position[i], Morty has m balls and needs to distribute the balls into the baskets such that the minimum magnetic force between any two balls is maximum.

Rick stated that magnetic force between two different balls at positions x and y is |x - y|.

Given the integer array position and the integer m. Return the required force.

 

Example 1:

//see image in link

Input: position = [1,2,3,4,7], m = 3
Output: 3
Explanation: Distributing the 3 balls into baskets 1, 4 and 7 will make the magnetic force between ball pairs [3, 3, 6]. The minimum magnetic force is 3. We cannot achieve a larger minimum magnetic force than 3.
Example 2:

Input: position = [5,4,3,2,1,1000000000], m = 2
Output: 999999999
Explanation: We can use baskets 1 and 1000000000.
 

Constraints:

n == position.length
2 <= n <= 105
1 <= position[i] <= 109
All integers in position are distinct.
2 <= m <= position.length
*/

//***************Solution********************
    //binary search method
public class Solution {
    public bool checkValidDistance(int[] position, int m, int d) {
        int totalBalls = 1;
        int lastPos = position[0];

        //loop through all the positions and while conditions are valid
        //increase totalballs by 1, set last position to curretn postion
        for(int i = 1; i < position.Length && totalBalls < m; i++) {
            if(position[i] >= lastPos + d) {
                totalBalls++;
                lastPos = position[i];
            }
        }
        //return bool value to check if it is valid
        return totalBalls >= m;
    }

    public int MaxDistance(int[] pos, int m) {
        //sort the array in ascending order
        Array.Sort(pos);
        int ans = 1, n = pos.Length, left = 1, right = pos[n-1] - pos[0];

        while(left <= right) {
            //find mid index
            int mid = left + (right - left) / 2;

            //check if condition valid, set ans = mid then shift left to right by 1 index, else shift right to left by 1 index
            if(checkValidDistance(pos, m, mid)) {
                ans = mid;
                left = mid + 1;
            }
            else 
                right = mid - 1;
        }

        return ans;
    }
}
