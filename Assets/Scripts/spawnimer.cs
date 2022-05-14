using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnimer : MonoBehaviour
{
    [SerializeField] private float time = 10.0f;

    Rigidbody rb;

    private float timer = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= time)
        {
            Debug.Log("CHICKEN !");
            rb.isKinematic = false;
        } else
        {
            timer += Time.deltaTime;
        }


    }
}
