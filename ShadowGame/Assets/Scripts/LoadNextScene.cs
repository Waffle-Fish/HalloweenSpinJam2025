using UnityEngine;
using UnityEngine.Playables;

public class LoadNextScene : MonoBehaviour
{
    [SerializeField] int sceneIdToLoad = 0;
    PlayableDirector pd;

    private void Awake()
    {
        pd = GetComponent<PlayableDirector>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        float delay = 0;
        if (pd != null && pd.playableAsset != null)
        {
            pd.Play();
            delay = (float)pd.playableAsset.duration;
        }
        SceneController.Instance.LoadScene(sceneIdToLoad, delay);
    }
}
