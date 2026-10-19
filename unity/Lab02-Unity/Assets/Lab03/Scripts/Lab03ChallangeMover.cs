using UnityEngine;

public class Lab03ChallangeMover : MonoBehaviour
{
    public float speed = 4f;
    private Vector3 direction;

    void Start()
    {
        direction = Random.insideUnitSphere.normalized;

        direction.y = 0f;
        direction.Normalize();
    }
    void Update()
    {
        
        transform.position += direction * speed * Time.deltaTime;
    }
}
