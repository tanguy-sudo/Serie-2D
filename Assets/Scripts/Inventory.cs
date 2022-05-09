using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class Inventory : MonoBehaviour
{
    public PlayerEffects playerEffects;
    public int coinsCount;
    public Text coinsCountText;
    public List<Item> content = new List<Item>();
    private int contentCurrentIndex;
    public Image itemImageUI;
    public Sprite emptyItemImage;
    public Text itemNameUI;

    public static Inventory instance;

    private void Start()
    {
        contentCurrentIndex = 0;
        UpdateTextUI();
    }

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Il y a plus d'une instance de Inventory dans la scène");
            return;
        }

        instance = this;
    }

    public void ConsumeItem()
    {
        if (content.Count == 0)
        {
            return;
        }
           
        Item currentItem = content[contentCurrentIndex];
        PlayerHealth.instance.HealPlayer(currentItem.hpGiven);
        playerEffects.AddSpeed(currentItem.speedGiven, currentItem.speedDuration);
        content.Remove(currentItem);
        GetNextItem();
        UpdateTextUI();
        
    }

    public void GetNextItem()
    {
        if (content.Count == 0)
        {
            return;
        }

        contentCurrentIndex++;
        if (contentCurrentIndex > content.Count - 1)
        {
            contentCurrentIndex = 0;
        }
        UpdateTextUI();
    }

    public void GetPreviousItem()
    {
        if (content.Count == 0)
        {
            return;
        }

        contentCurrentIndex--;
        if (contentCurrentIndex < 0)
        {
            contentCurrentIndex = content.Count - 1;
        }
        UpdateTextUI();
    }

    public void UpdateTextUI()
    {
        if(content.Count > 0)
        {
            itemImageUI.sprite = content[contentCurrentIndex].image;
            itemNameUI.text = content[contentCurrentIndex].name;
        } else
        {
            itemImageUI.sprite = emptyItemImage;
            itemNameUI.text = "";
        }
    }

    public void AddCoins(int count)
    {
        coinsCount += count;
        UpdateInventorytUI();
    }

    public void removeCoins(int count)
    {
        coinsCount -= count;
        UpdateInventorytUI();
    }

    public void UpdateInventorytUI()
    {
        coinsCountText.text = coinsCount.ToString();
    }

}
