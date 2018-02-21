using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Animator animator;
	
	
	void Update () {
		if (Input.GetAxis("Vertical") > 0 )
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
        animator.SetBool("isRunning", Input.GetButton("Run"));
        animator.SetFloat("direction", Input.GetAxis("Horizontal"));

        if (animator.GetBool("isWalking"))
        {
            transform.Rotate(transform.up, Input.GetAxis("Horizontal") * Time.deltaTime * 100);
        }

	}
}
