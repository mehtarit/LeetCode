public class Solution {
    public string GetHint(string secret, string guess) {
        
        var freqArr = new int[10];      
        foreach(var c in secret){
            int n = c-'0';          
            freqArr[n]++;
        }
        
        //FindBulls      
        var set = new HashSet<int>();  
        
        for(int i =0; i < guess.Length; i++){      
            if(guess[i] == secret[i]) {
                set.Add(i);
                var n = secret[i] - '0';
                freqArr[n]--;
            }           
        }
        
        int cows = 0;       
        for(int i=0; i<guess.Length; i++)
        {
            if(set.Contains(i)) continue;
            
            int n = guess[i] - '0';
            if(freqArr[n] > 0) {
                freqArr[n]--;
                cows++;
            }
            
        }
        
        return $"{set.Count}A{cows}B";
        
        
        
        
    }
}