using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockScript : MonoBehaviour
{public Transform hourHand;   // Reference to the hour hand
    public Transform minuteHand; // Reference to the minute hand
    public Transform secondHand; // Reference to the second hand

    void Update()
    {
        // Get the current time
        System.DateTime currentTime = System.DateTime.Now;

        // Calculate the angles for each hand
        float hourAngle = (currentTime.Hour % 12) * 30f + currentTime.Minute * 0.5f; // 30° per hour, 0.5° per minute
        float minuteAngle = currentTime.Minute * 6f + currentTime.Second * 0.1f;    // 6° per minute, 0.1° per second
        float secondAngle = currentTime.Second * 6f;                                // 6° per second

        // Rotate the hands
        if (hourHand != null)
            hourHand.localRotation = Quaternion.Euler(0, 0, -hourAngle); // Rotate around Z-axis
        if (minuteHand != null)
            minuteHand.localRotation = Quaternion.Euler(0, 0, -minuteAngle); // Rotate around Z-axis
        if (secondHand != null)
            secondHand.localRotation = Quaternion.Euler(0, 0, -secondAngle); // Rotate around Z-axis
    }
}
