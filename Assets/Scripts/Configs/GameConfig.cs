using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New_GameConfig", menuName = "GameConfig")]
public class GameConfig : ScriptableObject
{
    public float BricksDescendPeriod = 0.0f;
    public int ScoreForRound = 100;

}
