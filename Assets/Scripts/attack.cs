using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    public GameObject projectile;
    public float speed = 300f;

    void Start()
    {
        projectile.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject ball = Instantiate(projectile, transform.position,  
                                                     transform.rotation);
            ball.SetActive(true);
            ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3 
                                                (0, 0, speed));
            Destroy(ball, 10);
        }
    }
}
