using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour, IController
{
    public Button StartButton;
    
    public void OnGameStart()
    {
        gameObject.SetActive(false);
    }

    public void OnGameEnd()
    {
        gameObject.SetActive(true);
    }
}
