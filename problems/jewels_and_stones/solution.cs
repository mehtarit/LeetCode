public class Solution {
    public int NumJewelsInStones(string J, string S) {
        
        var set = new HashSet<char>();
        
        foreach(var c in J){
            set.Add(c);
        }
        
        var count =0;
        foreach(var c in S){           
            if(set.Contains(c)) count++;            
        }
        
        return count;
        
    }
}