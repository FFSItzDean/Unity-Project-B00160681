//B00160681 Dean Smith
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarFlipCheck : MonoBehaviour
{
    private float flipTime = 0f;
    private bool isFlipped = false;
    private const float FLIP_THRESHOLD = 2f;  //time in seconds before game over when flipped
    
    void Update()
    {
        //check if car is upside down (y-up vector less than -0.5)
        if (transform.up.y < -0.5f)
        {
            if (!isFlipped)
            {
                isFlipped = true;
                flipTime = Time.time;
            }
            else if (Time.time - flipTime >= FLIP_THRESHOLD)
            {
                GameManager.Instance.GameOver("Car Flipped!");
            }
        }
        else
        {
            isFlipped = false;
            flipTime = 0f;
        }
    }
}
