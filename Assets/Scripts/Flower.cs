using System;
using UnityEngine;

[Serializable]
public class Flower : MonoBehaviour
{
    public bool _isCollected { get; set; }
    void Start()
    {
        GetData();

        if (_isCollected)
        {
            PutInInventory();
        }
     }

    private void GetData()
    {
        FlowerData data = SaveFile.Instance.GetFlower();
        this._isCollected = data._IsCollected;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PutInInventory();
    }

    private void PutInInventory()
    {
        _isCollected = true;
        SaveFile.Instance.SetFlower(this);
        Destroy(gameObject);
    }
}
