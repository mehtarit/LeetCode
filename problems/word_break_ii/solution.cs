public class Solution {
    public IList<string> WordBreak(string s, IList<string> wordDict) {
        
        var map = new Dictionary<string, List<string>>();
        
        var result =  Helper(s, wordDict, map);
        
        return result;
        
    }
    
    IList<string> Helper(string s, IList<string> wordDict, Dictionary<string, List<string>> map){
        var result = new List<string>();
        
        if(string.IsNullOrEmpty(s)){
            result.Add("");
            return result;
        }
        
        if(map.ContainsKey(s)) return map[s];
        
        foreach(var word in wordDict){
            if(s.StartsWith(word)){
                
                var listOfWords = Helper(s.Substring(word.Length), wordDict, map);
                
                foreach(var w in listOfWords){
                    
                    if(w.Length == 0) result.Add(word);
                    else result.Add($"{word} {w}");
                    
                }
                
            }
        }
        
        map.Add(s, result);
        return result;
    }
}