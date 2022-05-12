using UnityEngine;
using UnityEngine.UI;

public class SellButtonItem : MonoBehaviour
{
    public Text itemName;
    public Image itemImage;
    public Text itemPrice;

    public Item item;

    public void BuyItem()
    {
        Inventory inventory = Inventory.instance;

        if(Inventory.instance.coinsCount >= item.price)
        {
            inventory.content.Add(item);
            inventory.UpdateTextUI();

            inventory.coinsCount -= item.price;
            inventory.UpdateInventorytUI();
        }
    }
}
