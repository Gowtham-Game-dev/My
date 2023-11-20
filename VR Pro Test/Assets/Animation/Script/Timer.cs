using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float elapsedTime = 0f;
    public float playTime = 130f;
    public TextMeshProUGUI timerText;

    public TextMeshProUGUI ScoreText;
    public int Score=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
                if (EditorApplication.isPlaying)
                {
                    elapsedTime += Time.deltaTime;
                    float remainingtime = playTime - elapsedTime;
                    timerText.text = remainingtime.ToString("F1");
                    if (elapsedTime >= 100)
                    {
                        timerText.color = Color.red;
                    }
                    if (elapsedTime >= playTime)
                    {
                        SceneManager.LoadScene("GameOver");
                    }
                }*/
        elapsedTime += Time.deltaTime;
        float remainingTime = playTime - elapsedTime;
        timerText.text = remainingTime.ToString("F1");
        if (elapsedTime >= 110)
        {
            timerText.color = Color.red;
        }
        if (elapsedTime >= playTime)
        {
            SceneManager.LoadScene("GameOver");
        }

    }
    public void score()
    {
        Score++;
        ScoreText.text = Score.ToString()+"/20";
        if(Score>=20)
        {
            SceneManager.LoadScene("Win");
        }
    }

}
