using UnityEngine;

public class ShadowBallBehavior : PooledObject_AbstractParentClass, IDamageDealer
{
    [Tooltip(">0 hurts player\n <0 heals player")]
    [SerializeField] float damageDelt = 0;
    [SerializeField] protected bool disappearAfterTouch = false;
    [SerializeField] protected AudioClip sfx;
    public float DamageDelt { get { return damageDelt; } private set { damageDelt = value; } }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (disappearAfterTouch && collision.CompareTag("Player"))
        {
            if (sfx && AudioManager.Instance) AudioManager.Instance.PlaySFX(sfx);
            gameObject.SetActive(false);
        }
    }
}
