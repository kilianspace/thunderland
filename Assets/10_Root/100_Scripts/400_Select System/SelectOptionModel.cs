using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SelectableOptionModel<T>
{
    public List<List<T>> matrix = new List<List<T>>();
    private int currentRow = 0;
    private int currentCol = 0;
    private SignalPool signalPool;

    public SelectableOptionModel(SignalPool pool)
    {
        signalPool = pool;
    }

}
