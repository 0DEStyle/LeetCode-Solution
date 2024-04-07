/*Challenge link:https://leetcode.com/problems/time-based-key-value-store/description/
Question:
Design a time-based key-value data structure that can store multiple values for the same key at different time stamps and retrieve the key's value at a certain timestamp.

Implement the TimeMap class:

TimeMap() Initializes the object of the data structure.
void set(String key, String value, int timestamp) Stores the key key with the value value at the given time timestamp.
String get(String key, int timestamp) Returns a value such that set was called previously, with timestamp_prev <= timestamp. If there are multiple such values, it returns the value associated with the largest timestamp_prev. If there are no values, it returns "".
 

Example 1:

Input
["TimeMap", "set", "get", "get", "set", "get", "get"]
[[], ["foo", "bar", 1], ["foo", 1], ["foo", 3], ["foo", "bar2", 4], ["foo", 4], ["foo", 5]]
Output
[null, null, "bar", "bar", null, "bar2", "bar2"]

Explanation
TimeMap timeMap = new TimeMap();
timeMap.set("foo", "bar", 1);  // store the key "foo" and value "bar" along with timestamp = 1.
timeMap.get("foo", 1);         // return "bar"
timeMap.get("foo", 3);         // return "bar", since there is no value corresponding to foo at timestamp 3 and timestamp 2, then the only value is at timestamp 1 is "bar".
timeMap.set("foo", "bar2", 4); // store the key "foo" and value "bar2" along with timestamp = 4.
timeMap.get("foo", 4);         // return "bar2"
timeMap.get("foo", 5);         // return "bar2"
 

Constraints:

1 <= key.length, value.length <= 100
key and value consist of lowercase English letters and digits.
1 <= timestamp <= 107
All the timestamps timestamp of set are strictly increasing.
At most 2 * 105 calls will be made to set and get.
*/

//***************Solution********************
/**
 * Your TimeMap object will be instantiated and called as such:
 * TimeMap obj = new TimeMap();
 * obj.Set(key,value,timestamp);
 * string param_2 = obj.Get(key,timestamp);
 */

public class TimeMap {
    private Dictionary<string, List<(string value, int timestamp)>> records;
    
    //create new dictionary records
    public TimeMap(){
        records = new();
    }

    //set method
    //if recirds does not contain key, create new list and add key
    //else add value and timestamp into key index
    public void Set(string key, string value, int timestamp){
        if (!records.ContainsKey(key))
            records.Add(key, new List<(string value, int timestamp)>());
        records[key].Add((value, timestamp));
    }
    
    public string Get(string key, int timestamp){
        var result = "";

        //check if it is possible to get key
        if (records.TryGetValue(key, out var record)){
            //if record.count is 1, and record[0] timestamp is less than or eqaul to timestamp, return record[0]'s value
            //else return result
            if (record.Count == 1) { 
                if (record[0].timestamp <= timestamp) return record[0].value; 
                else return result;
            }
            //if record count is 2 and record[1] timestamp is less than or equal to timestamp,  return record[1]'s value
            //else if record[0] timestamp is less than or equal to timestamp, return record[0]'s value
            //else return result
            if (record.Count == 2){
                if (record[1].timestamp <= timestamp) return record[1].value; 
                else if (record[0].timestamp <= timestamp) return record[0].value; 
                else return result;
            }

            // Binary search
            //set boundaries
            int left = 0, right = record.Count - 1;

            while (left <= right){
                //find mid index
                int mid = left + (right - left) / 2;

                //if mid index of record's timestamp is less than timestamp
                //shift right to left by 1 index
                //if opposite
                //shift left to right by 1 index
                //else return record[mid]'s value
                if (record[mid].timestamp > timestamp) 
                    right = mid - 1; 
                else if (record[mid].timestamp < timestamp)
                    left = mid + 1; 
                else 
                    return record[mid].value;
            }
            //if right index timestamp is less than timestamp, return right index's val
            if (record[right].timestamp < timestamp) return record[right].value; 
        }
        return result;
}
}
