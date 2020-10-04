public class MinHeap {
    
   private List<string> items = new List<string>();
    
    private int GetLeftChildIndex(int parentIndex){
        return parentIndex*2+1;
    }
    private int GetRightChildIndex(int parentIndex){
        return parentIndex*2+2;
    }
    private int GetParentIndex(int index){
        return (index-1)/2;
    }
    
    private bool HasLeftChild(int index){
        return GetLeftChildIndex(index) < items.Count;
    }
    private bool HasRightChild(int index){
        return GetRightChildIndex(index) < items.Count;
    }
    private bool HasParent(int index){
        return GetParentIndex(index) >=0;
    }
    
    private string LeftChild(int index){
        return items[GetLeftChildIndex(index)];
    }
    private string RightChild(int index){
        return items[GetRightChildIndex(index)];
    }
    private string Parent(int index){
        return items[GetParentIndex(index)];
    }
    
    private void swap(int indexOne, int indexTwo){
        var temp = items[indexOne];
        items[indexOne] = items[indexTwo];
        items[indexTwo] = temp;
    }
    
    public int Size(){
        return items.Count;
    }
    
    public string Peek(){
        if(items.Count == 0) throw new System.InvalidOperationException();
        return items[0];
    }
    
    public string Poll(){
        if(items.Count == 0) throw new InvalidOperationException();
        var item = items[0];
        items[0] = items[items.Count-1];
        items.RemoveAt(items.Count-1);
        HeapifyDown();
        return item;        
    }
    
    public void Add(string element){
        items.Add(element);
        HeapifyUp();
    }
    
    public void HeapifyUp(){
        var index = items.Count-1;
        while(HasParent(index) && string.Compare(Parent(index), items[index]) == 1){
            swap(GetParentIndex(index), index);
            index = GetParentIndex(index);
        }
        
    }
    public void HeapifyDown(){
        var index = 0;
        while(HasLeftChild(index)){
            var smallerChildIndex = GetLeftChildIndex(index);
            if(HasRightChild(index) && string.Compare(RightChild(index),LeftChild(index)) == -1){
                smallerChildIndex = GetRightChildIndex(index);
            }
            
            if(string.Compare(items[index],items[smallerChildIndex]) == -1)break;
            swap(index, smallerChildIndex);
            index = smallerChildIndex;
        }
    }
    
}

public class Solution {
    public IList<string> FindItinerary(IList<IList<string>> tickets) {
        
        var itineraryMap = new Dictionary<string, MinHeap>();
        foreach(var pair in tickets)
        {           
            var key = pair[0];
            var value = pair[1];
            Console.WriteLine("key is: " + key);
                        
            if(itineraryMap.ContainsKey(key))itineraryMap[key].Add(value);
            else {
                var sortedList = new MinHeap();
                sortedList.Add(value);
                itineraryMap.Add(key, sortedList);
            }
        }
        
        var route = new List<string>();
        var backTracker = new Stack<string>();
        
        var start = "JFK";
        var current = start;
        backTracker.Push(current);
        
        while(route.Count != tickets.Count){
            if(itineraryMap.ContainsKey(current)){
                var next = itineraryMap[current].Peek();
                backTracker.Push(next);
                itineraryMap[current].Poll();
                if(itineraryMap[current].Size() == 0) itineraryMap.Remove(current);
                current = next;
            }
            else {
                
                backTracker.Pop();
                route.Add(current);
                current = backTracker.Peek();
            }
            
        }
        
        route.Add(start);
        route.Reverse();
        return route;
    }
}