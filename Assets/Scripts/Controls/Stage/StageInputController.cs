using UnityEngine;
using UnityEngine.Events;

public class StageInputController : MonoBehaviour
{
    public UnityEvent OnLeftMouseDownEvent;
    public UnityEvent OnRightMouseDownEvent;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            OnLeftMouseDown();
        if (Input.GetMouseButtonDown(1))
            OnRightMouseDown();
    }

    private void OnLeftMouseDown()
    {
        if (OnLeftMouseDownEvent != null)
            OnLeftMouseDownEvent.Invoke();
    }

    private void OnRightMouseDown()
    {
        if (OnRightMouseDownEvent != null)
            OnRightMouseDownEvent.Invoke();
    }
}
