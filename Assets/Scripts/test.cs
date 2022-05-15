using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //check if the mouse is clicking in the object
        if (Input.GetMouseButtonDown(0))
        {
            playfabManager.SendLeaderboard(10);
        }
        if (Input.GetMouseButtonDown(1))
        {
            playfabManager.GetLeaderboard();
        }
    }
}
