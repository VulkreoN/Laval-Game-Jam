using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpellThrower : MonoBehaviour
{
    public GameObject projectile;
    public float speed = 300f;
    public Transform Head;

    public void Cast(string hand)
    {
        Debug.Log("testing...");
        try
        {
            GameObject ball = Instantiate(projectile, Head.position, Head.rotation);
            ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, speed));
            Destroy(ball, 10);
        }
        catch(Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }


    void Start()
    {
       //
    }

    void Update()
    {
       // useless
    }
}