using UnityEngine;
using UnityEngine.UI;

public class ShopTrigger : MonoBehaviour
{
    private bool isInRange;
    private Text interactUI;
    public Item[] itemsToSell;
    public string pnjName;


    private void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    void Update()
    {
        if (isInRange && Input.GetKey(KeyCode.E))
        {
            ShopManager.instance.OpenShop(itemsToSell, pnjName);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            interactUI.enabled = false;
            ShopManager.instance.CloseShop();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
            interactUI.enabled = true;
        }
    }
}
