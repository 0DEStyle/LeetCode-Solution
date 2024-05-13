/*Challenge link:https://leetcode.com/problems/range-frequency-queries/description/
Question:
Design a data structure to find the frequency of a given value in a given subarray.

The frequency of a value in a subarray is the number of occurrences of that value in the subarray.

Implement the RangeFreqQuery class:

RangeFreqQuery(int[] arr) Constructs an instance of the class with the given 0-indexed integer array arr.
int query(int left, int right, int value) Returns the frequency of value in the subarray arr[left...right].
A subarray is a contiguous sequence of elements within an array. arr[left...right] denotes the subarray that contains the elements of nums between indices left and right (inclusive).

 

Example 1:

Input
["RangeFreqQuery", "query", "query"]
[[[12, 33, 4, 56, 22, 2, 34, 33, 22, 12, 34, 56]], [1, 2, 4], [0, 11, 33]]
Output
[null, 1, 2]

Explanation
RangeFreqQuery rangeFreqQuery = new RangeFreqQuery([12, 33, 4, 56, 22, 2, 34, 33, 22, 12, 34, 56]);
rangeFreqQuery.query(1, 2, 4); // return 1. The value 4 occurs 1 time in the subarray [33, 4]
rangeFreqQuery.query(0, 11, 33); // return 2. The value 33 occurs 2 times in the whole array.
 

Constraints:

1 <= arr.length <= 105
1 <= arr[i], value <= 104
0 <= left <= right < arr.length
At most 105 calls will be made to query
*/

//***************Solution********************class RangeFreqQuery{
    //global dictionary int, List<int>
    Dictionary<int,List<int>> freqs = new Dictionary<int, List<int>>();   

    public RangeFreqQuery(int[] arr){
        //loop through arr length
        //if freqs contains current element of array, add index into arr[i]
        //else create new int list, add i into list, then add current element of arr and list into freqs
        for (int i = 0; i < arr.Length; i++){
            if (freqs.ContainsKey(arr[i]))
                freqs[arr[i]].Add(i);
            else{
                List<int> list = new List<int>();
                list.Add(i);
                freqs.Add(arr[i],list);
            }
        }
    }

    public int Query(int left, int right, int value){      
    //if freqs doesn't contain key vale, return 0  
      if (!freqs.ContainsKey(value))
            return 0;
        //create int list res, set it to freqs value
        // The list is already sorted during construction, no need to sort here.
        List<int> res = freqs[value];
        
        //find binary search res with left value, store in left index
        int leftIndex = res.BinarySearch(left);

        //if left index is less than 0, bit wise complement left index and update.
        if (leftIndex < 0)
            leftIndex = ~leftIndex; // Get the insertion point if not found.   

        //find binary search res with right value, store in right index
        //if right index is less than 0, bit wise complement right index and update 
        int rightIndex = res.BinarySearch(right);
        if (rightIndex < 0)
            rightIndex = ~rightIndex; // Get the insertion point if not found.    
        
        //else add 1 to right index
        else         
            rightIndex++; // Include the right boundary if it is found.    

        //find the difference between right and left.
        return rightIndex - leftIndex;
    }
}

/**
 * Your RangeFreqQuery object will be instantiated and called as such:
 * RangeFreqQuery obj = new RangeFreqQuery(arr);
 * int param_1 = obj.Query(left,right,value);
 */
