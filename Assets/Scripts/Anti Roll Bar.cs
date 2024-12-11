//B00160681 Dean Smith
using UnityEngine;

public class AntiRollBar : MonoBehaviour
{
    public WheelCollider wheelL; //left wheel collider
    public WheelCollider wheelR; //right wheel collider
    public float antiRoll = 5000.0f; //anti roll force

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        WheelHit hit;
        float travelL = 1.0f;
        float travelR = 1.0f;

        //get left wheel ground contact
        bool groundedL = wheelL.GetGroundHit(out hit);
        if (groundedL)
        {
            travelL = (-wheelL.transform.InverseTransformPoint(hit.point).y - wheelL.radius) / wheelL.suspensionDistance;
        }

        //get right wheel ground contact
        bool groundedR = wheelR.GetGroundHit(out hit);
        if (groundedR)
        {
            travelR = (-wheelR.transform.InverseTransformPoint(hit.point).y - wheelR.radius) / wheelR.suspensionDistance;
        }

        //calculate anti roll force
        float antiRollForce = (travelL - travelR) * antiRoll;

        //apply forces to keep car stable
        if (groundedL)
            rb.AddForceAtPosition(wheelL.transform.up * -antiRollForce,
                wheelL.transform.position);

        if (groundedR)
            rb.AddForceAtPosition(wheelR.transform.up * antiRollForce,
                wheelR.transform.position);
    }
}
