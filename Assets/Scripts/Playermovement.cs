using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Playermovement : MonoBehaviour
{
    public int speed;
    public Vector3 jump;
    public float jumpForce = 3.0f;
    public bool isGrounded;
    Rigidbody rb;
    public float StrikeDamage;
    float health, maxHealth = 80f;
    public FloatingHealthBar healthBar;
    public AudioSource audioSource;
    public AudioClip collisionSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 3.0f, 0.0f);
        health = maxHealth;
        healthBar.UpdateHealthBar(health, maxHealth);
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

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        healthBar.UpdateHealthBar(health, maxHealth);
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }


    void OnCollisionExit(Collision collision)
    {
        Debug.Log(collision.collider.tag);
        if (collision.collider.CompareTag("Esword"))
        {
            TakeDamage(StrikeDamage);
            audioSource.PlayOneShot(collisionSound);
        }
    }

}