using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool : MonoBehaviour
{
    public IObjectPool<PooledObject_AbstractParentClass> ObjPool { get; private set; }
    [SerializeField] private PooledObject_AbstractParentClass objectPrefab;
    [SerializeField] private bool collectionCheck = false;
    [SerializeField] private int defaultCapacity = 20;
    [SerializeField] private int maxSize = 100;

    private void Awake()
    {
        ObjPool = new ObjectPool<PooledObject_AbstractParentClass>(CreateProjectile, OnGetFromPool, OnReleaseToPool, OnDestroyPooledObject, collectionCheck, defaultCapacity, maxSize);
    }

    private PooledObject_AbstractParentClass CreateProjectile()
    {
        PooledObject_AbstractParentClass objInstance = Instantiate(objectPrefab);
        objInstance.Pool = ObjPool;
        return objInstance;
    }

    private void OnGetFromPool(PooledObject_AbstractParentClass pooledObject)
    {
        pooledObject.gameObject.SetActive(true);
    }

    private void OnReleaseToPool(PooledObject_AbstractParentClass pooledObject)
    {
        pooledObject.gameObject.SetActive(false);
    }

    private void OnDestroyPooledObject(PooledObject_AbstractParentClass pooledObject)
    {
        if (pooledObject) Destroy(pooledObject.gameObject);
    }
}