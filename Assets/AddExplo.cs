using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddExplo : MonoBehaviour
{

    public GameObject explo;

    public AudioSource audio;
    
    void InstanteExplo()
    {
        Instantiate(explo, transform);
        audio.Play();
    }
}
