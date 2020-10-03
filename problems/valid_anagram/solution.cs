public class Solution {
    public bool IsAnagram(string s, string t ) {
        
        var freqArray = new int[26];
        
        foreach(var c in s){
            int index = c-'a';
            freqArray[index]++;
        }
        
        foreach(var c in t){
            int index = c-'a';
            freqArray[index]--;
            if(freqArray[index] < 0) return false;
        }
        
        return freqArray.Sum() == 0;
        
    }
}