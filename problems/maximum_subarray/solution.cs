public class Solution {
    public int MaxSubArray(int[] nums) {
        
        var currentmax = new int[nums.Length];
        
        var sum = 0;
        
        for(int i = 0; i < nums.Length; i++){
            
            sum = sum + nums[i];
            if(sum< 0) 
            {
                currentmax[i] = nums[i];
                sum = 0;
            }
            
            else currentmax[i] = sum;
            
           // Console.Write($"{currentmax[i]} ");
        }
        
        
        return currentmax.Max();
    }
}