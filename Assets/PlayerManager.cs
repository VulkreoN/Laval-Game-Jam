using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public int pv = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void TakeDamage(int damage)
    {
        pv -= damage;
        if (pv <= 0)
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger");
        if (other.gameObject.tag == "Mob")
        {
            Debug.Log("ptrigger");
            Mob mob = other.gameObject.GetComponent<Mob>();
            TakeDamage(mob.damages);
        } if (other.gameObject.tag == "Projectile")
        {
            Projectile p = other.gameObject.GetComponent<Projectile>();
            TakeDamage(1);
            Destroy(other.gameObject);
        }
    }


}
