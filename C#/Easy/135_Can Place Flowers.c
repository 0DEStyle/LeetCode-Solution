/*Challenge link:https://leetcode.com/problems/can-place-flowers/description/
Question:
You have a long flowerbed in which some of the plots are planted, and some are not. However, flowers cannot be planted in adjacent plots.

Given an integer array flowerbed containing 0's and 1's, where 0 means empty and 1 means not empty, and an integer n, return true if n new flowers can be planted in the flowerbed without violating the no-adjacent-flowers rule and false otherwise.

 

Example 1:

Input: flowerbed = [1,0,0,0,1], n = 1
Output: true
Example 2:

Input: flowerbed = [1,0,0,0,1], n = 2
Output: false
 

Constraints:

1 <= flowerbed.length <= 2 * 104
flowerbed[i] is 0 or 1.
There are no two adjacent flowers in flowerbed.
0 <= n <= flowerbed.length
*/

//***************Solution********************
public class Solution {
    public bool CanPlaceFlowers(int[] flowerbed, int n) {
        int count = 0;

        //loop through length
        //if current i element is equal to 0 AND
        // i is 0 or last element is 0 AND
        //i equal last element or next lement equal 0
        //set current to 1, increase count by 1
        for (int i = 0; i < flowerbed.Length; i++){
            if (flowerbed[i] == 0 && (i == 0 || flowerbed[i - 1] == 0) &&
                (i == flowerbed.Length - 1 || flowerbed[i + 1] == 0))
            {
                flowerbed[i] = 1;
                count++;
            }
        }
        //return bool value
        return count >= n;
    }
}
