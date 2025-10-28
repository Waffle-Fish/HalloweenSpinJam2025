using UnityEngine;

public class ShadowBallBehavior : PooledObject_AbstractParentClass
{
    [Tooltip(">0 hurts player\n <0 heals player")]
    [SerializeField] float damageDelt = 0;
    public float DamageDelt { get { return damageDelt; } private set { damageDelt = value; } }
}
