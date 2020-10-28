public class Solution {
    public string[] FindOcurrences(string text, string first, string second) {
        
        var words = text.Split(' ');
        
        var result = new List<string>();
        
        if(text.Length < 3) return result.ToArray();
        
        for(int i = 0; i < words.Length-2; i++){
            
            if(words[i].Equals(first) && words[i+1].Equals(second)){
                result.Add(words[i+2]);
            }
            
        }
        
        return result.ToArray();
        
    }
}