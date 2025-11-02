using UnityEngine;

public class SwitchMusicTrack : MonoBehaviour
{
    [SerializeField] AudioClip sceneTrack;
    void Start()
    {
        if (!sceneTrack) Debug.LogError("NO MUSIC IN THIS SCENE!");
        if (!AudioManager.Instance) Debug.LogError("No Audiomanager");
        if (sceneTrack && AudioManager.Instance) AudioManager.Instance.PlayMusic(sceneTrack);
    }
}
