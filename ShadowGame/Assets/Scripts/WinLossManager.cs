using System;
using UnityEngine;

public class WinLossManager : MonoBehaviour
{
    [Header("Loss Objects")]
    [SerializeField] GameObject loseScreen;

    private void OnEnable()
    {
        EventService.Instance.OnDeath.AddListener(ProcessLost);
    }

    void OnDisable()
    {
        EventService.Instance.OnDeath.RemoveListener(ProcessLost);
    }

    private void ProcessLost()
    {
        loseScreen.SetActive(true);
    }
}
