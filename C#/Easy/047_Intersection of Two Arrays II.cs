/*Challenge link:https://leetcode.com/problems/intersection-of-two-arrays-ii/description/
Question:
Given two integer arrays nums1 and nums2, return an array of their intersection. Each element in the result must appear as many times as it shows in both arrays and you may return the result in any order.

 

Example 1:

Input: nums1 = [1,2,2,1], nums2 = [2,2]
Output: [2,2]
Example 2:

Input: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
Output: [4,9]
Explanation: [9,4] is also accepted.
 

Constraints:

1 <= nums1.length, nums2.length <= 1000
0 <= nums1[i], nums2[i] <= 1000
 

Follow up:

What if the given array is already sorted? How would you optimize your algorithm?
What if nums1's size is small compared to nums2's size? Which algorithm is better?
What if elements of nums2 are stored on disk, and the memory is limited such that you cannot load all elements into the memory at once?
*/

//***************Solution********************
//Question 3: What if elements of nums2 are stored on disk, and the memory is limited such that you cannot load all elements into the memory at once?
//hashmap to track frequency
public class Solution {
    public int[] Intersect(int[] nums1, int[] nums2) {
        //create hashmap to keey track of number frequency
        var map = new Dictionary<int, int>();

        //count the number occurrence in nums1
        for(int i = 0; i < nums1.Length; i++){
            if(map.ContainsKey(nums1[i]))  //more than once
                map[nums1[i]]++;
            else
                map[nums1[i]] = 1;         //only once
        }
        
        List<int> list = new List<int>();
        //subtract the number of occurrence of hashmap from nums2,
        //then add it to list.
        for(int i = 0; i < nums2.Length; i++){
             //if hashmap contains number from nums2 and that number in hashmap is greater than 0.
            if(map.ContainsKey(nums2[i]) && map[nums2[i]] > 0){  
                map[nums2[i]]--;   //reduce ocurrence by 1 and add to list
                list.Add(nums2[i]);
            }
                
        }
        return list.ToArray();
    }
}

//question 2: What if nums1's size is small compared to nums2's size? Which algorithm is better?
// if one array is very small and other is very large and larger array is sorted.
// iterate over the smaller array and binary search on the larger array.
//question 1: What if the given array is already sorted? How would you optimize your algorithm?
//binary search method
    public class Solution {
    public int[] Intersect(int[] nums1, int[] nums2) {
        var nums1Map = new Dictionary<int, int>();
        
        foreach(int num in nums1){
            if(nums1Map.ContainsKey(num))
                nums1Map[num]++;
            else
                nums1Map[num] = 1;
        }
        
        Array.Sort(nums2); //nums in testcase are not sorted, so sorting it here, assuming nums2 is the bigger array
        List<int> result = new List<int>();  //store final result
        HashSet<int> visited = new HashSet<int>();  //store visited value

        for(int i = 0; i < nums1.Length; i++){
            var count = GetCountByBinarySearch(nums2, nums1[i]); //get count
            if(count == 0 || visited.Contains(nums1[i])) continue; //check if count is empty and it is visited.
            
            visited.Add(nums1[i]);
            int min = Math.Min(count, nums1Map[nums1[i]]);          //select the bigger value between count and nums1Map[nums1[i]]
            while(min > 0){                                      //add value to result list, then reduce min by 1
                result.Add(nums1[i]);
                min--;
            }
        }
        return result.ToArray();
    }

      //count the number by direction
   private int GetCountByBinarySearch(int[] nums, int num){
        int left = GetLeftIndex(nums, num);
        int right = GetRightIndex(nums, num);
      
        if(left == -1) 
            return 0;
        return right - left + 1;
    }

      //look for left side
private int GetLeftIndex(int[] nums, int num){
        int low = 0;
        int high = nums.Length - 1;
        
        while(low <= high){
            int mid = low + (high - low)/ 2;
            if(nums[mid] == num && ( mid == 0 || nums[mid - 1] < num))
               return mid;            
            else if(nums[mid] < num)
                low = mid + 1;
            else if(nums[mid] >= num)
                high = mid - 1;
        }
        return -1;
    }
       //look for right side
    private int GetRightIndex(int[] nums, int num){
        int low = 0;
        int high = nums.Length - 1;
        
        while(low <= high){
            int mid = low + (high - low)/ 2;
            if(nums[mid] == num && ( mid == nums.Length - 1 || nums[mid + 1] > num))
               return mid;                 
            else if(nums[mid] <= num)
                low = mid + 1;
            else if(nums[mid] > num)
                high = mid - 1;
        }
        return -1;
    }
}
