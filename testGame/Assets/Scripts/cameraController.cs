using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    private Transform player;
    private Animator playerAnimator;
    private Vector3 targetPosition;
    private float currentVelocity;
    private bool zoomingIn = true;

    public float slowDownDistance;
    public float maxCameraVelocity;
    public float acellaration;
    public Vector3 followOffset, idlleOffset;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerAnimator = player.GetComponentInParent<Animator>();

        transform.position = player.position - player.forward * idlleOffset.z + player.up * idlleOffset.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerAnimator.GetBool("isWalking"))
        {
            if (zoomingIn)
                currentVelocity = 0;
            // Place camera in top-down position
            targetPosition = player.position - player.forward * followOffset.z + player.up * followOffset.y;
        }
        else
        {
            if (!zoomingIn)
                currentVelocity = 0;
            // Place camera in back position
            targetPosition = player.position - player.forward * idlleOffset.z + player.up * idlleOffset.y;
        }

        zoomingIn = !playerAnimator.GetBool("isWalking");

        if (zoomingIn && (transform.position - targetPosition).magnitude < slowDownDistance)
        {
            currentVelocity = Time.deltaTime * (transform.position - targetPosition).magnitude * maxCameraVelocity / slowDownDistance;
        }
        else
        {
            currentVelocity = currentVelocity + acellaration * Time.deltaTime;
            if (currentVelocity > maxCameraVelocity)
                currentVelocity = maxCameraVelocity;
        }



        // move camera towards target position
        if ((targetPosition - transform.position).magnitude >
               currentVelocity)
        {
            transform.position += (targetPosition - transform.position).normalized * currentVelocity;
        }
        else
        {
            transform.position = targetPosition;
        }
        // make camera look at player
        transform.LookAt(player.position);


    }

    /* private void setCamera()
     {
         // get player reference

         player = GameObject.FindGameObjectWithTag("Player").transform;
         lookAtOffset = player.position + Vector3.up * lookAtOffsetValue;
         //Place camera in top-down position
         transform.position = player.position - player.forward * followOffset.z + player.up * followOffset.y;

         // make camera look at player
         transform.LookAt(lookAtOffset);
     }
     */
}
