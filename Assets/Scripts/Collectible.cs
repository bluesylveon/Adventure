using System;
using UnityEngine;

[Serializable]
public class Collectible : MonoBehaviour
{
    public bool _isCollected { get; set; }
    public int _id { get; set; }
    void Start()
    {
        GetData();
        if (_isCollected)
            Destroy(gameObject);
    }

    private void GetData()
    {
        CollectibleData data = SaveFile.Instance.GetCollectibleDataById(_id);
        this._isCollected = data._IsCollected;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            PutInInventory();
    }

    private void PutInInventory()
    {
        _isCollected = true;
        Destroy(gameObject);
    }

    public override string ToString()
    {
        return "[isCollected: " + _isCollected + "],";
    }
}
