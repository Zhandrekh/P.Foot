using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Lifter : MonoBehaviour {

    [Header("Player")]
    public GameObject cameraRig;

    [Header("Lifter Targets")]
    public Transform targetUp;
    public Transform targetDown;

    [Header("Lifter Stat")]
    public float dampedSpeed = 4f;
    Vector3 vel;
    
    public void GoUp()
    {
        transform.position = Vector3.SmoothDamp(transform.position, targetUp.position, ref vel, dampedSpeed * Time.deltaTime);
    }    

    public void GoDown()
    {
        transform.position = Vector3.SmoothDamp(transform.position, targetDown.position, ref vel, dampedSpeed * Time.deltaTime);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("CameraRig"))
            cameraRig.transform.parent = transform.parent;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CameraRig"))
            cameraRig.transform.parent = null;
    }
}
