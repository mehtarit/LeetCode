public class Solution {
    
    public List<IList<int>> TwoSum(int[] nums, int target, int start){
        
        var result = new List<IList<int>>();
        
        var end = nums.Length-1;
        
        while(start <= end){
            
            if(start >= end) break;
            
            var sum = nums[start] + nums[end];

            if(sum == target) {
                var current = new List<int>();
                current.Add(nums[start]);
                current.Add(nums[end]);
                result.Add(current);
                start++;
                end--;
                if(start >= end) break;
            }
            else if(sum < target) start++;
            else end--;
        }
        
        
        return result;
        
    }
    
    public IList<IList<int>> ThreeSum(int[] nums) {
        
        var result = new List<IList<int>>();
        if(nums.Length < 3) return result;
        Array.Sort(nums);
        
        for(int i = 0; i < nums.Length; i++){
            
            var currentTarget = nums[i];
            
            if(i !=0 && currentTarget == nums[i-1]) 
                continue;
            
            var pairs = TwoSum(nums, currentTarget*(-1), i+1);
            if(pairs.Count == 0) continue;
            
            var index = 0;
            while(index < pairs.Count){
                
                var triplet = new List<int>();
                triplet.Add(currentTarget);
                triplet.Add(pairs[index][0]);
                triplet.Add(pairs[index][1]);
                
                if(result.Count != 0){
                    var previousTriplet = result[result.Count-1];
                    if(previousTriplet[0] == triplet[0] && previousTriplet[1] == triplet[1] && previousTriplet[2] == triplet[2]) {index++;
                    continue;
                    }
                }
                
                result.Add(triplet);                
                index++;
            }
            
            
        }
        
        return result;
        
    }
}