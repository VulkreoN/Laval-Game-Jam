using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionFix : MonoBehaviour
{
    [SerializeField] private float minY = -20.0f;

    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y < minY)
        {
            this.transform.position = new Vector3(this.transform.position.x, 1, this.transform.position.z);
            rb.velocity = Vector3.zero;
        }
    }
}
