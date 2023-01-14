using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shakeable : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = gameObject.GetComponentInParent<Animator>();
        if(animator == null)
        {
            Debug.LogError("Animator is null on Shakeable script");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("Shake Tree");
        }
    }

}
