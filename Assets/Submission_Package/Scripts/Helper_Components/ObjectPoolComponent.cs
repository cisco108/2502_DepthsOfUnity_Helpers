using UnityEngine;
using UnityEngine.Serialization;

public class ObjectPoolComponent : MonoBehaviour
{
    [SerializeField] private bool createOnStart;
    [SerializeField] private int poolSize;
    [SerializeField] private GameObject objectToPool;
    [SerializeField] private Transform spawnLocation;
    private ObjectPool pool;

    private void Start()
    {
        if (!createOnStart)
        {
            return;
        }

        InitPool();
    }

    [Button("Init Object Pool")]
    private void InitPool()
    {
        if (pool != null)
        {
            pool.ClearPool();
        }
        pool = new ObjectPool(objectToPool, poolSize);
    }

    [Button("Spawn Object")]
    private void SpawnObject()
    {
        if (pool == null)
        {
            Debug.LogError($"Object pool not initialized");
            return;
        }

        pool.GetObject(spawnLocation);
    }

    [Button("Clear Pool")]
    private void ClearPool()
    {
        if (pool == null)
        {
            Debug.LogError($"Object pool not initialized");
            return;
        }

        pool.ClearPool();
    }
}