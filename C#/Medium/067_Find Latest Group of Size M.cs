/*Challenge link:https://leetcode.com/problems/find-latest-group-of-size-m/description/
Question:
Given an array arr that represents a permutation of numbers from 1 to n.

You have a binary string of size n that initially has all its bits set to zero. At each step i (assuming both the binary string and arr are 1-indexed) from 1 to n, the bit at position arr[i] is set to 1.

You are also given an integer m. Find the latest step at which there exists a group of ones of length m. A group of ones is a contiguous substring of 1's such that it cannot be extended in either direction.

Return the latest step at which there exists a group of ones of length exactly m. If no such group exists, return -1.

 

Example 1:

Input: arr = [3,5,1,2,4], m = 1
Output: 4
Explanation: 
Step 1: "00100", groups: ["1"]
Step 2: "00101", groups: ["1", "1"]
Step 3: "10101", groups: ["1", "1", "1"]
Step 4: "11101", groups: ["111", "1"]
Step 5: "11111", groups: ["11111"]
The latest step at which there exists a group of size 1 is step 4.
Example 2:

Input: arr = [3,1,5,4,2], m = 2
Output: -1
Explanation: 
Step 1: "00100", groups: ["1"]
Step 2: "10100", groups: ["1", "1"]
Step 3: "10101", groups: ["1", "1", "1"]
Step 4: "10111", groups: ["1", "111"]
Step 5: "11111", groups: ["11111"]
No group of size 2 exists during any step.
 

Constraints:

n == arr.length
1 <= m <= n <= 105
1 <= arr[i] <= n
All integers in arr are distinct.
*/

//***************Solution********************
//Count the Length of Groups, O(N)
public class Solution {
    public int FindLatestStep(int[] arr, int m) {
        int res = -1, n = arr.Length;

        //if n matches m, just return n
        if (n == m) return n;

        int[] length = new int[n + 2];

        //loop through n
        for (int i = 0; i < n; ++i){
            //set a to current element of arr, get left and right index
            int a = arr[i], left = length[a - 1], right = length[a + 1];

            //set length at index(a - left) and length(a + right) to left + right + 1
            length[a - left] = length[a + right] = left + right + 1;

            //if left or right is equal to m, set res to i.
            if (left == m || right == m) res = i;
        }
        return res;
    }
}
