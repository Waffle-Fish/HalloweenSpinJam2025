using UnityEngine;

public class ShadowBallBehavior : PooledObject_AbstractParentClass, IDamageDealer
{
    [Tooltip(">0 hurts player\n <0 heals player")]
    [SerializeField] float damageDelt = 0;
    [SerializeField] bool disappearAfterTouch = false;
    public float DamageDelt { get { return damageDelt; } private set { damageDelt = value; } }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (disappearAfterTouch && collision.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}
