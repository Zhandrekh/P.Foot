using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnACube : MonoBehaviour {

    public GameObject theCube;

    public void SpawnACubePlease()
    {
        Instantiate(theCube,transform.position,Quaternion.identity);
    }
}
