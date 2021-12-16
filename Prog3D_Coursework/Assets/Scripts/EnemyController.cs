using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour
{
    private enum State{willMoveToDestination, movingToDestination, finishedMovingToDestination};
    
    [SerializeField] float lookRadius = 10f;
    [SerializeField] private float speed = 0.1f;
    [SerializeField] private GameObject AlarmSetDestination;
    private Transform targetPlayer;
    private Animator enemyAnimator;

    private State currentState = State.willMoveToDestination;
    private float distanceFromBottom;

    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        targetPlayer = GameManager.Instance.Player.transform;
        agent = GetComponent<NavMeshAgent>();
        enemyAnimator = transform.GetChild(0).gameObject.GetComponent<Animator>();
        enemyAnimator.SetBool("Open_Anim", false);
        distanceFromBottom = Random.Range(0f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.AlarmSet && currentState==State.willMoveToDestination && !GameManager.Instance.PlayerPassedPoint)
        {
            FaceTarget(AlarmSetDestination.transform);
            enemyAnimator.SetBool("Roll_Anim", true);
            transform.position = Vector3.MoveTowards(transform.position, AlarmSetDestination.transform.position, Time.fixedDeltaTime * speed);
            currentState = State.movingToDestination;
        }

        if (GameManager.Instance.AlarmSet && currentState == State.movingToDestination &&
            !GameManager.Instance.PlayerPassedPoint)
        {
            float distance = Vector3.Distance(AlarmSetDestination.transform.position, transform.position);
            if (distance <= distanceFromBottom)
            {
                enemyAnimator.SetBool("Roll_Anim", false);
                enemyAnimator.SetBool("Open_Anim", true);
                transform.position += Vector3.zero;
                FaceTarget(targetPlayer);
                currentState = State.finishedMovingToDestination;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, AlarmSetDestination.transform.position,
                    Time.deltaTime * speed);
                FaceTarget(AlarmSetDestination.transform);
            }
        }

        if (GameManager.Instance.AlarmSet && currentState == State.finishedMovingToDestination &&
            !GameManager.Instance.PlayerPassedPoint)
        {
            FaceTarget(targetPlayer);
        }
        
        // if the player has past the bottom of the stairs, start to follow them
        if (GameManager.Instance.AlarmSet && currentState == State.finishedMovingToDestination &&
            GameManager.Instance.PlayerPassedPoint)
        {
            float distance = Vector3.Distance(targetPlayer.transform.position, transform.position);
            if (distance <= lookRadius)
            {
                agent.SetDestination(targetPlayer.position);
                enemyAnimator.SetBool("Walk_Anim", true);
                if (distance <= agent.stoppingDistance)
                {
                    FaceTarget(targetPlayer);
                }
            }
        }
    }

    void FaceTarget(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
