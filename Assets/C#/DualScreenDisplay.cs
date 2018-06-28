using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DualScreenDisplay : MonoBehaviour {

    public bool startTimer;
    public float timer;
    float _timer;
    public Text timerText;

    int k = 0;

    [Header("Sprite")]
    [Header("K1")]
    public Sprite AA;
    public Sprite AB;
    [Header("K2")]
    public Sprite BA;
    public Sprite BB;
    [Header("K3")]
    public Sprite CA;
    public Sprite CB;
    [Header("K4")]
    public Sprite DA;
    public Sprite DB;
    [Header("K5")]
    public Sprite EA;
    public Sprite EB;
    [Header("K6")]
    public Sprite FA;
    public Sprite FB;
    [Header("K7")]
    public Sprite GA;
    public Sprite GB;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
