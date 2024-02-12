using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class killPnj : MonoBehaviour
{
    public bool isInRange = false;

    private bool isCoroutineExecuting = false;
    
    public Animator destroySystem;
    
    public AudioSource audio;

    public SpriteRenderer spriteRenderer;

    public Sprite newSprite;
    
    public Sprite newSpriteChauve;
    
    private Scene scene;
    
    private void Awake()
    {
        audio.Stop();
        destroySystem = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }
    
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        if (PlayerPrefs.HasKey(scene.name + " dead") && PlayerPrefs.GetInt(scene.name + " dead") == 1)
        {
            isCoroutineExecuting = true;
            if (PlayerPrefs.HasKey(scene.name + " head") && PlayerPrefs.GetInt(scene.name + " head") == 1)
                spriteRenderer.sprite = newSpriteChauve;
            else
                spriteRenderer.sprite = newSprite;
        }
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            isInRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            isInRange = false;
    }

    void Update()
    {
        if (isInRange == true && Input.GetKey("e") && !isCoroutineExecuting && destroySystem.GetInteger("skin") == 5)
        {
            isCoroutineExecuting = true;
            StartCoroutine(loadAnim());
            History.instance.AddScore();
        }
    }
    
    public IEnumerator loadAnim()
    {
        scene = SceneManager.GetActiveScene();
        PlayerPrefs.SetInt(scene.name + " dead", 1);
        destroySystem.SetBool("AnimActif", true);
        audio.Play();
        yield return new WaitForSeconds(1.5f);
        if (PlayerPrefs.HasKey(scene.name + " head") && PlayerPrefs.GetInt(scene.name + " head") == 1)
            spriteRenderer.sprite = newSpriteChauve;
        else
            spriteRenderer.sprite = newSprite;
        yield return new WaitForSeconds(0.5f);
        destroySystem.SetBool("AnimActif", false);
    }
}
