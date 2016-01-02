using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class AOUIItemIcon : MonoBehaviour 
{
    public AOItemEntity entity;
    public Text nameText;
    public Text numberText;
    public Image icon;
    public void Refresh(AOItemEntity ie, AOUIItemList l)
    {
        list = l;
        entity = ie;
        var item = AOItem.ViewItem(ie.id);
        nameText.text = item.name;
        icon.sprite = item.icon;
        numberText.text = entity.amount.ToString();
    }
    public AOUIItemList list;
    public void OnItemChosen()
    {
        list.OnItemChosen(this);
    }
}
