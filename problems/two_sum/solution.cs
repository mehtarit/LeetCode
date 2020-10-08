public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        
        var pairs = new Dictionary<int, int>();
        
        for(int i=0; i < nums.Length; i++){
            
            if(pairs.ContainsKey(nums[i])){
                var result = new int[2];
                result[0] = pairs[nums[i]];
                result[1] = i;
                return result;
            }
            if(pairs.ContainsKey(target-nums[i])) continue;
            pairs.Add(target-nums[i], i);
        }
        
        return new int[2];
        
    }
}