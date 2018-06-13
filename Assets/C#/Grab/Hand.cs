using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ViveController))]
public class Hand : MonoBehaviour
{
    GameObject heldObject;
    ViveController controller;

    public Valve.VR.EVRButtonId pickUpButton;
    public Valve.VR.EVRButtonId dropButton;

    int prevCount = 0;
    void Start()
    {
        controller = GetComponent<ViveController>();
    }

    void Update()
    {
        if (heldObject)
        {
            
            if ((controller.controller.GetPressUp(pickUpButton) && heldObject.GetComponent<HeldObject>().dropOnRelease) || (controller.controller.GetPressDown(dropButton) && !heldObject.GetComponent<HeldObject>().dropOnRelease))
            {
                heldObject.GetComponent<HeldObject>().Drop();
                heldObject = null;
            }
        }
        else
        {
            Collider[] cols = Physics.OverlapSphere(transform.position, 0.1f);

            int curCount = 0;
            foreach(Collider col in cols)
            {
                if (heldObject == null && col.GetComponent<HeldObject>() != null && col.GetComponent<HeldObject>().parent == null)
                {
                    curCount++;
                }                                
            }

            if (curCount != prevCount)
                controller.controller.TriggerHapticPulse(3999);

            prevCount = curCount;

            if (controller.controller.GetPressDown(pickUpButton))
            {             

                foreach (Collider col in cols)
                {
                    if (heldObject == null && col.GetComponent<HeldObject>() && col.GetComponent<HeldObject>().parent == null)
                    {
                        heldObject = col.gameObject;
                        heldObject.GetComponent<HeldObject>().parent = controller;
                        heldObject.GetComponent<HeldObject>().PickUp();
                    }
                }
            }


        }
        
    }
}