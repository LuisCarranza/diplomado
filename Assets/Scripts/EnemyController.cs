using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private Animator enemyAnimator;
    private NavMeshAgent enemyAgent;
    private Transform playerTransform;

    public int lives;
    // In animator create a "dead" trigger

    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        enemyAgent = GetComponent<NavMeshAgent>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        lives = 5;
    }

    void Update()
    {
        enemyAgent.SetDestination(playerTransform.position);
        // Debug.Log("Distance to player: " + enemyAgent.remainingDistance);
        enemyAnimator.SetBool("Punch", false);
        if (lives == 0)
        {
            //Launch "dead" trigger
            enemyAnimator.SetFloat("Speed", 0f);
            // yield return new WaitForSeconds(5);
            // Debug.Log("Dead");
            Destroy(this.gameObject);
        }
        if (enemyAgent.remainingDistance <= 1f && enemyAgent.hasPath)
        {
            enemyAnimator.SetFloat("Speed", 0f);
            enemyAnimator.SetBool("Punch", true);
        }
        else
            enemyAnimator.SetFloat("Speed", enemyAgent.speed);
    }
}
