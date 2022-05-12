using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;
    public Animator animator;
    public Text pnjNameText;
    public GameObject sellButtonPrefab;
    public Transform sellButtonsParent;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Il y a plus d'une instance de ShopManager dans la scène");
            return;
        }
        instance = this;
    }

    public void OpenShop(Item[] items, string pnjName)
    {
        pnjNameText.text = pnjName;
        UpdateItemsToSell(items);
        animator.SetBool("isOpen", true);
    }

    private void UpdateItemsToSell(Item[] items)
    {
        // Supprime les potentiels boutons présent dans le parent
        for (int i = 0; i < sellButtonsParent.childCount; i++)
        {
            Destroy(sellButtonsParent.GetChild(i).gameObject);
        }

        // Instancie un bouton pour chaque item à vendre et le configure
        for (int i = 0; i < items.Length; i++)
        { 
            GameObject button = Instantiate(sellButtonPrefab, sellButtonsParent);
            SellButtonItem buttonScript = button.GetComponent<SellButtonItem>();
            buttonScript.itemName.text = items[i].name;
            buttonScript.itemImage.sprite = items[i].image;
            buttonScript.itemPrice.text = items[i].price.ToString();

            buttonScript.item = items[i];

            button.GetComponent<Button>().onClick.AddListener(delegate {
                buttonScript.BuyItem();
            });
        }
    }

    public void CloseShop()
    {
        animator.SetBool("isOpen", false);
    }
}
