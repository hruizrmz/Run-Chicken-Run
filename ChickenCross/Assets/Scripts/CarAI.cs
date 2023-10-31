// References:
//  How to Make a Simple Enemy Patrol AI in Unity in 2 minutes by FPS Builders https://www.youtube.com/watch?v=gcT6NmN3Zyo
//  FULL 3D ENEMY AI in 6 MINUTES! || Unity Tutorial by Dave / GameDevelopment https://www.youtube.com/watch?v=UjkSFoLxesw

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarAI : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private LayerMask whatIsGround;

    private int currentPoint;
    private Vector3 walkPoint;
    private bool walkPointSet;
    [SerializeField] private Transform[] drivePoints;

    [SerializeField] private Transform carModel;
    
    public int damage;

    private void Start()
    {
        currentPoint = 0;
    }

    private void Update()
    {
        if (!walkPointSet)
        {
            currentPoint = (currentPoint + 1) % drivePoints.Length;
            walkPoint = drivePoints[currentPoint].position;
            agent.SetDestination(walkPoint);
            walkPointSet = true;
        }

        Vector3 distanceToPoint = carModel.position - walkPoint;
        if (distanceToPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }
}
