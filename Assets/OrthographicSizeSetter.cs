using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class OrthographicSizeSetter : MonoBehaviour
{
    public SpriteRenderer main;
    void Update()
    {
        // float size = main.bounds.size.x * Screen.height / Screen.width * 0.5f;
        float screenRatio = Screen.width / Screen.height;
        float targetRatio = main.bounds.size.x / main.bounds.size.y;
        if (screenRatio >= targetRatio)
        {
            Camera.main.orthographicSize = main.bounds.size.y / 2;
        }
        else
        {
            float differenceInSize = targetRatio / screenRatio;
            Camera.main.orthographicSize = main.bounds.size.y / 2 * differenceInSize;
        }
    }

}
