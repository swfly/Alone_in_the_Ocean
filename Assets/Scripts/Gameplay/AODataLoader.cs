using UnityEngine;
using System.Collections;

public class AODataLoader : MonoBehaviour 
{
    public AOItemData items;
    void Awake()
    {
        foreach (var i in items.propertyItems)
        {
            AOItem.itemDict[i.id] = i;
        }
    }
}
