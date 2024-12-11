//B00160681 Dean Smith
using UnityEngine;
using TMPro;

public class SpeedometerUI : MonoBehaviour
{
    [SerializeField] private Rigidbody carRigidbody;
    [SerializeField] private TMP_Text speedText; 
    [SerializeField] private bool useKPH = true; //true for kph, false for mph

    void Update()
    {
        if (carRigidbody != null && speedText != null)
        {
            float speed = carRigidbody.velocity.magnitude;
            float displaySpeed = useKPH ? speed * 3.6f : speed * 2.237f; //convert to km/h or mph
            speedText.text = Mathf.Round(displaySpeed) + (useKPH ? " kph" : " mph");
        }
    }
}
