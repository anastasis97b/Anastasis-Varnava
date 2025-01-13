using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 offset;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void OnMouseDown()
    {
        offset = transform.position - GetMouseWorldPosition();
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPosition() + offset;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = 10f; // Απόσταση από την κάμερα
        return mainCamera.ScreenToWorldPoint(mousePoint);
    }
}
