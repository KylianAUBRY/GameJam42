using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
    private bool isCoroutineExecuting = false;

    public Animator destroySystem;

    public Animator fuiteSprite;

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
        if (PlayerPrefs.HasKey(scene.name + this.ToString()) && PlayerPrefs.GetInt(scene.name + this.ToString()) == 1)
        {
            isCoroutineExecuting = true;
            fuiteSprite.SetBool("invisible", true);
            spriteRenderer.sprite = newSprite;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Input.GetKey("e") && !isCoroutineExecuting && destroySystem.GetInteger("skin") == 4)
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
        audio.Play();
        yield return new WaitForSeconds(1f);
        spriteRenderer.sprite = newSprite;
        destroySystem.SetBool("AnimActif", false);
        fuiteSprite.SetBool("Walk1", true);
        yield return new WaitForSeconds(14f);
        fuiteSprite.SetBool("invisible", true);
        Destroy(fuiteSprite);
    }

}
