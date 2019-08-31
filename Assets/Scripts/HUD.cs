using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    public Image life1, life2, life3, timeband, goScreen, winScreen;

    public Button restartBtn, quitBtn;

    public static int CurrentScore = 0;

    public Text scoreText;

    void Start()
    {
        winScreen.enabled = false;
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
                DestroyFrog();
                ResetPoints();
                break;
        }
    }


    public void AddPionts()
    {
        CurrentScore += 100;
        scoreText.text = CurrentScore.ToString();
        WinCondition();

    }

    public void ResetPoints()
    {
        CurrentScore = 0;
        scoreText.text = CurrentScore.ToString();
    }
    public void DestroyFrog()
    {
        Destroy(GameObject.FindWithTag("Frog"));
    }

    public void WinCondition()
    {
        if (CurrentScore == 500)
        {
            winScreen.enabled = true;
            DestroyFrog();
        }
        else
        {
            winScreen.enabled = false;
        }
    }
}
