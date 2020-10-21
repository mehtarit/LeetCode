public class MedianFinder {

    List<int> _set;
    /** initialize your data structure here. */
    public MedianFinder() {
        _set = new List<int>();
    }
    
    public void AddNum(int num) {
        if(_set.Count == 0) _set.Add(num);
        else {
            bool added = false;
            for(int i = 0; i <_set.Count; i++){
                if(_set[i] >= num){
                    _set.Insert(i, num);
                    added = true;
                    break;
                }
            }
            if(!added)_set.Add(num);
        }
    }
    
    public double FindMedian() {
        if(_set.Count % 2 != 0) return (double)_set[_set.Count/2];
        var mid = _set.Count/2;
        Console.WriteLine($"Median of {_set[mid]} and {_set[mid-1]}");
        return (double)(_set[mid] + _set[mid-1])/2;
    }
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */