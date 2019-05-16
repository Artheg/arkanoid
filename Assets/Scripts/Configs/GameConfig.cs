using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New_GameConfig", menuName = "GameConfig")]
public class GameConfig : ScriptableObject
{
    [SerializeField]
    private float bricksDescendPeriod = 0.0f;
    public float BricksDescendPeriod
    {
        get
        {
            return bricksDescendPeriod;
        }
    }
}
