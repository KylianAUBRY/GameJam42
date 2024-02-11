using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class headShaving : MonoBehaviour
{
    private bool isCoroutineExecuting = false;
    
    public Animator destroySystem;
    public AudioSource audio;

    public SpriteRenderer spriteRenderer;

    public Sprite newSprite;
    
    private Scene scene;
    
    private void Awake()
    {
        audio.Stop();
        destroySystem = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }
    
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        if (PlayerPrefs.HasKey(scene.name + " head") && PlayerPrefs.GetInt(scene.name + " head") == 1)
        {
            isCoroutineExecuting = true;
            audio.Play();
            spriteRenderer.sprite = newSprite;
        }
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Input.GetKey("e") && !isCoroutineExecuting && destroySystem.GetInteger("skin") == 2)
        {
            isCoroutineExecuting = true;
            StartCoroutine(loadAnim());
            History.instance.AddScore();
        }
    }
    
    public IEnumerator loadAnim()
    {
        scene = SceneManager.GetActiveScene();
        PlayerPrefs.SetInt(scene.name + " head", 1);
        
        destroySystem.SetBool("AnimActif", true);
        spriteRenderer.sprite = newSprite;
        audio.Play();
        yield return new WaitForSeconds(1f);
        destroySystem.SetBool("AnimActif", false);
    }
}
