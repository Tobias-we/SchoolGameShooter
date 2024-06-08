using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    [SerializeField] ScoreCounter scoreCounter;
    string highScore = "HighScore";
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnEnable()
    {
        TextMeshProUGUI textPrinter = GetComponent<TextMeshProUGUI>();

        if (scoreCounter.GetScore() > PlayerPrefs.GetFloat(highScore, 0))
        {
            PlayerPrefs.SetFloat(highScore, scoreCounter.GetScore());
            textPrinter.text = "New highscore! You scored: " + scoreCounter.GetScore();
        }
        else
        {
            textPrinter.text = "You scored: " + scoreCounter.GetScore() + ", highscore is: " + PlayerPrefs.GetFloat(highScore, 0);
        }
    }

}
