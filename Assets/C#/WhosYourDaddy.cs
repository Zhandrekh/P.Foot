using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhosYourDaddy : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CameraRig"))
        {
            other.transform.SetParent(this.transform, true);
        }
    }

}
