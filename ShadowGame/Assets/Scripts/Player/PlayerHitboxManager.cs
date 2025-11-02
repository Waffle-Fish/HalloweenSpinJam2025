using UnityEngine;

public class PlayerHitboxManager : MonoBehaviour
{
    [SerializeField][Range(0.0001f, 5f)] float invulnerabilityDuration = 1f;
    PlayerHealth playerHealth;
    bool tookDamageRecently = false;
    void Start()
    {
        playerHealth = GetComponentInParent<PlayerHealth>(true);
    }

    private void OnEnable()
    {
        EventService.Instance.OnDeath.AddListener(DisableOnDeath);
    }

    private void OnDisable()
    {
        EventService.Instance.OnDeath.RemoveListener(DisableOnDeath);
    }
    
    void OnTriggerStay2D(Collider2D collision)
    {
        if (tookDamageRecently) return;
        if (collision.TryGetComponent<ShadowBallBehavior>(out ShadowBallBehavior sbb))
        {
            tookDamageRecently = true;
            Invoke(nameof(SetTookDamageRecentlyToFalse), invulnerabilityDuration);
            float dmg = -sbb.DamageDelt;
            playerHealth.UpdateHealth(dmg);
        }
    }

    public void SetTookDamageRecentlyToFalse()
    {
        tookDamageRecently = false;
    }

    private void DisableOnDeath()
    {
        this.enabled = false;
    }
}
