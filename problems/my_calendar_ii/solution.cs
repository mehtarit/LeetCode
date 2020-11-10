public class MyCalendarTwo {
    
   List<Tuple<int,int>> calendar;
   List<Tuple<int,int>> overlaps;

    public MyCalendarTwo() {
        
        calendar = new List<Tuple<int,int>>();
        overlaps = new List<Tuple<int, int>>();
    }
    
    public bool Book(int start, int end) {
        
        foreach(var interval in overlaps){
            if(interval.Item1 < end && start < interval.Item2) return false;
        }
        
        foreach(var interval in calendar){
            if(interval.Item1 < end && start < interval.Item2)
                overlaps.Add(Tuple.Create(Math.Max(start, interval.Item1), Math.Min(end, interval.Item2)));
        }
        calendar.Add(Tuple.Create(start, end));
        return true;
        
    }
}

/**
 * Your MyCalendarTwo object will be instantiated and called as such:
 * MyCalendarTwo obj = new MyCalendarTwo();
 * bool param_1 = obj.Book(start,end);
 */