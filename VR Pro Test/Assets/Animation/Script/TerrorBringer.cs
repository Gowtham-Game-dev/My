using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TerrorBringer : MonoBehaviour
{
    // Start is called before the first frame update
    public NavMeshAgent agent;
    public GameObject Target;
    public float health = 100;
    public Animator animator;
    float timer;

    void Start()
    {
        timer = 0;

    }
    void Update()
    {

        timer += Time.deltaTime;
        if (timer < 5)
        {
            agent.enabled = false;
            animator.SetBool("Patrolling", false);

        }

        if (timer > 5)
        {
            agent.enabled = true;
            agent.SetDestination(Target.transform.position);
            animator.SetBool("Patrolling", true);
        }
    }
    public void GetDamage(float amount)
    {

        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
