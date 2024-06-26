/*Challenge link:https://leetcode.com/problems/koko-eating-bananas/description/
Question:
Koko loves to eat bananas. There are n piles of bananas, the ith pile has piles[i] bananas. The guards have gone and will come back in h hours.

Koko can decide her bananas-per-hour eating speed of k. Each hour, she chooses some pile of bananas and eats k bananas from that pile. If the pile has less than k bananas, she eats all of them instead and will not eat any more bananas during this hour.

Koko likes to eat slowly but still wants to finish eating all the bananas before the guards return.

Return the minimum integer k such that she can eat all the bananas within h hours.

 

Example 1:

Input: piles = [3,6,7,11], h = 8
Output: 4
Example 2:

Input: piles = [30,11,23,4,20], h = 5
Output: 30
Example 3:

Input: piles = [30,11,23,4,20], h = 6
Output: 23
 

Constraints:

1 <= piles.length <= 104
piles.length <= h <= 109
1 <= piles[i] <= 109
*/

//***************Solution********************
//binary search
public class Solution {
     private bool IsEnough(int[] piles, int k, int h){
        int hours = 0;
        //loop through each item in piles
        //accumulate sum to hours
        foreach (var item in piles)
            hours += (item + k - 1) / k;

        //return a bool value of whether accumulated hours is less than or equal to Koko eating hours.
        return hours <= h;
    }

    public int MinEatingSpeed(int[] piles, int h) {
        //set boundaries
        int l = 1, r = piles.Max();

        while (l < r){
            //find mid index
            int m = l + (r - l) / 2;

            //check valid
            //if true, set right as mid
            //else shift left to right by 1 index
            if (IsEnough(piles, m, h))
                r = m;
            else
                l = m + 1;
        }

        return l;
    }
}
