using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinderManager : MonoBehaviour
{
    [SerializeField] private float refreshRate = 5.0f;
    
    AstarPath pf;
    private float timer = 0.0f;
    
    void Start()
    {
        pf = GetComponent<AstarPath>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > refreshRate)
        {
            pf.Scan();
            timer = 0.0f;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
}
