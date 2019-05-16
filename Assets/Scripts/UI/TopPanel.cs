using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopPanel : MonoBehaviour, IController
{
    public GameModel gameModel;
    public Text ResultTF;

    private void Start() 
    {
        gameModel.OnGameLostEvent.AddListener(OnGameLost);   
        gameModel.OnGameWonEvent.AddListener(OnGameWon);
        ResultTF.text = "ARKANOID";
    }

    private void OnGameWon()
    {
        ResultTF.text = "YOU WIN";
    }

    private void OnGameLost()
    {
        ResultTF.text = "YOU LOSE";
    }

    public void OnGameStart()
    {
        gameObject.SetActive(false);
    }

    public void OnGameEnd()
    {
        gameObject.SetActive(true);
    }
}
