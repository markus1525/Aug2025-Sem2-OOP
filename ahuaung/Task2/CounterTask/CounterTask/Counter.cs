using System;

namespace CounterTask;

public class Counter
{
    //Add private fields
    private int _count;
    private string _name;

    //Create constructor to initialize
    public Counter(string name)
    {
        _name = name;
        _count = 0;
    }

    //Add Increment method
    public void Increment()
    {
        _count++;
    }

    //Add Reset method
    public void Reset()
    {
        _count = 0;
    }

    //Add Name property (read-write)
    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }
    }

    //Add Ticks property (read-only)
    public int Ticks
    {
        get { return _count; }
    }

    //Q12:Add ResetByDefault method
    //Use unchecked block because value is too big for int
    //unchecked prevents overflow exception
    //The large value wraps around to a negative number due to overflow
    public void ResetByDefault()
    {
        unchecked
        {
            _count = (int)214748364881; //Given value with my student ID last 4 digits //4881
        }
    }

    //Q13: Method to increase count by 5
    public void IncrementByFive()
    {
        _count += 5;

    //Q13 Answer: YES, the code still runs without bugs/crash
    //Reason: Adding 5 is a simple arithmetic operation that won't cause problems even with overflow values
    }
}
