using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BurnTheWheat : MonoBehaviour
{
    private bool isCoroutineExecuting = false;
    
    public Animator destroySystem;
    
    public AudioSource audio;
    
    public AudioSource audioFire;

    private Scene scene;
    
    public Sprite newSprite;

    public ParticleSystem part;
    
    public SpriteRenderer spriteRenderer;
    
    private void Awake()
    {
        part.Stop();
        audio.Stop();
        audioFire.Stop();
        destroySystem = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }
    
    void Start()
    {   
        scene = SceneManager.GetActiveScene();
        if (PlayerPrefs.HasKey(scene.name + this.ToString()) && PlayerPrefs.GetInt(scene.name + this.ToString()) == 1)
        {
            isCoroutineExecuting = true;
            part.Stop();
            audio.Stop();
            audioFire.Stop();
            spriteRenderer.sprite = newSprite;
        }

        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Input.GetKey("e") && !isCoroutineExecuting &&
            destroySystem.GetInteger("skin") == 3)
        {
            isCoroutineExecuting = true;
            StartCoroutine(loadAnim()); 
            History.instance.AddScore();
        }
    }
    
    public IEnumerator loadAnim()
    {
        scene = SceneManager.GetActiveScene();
        PlayerPrefs.SetInt(scene.name + this.ToString(), 1);
        destroySystem.SetBool("AnimActif", true);
        yield return new WaitForSeconds(1.5f);
        audio.Play();
        part.Play();
        audioFire.Play();
        //spriteRenderer.sprite = newSprite;
        destroySystem.SetBool("AnimActif", false);
    }
}
