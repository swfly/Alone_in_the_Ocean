using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AOUIItemDetails : MonoBehaviour
{
    public GameObject useButton;
    public Image icon;
    public Text nameText;
    AOItemEntity currentItem;
    public void ViewItem(AOItemEntity e)
    {
        if (e == null)
        {
            icon.color = new Color(0, 0, 0, 0);
            icon.sprite = null;
            nameText.text = "";
            useButton.SetActive(false);
            return;
        }

        icon.color = Color.white;
        var i = AOItem.ViewItem(e.id);
        currentItem = e;
        icon.sprite = i.icon;
        nameText.text = i.name;

        useButton.SetActive(i is AOPropertyDeltaItem);
    }

    public void UseItem()
    {
        var i = AOItem.ViewItem(currentItem.id);
        if (i is AOPropertyDeltaItem)
        {
            (i as AOPropertyDeltaItem).Use(AOGame.Instance.PlayerData);
            currentItem.amount--;
            if (currentItem.amount < 1)
            {
                AOGame.Instance.PlayerData.Items.Remove(currentItem.id);
                ViewItem(null);
            }
            GetComponentInParent<AOUIItemList>().RefreshItems();
        }
    }
}
