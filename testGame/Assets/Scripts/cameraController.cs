using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{

    private Vector3 lookAtOffset;
    public float lookAtOffsetValue;

    private Transform player;
    private Animator playerAnimator;
    private Vector3 targetPosition;
    private float currentVelocity;

    public float maxCameraVelocity;
    public float acellaration;
    public Vector3 followOffset, idlleOffset;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerAnimator = player.GetComponent<Animator>();

        transform.position = player.position - player.forward * idlleOffset.z + player.up * idlleOffset.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerAnimator.GetBool("isWalking"))
        {
            // get player reference
            targetPosition = player.position - player.forward * followOffset.z + player.up * followOffset.y;
        }
        else
        {
            // get player reference
            targetPosition = player.position - player.forward * idlleOffset.z + player.up * idlleOffset.y;
        }
        // move camera towards target position
        if ((targetPosition - transform.position).magnitude > maxCameraVelocity)
        {
            transform.position += (targetPosition - transform.position).normalized * maxCameraVelocity;

        }
        else
        {
            transform.position = targetPosition;
            currentVelocity = 0;
        }

        // make camera look at player
        lookAtOffset = player.position + Vector3.up * lookAtOffsetValue;
        transform.LookAt(lookAtOffset);

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
