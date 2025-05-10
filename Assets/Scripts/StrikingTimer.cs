using UnityEngine;

public class StrikingTimer : MonoBehaviour
{
    public float strikeDuration = 2f; // Total time for the strike
    private float currentTime = 0f;
    private bool isStriking = false;

    void Start()
    {
        // You can initialize variables here if needed
    }

    void Update()
    {
        if (isStriking)
        {
            currentTime -= Time.deltaTime; // Reduce timer by time elapsed
            if (currentTime <= 0)
            {
                // Stop timer and allow another strike
                isStriking = false;
                currentTime = 0;
                // Add logic to allow another strike here
                Debug.Log("Strike ready!");
            }
        }
    }

    // Start the strike timer
    public void StartStrikeTimer()
    {
        isStriking = true;
        currentTime = strikeDuration;
    }

    // Stop the strike timer
    public void StopStrikeTimer()
    {
        isStriking = false;
    }
}
