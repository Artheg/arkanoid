using System;
using UnityEngine;

public class BaseTransformController : MonoBehaviour
{
    [SerializeField]
    protected Transform controlledTransform;

    protected bool IsAllowed = true;

    void Start()
    {
        if (controlledTransform == null)
            throw new Exception("BaseTransformController: Assign transform first!");
    }

    private void Update()
    {
        if (IsAllowed)
            HandleControls();
    }

    protected virtual void HandleControls()
    {
        throw new NotImplementedException();
    }

    public void AllowControls(bool allow)
    {
        IsAllowed = allow;
    }
}