using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Character : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody2D rb;
    Vector2 dir;
    public GameObject canva;

	public GameObject settingsWindow;
    
    Animator anim;
    
    public Animator fadeSystem;
    
    private void Awake()
    {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }

    
    void Start()
    {
        canva.SetActive(false);
		settingsWindow.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetInteger("skin", 1);
        StartCoroutine(loadNextScene());
    }

    public IEnumerator loadNextScene()
    {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(12.88f, -6.85f);
        SceneManager.LoadScene("Vilage");
    }

    void Update()
    {
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");
        
        if (Input.GetKeyDown("escape"))
        {
            if (canva.active == false)
            {
                canva.SetActive(true);
                TimerScript.instance.StopTime();
            }
            else
			{
                TimerScript.instance.StartTime();
				settingsWindow.SetActive(false);
                canva.SetActive(false);
			}
        }
           
        if (anim.GetBool("AnimActif") == false)
        {
            rb.MovePosition(rb.position + dir * speed * Time.fixedDeltaTime);
            SetParam();
        }
    }

    void SetParam()
    {
        if (dir.x < 0) //gauche
            anim.SetInteger("dir", 1);
        else if (dir.x > 0) //droite
            anim.SetInteger("dir", 2);
        else if (dir.y < 0) // bas
            anim.SetInteger("dir", 3);
        else if (dir.y > 0) //haut
            anim.SetInteger("dir", 4);
        else if (dir.x == 0 && dir.y == 0)
            anim.SetInteger("dir", 0);
    }
}
