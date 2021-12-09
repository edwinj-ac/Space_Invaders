using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    public TMP_Text txt_score, score_UI, status_game;
    public int score = 0, max_Score = 0, column=0;
    public Sprite[] lives;
    public Image livesImageDisplay;
    public GameObject[] stars;
    public Invaders_Grid _invader_grid;
    public GameObject invader_manager, menu_UI;
    public bool win = false;

    void Start()
    {
        for(int i=0; i < stars.Length; i++)
        {
            stars[i].SetActive(false);
        }

        _invader_grid = invader_manager.GetComponent<Invaders_Grid>();
    }

    void Update()
    {
        //txt_score.text = score.ToString();
    }


    public void UpdateScore(int point_invader)
    {
        score += point_invader;
        Debug.Log("Score: " + score);
        txt_score.text = score.ToString();
        score_UI.text = score.ToString();
    }

    public void UpdateLives(int currentLives)
    {
        livesImageDisplay.sprite = lives[currentLives];
    }

    public void UpdateStars(bool win_flag)
    {
        menu_UI.SetActive(true);
        if (win_flag)
        {
            status_game.text = "WIN";
        }
        else
        {
            status_game.text = "LOSE";
        }
        double score_Actual = (double)score;

        column = _invader_grid.columns;

        int green_invader = 1 * column * 2;
        int blue_invader = 2 * column;
        int red_invader = 3 * column;

        max_Score = green_invader + blue_invader + red_invader;

        double star1 = max_Score * 0.30;
        double star2 = max_Score * 0.85;
        double star3 = max_Score * 0.9;

        if (score_Actual <= star1)
        {
            stars[0].SetActive(true);
            stars[1].SetActive(false);
            stars[2].SetActive(false);
        }
        if (score_Actual > star1 && score_Actual < star2)
        {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(false);
        }
        if (score_Actual > star3 )
        {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
        }

    }

}
