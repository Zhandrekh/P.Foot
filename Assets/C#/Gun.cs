using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HeldObject))]
public class Gun : MonoBehaviour {

    
    public GameObject bullet;
    public Transform bulletStart;

    HeldObject heldObject;

    private void Start()
    {
        heldObject = GetComponent<HeldObject>();
    }

    private void Update()
    {
        if (heldObject.parent.controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_Axis1))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        Instantiate(bullet, bulletStart.position, transform.rotation);
    }
}
