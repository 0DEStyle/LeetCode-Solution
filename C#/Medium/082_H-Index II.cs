/*Challenge link:https://leetcode.com/problems/h-index-ii/description/
Question:
Given an array of integers citations where citations[i] is the number of citations a researcher received for their ith paper and citations is sorted in ascending order, return the researcher's h-index.

According to the definition of h-index on Wikipedia: The h-index is defined as the maximum value of h such that the given researcher has published at least h papers that have each been cited at least h times.

You must write an algorithm that runs in logarithmic time.

 

Example 1:

Input: citations = [0,1,3,5,6]
Output: 3
Explanation: [0,1,3,5,6] means the researcher has 5 papers in total and each of them had received 0, 1, 3, 5, 6 citations respectively.
Since the researcher has 3 papers with at least 3 citations each and the remaining two with no more than 3 citations each, their h-index is 3.
Example 2:

Input: citations = [1,2,100]
Output: 2
 

Constraints:

n == citations.length
1 <= n <= 105
0 <= citations[i] <= 1000
citations is sorted in ascending order.
*/

//***************Solution********************
// binary search
//better explaination of wth is H-index https://www.youtube.com/watch?v=lMZfeiiDRs4

public class Solution {
    public int HIndex(int[] citations) {
        //set boundaries
        int n = citations.Length, low = 0, high = n - 1, ans = -1;

        //while true
        while (low <= high){
            //get mid index
            int mid = low + (high - low) / 2;

            //conditions, if mid index value of citations is matches citation's length - mid
            //set return  n - mid
            //else if the result is less, shift low to right by 1 index, else shift high to right by 1 index
            if (citations[mid] == n - mid)
                return n - mid;
            else if (citations[mid] < n - mid)
                low = mid + 1;
            else if (citations[mid] > n - mid)
                high = mid - 1;
        }
        //return n - low
        return n - low;
    }
}
