using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUi;
    public static GameOverManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de GameOverManager dans la sc�ne");
            return;
        }

        instance = this;
    }
    public void OnPlayerDeath()
    {
        if (CurrentSceneManager.instance.isPlayerPresentByDefault)
        {
            DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
        }
        gameOverUi.SetActive(true);
    }

    public void RetryButton()
    {
        // Recharge la sc�ne
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Inventory.instance.removeCoins(CurrentSceneManager.instance.coinsPicketUpInThisSceneCount);
        PlayerHealth.instance.Respawn();
        gameOverUi.SetActive(false);
    }
    public void MainMenuButton()
    {
        // Retour au menu principale
        DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
        SceneManager.LoadScene("MainMenu");
    }
    public void QuidButton()
    {
        // Fermer le jeu
        Application.Quit();
    }
}
