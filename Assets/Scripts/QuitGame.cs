using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void DoQuit()
    {
        Debug.Log("Player has quit the game");
        Application.Quit();
    }
}
