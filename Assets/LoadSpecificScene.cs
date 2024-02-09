using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSpecificScene : MonoBehaviour
{
    private bool isCoroutineExecuting = false;
    public string sceneName;
    
    public int tpX;
    public int tpY;

    public Animator fadeSystem;
    
    private void Awake()
    {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Input.GetKey("e") && !isCoroutineExecuting)
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
