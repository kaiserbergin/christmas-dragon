using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private float _targetRatio = 6.0f / 9.0f;


    [SerializeField]
    private GameObject _boundary;

    private Vector2 _resolution;
    // Start is called before the first frame update
    void Start()
    {
        _resolution = new Vector2(Screen.currentResolution.width, Screen.currentResolution.height);
        SetOrthographicSize();
    }

    // Update is called once per frame
    void Update()
    {
        if (_resolution.x != Screen.currentResolution.width || _resolution.y != Screen.currentResolution.height)
        {
            Debug.Log("Updating after resolution change.");
            SetOrthographicSize();
        }
    }

    private void SetOrthographicSize()
    {
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float screenToTargetRatio = screenRatio / _targetRatio;
        var cameraRect = Camera.main.rect;

        Debug.Log(screenRatio);
        Debug.Log(_targetRatio);

        if (screenRatio >= _targetRatio)
        {
            Camera.main.orthographicSize = _boundary.transform.localScale.z / 2;

            float scaleWidth = 1.0f / screenToTargetRatio;
            cameraRect.width = scaleWidth;
            cameraRect.height = 1.0f;
            cameraRect.x = (1.0f - scaleWidth) / 2.0f;
            cameraRect.y = 0;

            Camera.main.rect = cameraRect;
        }
        else
        {
            float targetToScreenRatio = _targetRatio / screenRatio;
            Camera.main.orthographicSize = _boundary.transform.localScale.z / 2 * targetToScreenRatio;

            cameraRect.width = 1.0f;
            cameraRect.height = screenToTargetRatio;
            cameraRect.x = 0;
            cameraRect.y = (1.0f - screenToTargetRatio) / 2.0f;

            Camera.main.rect = cameraRect;
        }

        Debug.Log(Camera.main.orthographicSize);
    }
}
