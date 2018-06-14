using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Door))]
public class Lever : MonoBehaviour {

    [Header("Axis")]
    public bool x;
    public bool y;
    public bool z;

    [Header("Events")]
    public UnityEvent hitMax;
    public UnityEvent hitMin;
    
	
	void Update () {

        
        if (x)
        {
            if(transform.rotation.x < -0.2f)
            {
                Debug.Log("DO SOMETHING NOW !!!!!");
                hitMin.Invoke();
            }
            else if(transform.rotation.x > 0.2f)
            {
                hitMax.Invoke();
            }
        }

        if (y)
        {
            if (transform.rotation.y < -0.2f)
            {
                hitMin.Invoke();
            }
            else if (transform.rotation.y > 0.2f)
            {
                hitMax.Invoke();
            }
        }

        if (z)
        {
            if (transform.rotation.z < -0.2f)
            {
                hitMin.Invoke();
            }
            else if (transform.rotation.z > 0.2f)
            {
                hitMax.Invoke();
            }
        }
	}
}
