using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    private Scene scene;

    public void RestartTheGame()
    {
        scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
