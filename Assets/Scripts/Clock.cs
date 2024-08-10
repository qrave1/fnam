using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Clock : MonoBehaviour
{
    private int time = 0;
    private TextMeshProUGUI clock;
    public float delay = 30f;

    private void Awake()
    {
        clock = GetComponent<TextMeshProUGUI>();
        InvokeRepeating("Timer", 2f, 30f);
    }

    public void Timer()
    {
        time++;

        clock.text = time.ToString() + " am";

        if (time >= 6)
        {
            CancelInvoke();
            Application.Quit();
        }
    }
}
