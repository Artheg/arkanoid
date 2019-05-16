using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public GameObject LevelPrefab;
    
    public void SpawnLevel()
    {
        Instantiate(LevelPrefab);
    }
}
