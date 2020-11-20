public class Solution {
    
    public int BinarySearch(int[] nums, int target, int start, int end){       
        if(start > end) return -1;      
        int mid = (start + end)/2;
        if(nums[mid] < target) return BinarySearch(nums, target, mid+1, end);
        if(nums[mid] > target)return BinarySearch(nums, target, start, mid -1);
        else return mid;
    }
    
    public int[] SearchRange(int[] nums, int target) {
        
        if(nums.Length == 0) return new int[2]{-1, -1};
        
        var start = BinarySearch(nums, target, 0, nums.Length-1);
        for(int i = start; i >=0; i--){
            if(nums[i] == target) start = i;
        }
        if(start < 0 || nums[start] != target) return new int[2]{-1, -1};
        
        var end = start;
        for(int i = start; i < nums.Length; i++){
            if(nums[i] == target) end = i;
        }
        
        return new int[2]{start, end};
    }
}