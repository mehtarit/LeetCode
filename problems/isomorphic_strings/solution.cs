public class Solution {
    public bool IsIsomorphic(string s, string t) {
        
        var s_tMap = new Dictionary<char, char>();
        
        for(int i = 0; i < s.Length; i++){
            var current = s[i];
            if(!s_tMap.ContainsKey(current)) {
                s_tMap.Add(current, t[i]);
                continue;
            }
            if(s_tMap[current] != t[i]) return false;           
        }
        
        var t_sMap = new Dictionary<char, char>();
        
        for(int i = 0; i < t.Length; i++){
            var current = t[i];
            if(!t_sMap.ContainsKey(current)) {
                t_sMap.Add(current, s[i]);
                continue;
            }
            if(t_sMap[current] != s[i]) return false; 
        }
        
        return true;
        
    }
}