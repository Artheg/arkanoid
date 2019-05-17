using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New_BrickConfig", menuName = "BrickConfig")]
public class BrickConfig : ScriptableObject
{
   public int HP;
   public Color Color;
   public int Score;
}
