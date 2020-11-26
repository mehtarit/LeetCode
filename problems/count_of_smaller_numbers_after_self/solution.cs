public class Solution {
    
    List<int> sorted = new List<int>();
    
    public int InsertInSorted(int num){
        
        if(sorted.Count == 0) {
            sorted.Add(num);
            return 0;
        }
             
        for(int i = 0; i < sorted.Count; i++){
            var current = sorted[i];
            if(current >= num) {
                sorted.Insert(i, num);
                return i;
            }
        }
        
        sorted.Add(num);
        return sorted.Count-1;
    }
    
    public IList<int> CountSmaller(int[] nums) {
        
        var result = new int[nums.Length];
        
        sorted = new List<int>();
        
        for(int i = nums.Length-1; i>=0; i--)
        {
            var position = InsertInSorted(nums[i]);
            result[i] = position;
        }
        
        return result;
        
    }
}