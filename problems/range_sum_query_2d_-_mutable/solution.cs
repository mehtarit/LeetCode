public class NumMatrix {
    
    int [][] _matrix;

    public NumMatrix(int[][] matrix) {
        
        _matrix = matrix;
        
    }
    
    public void Update(int row, int col, int val) {
        
        _matrix[row][col] = val;
        
    }
    
    public int SumRegion(int row1, int col1, int row2, int col2) {
        
        var sum = 0;
        for(int i = row1; i <= row2; i++){
            for(int j = col1; j <= col2; j++)
            {
                sum = sum + _matrix[i][j];
            }
        }
        
        return sum;
    }
}

/**
 * Your NumMatrix object will be instantiated and called as such:
 * NumMatrix obj = new NumMatrix(matrix);
 * obj.Update(row,col,val);
 * int param_2 = obj.SumRegion(row1,col1,row2,col2);
 */