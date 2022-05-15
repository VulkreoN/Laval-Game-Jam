using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] float speed;
    [SerializeField] Transform head;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.zero;
        movement.x = target.transform.position.x - transform.position.x;
        movement.y = target.transform.position.y - transform.position.y;
        movement.z = target.transform.position.z - transform.position.z;
        movement.Normalize();
        transform.position += movement * speed * Time.deltaTime;

        /*Vector3 look = target.transform.position - head.position;
        look.y = 0;
        look.Normalize();
        head.rotation = Quaternion.LookRotation(look);*/
        

        Vector3 orientation = Vector3.zero;
        orientation.x = target.transform.position.x - transform.position.x;
        orientation.y = target.transform.position.y - transform.position.y;
        orientation.z = target.transform.position.z - transform.position.z;
        orientation.Normalize();
        transform.rotation = Quaternion.LookRotation(orientation);


    }
}
