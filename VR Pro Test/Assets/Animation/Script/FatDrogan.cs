using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class FatDrogan : MonoBehaviour
{
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
        if(agent.stoppingDistance<5)
        {
            animator.SetBool("Patrolling", false);
            animator.SetBool("Attack", true);
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
