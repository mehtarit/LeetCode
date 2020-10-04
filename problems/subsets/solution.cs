public class Solution {
    public IList<IList<int>> Subsets(int[] nums) {
        
        var subSets = new List<IList<int>>();
        generateSubSets(nums, subSets, new List<int>(), 0);
        return subSets;
        
    }
    
    public void generateSubSets(int[] nums, List<IList<int>> subSets, List<int> current, int index){
        subSets.Add(new List<int>(current));
        for(int i=index; i< nums.Length; i++){
            current.Add(nums[i]);
            generateSubSets(nums, subSets, current, i+1);
            current.RemoveAt(current.Count-1);           
        }
    }
}