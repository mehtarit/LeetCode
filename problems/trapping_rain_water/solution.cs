public class Solution {
    public int Trap(int[] height) {
        
        var result = 0;
        var st = new Stack<int>();
        
        for(int i = 0; i < height.Length; i++){
            
            while(st.Count !=0 && height[i] > height[st.Peek()]){
                var top = st.Pop();
                if(st.Count == 0) break;
                int distance = i - st.Peek() -1;
                int boundedHeight = Math.Min(height[i], height[st.Peek()]) - height[top];
                result = result+ distance*boundedHeight;
            }
            st.Push(i);
        }
        
        return result;
        
    }
}