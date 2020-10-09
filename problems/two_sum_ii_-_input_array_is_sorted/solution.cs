public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        
        var result = new int[2];
        
        int start = 0;
        int end = nums.Length-1;
        
        while(start <=end){
            
            var sum = nums[start] + nums[end];
            if(sum == target) break;
            else if (sum > target) end=end-1;
            else start = start+1;
            
            //Console.WriteLine("target: " + target + " sum: " + sum + " start: "+ start + " end: " + end);
            
        }
        
        result[0] = start+1;
        result[1] = end+1;
        
        return result;
        
    }
}