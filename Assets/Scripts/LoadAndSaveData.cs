using UnityEngine;

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
        Inventory.instance.UpdateTextUI();

        /*
         * int currentHealth = PlayerPrefs.GetInt("currentHealth", PlayerHealth.instance.maxHealth);
         * PlayerHealth.instance.currentHealth = currentHealth;
         * PlayerHealth.instance.healthBar.SetHealth(currentHealth);
         * 
        */
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("coinsCount", Inventory.instance.coinsCount);

        if(CurrentSceneManager.instance.levelToUnlock > PlayerPrefs.GetInt("levelReached", 1))
        {
            PlayerPrefs.SetInt("levelReached", CurrentSceneManager.instance.levelToUnlock);
        }
         
        // PlayerPrefs.SetInt("currentHealth", PlayerHealth.instance.currentHealth);
    }
}
