using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class President : MonoBehaviour
{
    NavMeshAgent PresidentAI;
    Transform Player;
    Transform EscapeCar;
    [SerializeField]float DistanceToPlayer;
    [SerializeField]float AutoEscapeRange;
    [SerializeField]float PresidentSpeed;
    private void Start() {
        PresidentAI = GetComponent<NavMeshAgent>();
        PresidentAI.updateRotation = false;
        PresidentAI.updateUpAxis = false;
        PresidentAI.speed = PresidentSpeed;
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        EscapeCar = GameObject.FindGameObjectWithTag("EscapeCar").GetComponent<Transform>();
    }
    private void Update() {
        //followPlayer
        if(Vector2.Distance(transform.position, Player.position) > DistanceToPlayer)
        {
            PresidentAI.SetDestination(Player.position);
        }
        if(Vector2.Distance(transform.position, Player.position) <= DistanceToPlayer && !(Vector2.Distance(transform.position, EscapeCar.position) <= AutoEscapeRange))
        {
            PresidentAI.SetDestination(transform.position);
        }
        //auto Escape When Come Close To The Car
        if(Vector2.Distance(transform.position, EscapeCar.position) <= AutoEscapeRange)
        {
            PresidentAI.SetDestination(EscapeCar.position);
        }
    }
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, DistanceToPlayer);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, AutoEscapeRange);
    }
}
