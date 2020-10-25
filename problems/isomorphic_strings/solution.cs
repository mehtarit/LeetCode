public class Solution {
    public bool IsIsomorphic(string s, string t) {
        
        var index = 0;
        
        var mapS2T = new Dictionary<char, char>();
        var mapT2S = new Dictionary<char, char>();
        
        while(index < s.Length){
            var sChar = s[index];
            var tChar = t[index];
            
            if(!mapS2T.ContainsKey(sChar)) mapS2T.Add(sChar, tChar);
            else if(mapS2T[sChar] != tChar) return false;
            
            if(!mapT2S.ContainsKey(tChar)) mapT2S.Add(tChar, sChar);      
            else if(mapT2S[tChar] != sChar) return false;
                        
            index++;
                    
        }
        
        return true;
        
    }
}