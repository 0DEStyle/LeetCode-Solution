/*Challenge link:https://leetcode.com/problems/reverse-vowels-of-a-string/description/
Question:
Given a string s, reverse only all the vowels in the string and return it.

The vowels are 'a', 'e', 'i', 'o', and 'u', and they can appear in both lower and upper cases, more than once.

 

Example 1:

Input: s = "hello"
Output: "holle"
Example 2:

Input: s = "leetcode"
Output: "leotcede"
 

Constraints:

1 <= s.length <= 3 * 105
s consist of printable ASCII characters.
*/

//***************Solution********************
public class Solution {
    public string ReverseVowels(string s) {
        //string builder, stack, hashset, and list of index
    StringBuilder sb = new(s);
    Stack<char> stack = new();

    HashSet<char> hashSet = new("aeiouAEIOU".ToCharArray());
    List<int> vowelIndexes = new();

    for (int i=0; i< s.Length; i++){
        //if hashset contains element s[i], push it to stack, add current i to index
        if (hashSet.Contains(s[i])){
            stack.Push(s[i]);
            vowelIndexes.Add(i);
        }
    }
    int index = 0;
    //loop while stack count is greater than 0, pop stack into stirng builder
    while (stack.Count > 0)
        sb[vowelIndexes[index++]] = stack.Pop();

    return sb.ToString();
    }
}
