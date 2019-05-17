using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    private Vector2 levelSize;
    
    [SerializeField]
    private List<GameObject> brickPrefabs = new List<GameObject>();

    [SerializeField]
    private float brickXSize;

    public GameObject GenerateLevel(Transform levelContainer)
    {
        GameObject brickContainer = new GameObject("BrickContainer", typeof(BrickContainer));
        brickContainer.transform.SetParent(levelContainer);
        brickContainer.transform.localPosition = Vector2.zero;

        for (int i = 0; i < levelSize.y; i++)
        {
            for (int j = 0; j < levelSize.x; j++)
            {
                GameObject prefab = brickPrefabs[Random.Range(0, brickPrefabs.Count)];
                GameObject brickGameObject = Instantiate(prefab, brickContainer.transform);
                brickGameObject.transform.localPosition = new Vector2(j * brickXSize, -i);
            }
        }

        return brickContainer;
    }
}