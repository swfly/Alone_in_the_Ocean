using UnityEngine;
using System.Collections;

public class AOUIItemList : AutoLayoutMenu 
{
    public AOUIItemDetails detail;
    string[] keys;
    void OnEnable()
    {
        RefreshItems();
    }

    public void RefreshItems()
    {
        keys = new string[AOGame.Instance.PlayerData.Items.Count];
        AOGame.Instance.PlayerData.Items.Keys.CopyTo(keys, 0);
        GenerateButtons(AOGame.Instance.PlayerData.Items.Count);
    }

    public void OnItemChosen(AOUIItemIcon icon)
    {
        detail.ViewItem(icon.entity);
    }
    protected override void ProcessButtonEntity(int index, GameObject button)
    {

        button.GetComponent<AOUIItemIcon>().Refresh(AOGame.Instance.PlayerData.Items[keys[index]], this);
    }
}
