using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float maxHealth = 100;
    [SerializeField] bool takeDamage = false;
    float currentHealth = 100;
    void Start()
    {
        currentHealth = maxHealth;
    }

    // >0 : Heals player | <0 : Hurts player
    public void UpdateHealth(float value)
    {
        currentHealth += value;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
            return;
        }
        float healthPercent = currentHealth / maxHealth;
        EventService.Instance.OnHealthUpdated.InvokeEvent(healthPercent);
        if (currentHealth <= 0)
        {
            EventService.Instance.OnDeath.InvokeEvent();
        }
    }
}
