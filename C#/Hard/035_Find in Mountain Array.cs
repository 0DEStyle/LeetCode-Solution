/*Challenge link:https://leetcode.com/problems/find-in-mountain-array/description/
Question:
(This problem is an interactive problem.)

You may recall that an array arr is a mountain array if and only if:

arr.length >= 3
There exists some i with 0 < i < arr.length - 1 such that:
arr[0] < arr[1] < ... < arr[i - 1] < arr[i]
arr[i] > arr[i + 1] > ... > arr[arr.length - 1]
Given a mountain array mountainArr, return the minimum index such that mountainArr.get(index) == target. If such an index does not exist, return -1.

You cannot access the mountain array directly. You may only access the array using a MountainArray interface:

MountainArray.get(k) returns the element of the array at index k (0-indexed).
MountainArray.length() returns the length of the array.
Submissions making more than 100 calls to MountainArray.get will be judged Wrong Answer. Also, any solutions that attempt to circumvent the judge will result in disqualification.

 

Example 1:

Input: array = [1,2,3,4,5,3,1], target = 3
Output: 2
Explanation: 3 exists in the array, at index=2 and index=5. Return the minimum index, which is 2.
Example 2:

Input: array = [0,1,2,4,2,1], target = 3
Output: -1
Explanation: 3 does not exist in the array, so we return -1.
 

Constraints:

3 <= mountain_arr.length() <= 104
0 <= target <= 109
0 <= mountain_arr.get(index) <= 109
*/

//***************Solution********************
/**
 * // This is MountainArray's API interface.
 * // You should not implement it, or speculate about its implementation
 * class MountainArray {
 *     public int Get(int index) {}
 *     public int Length() {}
 * }
 */

class Solution {
    public int FindInMountainArray(int target, MountainArray mountainArr) {
        int length = mountainArr.Length();
        // Find the index of the peak element in the mountain array.
        int peakIndex = FindPeakIndex(1, length - 2, mountainArr);

        // Binary search for the target in the increasing part of the mountain array.
        int increasingIndex = BinarySearch(0, peakIndex, target, mountainArr, false);
        if (mountainArr.Get(increasingIndex)== target) 
            return increasingIndex; // Target found in the increasing part.

        // Binary search for the target in the decreasing part of the mountain array.
        int decreasingIndex = BinarySearch(peakIndex + 1, length - 1, target, mountainArr, true);
        if (mountainArr.Get(decreasingIndex) == target) 
            return decreasingIndex; // Target found in the decreasing part.

        return -1;  // Target not found in the mountain array.
        }

        private int FindPeakIndex(int low, int high, MountainArray mountainArr) {
        while (low != high) {
            //get mid index
            int mid = low + (high - low) / 2;

            //shift index accordingly
            if (mountainArr.Get(mid) < mountainArr.Get(mid + 1))
                low = mid + 1; 
            else
                high = mid; 
        }
        return low; // Return the index of the peak element.
        }

        private int BinarySearch(int low, int high, int target, MountainArray mountainArr, bool reversed) {
        while (low != high) {
            //find mid index
            int mid = low + (high - low) / 2;

            //shift index accordingly
            if (reversed) {
                if (mountainArr.Get(mid) > target)
                    low = mid + 1; // Move to the right side for a decreasing slope.
                else
                    high = mid; // Move to the left side for an increasing slope.
            } 
            else {
                if (mountainArr.Get(mid) < target)
                    low = mid + 1; // Move to the right side for an increasing slope.
                else
                    high = mid; // Move to the left side for a decreasing slope.
            }
        }
        return low; // Return the index where the target should be or would be inserted.
        }
    }
