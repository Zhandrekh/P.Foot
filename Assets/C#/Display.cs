using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(SpriteRenderer))]
public class Display : MonoBehaviour {

    public bool screenA;
    public bool screenB;
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
    [Header("K8")]
    public Sprite HA;
    public Sprite HB;

    Sprite A;
    Sprite B;

    SpriteRenderer screen;
	

	void Start () {
        screen = GetComponent<SpriteRenderer>();
        if (screenA)
        {
            screen.sprite = A;
            B = null;
        }
        else if(screenB)
        {
            screen.sprite = B;
            A = null;
        }
        else
        {
            screen.sprite = A;
        }
        
        _timer = timer;
	}
	
	// Update is called once per frame
	void Update () {
        if (startTimer)
        {
            if (A == null && !screenB)
                A = AA;
            if (B == null && !screenA)
                B = AB;
            timer -= Time.deltaTime;
            timerText.text = "" + timer;
            if (timer <= 0)
            {
                TimerEnd();
            }
        }

        if (k == 1)
        {
            A = AA;
            B = AB;
        }
        else if (k == 2)
        {
            A = BA;
            B = BB;
        }
        else if (k == 3)
        {
            A = CA;
            B = CB;
        }
        else if (k == 4)
        {
            A = CA;
            B = CB;
        }
        else if (k == 5)
        {
            A = DA;
            B = DB;
        }
        else if (k == 6)
        {
            A = EA;
            B = EB;
        }
        else if (k == 7)
        {
            A = FA;
            B = FB;
        }
        else if (k == 8)
        {
            A = GA;
            B = GB;
        }


    }

    void TimerEnd()
    {
        k++;
        timer = _timer;
    }

    public void StartTimer()
    {
        startTimer = true;
    }

    public void SwitchToA()
    {        
        screen.sprite = A;       
    }

    public void SwitchToB()
    {
        screen.sprite = B;
    }

    public void ButtonSelect()
    {
        TimerEnd();
    }
}
