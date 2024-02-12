using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class damageThePipe : MonoBehaviour
{

    private bool isCoroutineExecuting = false;
    
    public Animator destroySystem;

    public ParticleSystem part;

    public AudioSource audio;

    private Scene scene;
    
    private void Awake()
    {
        part.Stop();
        audio.Stop();
        destroySystem = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    void Start()
    {
        scene = SceneManager.GetActiveScene();
        if (PlayerPrefs.HasKey(scene.name + " pipe") && PlayerPrefs.GetInt(scene.name + " pipe") == 1)
        {
            isCoroutineExecuting = true;
            audio.Play();
            part.Play();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Input.GetKey("e") && !isCoroutineExecuting && destroySystem.GetInteger("skin") == 1)
        {
            isCoroutineExecuting = true;
            StartCoroutine(loadAnim());
            History.instance.AddScore();
       }
    }

    public IEnumerator loadAnim()
    {
        scene = SceneManager.GetActiveScene();
        PlayerPrefs.SetInt(scene.name + " pipe", 1);
        
        destroySystem.SetBool("AnimActif", true);
        yield return new WaitForSeconds(1.5f);
        audio.Play();
        part.Play();
        destroySystem.SetBool("AnimActif", false);
    }
}
