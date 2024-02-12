using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    
    public GameObject[] objects;
    
    public GameObject objectsText1;
    public GameObject objectsText2;
    public GameObject objectsText3;
    
    
    
    public Camera camera;

    public Canvas canva;
    
    
    private int time = 300;

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
            
            time = 300;
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
                    //time = 60;
                    break;
                case 3:
                    GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(-33.12f, 0.6f);
                    break;
                case 4:
                    if (test.name != "commico")
                        SceneManager.LoadScene("commico"); 
                    GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(0f, 0f);
                    break;
                case 5:
                    GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(20.94f, 1.24f);
                    break;
                case 6:
                    GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(21.84f, -6.77f);
                    break;
            }
        }//objectsText
        Destroy(objectsText1);
        Destroy(objectsText2);
        Destroy(objectsText3);
        GetComponent<Text>().text = "";
        
        camera.enabled = false;
        if (History.instance.GetDina() > 0)
        {
            SceneManager.LoadScene("FInalExplosion");
            yield return new WaitForSeconds(10f);
        }
        else
        {
            if (History.instance.GetScore() > 0)
            {
                SceneManager.LoadScene("FinalDark");
                yield return new WaitForSeconds(14f);
                
            }
            else
            {
                
            }
        }
        SceneManager.LoadScene("Credits");
        yield return new WaitForSeconds(20f);
        SceneManager.LoadScene("MainMenu");
        foreach (var element in objects)
        {
            //DontDestroyOnLoad(element);
            Destroy(element);
        }
    }
}
