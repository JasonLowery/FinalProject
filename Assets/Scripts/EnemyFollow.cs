using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    private NavMeshAgent agent;

    public Transform target;

    public int damage;

    void Awake()

    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
        if(target != null)
        {
            agent.SetDestination(target.position);
        }
    }

}
