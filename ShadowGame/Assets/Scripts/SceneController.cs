using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance { get; private set;}
    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this); 
        else Instance = this; 
    }

    public void LoadScene(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }
    
    public void LoadScene(int sceneId, float delayInSeconds)
    {
        IEnumerator DelayLoad(int sceneId, float delay)
        {
            yield return new WaitForSeconds(delay);
            LoadScene(sceneId);
        }

        StartCoroutine(DelayLoad(sceneId, delayInSeconds));
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
