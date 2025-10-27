using UnityEngine;
using UnityEngine.Pool;

public abstract class PooledObject_AbstractParentClass : MonoBehaviour
{
    public IObjectPool<PooledObject_AbstractParentClass> Pool;
}