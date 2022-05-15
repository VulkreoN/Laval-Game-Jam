using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FireballGesture : MonoBehaviour
{
    public Transform LeftTumbTip;
    public Transform LeftIndexTip;
    public Transform RightTumbTip;
    public Transform RightIndexTip;
    public UnityEvent spellFired = new UnityEvent();
    public UnityEvent firingSpell = new UnityEvent();
    private bool isFiring = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFiring && (Vector3.Distance(LeftIndexTip.position, LeftTumbTip.position) < 0.04 || Vector3.Distance(RightIndexTip.position, RightTumbTip.position) < 0.04))
        {
            isFiring = true;
            Debug.Log("fire?");
            firingSpell.Invoke();
        }
        if (isFiring && (Vector3.Distance(LeftIndexTip.position, LeftTumbTip.position) > 0.04 || Vector3.Distance(RightIndexTip.position, RightTumbTip.position) > 0.04))
        {
            Debug.Log("fire!!");
            isFiring = false;
            spellFired.Invoke();
        }
    }
}
