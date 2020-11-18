public class Solution {
    public int MaxProfit(int[] prices) {
        
        var max = 0;
        
        for(int i = 0; i < prices.Length-1; i++){
            for(int j = i+1; j < prices.Length; j++){
                var diff = prices[j] - prices[i];
                if(diff > max) max = diff;
            }
        }
        
        return max;
        
    }
}