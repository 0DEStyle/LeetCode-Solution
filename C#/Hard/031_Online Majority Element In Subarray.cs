/*Challenge link:https://leetcode.com/problems/online-majority-element-in-subarray/description/
Question:
Design a data structure that efficiently finds the majority element of a given subarray.

The majority element of a subarray is an element that occurs threshold times or more in the subarray.

Implementing the MajorityChecker class:

MajorityChecker(int[] arr) Initializes the instance of the class with the given array arr.
int query(int left, int right, int threshold) returns the element in the subarray arr[left...right] that occurs at least threshold times, or -1 if no such element exists.
 

Example 1:

Input
["MajorityChecker", "query", "query", "query"]
[[[1, 1, 2, 2, 1, 1]], [0, 5, 4], [0, 3, 3], [2, 3, 2]]
Output
[null, 1, -1, 2]

Explanation
MajorityChecker majorityChecker = new MajorityChecker([1, 1, 2, 2, 1, 1]);
majorityChecker.query(0, 5, 4); // return 1
majorityChecker.query(0, 3, 3); // return -1
majorityChecker.query(2, 3, 2); // return 2
 

Constraints:

1 <= arr.length <= 2 * 104
1 <= arr[i] <= 2 * 104
0 <= left <= right < arr.length
threshold <= right - left + 1
2 * threshold > right - left + 1
At most 104 calls will be made to query.
*/

//***************Solution********************
public class MajorityChecker {
    //15 bits, conect the majority of bits
        private readonly int digits = 15;
        private int[,] presum;
        private List<int>[] pos;

        public MajorityChecker(int[] arr){
            int len = arr.Length;
            presum = new int[len + 1, digits];
            pos = new List<int>[20001];

            //loop len times,
            for (int i = 0; i < len; i++){
                int n = arr[i];
                //if null, make new list for pos at index n.
                if (pos[n] == null)
                    pos[n] = new List<int>();

                //add current i to pos at index n
                pos[n].Add(i);

                //loop through digits
                //get presum
                //bit shfit n to right by 1
                for (int j = 0; j < digits; j++){
                    presum[i + 1, j] = presum[i, j] + (n & 1);
                    n >>= 1;
                }
            }
        }

        //return -1 if not found
        public int Query(int left, int right, int threshold){
            int ans = 0;

            //loop from end of digits down to 0
            for (int i = digits - 1; i >= 0; i--){
                //find cnt
                int cnt = presum[right + 1, i] - presum[left, i], b = 1;

                //check if count is greater or equal to threshold.
                if (cnt >= threshold)
                    b = 1;
                else if (right - left + 1 - cnt >= threshold)
                    b = 0;
                else
                    return -1;
                ans = (ans << 1) + b;
            }

            // check
            List<int> list = pos[ans];

            if (list == null) return -1;
            int L = Floor(list, left - 1),  R = Floor(list, right);

            //if R - L is greater or equal to threshold, return ans.
            if (R - L >= threshold) return ans;
            return -1;
        }

        //binary search
        private int Floor(List<int> list, int n){
            //set boundaries
            int left = 0, right = list.Count - 1, mid;
            while (left <= right){
                //find mid index
                mid = left + (right - left) / 2;
                int index = list[mid];

                //check condition and shift left and right accordingly
                if (index == n)
                    return mid;
                else if (index < n)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            return right;
        }
}

/**
 * Your MajorityChecker object will be instantiated and called as such:
 * MajorityChecker obj = new MajorityChecker(arr);
 * int param_1 = obj.Query(left,right,threshold);
 */
