/*Challenge link:https://leetcode.com/problems/frog-jump-ii/description/
Question:
You are given a 0-indexed integer array stones sorted in strictly increasing order representing the positions of stones in a river.

A frog, initially on the first stone, wants to travel to the last stone and then return to the first stone. However, it can jump to any stone at most once.

The length of a jump is the absolute difference between the position of the stone the frog is currently on and the position of the stone to which the frog jumps.

More formally, if the frog is at stones[i] and is jumping to stones[j], the length of the jump is |stones[i] - stones[j]|.
The cost of a path is the maximum length of a jump among all jumps in the path.

Return the minimum cost of a path for the frog.

 

Example 1:
//see image in link

Input: stones = [0,2,5,6,7]
Output: 5
Explanation: The above figure represents one of the optimal paths the frog can take.
The cost of this path is 5, which is the maximum length of a jump.
Since it is not possible to achieve a cost of less than 5, we return it.
Example 2:
//see image in link

Input: stones = [0,3,9]
Output: 9
Explanation: 
The frog can jump directly to the last stone and come back to the first stone. 
In this case, the length of each jump will be 9. The cost for the path will be max(9, 9) = 9.
It can be shown that this is the minimum achievable cost.
 

Constraints:

2 <= stones.length <= 105
0 <= stones[i] <= 109
stones[0] == 0
stones is sorted in a strictly increasing order.

*/

//***************Solution********************
public class Solution {
    public int MaxJump(int[] stones) {
    //check valid function
    bool Check(int maxJump) {
        //starting from 2 up tp stones.Lengt
        for (int i = 2; i < stones.Length; i++) {
            // stone out of reach, maxJump is too short
            //current stones - current stone's index - 2 is less than curremnt maxJump value, return false
            if (stones[i] - stones[i - 2] > maxJump)
                return false;
        }
        return true;
    }

    //no pint checking if only 2 stone left, return 1st stone's value
        if (stones.Length == 2)
            return stones[1];

    //set pointer to start and end
    int left = 1, right = stones[^1];

    while (left < right) {
        //get mid index
        var mid = left + (right - left) / 2;

        //check if mid is valid, if true, set right as mid, else left to right by 1 indedx
        if (Check(mid))
            right = mid;
        else
            left = mid + 1;
    }
    return left;
    }
}
