using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUpdate : MonoBehaviour
{
    public static ScoreUpdate instance;

    public int currentScore = 0;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Score: " + currentScore.ToString());
    }

    public void IncreaseScore(int v)
    {
        currentScore += v;
        Debug.Log("Score: " + currentScore.ToString());
    }
}

