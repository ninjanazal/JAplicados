using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{

    public Animator animator;

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.isStopped = true;
    }

    void Update()
    {
        // verifica se ainda existe caminho 
        if ((agent.hasPath || agent.pathPending) && (agent.remainingDistance > agent.stoppingDistance))
            agent.isStopped = false;

        // verifica se nao existe caminho
        else if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance &&
            (!agent.hasPath || agent.velocity.sqrMagnitude == 0f))
            agent.isStopped = true;


        animator.SetBool("isWalking", !agent.isStopped);

        if (animator.GetBool("isWalking"))
        {
            agent.speed = 2f;
            if (Input.GetButton("Run"))
                agent.speed = 5f;
        }
        animator.SetBool("isRunning", Input.GetButton("Run"));
        animator.SetFloat("direction", Input.GetAxis("Horizontal"));
    }

    /*
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
    */


    public void goThere(Vector3 pos)
    {
        StopAllCoroutines();
        StartCoroutine(SetDestination(pos));
    }

    // corrutina
    IEnumerator SetDestination(Vector3 pos)
    {
        while (animator.GetCurrentAnimatorStateInfo(0).IsName("turnRight") || animator.GetCurrentAnimatorStateInfo(0).IsName("turnLeft"))
        {
            yield return new WaitForSeconds(0.1f);
        }
        agent.SetDestination(pos);
    }
}
