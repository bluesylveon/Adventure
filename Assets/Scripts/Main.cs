using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public GameObject player;
    public GameObject grid;


    public GameObject box;


    private SaveFile savefile;


    void Start()
    {
        savefile = new SaveFile("Player 1", "data.json");
        Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
        Instantiate(grid, new Vector3(0, 0, 0), Quaternion.identity);

        savefile.Save();



        //Instantiate(box, new Vector3(1, 1, 0), Quaternion.identity);



    }

    // Update is called once per frame
    void Update()
    {

    }


}
