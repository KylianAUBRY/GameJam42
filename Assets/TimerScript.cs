using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    private int time = 60;

    private bool start = true;
    
    public Animator Player;
    
    public Animator fadeSystem;

    public static TimerScript instance;

    
    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }
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
        while (Player.GetInteger("skin") < 7)
        {
            while (time > 0)
            {
                yield return new WaitForSeconds(1f);
                if (start == false)
                    continue;
                time--;
                GetComponent<Text>().text = string.Format("{0:0}:{1:00}", Mathf.Floor(time / 60), time % 60);
            }
            
            time = 180;
            fadeSystem.SetTrigger("FadeIn");
            yield return new WaitForSeconds(1f);
            Scene test = SceneManager.GetActiveScene();
            if (test.name != "Vilage")
                SceneManager.LoadScene("Vilage");
            GetComponent<Text>().text = string.Format("{0:0}:{1:00}", Mathf.Floor(time / 60), time % 60);
            Player.SetInteger("skin", (Player.GetInteger("skin") + 1));
            switch (Player.GetInteger("skin"))
            {
                case 2 : 
                    GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(-17.12f, 3.26f);
                    break;
                case 3:
                    GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(-33.12f, 0.6f);
                    break;
                case 4:
                    GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(10f, 10f);
                    //ici tp scene comico
                    break;
                case 5:
                    GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(20.94f, 1.24f);
                    break;
                case 6:
                    GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(21.84f, -6.77f);
                    break;
            }
        }
        
    }
}
