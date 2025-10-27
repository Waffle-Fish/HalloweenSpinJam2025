using UnityEngine;

public class ShadowBallBehavior : PooledObject_AbstractParentClass
{
    [SerializeField] float damageDelt = 0;
    public float DamageDelt { get { return damageDelt; } private set { damageDelt = value; } }
}
