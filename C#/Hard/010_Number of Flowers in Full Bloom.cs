/*Challenge link:https://leetcode.com/problems/number-of-flowers-in-full-bloom/description/
Question:
You are given a 0-indexed 2D integer array flowers, where flowers[i] = [starti, endi] means the ith flower will be in full bloom from starti to endi (inclusive). You are also given a 0-indexed integer array people of size n, where people[i] is the time that the ith person will arrive to see the flowers.

Return an integer array answer of size n, where answer[i] is the number of flowers that are in full bloom when the ith person arrives.

 

Example 1:
//see image in link

Input: flowers = [[1,6],[3,7],[9,12],[4,13]], people = [2,3,7,11]
Output: [1,2,2,2]
Explanation: The figure above shows the times when the flowers are in full bloom and when the people arrive.
For each person, we return the number of flowers in full bloom during their arrival.
Example 2:
//see image in link

Input: flowers = [[1,10],[3,3]], people = [3,3,2]
Output: [2,2,1]
Explanation: The figure above shows the times when the flowers are in full bloom and when the people arrive.
For each person, we return the number of flowers in full bloom during their arrival.
 

Constraints:

1 <= flowers.length <= 5 * 104
flowers[i].length == 2
1 <= starti <= endi <= 109
1 <= people.length <= 5 * 104
1 <= people[i] <= 109
*/

//***************Solution********************
public class Solution {
    public int[] FullBloomFlowers(int[][] flowers, int[] people) {
        List<int> starts = new List<int>();
        List<int> ends = new List<int>();

        foreach (var flower in flowers){
            starts.Add(flower[0]);
            ends.Add(flower[1] + 1);
        }

        starts.Sort();
        ends.Sort();
        int[] ans = new int[people.Length];

        for (int index = 0; index < people.Length; index++){
            int person = people[index];
            int i = BinarySearch(starts, person);
            int j = BinarySearch(ends, person);
            ans[index] = i - j;
        }
        return ans;
    }

    public int BinarySearch(List<int> arr, int target){
        //set boundaries
        int left = 0, right = arr.Count;

        while (left < right){
            //find mid index
            int mid = (left + right) / 2;
            //check condition
            if (target < arr[mid])
                right = mid;
            else
                left = mid + 1;
        }
        return left;
    }
}
