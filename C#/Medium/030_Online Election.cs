/*Challenge link:https://leetcode.com/problems/online-election/description/
Question:
You are given two integer arrays persons and times. In an election, the ith vote was cast for persons[i] at time times[i].

For each query at a time t, find the person that was leading the election at time t. Votes cast at time t will count towards our query. In the case of a tie, the most recent vote (among tied candidates) wins.

Implement the TopVotedCandidate class:

TopVotedCandidate(int[] persons, int[] times) Initializes the object with the persons and times arrays.
int q(int t) Returns the number of the person that was leading the election at time t according to the mentioned rules.
 

Example 1:

Input
["TopVotedCandidate", "q", "q", "q", "q", "q", "q"]
[[[0, 1, 1, 0, 0, 1, 0], [0, 5, 10, 15, 20, 25, 30]], [3], [12], [25], [15], [24], [8]]
Output
[null, 0, 1, 1, 0, 0, 1]

Explanation
TopVotedCandidate topVotedCandidate = new TopVotedCandidate([0, 1, 1, 0, 0, 1, 0], [0, 5, 10, 15, 20, 25, 30]);
topVotedCandidate.q(3); // return 0, At time 3, the votes are [0], and 0 is leading.
topVotedCandidate.q(12); // return 1, At time 12, the votes are [0,1,1], and 1 is leading.
topVotedCandidate.q(25); // return 1, At time 25, the votes are [0,1,1,0,0,1], and 1 is leading (as ties go to the most recent vote.)
topVotedCandidate.q(15); // return 0
topVotedCandidate.q(24); // return 0
topVotedCandidate.q(8); // return 1

 

Constraints:

1 <= persons.length <= 5000
times.length == persons.length
0 <= persons[i] < persons.length
0 <= times[i] <= 109
times is sorted in a strictly increasing order.
times[0] <= t <= 109
At most 104 calls will be made to q.
*/

//***************Solution********************
//dinctionary plus binary search method

public class TopVotedCandidate {
    //global storage
    int[] Persons, Times;

    public TopVotedCandidate(int[] persons, int[] times) {
        Persons = persons;
        Times = times;

        //create a dictinary for frequence storage.
        int n = Persons.Length, maxFreqPerson = -1, maxFreq = -1;
        var freqs = new Dictionary<int, int>();

        //lopp through all elements in the person's length
        for (var i = 0; i < n; i++) {
            int freq = 1;

            //if the dictionary freqs contains current element of persons
            //increase that element by 1, then store in freq 
            //else add 1 current element of person, and 1 into freqs dictionary
            if (freqs.ContainsKey(Persons[i]))
                freq = ++freqs[Persons[i]];
            else
                freqs.Add(Persons[i], 1);

            //if freq is greater than maxFreq
            //update maxFreq as freq, and maxFreqPerson as current element of Persons
            if (freq >= maxFreq) {
                maxFreq = freq;
                maxFreqPerson = Persons[i];
            }
            //update curretn element of person to maxFreqPerson
            Persons[i] = maxFreqPerson;
        }
    }
    
    public int Q(int t) {
        //set upper and lower boundaries.
        int n = Persons.Length, low = 0, high = n - 1;

        while (low < high) {
            //get mid index
            int mid = low + (high - low) / 2;

            //if mid element is less than t, shift low to right by 1 index
            //else set high as mid
            if (Times[mid] < t) 
                low = mid + 1;
            else
                high = mid;
        }        
        //if the low index of times is less than t AND low is greater than 0, reduce low by 1
        //return the persons at low index
        if (Times[low] > t && low > 0) low--;
        return Persons[low];
    }
}

/**
 * Your TopVotedCandidate object will be instantiated and called as such:
 * TopVotedCandidate obj = new TopVotedCandidate(persons, times);
 * int param_1 = obj.Q(t);
 */
