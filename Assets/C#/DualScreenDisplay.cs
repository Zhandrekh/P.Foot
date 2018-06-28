using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DualScreenDisplay : MonoBehaviour {

    public bool startTimer;
    public float timer;
    float _timer;
    public Text timerText;
    public Text timerText2;

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

    Sprite A;
    Sprite B;

    public SpriteRenderer screenA;
    public SpriteRenderer screenB;

    // Use this for initialization
    void Start () {
        A = AA;
        B = AB;
        _timer = timer;
	}

    void Update()
    {
        screenA.sprite = A;
        screenB.sprite = B;
        if (startTimer)
        {
            if (A == null)
                A = AA;

            timer -= Time.deltaTime;
            timerText.text = "" + timer;
            timerText2.text = "" + timer;
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

        if (k > 7)
        {
            startTimer = false;
            A = null;
            B = null;
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

    public void ButtonSelect()
    {
        TimerEnd();
    }
}
