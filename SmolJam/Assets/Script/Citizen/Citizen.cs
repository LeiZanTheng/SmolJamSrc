using UnityEngine;
using UnityEngine.AI;
public class Citizen : MonoBehaviour
{
    public static float CurrentReputation = 100f;
    NavMeshAgent CitizenAI;
    bool FindNewPatrolPoint = true;
    Transform CurPatrolPoint;
    [SerializeField]float Reputation = 30f;
    private void Start() {
        CurrentReputation = 100f;
        CitizenAI = GetComponent<NavMeshAgent>();
        CitizenAI.updateRotation = false;
        CitizenAI.updateUpAxis = false;
    }
    private void Update() {
        if(FindNewPatrolPoint)
        {
            FindNewPatrolPoint = false;
            CurPatrolPoint = GetPatrolPointPos.PatrolPoints[Random.Range(0, GetPatrolPointPos.PatrolPoints.Length)];
            CitizenAI.SetDestination(CurPatrolPoint.position);
        }
        if(Vector2.Distance(transform.position, CurPatrolPoint.position) <= 0.02f)
        {
            FindNewPatrolPoint = true;
        }
    }
    public void Die()
    {
        CurrentReputation -= Reputation;
    }
}
