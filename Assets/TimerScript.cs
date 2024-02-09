using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    private int time = 180;

    private bool start = true;

    public static TimerScript instance;

    void Start()
    {
        instance = this;
        StartCoroutine(timer());
    }

    public void StartTime()
    {
        start = true;
    }
    
    public void StopTime()
    {
        start = false;
    }

    IEnumerator timer()
    {
        while(time > 0)
        {
            yield return new WaitForSeconds(1f);
            if (start == false)
                continue ;
            time--;
            GetComponent<Text>().text = string.Format ("{0:0}:{1:00}", Mathf.Floor(time/60), time%60);
        }
        if (time == 0)
        {

        }
    }
}
