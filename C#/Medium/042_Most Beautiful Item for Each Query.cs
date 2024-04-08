/*Challenge link:https://leetcode.com/problems/most-beautiful-item-for-each-query/description/
Question:
You are given a 2D integer array items where items[i] = [pricei, beautyi] denotes the price and beauty of an item respectively.

You are also given a 0-indexed integer array queries. For each queries[j], you want to determine the maximum beauty of an item whose price is less than or equal to queries[j]. If no such item exists, then the answer to this query is 0.

Return an array answer of the same length as queries where answer[j] is the answer to the jth query.

 

Example 1:

Input: items = [[1,2],[3,2],[2,4],[5,6],[3,5]], queries = [1,2,3,4,5,6]
Output: [2,4,5,5,6,6]
Explanation:
- For queries[0]=1, [1,2] is the only item which has price <= 1. Hence, the answer for this query is 2.
- For queries[1]=2, the items which can be considered are [1,2] and [2,4]. 
  The maximum beauty among them is 4.
- For queries[2]=3 and queries[3]=4, the items which can be considered are [1,2], [3,2], [2,4], and [3,5].
  The maximum beauty among them is 5.
- For queries[4]=5 and queries[5]=6, all items can be considered.
  Hence, the answer for them is the maximum beauty of all items, i.e., 6.
Example 2:

Input: items = [[1,2],[1,2],[1,3],[1,4]], queries = [1]
Output: [4]
Explanation: 
The price of every item is equal to 1, so we choose the item with the maximum beauty 4. 
Note that multiple items can have the same price and/or beauty.  
Example 3:

Input: items = [[10,1000]], queries = [5]
Output: [0]
Explanation:
No item has a price less than or equal to 5, so no item can be chosen.
Hence, the answer to the query is 0.
 

Constraints:

1 <= items.length, queries.length <= 105
items[i].length == 2
1 <= pricei, beautyi, queries[j] <= 109
*/

//***************Solution********************
//binary search
public class Solution {
    //simple method to compare a and b, return -1 or 1 accordingly
    public int Compare(int[] a, int[] b) => a[0] < b[0] ? -1 : 1;

    public int[] MaximumBeauty(int[][] items, int[] queries) {
        //sort Array items in ascend order
        Array.Sort(items, Compare);
        int n = items.Length,  max = 0;

        int[] MaxBeauty = new int[n];
        int[] ans = new int[queries.Length];

        //loop through all elements
        //find max value between max and current element, update to max, and store it in MaxBeauty
        for(int i = 0; i < n; i++){
            max = Math.Max(max, items[i][1]);
            MaxBeauty[i] = max;
        }

        //loop through queries
        //pass items, item's length and current query into FindIndex
        //if index is not -1, update ans to maxbeauty
        for(int i = 0; i < queries.Length; i++){
            int index = FindIndex(items, n, queries[i]);
            if (index != -1)
                ans[i] = MaxBeauty[index];
        }
        return ans;
    }
    //binary search
     private int FindIndex(int[][] items, int n, int price){
        //set boundaries
        int start = 0, end = n-1;

        while(start <= end){
            //find mid index
            int mid = start + (end-start)/2;

            //Return m if mid is equal to item's length AND current element is less than or equal to price
            //OR
            //if mid is less than item's length AND current element is less than price AND next element is greater than price.
            //else if item is greater price, shift end to left by 1 index
            //else shift start to right by 1 index
            if ((mid == n - 1 && items[mid][0] <= price) || (mid < n-1 && items[mid][0] <= price && items[mid+1][0] > price))
                return mid;
            else if (items[mid][0] > price)
                end = mid - 1;
            else
                start = mid + 1;
        }
        //no matches, return -1
        return -1;
    }
}
