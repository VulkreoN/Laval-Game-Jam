using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    private float timer = 0;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 4)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("ptrigger");
            PlayerManager pm = other.gameObject.GetComponent<PlayerManager>();
            pm.TakeDamage(1);
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("pcollision");
            PlayerManager pm = collision.gameObject.GetComponent<PlayerManager>();
            pm.TakeDamage(1);
            Destroy(gameObject);
        }
    }
}
