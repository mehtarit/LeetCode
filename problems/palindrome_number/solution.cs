public class Solution {
    public bool IsPalindrome(int x) {
        
        if(x < 0 ) return false;
        var input = x.ToString();
        var start = 0;
        var end = input.Length-1;
        
        while(start <= end){
            
            if(input[start] != input[end]) return false;
            start++;
            end--;
        }
        
        return true;
        
    }
}