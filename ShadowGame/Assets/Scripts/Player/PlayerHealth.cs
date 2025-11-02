using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance { get; private set; }
    [SerializeField] float maxHealth = 100;
    [SerializeField] bool takeDamage = false;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] PlayableDirector deathPD;
    float currentHealth = 100;

    Animator modelAnimator;
    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this; 
        
        modelAnimator = transform.GetChild(0).GetComponent<Animator>();
    }
    
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
        if (currentHealth <= 0) ProcessDeath();
    }

    private void ProcessDeath()
    {
        // Time.timeScale = 0;
        EventService.Instance.OnDeath.InvokeEvent();
        if (deathSFX && AudioManager.Instance) AudioManager.Instance.PlaySFX(deathSFX);
        if (deathPD) deathPD.Play();
    }
}
