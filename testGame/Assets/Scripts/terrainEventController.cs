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
        // guarda a posiçao no terreno do click
        target = eventData.pointerCurrentRaycast.worldPosition;
        // caso encontre uma posiçao para se mover
        if (NavMesh.SamplePosition(target, out hit, 0.5f, NavMesh.AllAreas)) {
            // chama o metodo do script no player
            player.goThere(hit.position);
        }
    }
     
   
}
