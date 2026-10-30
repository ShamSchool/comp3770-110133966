using UnityEngine;
public class Lab05TargetMotion : MonoBehaviour
{
    public Vector3[] waypoints = {
        new Vector3(-4f, 1f, -4f), new Vector3(4f, 1f, -4f), new Vector3(4f, 1f, 4f), new Vector3(-4f, 1f, 4f)
    };
    [Min(0.1f)]
    public float speed = 3f;
    int next;
    void Start()
    {
        if (waypoints.Length > 0) transform.position = waypoints[0];
        next = waypoints.Length > 1 ? 1 : 0;
    }
    void Update()
    {
        if (waypoints.Length < 2) return;
        transform.position = Vector3.MoveTowards(transform.position, waypoints[next], speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, waypoints[next]) < 0.001f) next = (next + 1) % waypoints.Length;
    }
}