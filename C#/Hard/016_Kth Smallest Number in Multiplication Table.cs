/*Challenge link:https://leetcode.com/problems/kth-smallest-number-in-multiplication-table/description/
Question:
Nearly everyone has used the Multiplication Table. The multiplication table of size m x n is an integer matrix mat where mat[i][j] == i * j (1-indexed).

Given three integers m, n, and k, return the kth smallest element in the m x n multiplication table.

 

Example 1:
//see image in link

Input: m = 3, n = 3, k = 5
Output: 3
Explanation: The 5th smallest number is 3.
Example 2:
//see image in link

Input: m = 2, n = 3, k = 6
Output: 6
Explanation: The 6th smallest number is 6.
 

Constraints:

1 <= m, n <= 3 * 104
1 <= k <= m * n
*/

//***************Solution********************
public class Solution {
    public int FindKthNumber(int m, int n, int k) {
        //swap variables
        if (m < n) 
            (m, n) = (n, m);


        //set boundaries.
        int l = 1, h = m * n + 1;

        while (l < h) {
            //find mid index
            int mid = l + (h - l) / 2;
            int less = getLessEqualThan(mid, m, n);

            //check validation, set low and high accordingly 
            if (less < k)
                l = mid + 1;
            else 
                h = mid;
        }
        return l;
    }
    
    //validation method
    private int getLessEqualThan(int target, int m, int n) {
        if (m * n <= target)
            return m * n;

        int m1 = Math.Min(m, target), n1 = Math.Min(n, target / m1);
        int result = m1 * n1;

        while (n1 < n && n1 < target) {
            n1++;
            while (m1 * n1 > target) 
                m1--;
            result += m1;
        }
        return result;
    }
}
