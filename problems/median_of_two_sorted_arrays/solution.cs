public class Solution {
    
    public double FindMedian(int[] arr){
        Array.Sort(arr);
        var mid = arr.Length/2;
        if(arr.Length % 2 != 0) return (double)arr[(mid)];
        else return (double)((double)arr[mid] + (double)arr[mid-1])/2;
    }
    
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        
        if(nums1.Length == 0) return FindMedian(nums2);
        if(nums2.Length == 0) return FindMedian(nums1);
        
        else return FindMedian(nums1.Concat(nums2).ToArray());
        
    }
}