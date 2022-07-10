using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NPCPatrol : MonoBehaviour
{
    NavMeshAgent _navMeshAgent;
    [SerializeField] Transform[] waypoints;
    enum EnemyStates { Patrolling, Chasing }
    [SerializeField] EnemyStates currentState;                   // NPC State
    Transform objectToChase;                                            // �߰��� ��ġ
    int currentWaypoint = 0;                                                // ������  Waypoint 
    public void Start()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
        objectToChase = GameObject.FindGameObjectWithTag("Player").transform;       // �߰��� ��ġ:  Player ��ġ�� ���� 
        if (_navMeshAgent == null)
            Debug.LogError("Nav Mesh Agent component not found attached to " + gameObject.name);
        else
        {
            // Patrolling �����̸� ���� Waypoint�� �̵�
            if (currentState == EnemyStates.Patrolling) _navMeshAgent.SetDestination(waypoints[currentWaypoint].position);
        }
    }
    public void Update()
    {
        // Player�� NPC�� �Ÿ��� 10 �̻��̸� Patrolling ����, �׷��������� Chasing ���·� ����
        if (Vector3.Distance(transform.position, objectToChase.position) > 10f) currentState = EnemyStates.Patrolling;
        else currentState = EnemyStates.Chasing;

        //  Patrolling �����̸� ����, Chasing �����̸� Player �߰�
        if (currentState == EnemyStates.Patrolling)
        {
            //  ���� Waypoint���� ���� �Ÿ��� 1 �����̸� ���� Waypoint�� ����
            if (_navMeshAgent.remainingDistance <= 1.0f)
            {
                currentWaypoint++;
                if (currentWaypoint == waypoints.Length) currentWaypoint = 0;
            }
            _navMeshAgent.SetDestination(waypoints[currentWaypoint].position);
        }
        else _navMeshAgent.SetDestination(objectToChase.position);
    }
}
