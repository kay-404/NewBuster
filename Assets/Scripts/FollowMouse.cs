using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private Camera mainCamera;

    public bool centerCamera = false;

    public float maxSpeed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (centerCamera == false)
        {
            FollowMousePosition();
        }
        else
        {
            transform.position = Vector3.zero;
        }
    }

    public void CenterCamera(bool zero)
    {
        centerCamera = zero;
    }
    private void FollowMousePosition()
    {
        transform.position = GetWorldPositionFromMouse();
    }

    private Vector2 GetWorldPositionFromMouse()
    {
        return mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }
}
