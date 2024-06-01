/*Challenge link:https://leetcode.com/problems/maximum-white-tiles-covered-by-a-carpet/description/
Question:
You are given a 2D integer array tiles where tiles[i] = [li, ri] represents that every tile j in the range li <= j <= ri is colored white.

You are also given an integer carpetLen, the length of a single carpet that can be placed anywhere.

Return the maximum number of white tiles that can be covered by the carpet.

 

Example 1:

//see image in link

Input: tiles = [[1,5],[10,11],[12,18],[20,25],[30,32]], carpetLen = 10
Output: 9
Explanation: Place the carpet starting on tile 10. 
It covers 9 white tiles, so we return 9.
Note that there may be other places where the carpet covers 9 white tiles.
It can be shown that the carpet cannot cover more than 9 white tiles.
Example 2:
//see image in link

Input: tiles = [[10,11],[1,1]], carpetLen = 2
Output: 2
Explanation: Place the carpet starting on tile 10. 
It covers 2 white tiles, so we return 2.
 

Constraints:

1 <= tiles.length <= 5 * 104
tiles[i].length == 2
1 <= li <= ri <= 109
1 <= carpetLen <= 109
The tiles are non-overlapping.
*/

//***************Solution********************
public class Solution {
    public int MaximumWhiteTiles(int[][] tiles, int cLen ) {
        //sort all tiles
        Array.Sort(tiles, (a, b) =>{
            if (a[0] != b[0])
                return a[0].CompareTo(b[0]);
            else
                return a[1].CompareTo(b[1]);
        });

        int n = tiles.Length, val = 0, max = 0;
        int[] psum = new int[n];

        // get val for current index in psum
        for (int i = 0; i < n; i++){
            val += (tiles[i][1] - tiles[i][0] + 1);
            psum[i] = val;
        }

        for (int i = 0; i < n; i++){
            int st = tiles[i][0], find = st + cLen - 1;
            //get binary index, set to idx
            int idx = BinarySearch(tiles, find);
            //find sum
            int sum = (idx - 2 >= 0 && i - 1 >= 0) ? psum[idx - 2] - psum[i - 1] : 0;

            if (idx - 2 >= 0 && i == 0)
                sum = psum[idx - 2];
            if (find >= tiles[idx - 1][1])
                sum += (tiles[idx - 1][1] - tiles[idx - 1][0] + 1);
            else
                sum += (find - tiles[idx - 1][0] + 1);
            max = Math.Max(max, sum);
        }
            return max;
        }

        private int BinarySearch(int[][] tiles, int find){
            //set boundaries
            int st = 0, end = tiles.Length;
            while (st < end){
                //find mid index
                int mid = st + (end - st) / 2;
                //if mid at 0 is less than or equal to find, shift start to right by 1 index
                //else set end to mid.
                if (tiles[mid][0] <= find)
                    st = mid + 1;
                else
                    end = mid;
            }
            return st;
        }
}
