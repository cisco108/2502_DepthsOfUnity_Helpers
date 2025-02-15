using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool
{
    private List<GameObject> _pooledObjects;
    private int _poolsize;
    private GameObject _prefab;
    private bool _isPoolEmpty = true;

    public ObjectPool(GameObject prefab, int poolsize)
    {
        _prefab = prefab;
        _poolsize = poolsize;
        _pooledObjects = new();

        for (int i = 0; i < _poolsize; i++)
        {
            GameObject gameObject = GameObject.Instantiate(_prefab) as GameObject;
            gameObject.SetActive(false);
            _pooledObjects.Add(gameObject);
            //Debug.Log($"objects stored: {_pooledObjects.Count}");
        }
    }

    public GameObject GetObject(Transform caller)
    {
        GameObject gameObject = null;
        try
        {
            gameObject = _pooledObjects.First(i => !i.activeInHierarchy);
        }
        catch
        {
            gameObject = AddOneMore();
        }

        gameObject.transform.position = caller.position;
        gameObject.transform.rotation = caller.rotation;
        gameObject.SetActive(true);
        return gameObject;
    }

    GameObject AddOneMore()
    {
        _pooledObjects.Add(GameObject.Instantiate(_prefab));
        return _pooledObjects.Last();
    }

    public void ClearPool()
    {
        foreach (var o in _pooledObjects)
        {
           GameObject.DestroyImmediate(o); 
        }
    }
}