public class MyCalendar {
    
    List<Tuple<int,int>> _calendar;

    public MyCalendar() {
        
        _calendar = new List<Tuple<int, int>>();
        
    }
    
    public bool Book(int start, int end) {
        
        foreach(var interval in _calendar){
            if(end <= interval.Item1) continue;
            if(start >= interval.Item2) continue;
            return false;
        }
        
        _calendar.Add(Tuple.Create(start, end));
        
        return true;  
    }
}

/**
 * Your MyCalendar object will be instantiated and called as such:
 * MyCalendar obj = new MyCalendar();
 * bool param_1 = obj.Book(start,end);
 */