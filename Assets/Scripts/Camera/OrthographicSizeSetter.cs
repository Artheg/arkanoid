using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class OrthographicSizeSetter : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer guide;

    void Start()
    {
        float screenRatio = Screen.width / Screen.height;
        float targetRatio = guide.bounds.size.x / guide.bounds.size.y;
        if (screenRatio >= targetRatio)
        {
            Camera.main.orthographicSize = guide.bounds.size.y / 2;
        }
        else
        {
            float differenceInSize = targetRatio / screenRatio;
            Camera.main.orthographicSize = guide.bounds.size.y / 2 * differenceInSize;
        }
    }

}
