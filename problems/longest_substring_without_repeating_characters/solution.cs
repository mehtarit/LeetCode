public class Solution {
    
    public bool IsUnique(string s){
        var seen = new HashSet<char>();
        foreach(var c in s){
            if(seen.Contains(c)) return false;
            seen.Add(c);
        }
        return true;
    }
    
    public int LengthOfLongestSubstring(string s) {
        
        HashSet<char> distinctChars = new HashSet<char>();
        
        foreach(var c in s){
            if(!distinctChars.Contains(c)) distinctChars.Add(c);
        }
        
        var slidingWindow = distinctChars.Count;
        if(slidingWindow < 2) //either 0 or 1
            return slidingWindow;
        
        while(slidingWindow > 2){
            
            var end = s.Length-slidingWindow;
            if(end == 0) return slidingWindow;
            for(int i =0; i<=end; i++){
                
                var current = s.Substring(i, slidingWindow);
                //Console.WriteLine("Current is: " + current);
                if(IsUnique(current)) {
                //Console.WriteLine("Breaking");
                return slidingWindow;}
                
            }
            slidingWindow--;        
        }
        
        return slidingWindow;       
        
    }
}