using System;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Flower flower;
    public GameObject box;
    private Camera _camera;

    void Start()
    {
        PlayerData data = SaveFile.Instance.GetPlayer();
        Instantiate(player, new Vector3(data._Position.x, data._Position.y, 0), Quaternion.identity);
        Instantiate(flower, new Vector3(2, 2, 0), Quaternion.identity);
    }

    void Update()
    {
       
    }
}
