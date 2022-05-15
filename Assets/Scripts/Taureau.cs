using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taureau : MonoBehaviour
{
    [SerializeField] GameObject targetPrefab;
    [SerializeField] float speed = 0.3f;
    [SerializeField] float runSpeed = 0.7f;
    [SerializeField] float visionDistance = 1f;

    private Mob mob;
    private GameObject target;
    private float timeout = 0;
    private float chargeReload = 20f;

    // Start is called before the first frame update
    void Start()
    {
        mob = GetComponent<Mob>();
        target = Instantiate(targetPrefab, transform.position, Quaternion.identity);
        RandomizeTarget();
        mob.des.target = target.transform;

    }

    IEnumerator run()
    {
        mob.aiPath.maxSpeed = 0;
        mob.animator.SetTrigger("Hit");
        yield return new WaitForSeconds(0.5f);
        target.transform.position = mob.player.transform.position;        
        mob.aiPath.maxSpeed = runSpeed;
        for (int i = 0; i < 10; i++)
        {
            if (Vector3.Distance(target.transform.position, transform.position) < 1f)
            {
                break;
            }
            yield return new WaitForSeconds(1f);
            
        }
        mob.aiPath.maxSpeed = speed;
        mob.animator.SetTrigger("runStop");
        RandomizeTarget();
    }

    private void RandomizeTarget()
    {
        timeout = 0;
        target.transform.position = new Vector3(Random.Range(-10, 10), transform.position.y, Random.Range(-10, 10));
    }

    // Update is called once per frame
    void Update()
    {
        mob.des.target = target.transform;
        if (chargeReload <= 0f &&  Vector3.Distance(transform.position, mob.player.transform.position) < visionDistance)
        {
            StartCoroutine(run());
            chargeReload = 20f;
        } else
        {
            chargeReload -= Time.deltaTime;
        }

        if (timeout > 10f)
        {
            RandomizeTarget();
        }

        timeout += Time.deltaTime;
    }
}
