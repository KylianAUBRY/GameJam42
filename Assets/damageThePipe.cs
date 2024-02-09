using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageThePipe : MonoBehaviour
{

    private bool isCoroutineExecuting = false;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Input.GetKey("e") && !isCoroutineExecuting)
        {
            isCoroutineExecuting = true;
            History.instance.AddScore();
            
       }
    }

}
