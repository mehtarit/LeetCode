public class UndergroundSystem {
    
    Dictionary<int, Tuple<string, int>> _systemMap;
    Dictionary<string, List<int>> _timeMap;

    public UndergroundSystem() {
        
        _systemMap = new Dictionary<int, Tuple<string,int>>();
        _timeMap = new Dictionary<string, List<int>>();
        
    }
    
    public void CheckIn(int id, string stationName, int t) {
                
        _systemMap.Add(id, Tuple.Create(stationName, t));
        
    }
    
    public void CheckOut(int id, string stationName, int t) {
        
        var checkInRecord = _systemMap[id];
        
        var toAndFromStations = $"{checkInRecord.Item1}-{stationName}";
        var timeTaken = t - checkInRecord.Item2;
        
        if(!_timeMap.ContainsKey(toAndFromStations)) _timeMap.Add(toAndFromStations, new List<int>(){timeTaken});
        
        else _timeMap[toAndFromStations].Add(timeTaken);
        
        _systemMap.Remove(id);
        
    }
    
    public double GetAverageTime(string startStation, string endStation) {
        
        var _timeMapRecord = _timeMap[$"{startStation}-{endStation}"];
        
        var sum = 0;
        
        foreach (var t in _timeMapRecord){
            sum +=t;
        }
        
        return (double)sum/_timeMapRecord.Count;
        
        
    }
}

/**
 * Your UndergroundSystem object will be instantiated and called as such:
 * UndergroundSystem obj = new UndergroundSystem();
 * obj.CheckIn(id,stationName,t);
 * obj.CheckOut(id,stationName,t);
 * double param_3 = obj.GetAverageTime(startStation,endStation);
 */