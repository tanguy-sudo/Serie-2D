using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    private Text interactUi;
    private bool isInRange;

    public Item item;
    public AudioClip soundToPlay;

    void Awake()
    {
        isInRange = false;
        interactUi = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && isInRange)
        {
            TakeItem();
        }
    }

    private void TakeItem()
    {
       Inventory.instance.content.Add(item);
       Inventory.instance.UpdateTextUI(); 
       AudioManager.instance.PlayClipAt(soundToPlay, transform.position);
       interactUi.enabled = false;
       Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUi.enabled = true;
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUi.enabled = false;
            isInRange = false;
        }
    }
}