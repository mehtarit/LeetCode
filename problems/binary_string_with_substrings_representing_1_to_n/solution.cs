public class Solution {
    public bool QueryString(string S, int N) {
        
        for(int i = 1; i <=N; i++){
            var consider = Convert.ToString(i, 2);
            if(!S.Contains(consider)) return false;
        }
        
        return true;
        
    }
}