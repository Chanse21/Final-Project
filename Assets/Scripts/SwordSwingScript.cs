using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSwingScript : MonoBehaviour
{

    public GameObject Sword;
    public Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
        }
    }


    IEnumerator SwordSwing()
    {
        Sword.GetComponent<Animator>().Play("SwordSwing");
        yield return new WaitForSeconds(1.0f);
        Sword.GetComponent<Animator>().Play("NewState");
    }
}
