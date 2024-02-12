using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptAnim : MonoBehaviour
{

    public static scriptAnim instance;
    public Animator animator;

    public Dialogue dialogue;

    public Dialogue dialogue1;

    public Dialogue dialogue2;

    public Dialogue dialogue3;

    public Dialogue dialogue4;

    public Dialogue dialogue5;

    public Dialogue dialogue6;

    public Dialogue dialogue7;

    public Dialogue dialogue8;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("il y a plus d'une instance de scriptAnim dans la scene");
            return ;
        }
       instance = this;
    }


    void Start()
    {
        animator.SetInteger("animLog", 1);
    }

    void Update()
    {
        
    }

    void TriggerDialogue()
    {
        DialogueManager.instance.StartDialogue(dialogue);
        
        //DialogueManager.instance.StartDialogue(dialogue1);
    }

    public void StartDialogue1()
    {
        DialogueManager.instance.StartDialogue(dialogue);
    }

    public void StartDialogue2()
    {
        DialogueManager.instance.StartDialogue(dialogue1);
    }

    public void StartDialogue3()
    {
        DialogueManager.instance.StartDialogue(dialogue2);
    }

    public void startPerso2()
    {
        DialogueManager.instance.StartDialogue(dialogue3);
    }
    public void startPerso2Dialogue1()
    {
        DialogueManager.instance.StartDialogue(dialogue4);
    }

    public void startPerso2Dialogue2()
    {
        DialogueManager.instance.StartDialogue(dialogue5);
    }

    public void startPerso3()
    {
        DialogueManager.instance.StartDialogue(dialogue6);
    }

    public void startPerso3Dialogue1()
    {
        DialogueManager.instance.StartDialogue(dialogue7);
    }
    public void startPerso3Dialogue2()
    {
        DialogueManager.instance.StartDialogue(dialogue8);
    }

    public void FinAnim()
    {
        SceneManager.LoadScene("temp");
    }
}
