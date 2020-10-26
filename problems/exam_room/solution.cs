public class ExamRoom {
    int N;
    SortedSet<int> students;

    public ExamRoom(int N) {
        this.N = N;
        students = new SortedSet<int>();
    }
    
    public int Seat() {
        
        int student = 0;
        if(students.Count() > 0){
            
            int dist = students.First();
            int prev = -1;
            
            foreach(var s in students){
                if(prev == -1) prev = s;
                else {
                    int d = (s-prev)/2;
                    if(d > dist) {
                        dist = d;
                        student = prev +d;
                    }
                    prev = s;
                }
            }
            
            if(N-1-students.Last() > dist)
                student = N-1;
            
        }
        
        students.Add(student);
        return student;
        
    }
    
    public void Leave(int p) {
        
        students.Remove(p);
        
    }
}

/**
 * Your ExamRoom object will be instantiated and called as such:
 * ExamRoom obj = new ExamRoom(N);
 * int param_1 = obj.Seat();
 * obj.Leave(p);
 */