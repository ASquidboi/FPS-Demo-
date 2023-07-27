using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public float rotationSpeed = 1f; // Adjust this to control the speed of rotation

    void Update()
    {
        // Rotate the light object around the Y-axis to simulate day/night cycle
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}

