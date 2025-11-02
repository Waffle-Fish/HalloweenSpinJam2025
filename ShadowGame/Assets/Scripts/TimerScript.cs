using System;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    float duration = 600;
    TextMeshProUGUI tmp;
    float timer = 600;

    private void Awake()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }
    
    private void Update() {
        timer -= Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds(timer);
        string stringTime = string.Format("{0:D2}:{1:D2}", (int)time.TotalMinutes, time.Seconds);   
        tmp.text = "Survive: " + stringTime;
    }
}
