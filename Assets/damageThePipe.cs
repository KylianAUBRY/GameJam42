using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageThePipe : MonoBehaviour
{

    private bool isCoroutineExecuting = false;
    
    public Animator destroySystem;

    public ParticleSystem part;

    public AudioSource audio;
    
    
    
    
    private void Awake()
    {
        part.Stop();
        audio.Stop();
        destroySystem = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
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
        destroySystem.SetBool("AnimActif", true);
        yield return new WaitForSeconds(1f);
        audio.Play();
        part.Play();
        destroySystem.SetBool("AnimActif", false);
        isCoroutineExecuting = false;
    }
}
