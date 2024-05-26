/*Challenge link:https://leetcode.com/problems/snapshot-array/description/
Question:
Implement a SnapshotArray that supports the following interface:

SnapshotArray(int length) initializes an array-like data structure with the given length. Initially, each element equals 0.
void set(index, val) sets the element at the given index to be equal to val.
int snap() takes a snapshot of the array and returns the snap_id: the total number of times we called snap() minus 1.
int get(index, snap_id) returns the value at the given index, at the time we took the snapshot with the given snap_id
 

Example 1:

Input: ["SnapshotArray","set","snap","set","get"]
[[3],[0,5],[],[0,6],[0,0]]
Output: [null,null,0,null,5]
Explanation: 
SnapshotArray snapshotArr = new SnapshotArray(3); // set the length to be 3
snapshotArr.set(0,5);  // Set array[0] = 5
snapshotArr.snap();  // Take a snapshot, return snap_id = 0
snapshotArr.set(0,6);
snapshotArr.get(0,0);  // Get the value of array[0] with snap_id = 0, return 5
 

Constraints:

1 <= length <= 5 * 104
0 <= index < length
0 <= val <= 109
0 <= snap_id < (the total number of times we call snap())
At most 5 * 104 calls will be made to set, snap, and get.
*/

//***************Solution********************
//binary search
public class SnapshotArray {
    //set global list int int , snap_id to 0
    public List<List<(int, int)>> List;
    public int snap_id = 0;

    public SnapshotArray(int length) {
        List = new List<List<(int, int)>>(length);
        for (int i = 0; i < length; i++){
            List.Add(new List<(int, int)>());
            List[i].Add((0, 0));
        }
    }
    public void Set(int index, int val) {
        List[index].Add((snap_id, val));
    }
    public int Snap() => snap_id++;
    
    public int Get(int index, int snap_id) {
        var values = List[index];
        // find max snapshot, which is <= snap_id
        int l = 0, r = values.Count - 1;

        while (l < r){
            //find mid index
            var mid = (l + r + 1) / 2;
            if (values[mid].Item1 <= snap_id)
                l = mid;
            else
                r = mid - 1;
        }
        return values[l].Item2;
    }
}

/**
 * Your SnapshotArray object will be instantiated and called as such:
 * SnapshotArray obj = new SnapshotArray(length);
 * obj.Set(index,val);
 * int param_2 = obj.Snap();
 * int param_3 = obj.Get(index,snap_id);
 */

//dictionary time out.
public class SnapshotArray {
    //set global dictionary int int a, snap_id to 0
    Dictionary<int, int>[] A;
    int snap_id = 0;

    public SnapshotArray(int length) {
    //give dictionary a the size of length
    A = new Dictionary<int, int>[length];
    //loop through length, set current index as new dictionary, add 0,0
    for (int i = 0; i < length; i++){
        A[i] = new Dictionary<int, int>();
        A[i].Add(0, 0);
    }
    }
    //set A at index and snap_id to val
    public void Set(int index, int val) {
        A[index][snap_id] = val;
    }
    
    //once snap, increase snap id by 1
    public int Snap() => snap_id++;
    
    //A at index, if x.key is less than or equal to snap_id, order it by descending, get first or default.
    //retunr entry value.
    public int Get(int index, int snap_id) {
    var entry = A[index].Where(x => x.Key <= snap_id)
                        .OrderByDescending(x => x.Key)
                        .FirstOrDefault();
    return entry.Value;
    }
}

/**
 * Your SnapshotArray object will be instantiated and called as such:
 * SnapshotArray obj = new SnapshotArray(length);
 * obj.Set(index,val);
 * int param_2 = obj.Snap();
 * int param_3 = obj.Get(index,snap_id);
 */
