public class Solution {
    public int FirstUniqChar(string s) {
        
        var freqArray = new int[26];
        
        foreach(var c in s){
            int index = c-'a';
            freqArray[index]++;
        }
        
        for(int i = 0; i < s.Length; i++){
            int index = s[i]-'a';
            if(freqArray[index] == 1) return i;
        }
        
        return -1;
        
    }
}