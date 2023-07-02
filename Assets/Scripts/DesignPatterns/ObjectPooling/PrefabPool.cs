using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class PoolSlot
{
    public GameObject Item;
    public bool IsInUse;
}

public class PrefabPool : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _cachedCount;

    public GameObject Prefab => _prefab;

    private List<PoolSlot> _slots = new();

    private void Start()
    {
        for (int i = 0; i < _cachedCount; i++)
        {
            CreateNewItem();
        }
    }

    private void CreateNewItem()
    {
        GameObject newItem = Instantiate(_prefab);
        newItem.SetActive(false);
        _slots.Add(new PoolSlot()
        {
            Item = newItem,
            IsInUse = false
        });
    }

    public GameObject SpawnItem()
    {
        int index = _slots.FindIndex(slot => slot.Item != null && !slot.IsInUse);

        if (index == -1)
        {
            CreateNewItem();
            index = _slots.Count - 1;
        }

        return UseItemAt(index);
    }

    private GameObject UseItemAt(int index)
    {
        _slots[index].IsInUse = true;
        _slots[index].Item.SetActive(true);
        return _slots[index].Item;
    }

    public void DespawnItem(GameObject item)
    {
        item.SetActive(false);

        for (int i = 0; i < _slots.Count; i++)
        {
            if (_slots[i].Item == item)
            {
                _slots[i].IsInUse = false;
                return;
            }
        }
    }

    public bool Contains(GameObject item) => _slots.Exists(slot => slot.Item == item);
}