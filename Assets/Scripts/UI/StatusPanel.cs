using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasRenderer))]
public class StatusPanel : MonoBehaviour, IGameListener
{
    [SerializeField]
    private GameModel gameModel;

    [SerializeField]
    private Text descendTimerTF;

    [SerializeField]
    private Text scoreTF;

    private void Start() 
    {
        gameModel.OnScoreChangeEvent.AddListener(UpdateScoreTF);
        scoreTF.text = "Score: 0"; 
    }

    public void UpdateScoreTF()
    {
        scoreTF.text = "Score: " + gameModel.Score;
    }

    public void UpdateDescendTimerTF()
    {
        descendTimerTF.text = "Next descend: " + string.Format("{0:N2}", gameModel.DescendSecondsLeft);
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
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
