using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed;
    public GameObject player;
    public float SwordDamage;
    float health, maxHealth = 100f;
    FloatingHealthBar healthBar;


    private float distance;

    public AudioSource audioSource;
    public AudioClip collisionSound;
    private void Awake()
    {
        healthBar = GetComponentInChildren<FloatingHealthBar>();
    }
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthBar.UpdateHealthBar(health, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        Vector3 direction = player.transform.position - transform.position;

        transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
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
        if (collision.collider.CompareTag("Sword"))
        {
         TakeDamage(SwordDamage);
         audioSource.PlayOneShot(collisionSound);
        }
    }
}