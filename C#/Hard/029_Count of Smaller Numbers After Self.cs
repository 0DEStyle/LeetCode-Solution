/*Challenge link:https://leetcode.com/problems/count-of-smaller-numbers-after-self/description/
Question:
Given an integer array nums, return an integer array counts where counts[i] is the number of smaller elements to the right of nums[i].

 

Example 1:

Input: nums = [5,2,6,1]
Output: [2,1,1,0]
Explanation:
To the right of 5 there are 2 smaller elements (2 and 1).
To the right of 2 there is only 1 smaller element (1).
To the right of 6 there is 1 smaller element (1).
To the right of 1 there is 0 smaller element.
Example 2:

Input: nums = [-1]
Output: [0]
Example 3:

Input: nums = [-1,-1]
Output: [0,0]
 

Constraints:

1 <= nums.length <= 105
-104 <= nums[i] <= 104
*/

//***************Solution********************
//https://www.youtube.com/watch?v=wWrprKyQmE4
public class Solution {
    public IList<int> CountSmaller(int[] nums) {
        var list = new List<int>();
        //add index of nums.length-1 of nums into list
        list.Add(nums[nums.Length-1]);
        //set the last index to 0, since nothing is smaller to the right
        nums[nums.Length-1]=0;

        //loop from nums.length -2 down to 0
        //pass list and current element of num into binary search method, set to sum
        //set curretn element to sum
        for(int i=nums.Length-2;i>=0;i--){
            int sum = binSearch(list, nums[i]);
            nums[i]=sum;
        }
        return nums;
    }

    private int binSearch(List<int> list, int target){
        //set boundaries
        int left = 0, right= list.Count-1;

        while(left<=right){
            //find mid index
            int mid = (left + right)/2;
            //check condition
            if(list[mid]<target)
                left = mid+1;
            else
                right= mid-1;            
        }
        //insert left and target into list
        list.Insert(left,target);
        return left;
    }
}
