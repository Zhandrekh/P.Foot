using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class HeldObject : MonoBehaviour
{
    [HideInInspector]
    public ViveController parent;

    public bool canPickUp = true;
    public bool dropOnRelease;

    public float disconnectDistance = 0f;

    public UnityEvent pickUp;

    public UnityEvent drop;

    [HideInInspector]
    public Rigidbody simulator;

    void Start()
    {
        simulator = new GameObject().AddComponent<Rigidbody>();
        simulator.name = "simulator";
        simulator.transform.parent = transform.parent;
        simulator.useGravity = false;
    }

    private void Update()
    {
        if (parent != null)
        {
            simulator.velocity = (parent.transform.position - simulator.position) * 50f;

            if (disconnectDistance > 0f)
            {
                if(!GetComponent<Collider>().bounds.Contains(parent.transform.position) &&
                    Vector3.Distance(GetComponent<Collider>().bounds.ClosestPoint(parent.transform.position), parent.transform.position) > disconnectDistance)
                {
                    Drop();
                }
            }
        }
    }

    public void PickUp()
    {
        if (canPickUp)
        {
            pickUp.Invoke();
            if (pickUp.GetPersistentEventCount() == 0)
            {
                DefaultPickUp();
            }
            parent.controller.TriggerHapticPulse(3999);
        }        
    }

    public void Drop()
    {
        drop.Invoke();
        if (drop.GetPersistentEventCount() == 0)
        {
            DefaultDrop();
        }
        if(parent != null)
        parent.controller.TriggerHapticPulse(3999);
        parent = null;
    }

    public void DefaultDrop()
    {
        transform.parent = null;
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().velocity = simulator.velocity;
        parent = null;
    }

    public void DefaultPickUp()
    {
        transform.parent = parent.transform;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        GetComponent<Rigidbody>().isKinematic = true;
    }
}
