using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class History : MonoBehaviour
{
    public int scoreCount;

    private int dina = 0;
    
    public static History instance;

    public Text HistoryCountText;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("il y a plus d'une instance de History dans la scene");
        }
        instance = this;
    }
    
    public void AddScore()
    {
        scoreCount ++;
        HistoryCountText.text = scoreCount.ToString();
    }

    public int GetScore()
    {
        return scoreCount;
    }

    public void AddDina()
    {
        dina++;
    }

    public int GetDina()
    {
        return (dina);
    }
}
