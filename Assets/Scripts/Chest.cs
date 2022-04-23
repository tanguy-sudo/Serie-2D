using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    private Text interactUi;
    private bool isInRange;

    public Animator animator;
    public int coinsToAdd;
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
            OpenChest();
        }
    }

    private void OpenChest()
    {
        animator.SetTrigger("OpenChest");
        Inventory.instance.AddCoins(coinsToAdd);
        AudioManager.instance.PlayClipAt(soundToPlay, transform.position);
        GetComponent<BoxCollider2D>().enabled = false;
        interactUi.enabled = false;
        isInRange = false;
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
