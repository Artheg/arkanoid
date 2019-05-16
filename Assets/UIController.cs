using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private List<IController> UIList = new List<IController>();
    private void Start()
    {
        GetComponentsInChildren<IController>(UIList);
    }

    public void OnGameStart()
    {
        for (int i = 0; i < UIList.Count; i++)
            UIList[i].OnGameStart();
    }

    public void OnGameEnd()
    {
        for (int i = 0; i < UIList.Count; i++)
            UIList[i].OnGameEnd();
    }
}
