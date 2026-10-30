using UnityEngine;
public class Lab05TrackingCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 6f, -10f);
    public bool smoothTracking = true;
    [Min(0.1f)]
    public float trackingRate = 4f;

    public bool predictiveTracking;
    [Min(0f)] public float predictionTime = 0.6f;

    Vector3 previousTargetPosition;
    Vector3 measuredVelocity;
    bool hasPreviousSample;


    protected virtual void LateUpdate()
    {
        if (target == null) return;

        
        Vector3 displacement = target.position - previousTargetPosition;

  
        if (hasPreviousSample && Time.deltaTime > 0f)
        {
            measuredVelocity = displacement / Time.deltaTime;
        }
        else
        {
            measuredVelocity = Vector3.zero;
        }

        Vector3 predictedPosition = target.position;
        if (predictiveTracking)
        {
            predictedPosition = target.position + measuredVelocity * predictionTime;
        }

        
        Vector3 desiredPosition = predictedPosition + offset;
        Quaternion desiredRotation = Quaternion.LookRotation(predictedPosition - transform.position);

        float alpha = 1f - Mathf.Exp(-trackingRate * Time.deltaTime);
        if (smoothTracking || predictiveTracking)
        {
            transform.position = Vector3.Lerp(transform.position,desiredPosition,alpha);
            transform.rotation = Quaternion.Slerp(transform.rotation,desiredRotation,alpha);
        }
        else
        {
            transform.position = desiredPosition;
            transform.rotation = desiredRotation;
        }

        previousTargetPosition = target.position;
        hasPreviousSample = true;
    }

}