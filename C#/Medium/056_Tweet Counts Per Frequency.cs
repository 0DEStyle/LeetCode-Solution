/*Challenge link:https://leetcode.com/problems/tweet-counts-per-frequency/description/
Question:
A social media company is trying to monitor activity on their site by analyzing the number of tweets that occur in select periods of time. These periods can be partitioned into smaller time chunks based on a certain frequency (every minute, hour, or day).

For example, the period [10, 10000] (in seconds) would be partitioned into the following time chunks with these frequencies:

Every minute (60-second chunks): [10,69], [70,129], [130,189], ..., [9970,10000]
Every hour (3600-second chunks): [10,3609], [3610,7209], [7210,10000]
Every day (86400-second chunks): [10,10000]
Notice that the last chunk may be shorter than the specified frequency's chunk size and will always end with the end time of the period (10000 in the above example).

Design and implement an API to help the company with their analysis.

Implement the TweetCounts class:

TweetCounts() Initializes the TweetCounts object.
void recordTweet(String tweetName, int time) Stores the tweetName at the recorded time (in seconds).
List<Integer> getTweetCountsPerFrequency(String freq, String tweetName, int startTime, int endTime) Returns a list of integers representing the number of tweets with tweetName in each time chunk for the given period of time [startTime, endTime] (in seconds) and frequency freq.
freq is one of "minute", "hour", or "day" representing a frequency of every minute, hour, or day respectively.
 

Example:

Input
["TweetCounts","recordTweet","recordTweet","recordTweet","getTweetCountsPerFrequency","getTweetCountsPerFrequency","recordTweet","getTweetCountsPerFrequency"]
[[],["tweet3",0],["tweet3",60],["tweet3",10],["minute","tweet3",0,59],["minute","tweet3",0,60],["tweet3",120],["hour","tweet3",0,210]]

Output
[null,null,null,null,[2],[2,1],null,[4]]

Explanation
TweetCounts tweetCounts = new TweetCounts();
tweetCounts.recordTweet("tweet3", 0);                              // New tweet "tweet3" at time 0
tweetCounts.recordTweet("tweet3", 60);                             // New tweet "tweet3" at time 60
tweetCounts.recordTweet("tweet3", 10);                             // New tweet "tweet3" at time 10
tweetCounts.getTweetCountsPerFrequency("minute", "tweet3", 0, 59); // return [2]; chunk [0,59] had 2 tweets
tweetCounts.getTweetCountsPerFrequency("minute", "tweet3", 0, 60); // return [2,1]; chunk [0,59] had 2 tweets, chunk [60,60] had 1 tweet
tweetCounts.recordTweet("tweet3", 120);                            // New tweet "tweet3" at time 120
tweetCounts.getTweetCountsPerFrequency("hour", "tweet3", 0, 210);  // return [4]; chunk [0,210] had 4 tweets
 

Constraints:

0 <= time, startTime, endTime <= 109
0 <= endTime - startTime <= 104
There will be at most 104 calls in total to recordTweet and getTweetCountsPerFrequency.
*/

//***************Solution********************
public class TweetCounts {

    //compare time
    private class Tweet : IComparable<Tweet>{
        public string Name;
        public int Time;

        public int CompareTo(Tweet other){
            var comp = Time.CompareTo(other.Time);
            return comp == 0 ? 1 : comp;
        }
    }

    private readonly SortedList<Tweet, Tweet> _list = new();

    //add new tweets to the list, tweet name and time
    public void RecordTweet(string tweetName, int time) {
        var tweet = new Tweet { Name = tweetName, Time = time };
        _list.Add(tweet, tweet);
    }
    
    //main, binary search
    public IList<int> GetTweetCountsPerFrequency(string freq, string tweetName, int startTime, int endTime) {
        //set boundaries
        int l = 0, r = _list.Count - 1, index = 0, size = 0;

        while (l <= r){
            //get mid index
            var m = l + (r - l) / 2;

            //if list mid values of time is less than start tiem, shift left to right by 1 index. set index to mid
            //else shift right to left by 1 index.
            if (_list.Values[m].Time < startTime){
                l = m + 1;
                index = m;
            }
            else
                r = m - 1;
        }

        //if check words and set time accordingly
        if (freq == "minute") size = 60;
        else if (freq == "hour") size = 3600;
        else size = 86400;

        //intialize length, buckets and list result.
        var length = (decimal) (endTime - startTime + 1);
        var buckets = (int) Math.Ceiling(length / size);
        var result = new List<int>(buckets);
        //loop buckets amount of times, add 0 to result list.
        for (var i = 0; i < buckets; i++)
            result.Add(0);

        //start from index, loop list's length amount of time.
        for (var i = index; i < _list.Count; i++){
            //if current value's name is not the same as tweet name, continue.
            if (_list.Values[i].Name != tweetName) continue;

            //set time to curretn time
            //if time is less than startTime, continue, then break if time is greater than endTime
            var time = _list.Values[i].Time;
            if (time < startTime) continue;
            if (time > endTime) break;

            //find the difference between current time and startime.
            //increase result at diff/size index by 1
            var diff = time - startTime;
            result[diff / size] += 1;
        }
        return result;
    }
}

/**
 * Your TweetCounts object will be instantiated and called as such:
 * TweetCounts obj = new TweetCounts();
 * obj.RecordTweet(tweetName,time);
 * IList<int> param_2 = obj.GetTweetCountsPerFrequency(freq,tweetName,startTime,endTime);
 */
