public class Solution {
    public string GetHint(string secret, string guess) {
        
        
        
       var freqArr = new int[10];
       foreach(var c in secret){
           int digit = c-'0';
           freqArr[digit]++;
       }
       
        int bullCount = 0;
        int cowCount = 0;
        
        var set = new HashSet<int>();
        for(int i = 0; i < guess.Length; i++)
        {
            var current = guess[i]-'0';
            if(current == (secret[i]-'0')) {
                bullCount++;
                freqArr[current]--;
                set.Add(i);
                continue;
            }            
            
        }
        
        for(int i = 0; i < guess.Length; i++)
        {
            if(set.Contains(i)) continue;
            var current = guess[i]-'0';
            if(freqArr[current] > 0) cowCount++;
            freqArr[current]--;
        }
        
        
        
        return $"{bullCount}A{cowCount}B";
        
    }
}