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
        // Debug.Log("I got touched by: " + collision.name + " with tag: " + collision.tag);
        if(collision.CompareTag("Hazard"))
        {
            playerHealth.UpdateHealth(-34f);
        }
    }
}
