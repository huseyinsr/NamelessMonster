using UnityEngine;

public class CameraRange : MonoBehaviour
{
    public Camera targetCamera;

    public float zoomSpeed = 0.4f;
    public float minZoom = 1f;
    public float maxZoom = 5f;

    void Start()
    {
        // Eðer Inspector’dan atanmamýþsa ana kamerayý al
        if (targetCamera == null)
            targetCamera = Camera.main;
    }

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll != 0f)
        {
            targetCamera.orthographicSize -= scroll * zoomSpeed;
            targetCamera.orthographicSize = Mathf.Clamp(
                targetCamera.orthographicSize,
                minZoom,
                maxZoom
            );
        }
    }
}