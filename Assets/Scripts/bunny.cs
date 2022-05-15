using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bunny : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileFiringPeriod = 2f;
    [SerializeField] float detectionDistance = 3f;

    private Mob mobScp;
    private float lastFired;
    private float timer = 0f;
    private Animator animator;
    public bool shootReady = false;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        mobScp = GetComponent<Mob>();
    }

    private void shoot()
    {
        animator.SetTrigger("Shoot");
    }

    private void shootAction()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody>().velocity = (mobScp.player.transform.position - transform.position).normalized * projectileSpeed;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, mobScp.player.transform.position) < detectionDistance)
        {
            if (timer > projectileFiringPeriod)
            {
                shoot();
                if (shootReady)
                {
                    shootAction();
                    timer = 0f;
                    shootReady = false;
                }
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
    }
}
