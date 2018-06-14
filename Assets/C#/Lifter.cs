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
    public float dampTime = 4f;
    Vector3 vel;

    Vector3 targetPosition;

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref vel, dampTime);
    }

    public void GoUp()
    {
        targetPosition = targetUp.position;
    }    

    public void GoDown()
    {
        targetPosition = targetDown.position;
    }

}
