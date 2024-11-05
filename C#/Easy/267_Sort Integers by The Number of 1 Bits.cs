/*Challenge link:https://leetcode.com/problems/sort-integers-by-the-number-of-1-bits/description/
Question:
You are given an integer array arr. Sort the integers in the array in ascending order by the number of 1's in their binary representation and in case of two or more integers have the same number of 1's you have to sort them in ascending order.

Return the array after sorting it.

 

Example 1:

Input: arr = [0,1,2,3,4,5,6,7,8]
Output: [0,1,2,4,8,3,5,6,7]
Explantion: [0] is the only integer with 0 bits.
[1,2,4,8] all have 1 bit.
[3,5,6] have 2 bits.
[7] has 3 bits.
The sorted array by bits is [0,1,2,4,8,3,5,6,7]
Example 2:

Input: arr = [1024,512,256,128,64,32,16,8,4,2,1]
Output: [1,2,4,8,16,32,64,128,256,512,1024]
Explantion: All integers have 1 bit in the binary representation, you should just sort them in ascending order.
 

Constraints:

1 <= arr.length <= 500
0 <= arr[i] <= 104

*/

//***************Solution********************
public class Solution {
    //count the number of 1, sort in ascending order first, then by ascending again
    // 1st sort 0,1,2,4,8  2nd sort ,3,5,6,7
    //convert to array and return result.
    public int[] SortByBits(int[] arr) =>
    arr.OrderBy(x => CountOnes(x)).ThenBy(x => x).ToArray();

    private int CountOnes(int x) {
        int count = 0;
        //while x is not 0
        //set count to x AND 1 + count
        //right shift by 1 bit each iteration.
        while (x != 0) {
            count += x & 1;
            x >>= 1;
        }
        return count;
    }
}
