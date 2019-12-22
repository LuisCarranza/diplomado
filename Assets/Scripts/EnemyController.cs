using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private Animator enemyAnimator;
    private NavMeshAgent enemyAgent;
    private Transform playerTransform;

    public int maxHealth = 5;
    public int currentHealth;
    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        enemyAgent = GetComponent<NavMeshAgent>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = maxHealth;
    }

    void Update()
    {
        enemyAgent.SetDestination(playerTransform.position);
        // Debug.Log("Distance to player: " + enemyAgent.remainingDistance);
        if (currentHealth <= 0)
        {
            enemyAnimator.SetTrigger("Dead");
            enemyAgent.isStopped = true;
            if (enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("Dead"))
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().score += 1;
                Destroy(this.gameObject);
            }
        }
        if (enemyAgent.remainingDistance <= 1.2f && enemyAgent.hasPath)
        {
            enemyAnimator.SetFloat("Speed", 0f);
            enemyAnimator.SetBool("Punch", true);
        }
        else
        {
            enemyAnimator.SetFloat("Speed", enemyAgent.speed);
            enemyAnimator.SetBool("Punch", false);
        }
    }
}
