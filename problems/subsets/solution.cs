public class Solution {
    public IList<IList<int>> Subsets(int[] nums) {
        
        List<int> numsList = new List<int>(nums);
        var result = new List<IList<int>>();
        generateSubsets(numsList, result, 0 , new List<int>());
        return result;
        
    }
    
    public void generateSubsets(List<int> numsList, List<IList<int>> subSets,  int index, List<int> currentSubSet)
    {
        subSets.Add(new List<int>(currentSubSet));
        for(int i = index; i < numsList.Count; i++){
            currentSubSet.Add(numsList[i]);
            generateSubsets(numsList, subSets, i+1, currentSubSet);
            currentSubSet.Remove(currentSubSet[currentSubSet.Count - 1]);
        }
    }
}