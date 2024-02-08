/*Challenge link:https://leetcode.com/problems/intersection-of-two-arrays/description/
Question:
Given two integer arrays nums1 and nums2, return an array of their intersection. Each element in the result must be unique and you may return the result in any order.

 

Example 1:

Input: nums1 = [1,2,2,1], nums2 = [2,2]
Output: [2]
Example 2:

Input: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
Output: [9,4]
Explanation: [4,9] is also accepted.
 

Constraints:

1 <= nums1.length, nums2.length <= 1000
0 <= nums1[i], nums2[i] <= 1000
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Solution {
    public int[] Intersection(int[] nums1, int[] nums2) {
      return nums1.Intersect(nums2).ToArray(); 
    }
}


//solution 2 hashset, 
//loop through each number and check 
//if element in num2 is contained within num1
//if element in num1 is contained within num2
//if true, add it to hash set
public class Solution {
    public int[] Intersection(int[] nums1, int[] nums2) {
      var unique = new HashSet<int>();
      
      if (nums1.Length >= nums2.Length){
          for (int i = 0; i < nums1.Length; i++){
              if (nums2.Contains(nums1[i]))
                    unique.Add(nums1[i]);
      }}
      else{
    for (int i = 0; i < nums2.Length; i++){
        if (nums1.Contains(nums2[i]))
            unique.Add(nums2[i]);
    }}
    return unique.ToArray();
    }
}
