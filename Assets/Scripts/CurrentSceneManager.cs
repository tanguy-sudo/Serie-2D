using UnityEngine;

public class CurrentSceneManager : MonoBehaviour
{
    public int coinsPicketUpInThisSceneCount;
    public Vector3 respawnpoint;

    public static CurrentSceneManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Il y a plus d'une instance de CurrentSceneManager dans la scène");
            return;
        }

        instance = this;

        respawnpoint = GameObject.FindGameObjectWithTag("Player").transform.position;
    }
}
