using UnityEngine;
using UnityEngine.Playables;

public class StartBattle : MonoBehaviour
{
    [SerializeField] PlayableDirector pd;

    void OnTriggerEnter(Collider other)
    {
        pd.Play();
    }
}
