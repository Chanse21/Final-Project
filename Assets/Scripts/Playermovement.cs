using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public int speed;
    public Vector3 jump;
    public float jumpForce = 3.0f;
    public bool isGrounded;
    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 3.0f, 0.0f);
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;

        if (Input.GetKey("d"))
        {
            newPosition += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            newPosition += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey("w"))
        {
            newPosition += Vector3.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            newPosition += Vector3.back * speed * Time.deltaTime;
        }
        transform.position = newPosition;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
}