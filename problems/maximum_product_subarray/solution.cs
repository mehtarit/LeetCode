public class Solution {
    public int MaxProduct(int[] nums) {
        
        int max = Int32.MinValue;
        
        int product = 1;
        
        foreach(var num in nums){
            product = product*num;
            max = Math.Max(product, max);
            if(product == 0) product = 1;
        }
        
        product = 1;
        for(int i =nums.Length-1; i >=0; i--){
            product = product*nums[i];
            max = Math.Max(product, max);
            if(product == 0) product = 1;
        }
        
        return max;
        
    }
}