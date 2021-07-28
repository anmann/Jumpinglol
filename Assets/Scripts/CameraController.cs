using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float cameraMinX;
    [SerializeField] float cameraMinY;
    [SerializeField] float cameraMaxY;

    [SerializeField] private Transform player;

    // target size of the view port
    public Vector2 targetViewportSizeInPixels = new Vector2(480.0f, 320.0f);

    // Snap movement of the camera to pixels
    public bool lockToPixels = true;

    // The number of target pixels in every Unity unit
    public float pixelsPerUnit = 32.0f;

    private Camera _camera;
    private int _currentScreenWidth = 0;
    private int _currentScreenHeight = 0;

    private float _pixelLockedPPU = 32.0f;
    private Vector2 _winSize;

    protected void Start()
    {
        _camera = this.GetComponent<Camera>();
        if (!_camera)
        {
            Debug.LogWarning("How do you not have a camera");
        }
        else
        {
            _camera.orthographic = true;
            ResizeCamToTargetSize();
        }
    }

    public void ResizeCamToTargetSize()
    {
        if (_currentScreenWidth != Screen.width || _currentScreenHeight != Screen.height)
        {
            float percentageX = Screen.width / targetViewportSizeInPixels.x;
            float percentageY = Screen.height / targetViewportSizeInPixels.y;
            float targetSize = 0.0f;

            if (percentageX > percentageY)
            {
                targetSize = percentageY;
            }
            else
            {
                targetSize = percentageX;
            }

            int floored = Mathf.FloorToInt(targetSize);
            if (floored < 1)
            {
                floored = 1;
            }

            float camSize = ((Screen.height / 2) / floored) / pixelsPerUnit;
            _camera.orthographicSize = camSize;
            _pixelLockedPPU = floored * pixelsPerUnit;
        }
        _winSize = new Vector2(Screen.width, Screen.height);
    }

    private void Update()
    {
        if (_winSize.x != Screen.width || _winSize.y != Screen.height)
        {
            ResizeCamToTargetSize();
        }

        float x = player.position.x;
        float y = player.position.y;
        float z = transform.position.z;

        if (player.transform.position.x < cameraMinX)
        {
            x = cameraMinX;
        }
        if (player.transform.position.y < cameraMinY)
        {
            y = cameraMinY;
        }
        if (player.transform.position.y > cameraMaxY)
        {
            y = cameraMaxY;
        }
        _camera.transform.position = new Vector3(x, y, z);

    }

}
