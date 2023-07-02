using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : SingletonMono<PoolManager>
{
    [SerializeField] private PrefabPool[] _pools;

    public override void Init()
    {
    }

    public GameObject SpawnItem(GameObject prefab)
    {
        for (int i = 0; i < _pools.Length; i++)
        {
            if (_pools[i].Prefab == prefab)
            {
                return _pools[i].SpawnItem();
            }
        }
        return Instantiate(prefab);
    }

    public void DespawnItem(GameObject item)
    {
        for (int i = 0; i < _pools.Length; i++)
        {
            if (_pools[i].Contains(item))
            {
                _pools[i].DespawnItem(item);
                return;
            }
        }

        Destroy(item);
    }
}