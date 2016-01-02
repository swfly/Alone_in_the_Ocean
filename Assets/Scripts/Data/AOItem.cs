using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[System.Serializable]
public class AOItemEntity
{
    public string id;
    public int amount;
}
[System.Serializable]
public abstract class AOItem 
{
    public string id;
    public string name;
    public Sprite icon;


    public static AOItem GetItem(string id)
    {
        if (!itemDict.ContainsKey(id))
            return null;
        return itemDict[id].MemberwiseClone() as AOItem;
    }
    public static AOItem ViewItem(string id)
    {
        if (!itemDict.ContainsKey(id))
            return null;
        return itemDict[id];
    }
    public static Dictionary<string, AOItem> itemDict = new Dictionary<string, AOItem>();
}
