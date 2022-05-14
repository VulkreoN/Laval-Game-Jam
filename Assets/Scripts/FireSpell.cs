using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FireSpell : MonoBehaviour
{
    public GameObject projectile;
    public float speed = 300f;

    void Start()
    {
        GameObject ball = Instantiate(projectile, transform.position,
                                                     transform.rotation);
        ball.SetActive(true);
        ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3
                                            (0, 0, speed));
        Destroy(ball, 10);
    }

    void Update()
    {
       // useless
    }
}