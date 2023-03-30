using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManagment : MonoBehaviour
{
    public GameObject gameOverPanel;
    PlayerController playerController;
    public TextMeshProUGUI scorePointsText;
    public TextMeshProUGUI endGameScorePanelText;
    private float score;

    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        Time.timeScale = 1;
        scorePointsText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerController.obstacleCollision == true)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0;
            endGameScorePanelText.text = score > 1 ? $"Your score: {score} points" : $"Your score: {score} point";
        }

    }

    public void AddScorePoints()
    {
        score++;
        scorePointsText.text = score.ToString();
    }
}
