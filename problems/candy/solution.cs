public class Solution {
    public int Candy(int[] ratings) {
        
        var result1 = new int[ratings.Length];
        var result2 = new int[ratings.Length];
        
        for(int i = 0; i < ratings.Length; i++){
            result1[i] = 1;
            result2[i] = 1;
        }
        
        for(int i = 1; i < ratings.Length; i++){
            var prev = ratings[i-1];
            var current = ratings[i];
            
            if(current > prev) result1[i] = result1[i-1]+1;            
        }
        
        for(int i = ratings.Length-1; i>=1; i--){
            var next = ratings[i-1];
            var current = ratings[i];
            if(next > current) result2[i-1] = result2[i] + 1;           
        }
        
        var sum = 0;
        for(int i = 0; i < ratings.Length; i++){
            sum = sum + Math.Max(result1[i], result2[i]);
        }
        
        return sum;
    }
}