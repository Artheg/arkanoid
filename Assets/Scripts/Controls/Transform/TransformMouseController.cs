using UnityEngine;

public class TransformMouseController : BaseTransformController
{
    private bool isMouseDrag;

    protected override void HandleControls()
    {
        if (Input.GetMouseButtonDown(0))
            isMouseDrag = true;
        else if (Input.GetMouseButtonUp(0))
            isMouseDrag = false;

        if (isMouseDrag)
            HandleMouseDrag();
    }

    private void HandleMouseDrag()
    {
        var newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPos.y = controlledTransform.transform.position.y;
        newPos.z = 0;
        controlledTransform.position = newPos;
    }
}
