using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New_BallConfig", menuName = "BallConfig")]
public class BallConfig : ScriptableObject
{
   public int AttackPower;
   public Color Color;
   public int Speed;
}
