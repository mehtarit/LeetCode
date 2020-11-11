/**
 * // This is the Master's API interface.
 * // You should not implement it, or speculate about its implementation
 * class Master {
 *     public int Guess(string word);
 * }
 */
class Solution {
    Random rand = new Random();
    
    public int MatchCount(string s1, string s2){
        int numMatch = 0;
        for(int i = 0; i < s1.Length; i++){
            if(s1[i] == s2[i]) numMatch++;
        }
        return numMatch;
    }
    
    public string[] NarrowDown(string[] wordlist, int match, int index){
        
        var result = new List<string>();
        
        foreach(var word in wordlist){
            if(MatchCount(word, wordlist[index]) == match)
                result.Add(word);
        }
        
        return result.ToArray();
    }
    
    public void FindSecretWord(string[] wordlist, Master master) {
        
        var index = rand.Next(wordlist.Length);
        
        var match = master.Guess(wordlist[index]);
        
        if(match == 6) return;
        
        wordlist = NarrowDown(wordlist, match, index);
        
        FindSecretWord(wordlist, master);
        
    }
}