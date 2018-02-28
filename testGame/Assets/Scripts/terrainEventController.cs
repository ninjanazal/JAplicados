using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.AI;

public class terrainEventController : MonoBehaviour, IPointerClickHandler
{
    private Vector3 target;
    private NavMeshHit hit;

    private PlayerController player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponentInParent<PlayerController>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        target = eventData.pointerCurrentRaycast.worldPosition;

        // gera espera no ponto World em click
        GameObject s = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        s.transform.position = eventData.pointerCurrentRaycast.worldPosition;
        s.transform.localScale = Vector3.one * 0.5f;
        Destroy(s.GetComponent<SphereCollider>());

        if (NavMesh.SamplePosition(target, out hit, 2.0f, NavMesh.AllAreas)) {
            GameObject c = GameObject.CreatePrimitive(PrimitiveType.Cube);
            c.transform.position = hit.position;
            c.transform.localScale = Vector3.one * 0.4f;
            Destroy(c.GetComponent<BoxCollider>());

            player.goThere(hit.position);
        }
    }
     
   
}
