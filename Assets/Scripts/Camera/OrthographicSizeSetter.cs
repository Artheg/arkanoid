using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class OrthographicSizeSetter : MonoBehaviour
{
    public SpriteRenderer Guide;
    void Start()
    {
        float screenRatio = Screen.width / Screen.height;
        float targetRatio = Guide.bounds.size.x / Guide.bounds.size.y;
        if (screenRatio >= targetRatio)
        {
            Camera.main.orthographicSize = Guide.bounds.size.y / 2;
        }
        else
        {
            float differenceInSize = targetRatio / screenRatio;
            Camera.main.orthographicSize = Guide.bounds.size.y / 2 * differenceInSize;
        }
    }

}
