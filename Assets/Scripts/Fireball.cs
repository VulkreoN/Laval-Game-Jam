using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fireball : MonoBehaviour
{
    public Transform LeftTumbTip;
    public Transform LeftIndexTip;
    public UnityEvent spellFired = new UnityEvent();
    private bool isFiring = false;
    public UnityEvent firingSpell = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFiring && Vector3.Distance(LeftIndexTip.position, LeftTumbTip.position) < 0.04)
        {
            Debug.Log("Fireball");
            isFiring = true;
            firingSpell.Invoke();
        }
        if (isFiring && Vector3.Distance(LeftIndexTip.position, LeftTumbTip.position) > 0.04)
        {
            Debug.Log("Finish casting the spell");
            spellFired.Invoke();
            isFiring = false;
        }
    }
}