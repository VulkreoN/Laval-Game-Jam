using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ElectroGesture : MonoBehaviour
{
    public Transform MajTip;
    public Transform IndexTip;
    public LockingScript lockingScript;
    public string hand;
    public UnityEvent<string> spellFired = new UnityEvent<string>();
    public UnityEvent<string> firingSpell = new UnityEvent<string>();
    private bool isFiring = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isFiring && Vector3.Distance(IndexTip.position, MajTip.position) < 0.04)
        {
            isFiring = true;
            Debug.Log("fire?");
            firingSpell.Invoke(hand);
        }
        if (isFiring && Vector3.Distance(IndexTip.position, MajTip.position) > 0.04)
        {
            Debug.Log("fire!!");
            isFiring = false;
            spellFired.Invoke(hand);
        }
    }
}
