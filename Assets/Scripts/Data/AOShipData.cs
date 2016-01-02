using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AOShipData
{
    public AOShipData()
    {
        Items = new Dictionary<string, AOItemEntity>();
    }
    public float Population
    {
        get;
        set;
    }
    public float Food
    {
        get;
        set;
    }
    public float Water
    {
        get;
        set;
    }
    public float Energy
    {
        get;
        set;
    }
    public float Panic
    {
        get;
        set;
    }
    public Dictionary<string, AOItemEntity> Items
    {
        get;
        set;
    }
    public void GetItem(AOItemEntity e)
    {
        if (Items.ContainsKey(e.id))
        {
            Items[e.id].amount += e.amount;
        }
        else
        {
            Items[e.id] = e;
        }
    }
}