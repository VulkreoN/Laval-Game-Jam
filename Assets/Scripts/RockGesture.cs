using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RockGesture : MonoBehaviour
{
    public Transform LeftIndex;
    public Transform RightIndex;
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
        Debug.Log(Vector3.Distance(LeftIndex.position, RightIndex.position));
        if (!isFiring && Vector3.Distance(LeftIndex.position, RightIndex.position) < 0.04)
        {
            isFiring = true;
            Debug.Log("fire?");
            firingSpell.Invoke(hand);
        }
        if (isFiring && Vector3.Distance(LeftIndex.position, RightIndex.position) > 0.04)
        {
            Debug.Log("fire!!");
            isFiring = false;
            spellFired.Invoke(hand);
        }
    }
}
