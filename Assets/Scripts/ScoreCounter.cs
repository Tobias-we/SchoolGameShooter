using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    TextMeshProUGUI textPrinter;
    float score = 0;
    // Start is called before the first frame update
    void Start()
    {
        textPrinter = GetComponent<TextMeshProUGUI>();
        PrintScore();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddScore(float scoreToAdd)
    {
        score += scoreToAdd;
        PrintScore();
    }

    public float GetScore()
    {
        return score;
    }
    private void PrintScore()
    {
        textPrinter.text = "Score: " + score;
    }
}
