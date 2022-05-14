using Microsoft.MixedReality.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    [SerializeField] GameObject hitObject;
    [SerializeField] GameObject target;


    public GameObject mobPrefab = null;
    public GameObject player = null;
    public float wanderingRadius = 1f;
    public float wanderingHeight = 1f;
    private Vector3 randomTarget = Vector3.zero;
    private Rigidbody rb;
    [SerializeField] private float acceleration = 0.1f;
    [SerializeField] private float maxSpeed = 1f;


    // Start is called before the first frame update
    void Start()
    {
        rb = hitObject.GetComponent<Rigidbody>();


        NewTarget();
    }

    private void NewTarget()
    {
        Vector3 playPos = player.transform.position;
        randomTarget.x = Random.Range(playPos.x + -wanderingRadius, playPos.x + wanderingRadius);
        randomTarget.z = Random.Range(playPos.z + -wanderingRadius, playPos.z + wanderingRadius);
        randomTarget.y = Random.Range(playPos.y - 0.3f, playPos.y + wanderingHeight);
    }
    
    private void Move()
    {
        target.transform.position = randomTarget;

        Vector3 position = hitObject.transform.position;

        Vector3 force = Vector3.zero;
        force.x = randomTarget.x < position.x ? -acceleration : acceleration;
        force.y = randomTarget.y < position.y ? -acceleration : acceleration;
        force.z = randomTarget.z < position.z ? -acceleration : acceleration;

        if (rb.velocity.y > maxSpeed)
            rb.velocity = new Vector3(rb.velocity.x, maxSpeed, rb.velocity.z);
        if (rb.velocity.y < -maxSpeed)
            rb.velocity = new Vector3(rb.velocity.x, -maxSpeed, rb.velocity.z);
        if (rb.velocity.x > maxSpeed)
            rb.velocity = new Vector3(maxSpeed, rb.velocity.y, rb.velocity.z);
        if (rb.velocity.x < -maxSpeed)
            rb.velocity = new Vector3(-maxSpeed, rb.velocity.y, rb.velocity.z);
        if (rb.velocity.z > maxSpeed)
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, maxSpeed);
        if (rb.velocity.z < -maxSpeed)
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -maxSpeed);

        rb.AddForce(force);

        if (Vector3.Distance(position, randomTarget) <= 5f)
        {
            NewTarget();
        }
    }

    private void Spawn()
    {
        if (CoreServices.InputSystem.EyeGazeProvider.HitInfo.raycastValid)
        {
            if (hitObject.transform == CoreServices.InputSystem.EyeGazeProvider.HitInfo.transform)
            {
                GameObject hit = CoreServices.InputSystem.EyeGazeProvider.HitInfo.transform.gameObject;

                GameObject mob = Instantiate(mobPrefab, hit.transform.position, Quaternion.identity);
                Mob mob_scp = mob.GetComponent<Mob>();
                mob_scp.player = player;
                
                Destroy(hitObject.gameObject);
                Destroy(this.gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        Move();
        Spawn();
        
    }
}
