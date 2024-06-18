/*Challenge link:https://leetcode.com/problems/find-a-value-of-a-mysterious-function-closest-to-target/description/
Question:
//see image in link
Winston was given the above mysterious function func. He has an integer array arr and an integer target and he wants to find the values l and r that make the value |func(arr, l, r) - target| minimum possible.

Return the minimum possible value of |func(arr, l, r) - target|.

Notice that func should be called with the values l and r where 0 <= l, r < arr.length.

 

Example 1:

Input: arr = [9,12,3,7,15], target = 5
Output: 2
Explanation: Calling func with all the pairs of [l,r] = [[0,0],[1,1],[2,2],[3,3],[4,4],[0,1],[1,2],[2,3],[3,4],[0,2],[1,3],[2,4],[0,3],[1,4],[0,4]], Winston got the following results [9,12,3,7,15,8,0,3,7,0,0,3,0,0,0]. The value closest to 5 is 7 and 3, thus the minimum difference is 2.
Example 2:

Input: arr = [1000000,1000000,1000000], target = 1
Output: 999999
Explanation: Winston called the func with all possible values of [l,r] and he always got 1000000, thus the min difference is 999999.
Example 3:

Input: arr = [1,2,4,8,16], target = 0
Output: 0
 

Constraints:

1 <= arr.length <= 105
1 <= arr[i] <= 106
0 <= target <= 107
*/

//***************Solution********************
public class Solution {

    //update method
    //loop through count.length
    //accumulate current count by either delta or 0
    private void Update(int[] count, int val, int delta){
            for (int i = 0; i < count.Length; i++)
                count[i] += ((val & (1 << i)) != 0) ? delta : 0;
        }

        //value method, if size is greater than 0
        //loop through count.length
        //Or with val with either (1 << i) : 0
        private int Value(int[] count, int size){
            int val = 0;
            if (size > 0)
                for (int i = 0; i < count.Length; i++)
                    val |= (count[i] == size) ? (1 << i) : 0;
            return val;
        }


        //main
    public int ClosestToTarget(int[] arr, int target) {
        //count storage, set boundaries
        var count = new int[20];
        int l = 0, res = int.MaxValue;

        //loop through arr.length
        for(int r = 0; r < arr.Length; r++) {
            //pass variables into update method
            //update Value to val
            Update(count, arr[r], 1);
            int val = Value(count, r-l+1);
            //select min value between res and absolute value of val- target
            res = Math.Min(res, Math.Abs(val - target));

            
            while(val < target && l <= r) {
                Update(count, arr[l++], -1);
                val = Value(count, r-l+1);
                res = Math.Min(res, Math.Abs(val - target));
            }
        }
        return res;
    }
}
