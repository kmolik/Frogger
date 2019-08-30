using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Image life1, life2, life3, timeband, goScreen, buttonMenu, scoreMenu;

    public static int CurrentScore = 0;

    public Text scoreText;

    void Start()
    {
      goScreen.enabled = false;
      scoreText.text = CurrentScore.ToString();
    }

    void Update()
    {
        
    }

    public void UpdatePlayerLivesHUD(int playerHealth)
    {
        switch (playerHealth)
        {
            case 3:
                life1.enabled = true;
                life2.enabled = true;
                life3.enabled = true;
                goScreen.enabled = false;
                break;
            case 2:
                life1.enabled = true;
                life2.enabled = true;
                life3.enabled = false;
                goScreen.enabled = false;
                break;
            case 1:
                life1.enabled = true;
                life2.enabled = false;
                life3.enabled = false;
                goScreen.enabled = false;
                break;
            case 0:
                life1.enabled = false;
                life2.enabled = false;
                life3.enabled = false;
                goScreen.enabled = true;
                break;
        }
    }

    public void EndMenu()
    {
        
    }

    public void AddPionts()
    {
        CurrentScore += 100;
        scoreText.text = CurrentScore.ToString();

    }

    public void ResetPoints()
    {
        CurrentScore = 0;
        scoreText.text = CurrentScore.ToString();
    }

}
