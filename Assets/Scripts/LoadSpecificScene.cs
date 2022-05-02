using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class LoadSpecificScene : MonoBehaviour
{
    public string sceneName;
    private Animator fadeSystem;
    public AudioClip loadSceneSound;

    private void Awake()
    {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            StartCoroutine(loadNextScene());
        }
    }

    public IEnumerator loadNextScene()
    {
        LoadAndSaveData.instance.SaveData();
        fadeSystem.SetTrigger("FadeIn");
        AudioManager.instance.PlayClipAt(loadSceneSound, transform.position);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }
}
