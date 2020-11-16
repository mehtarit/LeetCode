public class Logger {

    /** Initialize your data structure here. */
    Dictionary<string, int> _messageMap;
    public Logger() {    
        _messageMap = new Dictionary<string, int>();
    }
    
    /** Returns true if the message should be printed in the given timestamp, otherwise returns false.
        If this method returns false, the message will not be printed.
        The timestamp is in seconds granularity. */
    public bool ShouldPrintMessage(int timestamp, string message) {
        
        if(_messageMap.Count == 0 || !_messageMap.ContainsKey(message)){
            _messageMap.Add(message, timestamp);
            return true;
        }
        
        var previous = _messageMap[message];
        if(timestamp - previous >=10) {
            _messageMap[message] = timestamp;
            return true;
        }
        
        return false;
        
    }
}

/**
 * Your Logger object will be instantiated and called as such:
 * Logger obj = new Logger();
 * bool param_1 = obj.ShouldPrintMessage(timestamp,message);
 */