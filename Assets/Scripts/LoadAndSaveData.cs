using UnityEngine;
using System.Linq;

public class LoadAndSaveData : MonoBehaviour
{
    public static LoadAndSaveData instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Il y a plus d'une instance de LoadAndSaveData dans la scène");
            return;
        }

        instance = this;
    }

    void Start()
    {
        Inventory.instance.coinsCount = PlayerPrefs.GetInt("coinsCount", 0);
        Inventory.instance.UpdateInventorytUI();

        /*
         * int currentHealth = PlayerPrefs.GetInt("currentHealth", PlayerHealth.instance.maxHealth);
         * PlayerHealth.instance.currentHealth = currentHealth;
         * PlayerHealth.instance.healthBar.SetHealth(currentHealth);
        */

        // Chargement des items
        string[] itemsSaved = PlayerPrefs.GetString("inventoryItems", "").Split(',');

        for (int i = 0; i < itemsSaved.Length; i++)
        {
            if(itemsSaved[i] != "")
            {
                // Ajoute l'item à l'inventaire
                int id = int.Parse(itemsSaved[i]);
                Item currentItem = ItemsDatabase.instance.allItems.Single(item => item.id == id);
                Inventory.instance.content.Add(currentItem);
            }
        }

        Inventory.instance.UpdateTextUI();
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("coinsCount", Inventory.instance.coinsCount);

        if(CurrentSceneManager.instance.levelToUnlock > PlayerPrefs.GetInt("levelReached", 1))
        {
            PlayerPrefs.SetInt("levelReached", CurrentSceneManager.instance.levelToUnlock);
        }

        // PlayerPrefs.SetInt("currentHealth", PlayerHealth.instance.currentHealth);

        // Sauvegarde des items
        string itemsInInventory = string.Join(",", Inventory.instance.content.Select(item => item.id));
        PlayerPrefs.SetString("inventoryItems", itemsInInventory);

    }
}
