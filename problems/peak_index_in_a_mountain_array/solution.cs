public class Solution {
    public int PeakIndexInMountainArray(int[] arr) {       
        return Array.IndexOf(arr,arr.Max());
    }
}