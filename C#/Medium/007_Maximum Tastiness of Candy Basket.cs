/*Challenge link:https://leetcode.com/problems/maximum-tastiness-of-candy-basket/description/
Question:
You are given an array of positive integers price where price[i] denotes the price of the ith candy and a positive integer k.

The store sells baskets of k distinct candies. The tastiness of a candy basket is the smallest absolute difference of the prices of any two candies in the basket.

Return the maximum tastiness of a candy basket.

 

Example 1:

Input: price = [13,5,1,8,21,2], k = 3
Output: 8
Explanation: Choose the candies with the prices [13,5,21].
The tastiness of the candy basket is: min(|13 - 5|, |13 - 21|, |5 - 21|) = min(8, 8, 16) = 8.
It can be proven that 8 is the maximum tastiness that can be achieved.
Example 2:

Input: price = [1,3,1], k = 2
Output: 2
Explanation: Choose the candies with the prices [1,3].
The tastiness of the candy basket is: min(|1 - 3|) = min(2) = 2.
It can be proven that 2 is the maximum tastiness that can be achieved.
Example 3:

Input: price = [7,7,7,7], k = 2
Output: 0
Explanation: Choosing any two distinct candies from the candies we have will result in a tastiness of 0.
 

Constraints:

2 <= k <= price.length <= 105
1 <= price[i] <= 109
*/

//***************Solution********************
//binary search method
//reference algo: https://www.youtube.com/watch?v=uHGWEGMCKm4
public class Solution {
    public bool checkValid(int target,int[] price,int k) {
        int prev = price[0], count = 1; 
        //compare price different to see if it is greater or equal to target price
        for(int i = 1; i < price.Length; i++){
                if(price[i] - prev >= target){
                    count++;
                    prev = price[i];
                }
        }
        //return a bool value
         return count >= k;
    }

    public int MaximumTastiness(int[] price, int k) {
        //sort the array in ascending order
        Array.Sort(price);
        //low and high bound of search
        int low = 0, high = price[price.Length-1] - price[0], ans = 0;

        //loop through the boundary while low is less than or equal to high
        while(low <= high){
            //find mid index, set count of candies to 1, last price as price[0]
            int mid = low + (high - low) / 2, count = 1, last = price[0];

            //pass the values into check valid
            //if true, set mid as answer, shift low to the right by 1 index, else shift high to the left by 1 index
            if(checkValid(mid, price, k)){
                ans = mid;
                low = mid + 1;
            }
            else
                high = mid - 1;
        }
        return ans;
    }
}
