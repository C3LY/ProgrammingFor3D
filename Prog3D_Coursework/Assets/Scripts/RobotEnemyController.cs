//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class RobotEnemyController : EnemyController
//{
//    // Start is called before the first frame update
//    void Start()
//    {
//        target = GameManager.Instance.Player.transform;
//        agent = GetComponent<NavMeshAgent>();
//    }
//
//    // Update is called once per frame
//    void Update()
//    {
//        float distance = Vector3.Distance(target.position, transform.position);
//
//        if (distance <= lookRadius)
//        {
//            agent.SetDestination(target.position);
//
//            if (distance <= agent.stoppingDistance)
//            {
//                FaceTarget();
//            }
//        }
//    }
//}
