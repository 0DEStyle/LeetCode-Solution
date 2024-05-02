/*Challenge link:https://leetcode.com/problems/reach-a-number/description/
Question:
You are standing at position 0 on an infinite number line. There is a destination at position target.

You can make some number of moves numMoves so that:

On each move, you can either go left or right.
During the ith move (starting from i == 1 to i == numMoves), you take i steps in the chosen direction.
Given the integer target, return the minimum number of moves required (i.e., the minimum numMoves) to reach the destination.

 

Example 1:

Input: target = 2
Output: 3
Explanation:
On the 1st move, we step from 0 to 1 (1 step).
On the 2nd move, we step from 1 to -1 (2 steps).
On the 3rd move, we step from -1 to 2 (3 steps).
Example 2:

Input: target = 3
Output: 2
Explanation:
On the 1st move, we step from 0 to 1 (1 step).
On the 2nd move, we step from 1 to 3 (2 steps).
 

Constraints:

-109 <= target <= 109
target != 0
*/

//***************Solution********************
//binary search
public class Solution {
    public int ReachNumber(int target) {
        //convert negative target to positive
        if(target < 0)
            target *= -1;

        int start = 1, end = target, numMoves = 0;
        long finalPosition = 0;

        while(start <= end){
        //find mid index
        int mid = start + (end - start) / 2;
        
        // here we consider n = mid then n*(n+1)/2 becomes mid*(mid+1)/2
        long sum = (long)mid * (mid + 1) / 2;
        
        //if difference is even direct binary search
        if(sum >= target){
            finalPosition = sum;
            numMoves = mid;
            end = mid - 1;
        }
        else
            start = mid + 1;
        }
            
        int difference = (int)(finalPosition - target);
        //if difference is odd
        if(difference % 2 != 0){
            //if n+1 is odd
            //else n+1 is even, then n+2 is odd
            if((numMoves + 1) % 2 != 0)
                numMoves += 1;
            else
                numMoves += 2;
        }
        return numMoves;
        }
}
