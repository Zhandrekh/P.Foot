using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(HeldObject))]
[RequireComponent(typeof(HingeJoint))]
public class Door : MonoBehaviour {

    public Transform parent;
    [Header("Axis")]
    public bool x;
    public bool y;
    public bool z;

    [Header("Limits")]
    public float minRot;
    public float maxRot;
    Vector3 from;

    private void Awake()
    {
        JointLimits limits = new JointLimits();
        limits.min = minRot;
        limits.max = maxRot;
        GetComponent<HingeJoint>().limits = limits;
        GetComponent<HingeJoint>().useLimits = true;
    }

    void Start () {    

        if (x || z)
        {
            from = transform.up;
        }

        if (y)
        {
            from = transform.forward;
        }
	}
	
	
	void Update () {
		if(parent != null)
        {
            Vector3 targetDelta = parent.position - transform.position;
            if (y)
            {
                targetDelta.y = 0;
            }
            else if (x)
            {
                targetDelta.x = 0;
            }
            else if (z)
            {
                targetDelta.z = 0;
            }
            

            float angleDiff = Vector3.Angle(from, targetDelta);

            Vector3 cross = Vector3.Cross(from, targetDelta);

            GetComponent<Rigidbody>().angularVelocity = cross * angleDiff * 50f;
        }
	}

    public void PickUp()
    {
        parent = GetComponent<HeldObject>().parent.transform;
    }

    public void Drop()
    {
        parent = null;
    }
}
