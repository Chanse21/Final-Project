using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class CameraMovement : MonoBehaviour
{
    public float sensitivity = 5.0f;
    public GameObject cameraeyes;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Optional: Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //If my mouse goes left/right my body moves left/right
        float xRot = Input.GetAxis("Mouse X") * sensitivity;
        transform.Rotate(0, xRot, 0);

        //If my mouse goes up/down my aim (but not body) go up/down
        float yRot = -Input.GetAxis("Mouse Y") * sensitivity;
        cameraeyes.transform.Rotate(yRot, 0, 0);
    }
}
