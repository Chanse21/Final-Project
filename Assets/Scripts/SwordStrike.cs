using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordStrikeScript : MonoBehaviour
{

    public GameObject Esword;
    public Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
        }
    }

    IEnumerator SwordSwing()
    {
        Esword.GetComponent<Animator>().Play("SwordStrike");
        yield return new WaitForSeconds(1.0f);
        Esword.GetComponent<Animator>().Play("NewState");
    }
}
