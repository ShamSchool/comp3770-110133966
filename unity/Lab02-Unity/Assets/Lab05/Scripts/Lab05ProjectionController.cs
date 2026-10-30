using UnityEngine;
[RequireComponent(typeof(Camera))]
public class Lab05ProjectionController : MonoBehaviour
{
    public bool orthographicMode;
    [Range(10f, 120f)]
    public float fieldOfView = 60f;
    [Min(0.1f)]
    public float orthographicSize = 7f;
    [Min(0.01f)]
    public float nearClip = 0.3f;
    [Min(1f)]
    public float farClip = 100f;
    Camera cameraComponent;
    void Awake()
    {
        cameraComponent = GetComponent<Camera>();
    }
    void LateUpdate()
    {
        cameraComponent.orthographic = orthographicMode;
        cameraComponent.fieldOfView = fieldOfView;
        cameraComponent.orthographicSize = orthographicSize;
        cameraComponent.nearClipPlane = nearClip;
        cameraComponent.farClipPlane = Mathf.Max(farClip, nearClip + 0.1f);
    }
}