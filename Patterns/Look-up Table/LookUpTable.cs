using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LookUpTable<T1, T2>
{
    public delegate T2 Ecuacion(T1 keyToReturn);
    Dictionary<T1, T2> _table;
    Ecuacion _factoryMethod;

    public LookUpTable(Ecuacion newFactory)
    {
        _factoryMethod = newFactory;
        _table = new Dictionary<T1, T2>();
    }

    public T2 ReturnValue(T1 myKey)
    {
        if (_table.ContainsKey(myKey))
        {
            Debug.Log("I grab the value of " + myKey.ToString());
            return _table[myKey];
        }
        else
        {
            Debug.Log("I create the value for " + myKey.ToString());
            var value = _factoryMethod(myKey);
            _table[myKey] = value;
            return value;
        }
    }
}
