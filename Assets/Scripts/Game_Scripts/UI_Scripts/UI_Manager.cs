using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    public TMP_Text txt_score;
    public int score = 0;
    public Sprite[] lives;
    public Image livesImageDisplay;

    void Update()
    {
        //txt_score.text = score.ToString();
    }

    
    public void UpdateScore(int point_invader)
    {
        score += point_invader;
        Debug.Log("Score: " + score);
        txt_score.text = score.ToString();
    }

    public void UpdateLives(int currentLives)
    {
        livesImageDisplay.sprite = lives[currentLives];
    }
}
