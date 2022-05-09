using UnityEngine;

public class PickUpCoin : MonoBehaviour
{
    public AudioClip sound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //AudioSource.PlayClipAtPoint(sound, transform.position);
            AudioManager.instance.PlayClipAt(sound, transform.position);
            Inventory.instance.AddCoins(1);
            CurrentSceneManager.instance.coinsPicketUpInThisSceneCount++;
            Destroy(gameObject);
        }
    }
}
