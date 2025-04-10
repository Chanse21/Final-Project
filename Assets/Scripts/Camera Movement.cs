using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class CameraMovement : MonoBehaviour
{
    public float sensitivity = 5.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get mouse Input
        float horizontalInput = Input.GetAxis("Mouse X");
        float verticalInput = Input.GetAxis("Mouse Y");

        //Calculate rotation
        //Space.Self: Rotation is relative to the camera's local axes.
        //Space.World: Rotation is relative to the world's axes.
        transform.Rotate(Vector3.right, -verticalInput * sensitivity, Space.Self); //Pitch(rotation around the x-axis of an object)
        transform.Rotate(Vector3.right, -horizontalInput * sensitivity, Space.World); //Yaw(rotation around the Y-axis of an object, causing it to turn left or right)

        //Optional: Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
    }
}
