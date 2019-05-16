using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasRenderer))]
public class StatusPanel : MonoBehaviour, IController
{
    public GameModel gameModel;
    public Text DescendTimerTF;
    public Text ScoreTF;

    private void Start() 
    {
        gameModel.OnScoreChangeEvent.AddListener(UpdateScoreTF);
        ScoreTF.text = "Score: 0"; 
    }

    public void UpdateScoreTF()
    {
        ScoreTF.text = "Score: " + gameModel.Score;
    }

    public void UpdateDescendTimerTF()
    {
        DescendTimerTF.text = "Next descend: " + string.Format("{0:N2}", gameModel.DescendSecondsLeft);
    }

    public void OnGameStart()
    {
        StartCoroutine(SlideAnimation(100));
    }

    public void OnGameEnd()
    {
        StartCoroutine(SlideAnimation(-100));        
    }

    private IEnumerator SlideAnimation(int targetX, float time = 0.5f)
    {
        Vector3 destination = new Vector2(targetX, transform.position.y);
        float elapsedTime = 0.0f;
        while(elapsedTime < time)
        {
            transform.position = Vector3.Lerp(transform.position, destination, elapsedTime / time);
            print("YIELDING " + transform.position + destination);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
