using UnityEngine;
public class Lab05CoordinateReporter : MonoBehaviour
{
    public Camera viewCamera;
    public Transform target;
    void OnGUI()
    {
        if (viewCamera == null || target == null) return;
        Vector3 world = target.position;
        Vector3 cameraLocal = viewCamera.transform.InverseTransformPoint(world);
        Vector3 viewport = viewCamera.WorldToViewportPoint(world);
        Vector3 screen = viewCamera.WorldToScreenPoint(world);
        bool visible = viewport.z > 0f && viewport.x >= 0f && viewport.x <= 1f && viewport.y >= 0f && viewport.y <= 1f;
        GUI.Label(new Rect(10, 10, 1000, 90), $"World {world} | Camera {cameraLocal} | Screen {screen} | Visible {visible}");
    }
}