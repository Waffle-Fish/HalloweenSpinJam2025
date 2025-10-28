using UnityEngine;

public class PlayerHitboxManager : MonoBehaviour
{
    PlayerHealth playerHealth;
    void Start()
    {
        playerHealth = GetComponentInParent<PlayerHealth>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<ShadowBallBehavior>(out ShadowBallBehavior sbb))
        {   
            float dmg = -sbb.DamageDelt;
            playerHealth.UpdateHealth(dmg);
        }
    }
}
