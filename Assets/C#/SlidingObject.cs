using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SlidingObject : MonoBehaviour {

    public bool thisIsAButton;

    Transform parent;
    public Transform pointA;
    public Transform pointB;

    Vector3 offset;

    HeldObject heldObject;

    [Header("Events")]
    public UnityEvent Released;
    public bool callOnce;
    bool done = false;
    public UnityEvent Pushed;

    
    void Start()
    {
        heldObject = GetComponent<HeldObject>();
    }

    void Update()
    {
        if (parent != null)
        {
            transform.position = ClosestPointOnLine(parent.position) - offset;
        }
        else
        {
            transform.position = ClosestPointOnLine(transform.position);
        }

        if(transform.position == pointA.position)
        {
            Released.Invoke();
            done = false;
        }
        else if(transform.position == pointB.position)
        {
            if (callOnce && !done)
            {
                Pushed.Invoke();
                done = true;
            }
            else if (!callOnce)
            {
                Pushed.Invoke();
            }
            
        }
    }

    public void PickUp()
    {
        parent = heldObject.parent.transform;

        offset = parent.position - transform.position;
    }

    public void Drop()
    {
        heldObject.simulator.transform.position = transform.position + offset;

        parent = heldObject.simulator.transform;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Controller") && thisIsAButton)
        {
            heldObject.parent = collision.gameObject.GetComponent<ViveController>();
            Debug.Log("Luke IM UR FATHER");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Controller") && thisIsAButton)
        {
            heldObject.parent = null;
            Debug.Log("NOOOOOOOOOOOOOOOOOOOOOOOO!!!!");
        }
    }
    Vector3 ClosestPointOnLine(Vector3 point)
    {
        Vector3 va = pointA.position + offset;
        Vector3 vb = pointB.position + offset;

        Vector3 vVector1 = point - va;

        Vector3 vVector2 = (vb - va).normalized;

        float t = Vector3.Dot(vVector2, vVector1);

        if (t <= 0)
            return va;

        if (t >= Vector3.Distance(va, vb))
            return vb;

        Vector3 vVector3 = vVector2 * t;

        Vector3 vClosestPoint = va + vVector3;

        return vClosestPoint;
    }
}
