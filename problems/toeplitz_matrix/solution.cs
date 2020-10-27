public class Solution {
    public bool IsToeplitzMatrix(int[][] matrix) {
        
        for(int i = matrix.Length-1; i >=0; i--){
            for(int j = 0; j < matrix[i].Length; j++){
                
                if(i==0 || j==(matrix[i].Length-1)) continue;
                var up = matrix[i-1][j];
                var right = matrix[i][j+1];
                if(up == right) continue;
                return false;
            }
        
        }
        
        return true;
        
    }
}