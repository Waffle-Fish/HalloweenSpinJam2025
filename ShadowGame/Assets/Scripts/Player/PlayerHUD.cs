using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] Slider healthSlider;
    
    private void OnEnable()
    {
        EventService.Instance.OnHealthUpdated.AddListener(UpdateHealth);
    }

    private void OnDisable()
    {
        EventService.Instance.OnHealthUpdated.RemoveListener(UpdateHealth);
    }
    
    void UpdateHealth(float healthPercent)
    {
        if (healthSlider) healthSlider.value = healthPercent;
    }
}
