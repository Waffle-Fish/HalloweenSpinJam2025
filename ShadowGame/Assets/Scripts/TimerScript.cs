using System;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class TimerScript : MonoBehaviour
{
    [SerializeField] PlayableAsset gameTimeline;
    float duration = 600;
    TextMeshProUGUI tmp;
    float timer = 600;

    private void Awake()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        duration = (float)gameTimeline.duration;
        timer = duration;
    }
    
    private void Update() {
        timer -= Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds(timer);
        string stringTime = string.Format("{0:D2}:{1:D2}", (int)time.TotalMinutes, time.Seconds);   
        tmp.text = "Survive: " + stringTime;
    }
}
