using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSpecificScene : MonoBehaviour
{
    public bool isInRange = false;

    private bool isCoroutineExecuting = false;
    public string sceneName;
    
    public float tpX;
    public float tpY;

    public Animator fadeSystem;
    
    public Animator anim;
    
    private void Awake()
    {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
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
        if (isInRange == true && Input.GetKey("e") && !isCoroutineExecuting && anim.GetInteger("skin") != 6)
        {
            isCoroutineExecuting = true;
            StartCoroutine(loadNextScene());
        }
    }
    public IEnumerator loadNextScene()
    {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(tpX, tpY);
        isCoroutineExecuting = false;
    }
}
