/*Challenge link:https://leetcode.com/problems/capacity-to-ship-packages-within-d-days/description/
Question:
A conveyor belt has packages that must be shipped from one port to another within days days.

The ith package on the conveyor belt has a weight of weights[i]. Each day, we load the ship with packages on the conveyor belt (in the order given by weights). We may not load more weight than the maximum weight capacity of the ship.

Return the least weight capacity of the ship that will result in all the packages on the conveyor belt being shipped within days days.

 

Example 1:

Input: weights = [1,2,3,4,5,6,7,8,9,10], days = 5
Output: 15
Explanation: A ship capacity of 15 is the minimum to ship all the packages in 5 days like this:
1st day: 1, 2, 3, 4, 5
2nd day: 6, 7
3rd day: 8
4th day: 9
5th day: 10

Note that the cargo must be shipped in the order given, so using a ship of capacity 14 and splitting the packages into parts like (2, 3, 4, 5), (1, 6, 7), (8), (9), (10) is not allowed.
Example 2:

Input: weights = [3,2,2,4,1,4], days = 3
Output: 6
Explanation: A ship capacity of 6 is the minimum to ship all the packages in 3 days like this:
1st day: 3, 2
2nd day: 2, 4
3rd day: 1, 4
Example 3:

Input: weights = [1,2,3,1,1], days = 4
Output: 3
Explanation:
1st day: 1
2nd day: 2
3rd day: 3
4th day: 1, 1
 

Constraints:

1 <= days <= weights.length <= 5 * 104
1 <= weights[i] <= 500
*/

//***************Solution********************
public class Solution {
    public int ShipWithinDays(int[] weights, int days){
	//min and max capacities for the ship
	int minCapacity = weights.Max();
	int maxCapacity = weights.Sum();
    //set current capacity to an invalid value
	int currCap = -1;

	//binary search ship all the packages within D days
	while (minCapacity <= maxCapacity){
		//find mid, no overflow way
		int mid = minCapacity + (maxCapacity - minCapacity) / 2;

		// Check if all packages can ship within D days 
	    //update the current capacity and continue searching towards smaller capacities
		if (canShip(mid, weights, days)){
			currCap = mid;
			maxCapacity = mid - 1;   //shift mid to left
		}
		else{
			minCapacity = mid + 1;  //shift mid to right
		}
	}
	return currCap;
}

public bool canShip(int capacity, int[] weights, int days){
	//capacity to the input capacity
	int currCap = capacity;

	//loop through each weight
	foreach (int weight in weights){
		// If the package can be loaded onto the ship, update the current capacity
		if (currCap - weight >= 0)
			currCap -= weight;
		else{
			// If the package cannot be loaded onto the ship, we need to use another day to ship it
			days--;
			currCap = capacity - weight;
		}
	}
	// Return bool value if we can ship all the packages within D days using the input capacity
	return days > 0;
}
}
