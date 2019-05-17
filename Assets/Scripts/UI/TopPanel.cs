using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopPanel : MonoBehaviour, IGameListener
{
    [SerializeField]
    private GameModel gameModel;

    [SerializeField]
    private Text resultTF;

    private void Start() 
    {
        gameModel.OnGameLostEvent.AddListener(OnGameLost);   
        gameModel.OnGameWonEvent.AddListener(OnGameWon);
        resultTF.text = "ARKANOID";
    }

    private void OnGameWon()
    {
        resultTF.text = "YOU WIN";
    }

    private void OnGameLost()
    {
        resultTF.text = "YOU LOSE";
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
