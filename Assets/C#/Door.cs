using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(HeldObject))]
[RequireComponent(typeof(HingeJoint))]
public class Door : MonoBehaviour {

    public Transform parent;

    public float minRot;
    public float maxRot;

	void Start () {
        JointLimits limits = new JointLimits();
        limits.min = minRot;
        limits.max = maxRot;
        GetComponent<HingeJoint>().limits = limits;
        GetComponent<HingeJoint>().useLimits = true;
	}
	
	
	void Update () {
		if(parent != null)
        {
            Vector3 targetDelta = parent.position - transform.position;
            targetDelta.y = 0;

            float angleDiff = Vector3.Angle(transform.forward, targetDelta);

            Vector3 cross = Vector3.Cross(transform.forward, targetDelta);

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
