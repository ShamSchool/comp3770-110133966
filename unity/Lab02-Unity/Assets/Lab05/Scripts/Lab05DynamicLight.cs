using UnityEngine;
[RequireComponent(typeof(Light))]
public class Lab05DynamicLight : MonoBehaviour
{
    public float minIntensity = 0.5f;
    public float maxIntensity = 4f;
    [Min(0.1f)]
    public float transitionSeconds = 3f;
    public Color firstColour = Color.blue;
    public Color secondColour = Color.yellow;
    Light lightComponent;
    Vector3 initialPosition;
    void Awake()
    {
        lightComponent = GetComponent<Light>();
        initialPosition = transform.position;
    }
    void Update()
    {
        float t = (Mathf.Sin(Time.time * Mathf.PI / transitionSeconds) + 1f) * 0.5f;
        lightComponent.intensity = Mathf.Lerp(minIntensity, maxIntensity, t);
        lightComponent.color = Color.Lerp(firstColour, secondColour, t);
        transform.position = initialPosition + new Vector3(0f, 0.5f * Mathf.Sin(Time.time), 0f);
    }
}