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
            Debug.LogError("Il y a plus d'une instance de GameOverManager dans la sc�ne");
            return;
        }

        instance = this;
    }
    public void OnPlayerDeath()
    {
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
        SceneManager.LoadScene("MainMenu");
    }
    public void QuidButton()
    {
        // Fermer le jeu
        Application.Quit();
    }
}
